using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00016908_backend.models
{
    public class Contact
    {
        public long Id { get; set; } // Unique identifier

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }        // Full name

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }       // Email address

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }       // Phone number

        [Required(ErrorMessage = "Address is required")]
        [StringLength(255, ErrorMessage = "Purpose cannot exceed 255 characters")]
        public string Address { get; set; }

        public long? GroupId { get; set; } // Foreign key to Group

        [ForeignKey("GroupId")]
        public Group? Group { get; set; } // Navigation property
    }
}
