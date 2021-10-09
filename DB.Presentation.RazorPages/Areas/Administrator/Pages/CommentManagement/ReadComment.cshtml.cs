using DB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.CommentManagement
{
    public class ReadCommentModel : PageModel
    {
        public CommentViewModel Comment { get; set; }
        private readonly ICommentApplication _commentApplication;

        public ReadCommentModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Comment = _commentApplication.Get(id);
        }
    }
}
