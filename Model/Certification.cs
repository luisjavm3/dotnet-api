using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class Certification
    {
        //public Certification(Candidate candidate)
        //{
        //    Candidate = candidate;
        //}
        public int Id { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public CertificationStatus Status { get; set; }


        [Required(ErrorMessage = "Category is required.")]
        public CertificationCategory Category { get; set; }


        [Required(ErrorMessage = "Candidate is required.")]
        public Candidate Candidate { get; set; }

    }

    public enum CertificationStatus
    {
        PendingConfirmation,
        InProgress,
        Complete,
        Failed
    }

    public enum CertificationCategory
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        RC1,
        RC2,
        RC3
    }
}
