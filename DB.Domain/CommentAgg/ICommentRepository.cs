using _01_Framework.Infrastructure;
using DB.Application.Contracts.Comment;
using System.Collections.Generic;

namespace DB.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long, Comment>
    {
        List<CommentViewModel> GetList();
        CommentViewModel GetToRead(long id);
    }
}
