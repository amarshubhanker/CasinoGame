using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.EntityDataModel;
using Casino.EntityDataModel.EntityModel;
using System.Data.Entity.Validation;


namespace Casino.Data
{
    public class CustomerDAC : DACBase, ICustomerDAC
    {
        public CustomerDAC()
            : base(DACType.CustomerDAC)
        {

        }

        public IList<ICustomerDTO> SearchCustomers(ICustomerSearchDTO customerDTO)
        {
            IList<ICustomerDTO> retListCustomerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    List<CasinoDB> customers = new List<CasinoDB>();
                    customers = context.SearchCustomers(customerDTO.Name, customerDTO.EmailId, customerDTO.ContactNumber).ToList();
                    if (customers.Count > 0)
                    {
                        retListCustomerDTO = new List<ICustomerDTO>();
                        foreach (CasinoDB customer in customers)
                        {
                            ICustomerDTO retCustomerDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                            EntityConverter.FillDTOFromEntity(customer, retCustomerDTO);
                            retListCustomerDTO.Add(retCustomerDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retListCustomerDTO;
        }

        public ICustomerDTO AddBalance(int customerId, decimal amount)
        {
            ICustomerDTO retValCustomerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB customer = context.CasinoDBs.Where(c => c.CustomerId == customerId).SingleOrDefault();
                    if (customer.Balance + amount <= Constants.MAX_DECIMAL)
                        customer.Balance += amount;
                    if (context.SaveChanges() > 0)
                    {
                        retValCustomerDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        EntityConverter.FillDTOFromEntity(customer, retValCustomerDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValCustomerDTO;
        }

        public ICustomerDTO CreateCustomer(ICustomerDTO customerDTO)
        {
            ICustomerDTO retValCustomerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB customer = new CasinoDB();
                    EntityConverter.FillEntityFromDTO(customerDTO, customer);
                    context.CasinoDBs.Add(customer);
                    if (context.SaveChanges() > 0)
                    {
                        customerDTO.CustomerId = customer.CustomerId;
                        retValCustomerDTO = customerDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValCustomerDTO;
        }

        public ICustomerDTO GetCustomerByUniqueId(string uniqueId)
        {
            ICustomerDTO retValCustomerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB customer = context.CasinoDBs.Where(c => c.UniqueId == uniqueId).SingleOrDefault();
                    if (customer != null)
                    {
                        retValCustomerDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                        EntityConverter.FillDTOFromEntity(customer, retValCustomerDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValCustomerDTO;
        }


        public IList<ICustomerDTO> GetCustomers()
        {
            IList<ICustomerDTO> retListCustomerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    List<CasinoDB> customers = context.CasinoDBs.ToList();
                    if (customers.Count > 0)
                    {
                        retListCustomerDTO = new List<ICustomerDTO>();
                        foreach (CasinoDB customer in customers)
                        {
                            ICustomerDTO customerDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
                            EntityConverter.FillDTOFromEntity(customer, customerDTO);
                            retListCustomerDTO.Add(customerDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retListCustomerDTO;
        }
    }
}
