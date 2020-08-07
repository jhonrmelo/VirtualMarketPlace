
namespace Domain.Models
{
    public class CollaboratorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CollaboratorTypeId { get; set; }
        public CollaboratorTypeModel CollaboratorType { get; set; }
    }
}
