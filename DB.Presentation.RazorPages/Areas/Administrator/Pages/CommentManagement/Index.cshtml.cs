using DB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DB.Presentation.RazorPages.Areas.Administrator.Pages.CommentManagement
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetList();
        }

        public RedirectToPageResult OnGetConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }

        public RedirectToPageResult OnGetCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }
    }
}
