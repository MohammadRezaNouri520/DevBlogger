using _01_Framework.Domain;
using DB.Domain.ArticleAgg.Services;
using DB.Domain.ArticleCategoryAgg;
using DB.Domain.CommentAgg;
using System;
using System.Collections.Generic;

namespace DB.Domain.ArticleAgg
{
    public class Article:DomainBase<long>
    {
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }

        // Navigaton Property:
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }
        public ICollection<Comment> Comments { get; set; }

        protected Article()
        {
        }

        public Article(string title, string image, string shortDescription, string content, long articleCategoryId, IArticleValidatorService validatorService)
        {
            Validate(title, articleCategoryId);
            validatorService.CheckThisRecordAlreadyExist(title);
            Title = title;
            Image = image;
            ShortDescription = shortDescription;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string image, string shortDescription, string content, long articleCategoryId)
        {
            Title = title;
            Image = image;
            ShortDescription = shortDescription;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Activate()
        {
            IsDeleted = false;
        }

        private void Validate(string title, long articleCategoryId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Title can not be empty!");
            }
            if (articleCategoryId==0)
            {
                throw new ArgumentNullException("Article Category Id can not be empty!");
            }
        }
    }
}
