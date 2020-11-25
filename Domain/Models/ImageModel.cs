using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Image")]
    public class ImageModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
    }
}
