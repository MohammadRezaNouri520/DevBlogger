using DB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class CreateModel : PageModel
    {
        [BindProperty] public CreateArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategory = new CreateArticleCategory();
        }

        public RedirectToPageResult OnPost()
        {
            _articleCategoryApplication.Create(ArticleCategory);
            return RedirectToPage("./Index");
        }
    }
}
