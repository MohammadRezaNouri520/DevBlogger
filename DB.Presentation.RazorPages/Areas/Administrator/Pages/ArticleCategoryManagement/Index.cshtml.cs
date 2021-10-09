using DB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class IndexModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetList();
        }

        public RedirectToPageResult OnGetDelete(long id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        // 1st way:
        public RedirectToPageResult OnGetActivate(long id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("./Index");
        }

        // 2nd way:
        //public RedirectToPageResult OnPostActivate(long id)
        //{
        //    _articleCategoryApplication.Activate(id);
        //    return RedirectToPage("./Index");
        //}
    }
}
