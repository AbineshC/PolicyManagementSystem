using Assignment.Contracts.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class ApprovalHistoryDTO
    {
        [Key]
        public int Id { get; set; }
        //public int? ClaimID { get; set; }
        //public int? PolicyID { get; set; }
        public int EntityID { get; set; }
        public string EntityType { get; set; }
        public string? Comments { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovalStatus { get; set; }
    }
}
