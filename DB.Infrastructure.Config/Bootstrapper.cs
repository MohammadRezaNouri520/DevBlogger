using _01_Framework.Infrastructure;
using DB.Application;
using DB.Application.Contracts.Article;
using DB.Application.Contracts.ArticleCategory;
using DB.Application.Contracts.Comment;
using DB.Domain.ArticleAgg;
using DB.Domain.ArticleAgg.Services;
using DB.Domain.ArticleCategoryAgg;
using DB.Domain.ArticleCategoryAgg.Services;
using DB.Domain.CommentAgg;
using DB.Infrastructure.EFCore;
using DB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Infrastructure.Config
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DevBloggerContext>(options => 
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();

            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

        }
    }
}
