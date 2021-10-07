using DB.Domain.ArticleCategoryAgg;
using DB.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DB.Infrastructure.EFCore
{
    public class DevBloggerContext : DbContext
    {
        public DevBloggerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
