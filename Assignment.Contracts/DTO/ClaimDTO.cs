using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class ClaimDTO
    {
        [Key]
        [Required]
        public int ClaimID { get; set; }
        public int PolicyID { get; set; }
        [Required(ErrorMessage = "ClaimAmount is Required.")]
        public float? ClaimAmount { get; set; }
        [Required(ErrorMessage = "ClaimReason is Required.")]
        public string ClaimReason { get; set; }
        [Required(ErrorMessage = "ClaimDescription is Required.")]
        public string ClaimDescription { get; set; }
        [Required(ErrorMessage = "ClaimDate is Required.")]
        public DateTime ClaimDate { get; set; }
        public bool IsActive { get; set; }
        public string StatusOfClaim { get; set; }
    }
}
