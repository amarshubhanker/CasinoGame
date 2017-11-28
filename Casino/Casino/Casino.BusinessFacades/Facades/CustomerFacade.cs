using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Shared;

namespace Casino.BusinessFacades
{
    public class CustomerFacade: FacadeBase, ICustomerFacade
    {
        public CustomerFacade() : base(FacadeType.CustomerFacade)
        {

        }

        public OperationResult<IList<ICustomerDTO>> SearchCustomers(ICustomerSearchDTO customerDTO)
        {
            ICustomerBDC customerBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return customerBDC.SearchCustomers(customerDTO);
        }

        public OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO customerDTO)
        {
            ICustomerBDC customerBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return customerBDC.CreateCustomer(customerDTO);
        }

        public OperationResult<IList<ICustomerDTO>> GetCustomers()
        {
            ICustomerBDC customerBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return customerBDC.GetCustomers();
        }


        public OperationResult<ICustomerDTO> AddBalance(int customerId, decimal amount)
        {
            ICustomerBDC customerBDC = (ICustomerBDC)BDCFactory.Instance.Create(BDCType.CustomerBDC);
            return customerBDC.AddBalance(customerId, amount);
        }
    }
}
