using Assignment.Contracts.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.API.Validation
{
    public static class PolicyValidation
    {
        public static void IsPolicyValid(PolicyDTO policy)
        {
            if (policy.EndDate == policy.StartDate || policy.EndDate < DateTime.Today)
            {
                throw new ValidationException("Policy's End date should not be same as start date or it should not be in past");
            }
        }
    }
}
