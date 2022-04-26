using LinkShortenerShtokal.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerShtokal.StartupTasks
{
    public class AutoMigrationStartupTask : IStartupTask
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMigrationStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();
            var applicationContext = scope.ServiceProvider.GetService<ApplicationContext>();
            //applicationContext.Database.EnsureCreated();
            await applicationContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
