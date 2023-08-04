using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;

namespace Policy_Management_System_API
{

    public class VehicleDetail
    {
        [Key]
        public int VehicleDetailId { get; set; }
        public string? VehicleNumber { get; set; }
        public string? VehicleModel { get; set; }
        public Policy? policy { get; set; }
       
    }
}