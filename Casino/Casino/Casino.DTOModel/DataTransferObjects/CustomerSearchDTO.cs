using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DTOModel
{
    [EntityMapping("Casino.EntityDataModel.EntityModel.Customer", MappingType.TotalExplicit)]
    [ViewModelMapping("Casino.Web.Models.CustomerSearch", MappingType.TotalExplicit)]
    public class CustomerSearchDTO : DTOBase, ICustomerSearchDTO
    {
        public CustomerSearchDTO() : base(DTOType.CustomerSearchDTO)
        {
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ContactNumber")]
        public string ContactNumber { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "EmailId")]
        public string EmailId { get; set; }
    }
}
