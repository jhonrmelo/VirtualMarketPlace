using Helpers.LanguageHelpers;
using System.ComponentModel.DataAnnotations;

namespace VirtualMarketPlace.Models
{
    public class Contact
    {
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E002")]
        [MaxLength(10, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E003")]
        public string Message { get; set; }
    }
}
