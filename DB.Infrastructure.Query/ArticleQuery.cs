using DB.Domain.CommentAgg;
using DB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly DevBloggerContext _context;

        public ArticleQuery(DevBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles
                .Where(a => a.IsDeleted == false)
                .Include(a => a.ArticleCategory)
                .Include(a => a.Comments)
                .Select(a => new ArticleQueryView
                {
                    Id = a.Id,
                    Image = a.Image,
                    CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory = a.ArticleCategory.Name,
                    Title = a.Title,
                    ShortDescription = a.ShortDescription,
                    Content = a.Content,
                    CommentsCount = a.Comments.Count(c => c.Status == Statuses.Confirmed),
                    Comments = MapComments(a.Comments.Where(c => c.Status == Statuses.Confirmed))
                })
                .FirstOrDefault(a => a.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(c => new CommentQueryView
            {
                Id = c.Id,
                Name = c.Name,
                Message = c.Message,
                CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).OrderByDescending(c => c.Id).ToList();
        }
        public List<ArticleQueryView> GetList()
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Include(a => a.Comments)
                .Where(a => a.IsDeleted == false)
                .Select(a => new ArticleQueryView
                {
                    Id = a.Id,
                    Image=a.Image,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ArticleCategory=a.ArticleCategory.Name,
                    Title=a.Title,
                    ShortDescription=a.ShortDescription,
                    CommentsCount=a.Comments.Count(c => c.Status==Statuses.Confirmed)
                })
                .ToList();
        }
    }
}
