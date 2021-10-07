namespace DB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidatorService
    {
        void CheckThisRecordAlreadyExist(string name);
    }
}
