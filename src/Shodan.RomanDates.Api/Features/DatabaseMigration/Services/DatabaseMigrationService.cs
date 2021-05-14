using Microsoft.EntityFrameworkCore;
using Shodan.RomanDates.Api.Dto;
using Shodan.RomanDates.Api.Features.DatabaseMigration.Services.Interfaces;
using Shodan.RomanDates.Api.Options;

namespace Shodan.RomanDates.Api.Features.DatabaseMigration.Services
{
    public class DatabaseMigrationService : IDatabaseMigrationService
    {
        private readonly RomanusDbContext _dbContext;

        public DatabaseMigrationService(RomanusDbContext dbContext) => this._dbContext = dbContext;

        public void ApplyDatabaseMigrations(DatabaseMigrationOptions config)
        {
            if (config != null && config.ApplyDatabaseMigrations)
            {
                this._dbContext.Database.Migrate();
            }
        }
    }
}
