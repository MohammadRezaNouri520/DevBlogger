using System.ComponentModel.DataAnnotations;

namespace DB.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage ="{0} is required")]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public long ArticleCategoryId { get; set; }
        
        [Required(ErrorMessage = "{0} is required")]
        public string Image { get; set; }
        
        [Required(ErrorMessage ="{0} is required")]
        [MaxLength(800)]
        [Display(Name ="Short Description")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage ="{0} is required")]
        public string Content { get; set; }
    }
}