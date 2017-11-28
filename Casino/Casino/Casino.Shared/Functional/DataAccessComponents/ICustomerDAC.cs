using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface ICustomerDAC : IDataAccessComponent
    {
        IList<ICustomerDTO> SearchCustomers(ICustomerSearchDTO customerDTO);

        IList<ICustomerDTO> GetCustomers();

        ICustomerDTO AddBalance(int CustomerId, decimal amount);

        ICustomerDTO CreateCustomer(ICustomerDTO customerDTO);

    }
}
