using DB.Domain.ArticleCategoryAgg.Exceptions;

namespace DB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThisRecordAlreadyExist(string name)
        {
            if (_articleCategoryRepository.Exists(c => c.Name==name))
            {
                throw new DuplicatedRecordException("This record already exists in database!");
            }
        }
    }
}
