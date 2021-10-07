using System;

namespace DB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorService : IArticleValidatorService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThisRecordAlreadyExist(string title)
        {
            if (_articleRepository.Exists(a => a.Title==title))
            {
                throw new Exception("There is an article with this title in database");
            }
        }
    }
}
