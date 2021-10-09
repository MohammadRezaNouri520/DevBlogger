using DB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DB.Presentation.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public void OnGet()
        {
            Articles = _articleQuery.GetList();
        }
    }
}