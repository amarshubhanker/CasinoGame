using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DTOModel
{
    [EntityMapping("Casino.EntityDataModel.EntityModel.Customer", MappingType.TotalExplicit)]
    [ViewModelMapping("Casino.Web.Models.RoulettePlayer", MappingType.TotalExplicit)]
    public class RoulettePlayerDTO : DTOBase, IRoulettePlayerDTO
    {
        public RoulettePlayerDTO() : base(DTOType.RoulettePlayerDTO)
        {
        }
        [EntityPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CustomerId")]
        public int CustomerId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Balance")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AccountBalance")]
        public decimal AccountBalance { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "BloackedAmount")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "BlockedAmount")]
        public decimal BlockedAmount { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "BetAmount")]
        public decimal BetAmount { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "WinAmount")]
        public decimal WinAmount { get; set; }
    }
}
