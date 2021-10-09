using System.Collections.Generic;

namespace DB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetList();
        List<ArticleCategorySelectList> GetSelectList();
        void Create(CreateArticleCategory command);
        EditArticleCategory GetBy(long id);
        void Edit(EditArticleCategory command);
        void Remove(long id);
        void Activate(long id);
    }
}
