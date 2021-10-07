using _01_Framework.Infrastructure;
using DB.Application.Contracts.ArticleCategory;
using DB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly DevBloggerContext _context;
        public ArticleCategoryRepository(DevBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetList()
        {
            return _context.ArticleCategories
                .Select(a => new ArticleCategoryViewModel 
                {
                    Id=a.Id,
                    Name=a.Name,
                    Status=a.IsDeleted,
                    CreationDate=a.CreationDate.ToString(CultureInfo.InvariantCulture)
                }).ToList();
        }
    }
}
