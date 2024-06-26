using DB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.ArticleManagement
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }

        public RedirectToPageResult OnGetDelete(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public RedirectToPageResult OnGetActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}
