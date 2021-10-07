using DB.Domain.ArticleAgg;
using DB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Infrastructure.EFCore.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Message).HasMaxLength(500).IsRequired();
            builder.Property(c => c.ArticleId).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Article>(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId);
        }
    }
}
