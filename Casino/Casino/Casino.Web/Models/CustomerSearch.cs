using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Casino.Web.Models
{
    public class CustomerSearch
    {
        public string Name { get; set; }

        [DisplayName("Contact")]
        public string ContactNumber { get; set; }

        [DisplayName("Email ID")]
        public string EmailId { get; set; }

        public IList<Customer> CustomerList { get; set; }
    }
}