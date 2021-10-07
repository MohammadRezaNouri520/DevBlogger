using System.Collections.Generic;

namespace DB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        List<CommentViewModel> GetList();
        void Create(CreateComment command);
        CommentViewModel Get(long id);
        void Confirm(long id);
        void Cancel(long id);
    }
}
