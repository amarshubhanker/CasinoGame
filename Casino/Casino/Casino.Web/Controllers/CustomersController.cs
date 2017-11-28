using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casino.Shared;
using Casino.Web.Shared;
using Casino.Web.Models;

namespace Casino.Web.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/

        public ActionResult Index(CustomerSearch customerSearch)
        {
            ICustomerFacade customerFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            ICustomerSearchDTO customerSearchDTO = (ICustomerSearchDTO)DTOFactory.Instance.Create(DTOType.CustomerSearchDTO);
            DTOConverter.FillDTOFromViewModel(customerSearchDTO, customerSearch);
            OperationResult<IList<ICustomerDTO>> res = customerFacade.SearchCustomers(customerSearchDTO);

            CustomerSearch searchResult = new CustomerSearch();
            searchResult.CustomerList = new List<Customer>();
            if (res.IsValid())
            {
                foreach (ICustomerDTO customerDTO in res.Data)
                {
                    Customer customer = new Customer();
                    DTOConverter.FillViewModelFromDTO(customer, customerDTO);
                    searchResult.CustomerList.Add(customer);
                }
            }
            return View(searchResult);
        }

        //
        // GET: /Customers/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Create(Customer customerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(customerModel);
            }

            ICustomerFacade customerFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            ICustomerDTO customerDTO = (ICustomerDTO)DTOFactory.Instance.Create(DTOType.CustomerDTO);
            DTOConverter.FillDTOFromViewModel(customerDTO, customerModel);

            //save file locally
            string filePath = Server.MapPath("~/IDs");
            customerDTO.IdentityProofFileName = customerDTO.EmailId + "_" + customerModel.IdentityProof.FileName;
            customerModel.IdentityProof.SaveAs(filePath + customerDTO.IdentityProofFileName);

            OperationResult<ICustomerDTO> result = customerFacade.CreateCustomer(customerDTO);
            if (result.IsValid())
            {
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        [HttpPost]
        public ActionResult AddBalance(int customerId, decimal amount)
        {
            ICustomerFacade customerFacade = (ICustomerFacade)FacadeFactory.Instance.Create(FacadeType.CustomerFacade);
            OperationResult<ICustomerDTO> result = customerFacade.AddBalance(customerId, amount);
            if (result.IsValid())
            {
                return Json(new { data = result.Data.AccountBalance });
            }
            return Json(new { error = result.Message });
        }
    }
}
