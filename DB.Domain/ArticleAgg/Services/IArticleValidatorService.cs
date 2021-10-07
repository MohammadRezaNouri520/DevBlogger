using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
        void CheckThisRecordAlreadyExist(string title);
    }
}
