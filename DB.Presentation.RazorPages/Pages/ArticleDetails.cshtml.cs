using DB.Application.Contracts.Comment;
using DB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DB.Presentation.RazorPages.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery;

        [BindProperty] public CreateComment Comment { get; set; }
        private readonly ICommentApplication _commentApplication;
        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleQuery.Get(id);
            Comment = new CreateComment() { ArticleId = Article.Id };
        }

        public RedirectToPageResult OnPost()
        {
            _commentApplication.Create(Comment);
            return RedirectToPage("./ArticleDetails", new { id = Comment.ArticleId });
        }
    }
}