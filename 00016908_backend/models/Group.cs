using System.ComponentModel.DataAnnotations;

namespace _00016908_backend.models
{
    public class Group
    {

        public long Id { get; set; }                     // Unique identifier

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }                 // Group name
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>(); // Navigation property

    }
}
