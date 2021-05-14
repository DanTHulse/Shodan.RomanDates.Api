using Shodan.RomanDates.Api.Features.Shared.Interfaces;
using Shodan.RomanDates.Api.Options;

namespace Shodan.RomanDates.Api.Features.DatabaseMigration.Services.Interfaces
{
    public interface IDatabaseMigrationService : IScoped
    {
        void ApplyDatabaseMigrations(DatabaseMigrationOptions config);
    }
}
