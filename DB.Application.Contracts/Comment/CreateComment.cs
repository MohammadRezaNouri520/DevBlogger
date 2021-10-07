using System.ComponentModel.DataAnnotations;

namespace DB.Application.Contracts.Comment
{
    public class CreateComment
    {
        [Required(ErrorMessage="{0} is required")]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(256)]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(500)]
        public string Message { get; set; }
        public long ArticleId { get; set; }

    }
}
