using _01_Framework.Infrastructure;
using DB.Application.Contracts.ArticleCategory;
using System.Collections.Generic;

namespace DB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository :IRepository<long, ArticleCategory>
    {
        List<ArticleCategoryViewModel> GetList();
        List<ArticleCategorySelectList> GetSelectList();
    }
}
