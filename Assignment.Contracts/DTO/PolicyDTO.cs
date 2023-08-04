using Assignment.Contracts.Data.Entities;
using Policy_Management_System_API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class PolicyDTO
    {
        [Key]
        [Required]
        public int PolicyID { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        public string? Description { get; set; } = String.Empty;
        [Required(ErrorMessage = "Title is Required.")]
        [StringLength(20)]
        public string Title { get; set; } = String.Empty;
        [Required(ErrorMessage = "Start date of policy is Required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date of policy is Required.")]
        public DateTime EndDate { get; set; }
        [Required]
        public float Premium { get; set; }
        [Required(ErrorMessage = "Duration of policy is Required.")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Insured amount is Required.")]
        public float InsuredAmount { get; set; }
        [Required(ErrorMessage = "Insured holder's name is Required.")]
        [StringLength(15)]
        public string InsurerName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Insured holder's age is Required")]
        [Range(18, 100, ErrorMessage = "Age of an insured person should be between 18 and 100.")]
        public int InsurerHolderAge { get; set; }
        public int PolicyTypeId { get; set; }

        public string? VehicleNumber { get; set; }

        public string? Model { get; set; }

        public string? HouseAddress { get; set; }

        public string? AssetValue { get; set; }
        public float? Coverage { get; set; }
        public bool Status { get; set; }
        public string StatusOfPolicy { get; set; }
        public List<ClaimDTO> Claims { get; set; }
       
    }
}
