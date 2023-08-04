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
    public class ApprovalHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("ClaimID")]
        //[Required(ErrorMessage = "ClaimID is Required.")]
        //public int? ClaimID { get; set; }

        //[JsonIgnore]
        //public virtual Claim? Claim { get; set; }

        //[ForeignKey("PolicyID")]

        //public int? PolicyID { get; set; }

        //[JsonIgnore]
        //public virtual Policy? Policy { get; set; }
        public int EntityID    { get; set; }

        public string EntityType { get; set; }

        public string Comments { get; set; }

        public string ApprovedBy { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string ApprovalStatus { get; set; }

        public bool IsApproval { get; set; }
    }
}
