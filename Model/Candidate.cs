using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class Candidate
    {
        public Candidate()
        {
            Certifications = new HashSet<Certification>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(50, ErrorMessage ="FirstName must have less than 50 characters.")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "DocumentType is required.")]
        public string DocumentType { get; set; } = string.Empty;

        [StringLength(10)]
        [Required(ErrorMessage = "DocumentNumber is required.")]
        public string DocumentNumber { get; set; } = string.Empty;

        public ICollection<Certification> Certifications { get; set; }
    }
}
