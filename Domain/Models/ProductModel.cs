using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Product")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }

        public virtual ICollection<ImageModel> Images { get; set; }

    }
}
