using System.Collections.Generic;

namespace DB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetList();
        ArticleQueryView Get(long id);
    }
}
