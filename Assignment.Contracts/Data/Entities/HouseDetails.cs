using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Assignment.Contracts.Data.Entities;

namespace Policy_Management_System_API
{

    public class HouseDetail
    {
        [Key]
        public int HouseDetailId { get; set; }
        public string? HouseAddress { get; set; }
        public float? AssetValue { get; set; }
        public Policy? policy { get; set; }
        
    }
}