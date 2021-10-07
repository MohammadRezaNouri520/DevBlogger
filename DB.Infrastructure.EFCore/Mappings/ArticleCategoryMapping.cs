using DB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Infrastructure.EFCore.Mappings
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(256).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.CreationDate).IsRequired();

            // Relationships:

        }
    }
}
