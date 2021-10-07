using _01_Framework.Infrastructure;
using DB.Application.Contracts.ArticleCategory;
using DB.Domain.ArticleCategoryAgg;
using DB.Domain.ArticleCategoryAgg.Services;
using System.Collections.Generic;

namespace DB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryValidatorService _validatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork, IArticleCategoryValidatorService validatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _unitOfWork = unitOfWork;
            _validatorService = validatorService;
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = new ArticleCategory(command.Name, _validatorService);
            _articleCategoryRepository.Create(articleCategory);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticleCategory command)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Name, _validatorService);
            _unitOfWork.CommitTran();
        }

        public EditArticleCategory GetBy(long id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new EditArticleCategory 
            {
                Id=articleCategory.Id,
                Name=articleCategory.Name
            };
        }

        public List<ArticleCategoryViewModel> GetList()
        {
            return _articleCategoryRepository.GetList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }
    }
}
