using Assignment.Contracts.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Policy_Management_System_API
{
    public class PolicyType
    {

        [Key]
        public virtual int PolicyTypeId { get; set; }
        public PolicyTypes Policytype
        {
            get
            {
                return (PolicyTypes)this.PolicyTypeId;
            }
            set
            {
                this.PolicyTypeId = (int)value;
            }
        }

        public bool IsActive { get; set; }

        public enum PolicyTypes
        {
            Personal = 1,
            Vehicle = 2,
            Asset = 3
        }
    }

}