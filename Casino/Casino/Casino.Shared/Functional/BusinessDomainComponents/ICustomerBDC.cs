using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface ICustomerBDC : IBusinessDomainComponent
    {
        OperationResult<IList<ICustomerDTO>> SearchCustomers(ICustomerSearchDTO customerDTO);

        OperationResult<IList<ICustomerDTO>> GetCustomers();

        OperationResult<ICustomerDTO> AddBalance(int customerId, decimal amount);

        OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO customerDTO);
    }
}
