using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DTOModel
{
    [EntityMapping("Casino.EntityDataModel.EntityModel.Customer", MappingType.TotalExplicit)]
    [ViewModelMapping("Casino.Web.Models.Customer", MappingType.TotalExplicit)]
    public class CustomerDTO : DTOBase, ICustomerDTO
    {
        public CustomerDTO() : base(DTOType.CustomerDTO)
        {
        }
        [EntityPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        public int CustomerId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DOB")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        public string ContactNumber { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "EmailId")]
        public string EmailId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IdPoof")]
       // [ViewModelPropertyMapping(MappingDirectionType.Both, "IdentityProof")]
        public string IdentityProofFileName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Balance")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        public Nullable<decimal> AccountBalance { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UniqueId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "UniqueId")]
        public string UniqueId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "BloackedAmount")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "BlockedAmount")]
        public Nullable<decimal> BlockedAmount { get; set; }
    }
}
