using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using Casino.Web.Models.CustomValidatons;
using Casino.Shared;

namespace Casino.Web.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Alphabets and spaces only.")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Date Of Birth")]
        [AgeValidator]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Contact")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter 10 digit numeric contact")]
        [Required]
        public string ContactNumber { get; set; }

        [DisplayName("Email ID")]
        [EmailAddress]
        [Required]
        public string EmailId { get; set; }

        [DisplayName("Identity Proof")]
        [Required]
        public HttpPostedFileBase IdentityProof { get; set; }

        [ScaffoldColumn(false)]
        [Range((double)0.0, (double)Constants.MAX_DECIMAL)]
        public decimal AccountBalance { get; set; }

        [ScaffoldColumn(false)]
        public decimal BlockedAmount { get; set; }

        [ScaffoldColumn(false)]
        public string UniqueId { get; set; }
    }
}