using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("CollaboratorType")]
    public class CollaboratorTypeModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
