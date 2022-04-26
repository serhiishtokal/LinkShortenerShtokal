

using LinkShortenerShtokal.Core.Domain;
using LinkShortenerShtokal.Infrastructure.Services;
using LinkShortenerShtokal.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkShortenerShtokal.Infrastructure.EF
{
    public class ApplicationContext : DbContext
    {
        public readonly ConnectionStringOptions _connectionStringOptions;
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options, ConnectionStringOptions connectionStringOptions) : base(options)
        {
            _connectionStringOptions = connectionStringOptions;
        }

        public DbSet<ShortenedUrl> Urls { get; set; }
        public DbSet<RedirectRequest> RedirectRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>().HasIndex(x => x.UrlAlias).IsUnique();
            modelBuilder.Entity<ShortenedUrl>().HasAlternateKey(x => x.UrlId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringOptions.DefaultConnection);
        }

        public async Task<int> SaveChangesAndCommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await SaveChangesAsync(cancellationToken);
            if (Database.CurrentTransaction != null)
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            return result;
        }
    }
}
