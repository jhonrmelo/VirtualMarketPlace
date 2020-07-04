using System.ComponentModel.DataAnnotations;
namespace VirtualMarketPlace.Models
{
    public class Contact
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(10)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
