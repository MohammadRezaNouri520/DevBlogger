using _01_Framework.Domain;
using DB.Domain.ArticleAgg;
using DB.Domain.ArticleCategoryAgg.Services;
using System.Collections.Generic;
using System;

namespace DB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        // Navigation Property:
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
        }
        
        public ArticleCategory(string name, IArticleCategoryValidatorService validatorService)
        {
            Validate(name);
            validatorService.CheckThisRecordAlreadyExist(name);
            Name = name;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        public void Rename(string name, IArticleCategoryValidatorService validatorService)
        {
            Validate(name);
            validatorService.CheckThisRecordAlreadyExist(name);
            Name = name;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty!");
            }
        }
    }
}
