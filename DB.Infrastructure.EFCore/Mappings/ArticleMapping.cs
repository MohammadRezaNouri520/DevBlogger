using DB.Domain.ArticleAgg;
using DB.Domain.ArticleCategoryAgg;
using DB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Infrastructure.EFCore.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).HasMaxLength(500).IsRequired();
            builder.Property(a => a.Image).IsRequired();
            builder.Property(a => a.ShortDescription).HasMaxLength(800).IsRequired();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.CreationDate).IsRequired();
            builder.Property(a => a.ArticleCategoryId).IsRequired();

            builder.HasOne<ArticleCategory>(a => a.ArticleCategory)
                .WithMany(ac => ac.Articles)
                .HasForeignKey(a => a.ArticleCategoryId);

            builder.HasMany<Comment>(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId);
        }
    }
}
