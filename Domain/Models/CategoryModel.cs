using Helpers.LanguageHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Name:")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [Display(Name = "Slug:")]
        public string Slug { get; set; }
        [Display(Name = "Father Category:")]
        public int? FatherCategoryId { get; set; }

        [ForeignKey("FatherCategoryId")]
        public virtual CategoryModel FatherCategory { get; set; }
    }
}
