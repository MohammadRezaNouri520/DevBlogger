using _01_Framework.Infrastructure;
using DB.Application.Contracts.Article;
using DB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:BaseRepository<long,Article>, IArticleRepository
    {
        private readonly DevBloggerContext _context;
        public ArticleRepository(DevBloggerContext context):base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles.Select(a => new ArticleViewModel 
            {
                Id=a.Id,
                Title= a.Title,
                Category = a.ArticleCategory.Name,
                CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture),
                Status = a.IsDeleted
            }).ToList();
        }
    }
}
