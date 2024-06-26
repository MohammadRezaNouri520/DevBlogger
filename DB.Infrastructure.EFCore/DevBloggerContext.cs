﻿using DB.Domain.ArticleAgg;
using DB.Domain.ArticleCategoryAgg;
using DB.Domain.CommentAgg;
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
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
