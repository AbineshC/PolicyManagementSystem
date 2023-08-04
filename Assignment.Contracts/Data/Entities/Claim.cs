using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment.Contracts.Data.Entities
{
    public class Claim
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimID { get; set; }
        [ForeignKey("Policy ")]
        [Required(ErrorMessage = "PolicyID is Required.")]
        public int PolicyID { get; set; }
        [JsonIgnore]
        public virtual Policy? Policy { get; set; }
        [Required(ErrorMessage = "ClaimAmount is Required.")]
        public float? ClaimAmount { get; set; }
        [Required(ErrorMessage = "ClaimReason is Required.")]
        public string ClaimReason { get; set; }
        [Required(ErrorMessage = "ClaimDescription is Required.")]
        public string ClaimDescription { get; set; }
        [Required(ErrorMessage = "ClaimDate is Required.")]
        public DateTime ClaimDate { get; set; }
        [Required]
        public bool ApprovalStatus { get; set; }
        public bool IsActive { get; set; }
        public string StatusOfClaim { get; set; }
    }
       
}
