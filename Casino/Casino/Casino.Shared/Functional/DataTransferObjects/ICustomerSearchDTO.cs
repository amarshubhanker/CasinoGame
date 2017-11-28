using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface ICustomerSearchDTO: IDTO
    {
        string Name { get; set; }
        string ContactNumber { get; set; }
        string EmailId { get; set; }
    }
}
