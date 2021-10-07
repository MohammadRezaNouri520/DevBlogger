namespace DB.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public bool Status { get; set; }
    }
}
