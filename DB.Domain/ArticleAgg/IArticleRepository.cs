using _01_Framework.Infrastructure;
using DB.Application.Contracts.Article;
using System.Collections.Generic;

namespace DB.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long, Article>
    {
        List<ArticleViewModel> GetList();
    }
}
