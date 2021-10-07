using _01_Framework.Infrastructure;
using DB.Application.Contracts.Comment;
using DB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DB.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly DevBloggerContext _context;
        public CommentRepository(DevBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments
                .Include(c => c.Article)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ArticleTitle = c.Article.Title,
                    CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Status = c.Status
                })
                .OrderByDescending(c => c.Id)
                .ToList();
        }

        public CommentViewModel GetToRead(long id)
        {
            return _context.Comments
                .Include(c => c.Article)
                .Select(c => new CommentViewModel 
                {
                    Id=c.Id,
                    Name=c.Name,
                    Email=c.Email,
                    Message=c.Message,
                    ArticleTitle=c.Article.Title,
                    CreationDate=c.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Status=c.Status
                })
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
