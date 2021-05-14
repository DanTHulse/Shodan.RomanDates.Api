using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Grinderofl.FeatureFolders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi.Models;
using Shodan.RomanDates.Api.Dto;
using Shodan.RomanDates.Api.Features.DatabaseMigration.Services.Interfaces;
using Shodan.RomanDates.Api.Features.Shared.Interfaces;
using Shodan.RomanDates.Api.HealthChecks;
using Shodan.RomanDates.Api.Options;

namespace Shodan.RomanDates.Api
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            this.Environment = environment;
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddFeatureManagement();
            _ = services.AddControllers()
                .AddFeatureFolders()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            _ = services.AddAutoMapper(typeof(Startup));

            _ = services.AddApplicationInsightsTelemetry();

            var assembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var experienceConnection = this.Configuration.GetSection("ConnectionStrings").Get<ConnectionOptions>();
            _ = services.AddDbContext<RomanusDbContext>(
                options => options.UseSqlServer(experienceConnection.RomanusSql, sql => sql.MigrationsAssembly(assembly)));

            _ = services.AddHealthChecks()
                    .AddCheck<DefaultHealthCheck>("DefaultHealthCheck")
                    .AddDbContextCheck<RomanusDbContext>();

            _ = services.Configure<SwaggerOptions>(this.Configuration.GetSection("Swagger"));

            _ = services.Scan(s
                => s.FromAssemblyOf<ITransient>()
                .AddClasses(c => c.AssignableTo<ITransient>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            _ = services.Scan(s
                => s.FromAssemblyOf<ISingleton>()
                .AddClasses(c => c.AssignableTo<ISingleton>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
            _ = services.Scan(s
                => s.FromAssemblyOf<IScoped>()
                .AddClasses(c => c.AssignableTo<IScoped>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            var swaggerConfig = this.Configuration.GetSection("Swagger").Get<SwaggerOptions>();
            if (swaggerConfig == null)
            {
                throw new ConfigurationErrorsException("Swagger Section Missing");
            }

            _ = services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Version = swaggerConfig.Version,
                      Title = swaggerConfig.Title,
                      Description = swaggerConfig.Description,
                      Contact = new OpenApiContact
                      {
                          Name = swaggerConfig.ContactName,
                          Email = swaggerConfig.ContactEmail,
                          Url = swaggerConfig.ContactUrl,
                      }
                  });

                  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  c.IncludeXmlComments(xmlPath);
              });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseMigrationService databaseMigration)
        {
            var databaseMigrationConfig = this.Configuration.GetSection(nameof(DatabaseMigrationOptions))
               .Get<DatabaseMigrationOptions>();

            databaseMigration.ApplyDatabaseMigrations(databaseMigrationConfig);

            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                  {
                      ResultStatusCodes =
                      {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status418ImATeapot,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                      },
                      AllowCachingResponses = false
                  });
                  _ = endpoints.MapControllers();
              });

            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roman Dates Api");
                  c.DefaultModelsExpandDepth(-1);
              });
        }
    }
}
