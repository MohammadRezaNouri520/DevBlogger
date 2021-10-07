using _01_Framework.Infrastructure;
using DB.Application.Contracts.Article;
using DB.Domain.ArticleAgg;
using DB.Domain.ArticleAgg.Services;
using System.Collections.Generic;

namespace DB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleValidatorService _validatorService;
        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IArticleValidatorService validatorService)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _validatorService = validatorService;
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Activate();
            _unitOfWork.CommitTran();
        }

        public void Create(CreateArticle command)
        {
            _unitOfWork.BeginTran();
            var article = new Article(command.Title, command.Image, command.ShortDescription,
                command.Content, command.ArticleCategoryId, _validatorService);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditArticle command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.Image, command.ShortDescription,
                command.Content, command.ArticleCategoryId);
            _unitOfWork.CommitTran();
        }

        public EditArticle GetEditArticle(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Id = article.Id,
                Title = article.Title,
                ArticleCategoryId = article.ArticleCategoryId,
                Image = article.Image,
                ShortDescription = article.ShortDescription,
                Content = article.Content
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();     
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }
    }
}
