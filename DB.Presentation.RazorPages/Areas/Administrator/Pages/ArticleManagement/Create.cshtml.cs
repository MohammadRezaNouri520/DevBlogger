using DB.Application.Contracts.Article;
using DB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class CreateModel : PageModel
    {
        [BindProperty] public CreateArticle Article { get; set; }
        public SelectList ArticleCategories { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            Article = new CreateArticle();
            ArticleCategories = new SelectList(_articleCategoryApplication.GetSelectList(),"Id","Name");
        }
        
        public RedirectToPageResult OnPost()
        {
            _articleApplication.Create(Article);
            return RedirectToPage("./Index");
        }
    }
}
