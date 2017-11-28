using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface ICustomerFacade : IFacade
    {
        OperationResult<IList<ICustomerDTO>> SearchCustomers(ICustomerSearchDTO customerDTO);

        OperationResult<IList<ICustomerDTO>> GetCustomers();

        OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO customerDTO);

        OperationResult<ICustomerDTO> AddBalance(int customerId, decimal amount);
    }
}
