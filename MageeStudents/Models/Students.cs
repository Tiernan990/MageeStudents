using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MageeStudents.Models
{
    public class Students
    {
        [Key]
        [Column("StudentId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter surname"), MaxLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter firstname"), MaxLength(50)]
        public string FirstName { get; set; }

        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Your telephone number is not valid.")]
        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(1, 150, ErrorMessage = "Please enter valid integer greater than 0 and less than 150")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Country of Origin (less than 50 chars)"), MaxLength(50)]
        public string CountryOfOrigin { get; set; }
    }
}
