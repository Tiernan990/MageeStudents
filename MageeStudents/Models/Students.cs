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

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
