using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Validations;

namespace Casino.Business
{
    public class CustomerBDC : BDCBase, ICustomerBDC
    {
        public CustomerBDC() : base(BDCType.CustomerBDC)
        {

        }


        public OperationResult<IList<ICustomerDTO>> SearchCustomers(ICustomerSearchDTO customerDTO)
        {
            OperationResult<IList<ICustomerDTO>> retListCustomerDTO = null;
            ICustomerDAC customerDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
            IList<ICustomerDTO> resListCustomerDTO = customerDAC.SearchCustomers(customerDTO);
            if (resListCustomerDTO != null)
            {
                retListCustomerDTO = OperationResult<IList<ICustomerDTO>>.CreateSuccessResult(resListCustomerDTO, "Success");
            }
            else
            {
                retListCustomerDTO = OperationResult<IList<ICustomerDTO>>.CreateFailureResult("Failure");
            }
            return retListCustomerDTO;
        }

        public OperationResult<ICustomerDTO> AddBalance(int customerId, decimal amount)
        {
            OperationResult<ICustomerDTO> retValCustomerDTO = null;
            try
            {
                //validation
                if (amount > 0 && amount <= Constants.MAX_DECIMAL)
                {
                    ICustomerDAC customerDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                    ICustomerDTO resValCustomerDTO = customerDAC.AddBalance(customerId, amount);
                    if (resValCustomerDTO != null)
                    {
                        retValCustomerDTO = OperationResult<ICustomerDTO>.CreateSuccessResult(resValCustomerDTO, Constants.CustomerMessages.UpdateSuccess);
                    }
                    else
                    {
                        retValCustomerDTO = OperationResult<ICustomerDTO>.CreateFailureResult(Constants.CustomerMessages.UpdateFailure);
                    }
                }
                else
                {
                    throw new Exception("Invalid recharge amount");
                }
            }
            catch (DACException dacEx)
            {
                retValCustomerDTO = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retValCustomerDTO = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retValCustomerDTO;
        }

        public OperationResult<ICustomerDTO> CreateCustomer(ICustomerDTO customerDTO)
        {
            OperationResult<ICustomerDTO> retValCustomerDTO = null;
            try
            {
                //Default values
                customerDTO.UniqueId = Guid.NewGuid().ToString().Substring(0,8);
                customerDTO.AccountBalance = 500M;
                customerDTO.BlockedAmount = 0M;

                CasinoValidationResult validationResult = Validator<CustomerValidator, ICustomerDTO>.Validate(customerDTO, Constants.CustomerMessages.CommonRuleSet);
                if (!validationResult.IsValid)
                {
                    retValCustomerDTO = OperationResult<ICustomerDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    ICustomerDAC customerDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
                    
                    ICustomerDTO resCustomerDTO = customerDAC.CreateCustomer(customerDTO);
                    if (resCustomerDTO != null)
                    {
                        retValCustomerDTO = OperationResult<ICustomerDTO>.CreateSuccessResult(resCustomerDTO, "Success");
                    }
                    else
                    {
                        retValCustomerDTO = OperationResult<ICustomerDTO>.CreateFailureResult("Failure");
                    }
                }
            }
            catch (DACException dacEx)
            {
                retValCustomerDTO = OperationResult<ICustomerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retValCustomerDTO = OperationResult<ICustomerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retValCustomerDTO;
        }

        public OperationResult<IList<ICustomerDTO>> GetCustomers()
        {
            OperationResult<IList<ICustomerDTO>> retListCustomerDTO = null;
            ICustomerDAC customerDAC = (ICustomerDAC)DACFactory.Instance.Create(DACType.CustomerDAC);
            IList<ICustomerDTO> resListCustomerDTO = customerDAC.GetCustomers();
            if (resListCustomerDTO != null)
            {
                retListCustomerDTO = OperationResult<IList<ICustomerDTO>>.CreateSuccessResult(resListCustomerDTO, "Success");
            }
            else
            {
                retListCustomerDTO = OperationResult<IList<ICustomerDTO>>.CreateFailureResult("Failure");
            }
            return retListCustomerDTO;
        }
    }
}
