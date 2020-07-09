using System.ComponentModel.DataAnnotations;
using VirtualMarketPlace.Helpers.LanguageHelpers;

namespace VirtualMarketPlace.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
    }
}
