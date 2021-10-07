using _01_Framework.Domain;
using DB.Domain.ArticleCategoryAgg.Services;
using System.Collections.Generic;

namespace DB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        // Navigation Property:
        //public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
        }
        
        public ArticleCategory(string name, IArticleCategoryValidatorService validatorService)
        {
            validatorService.CheckThisRecordAlreadyExist(name);
            Name = name;
            IsDeleted = false;
            //Articles = new List<Article>();
        }

        public void Rename(string name, IArticleCategoryValidatorService validatorService)
        {
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
    }
}
