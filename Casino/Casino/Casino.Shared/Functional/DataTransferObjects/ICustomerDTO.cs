using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface ICustomerDTO: IDTO
    {
        int CustomerId { get; set; }
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
        string ContactNumber { get; set; }
        string EmailId { get; set; }
        string IdentityProofFileName { get; set; }
        decimal AccountBalance { get; set; }
        decimal BlockedAmount { get; set; }
        string UniqueId { get; set; }
    }
}
