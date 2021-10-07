using System.ComponentModel.DataAnnotations;

namespace DB.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage ="{0} is required")]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}