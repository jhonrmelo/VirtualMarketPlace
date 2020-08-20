using Helpers.LanguageHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Collaborator")]
    public class CollaboratorModel
    {
        public int Id { get; set; }
        [Display(Name = "Name:")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }
        [Display(Name = "Email:")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
        [Display(Name = "Password:")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E005")]
        public string ConfirmedPassword { get; set; }
        [Required]
        public int CollaboratorTypeId { get; set; }
        public CollaboratorTypeModel CollaboratorType { get; set; }
    }
}
