using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface IRouletteBDC : IBusinessDomainComponent
    {
        OperationResult<IRoulettePlayerDTO> GetPlayerByUniqueId(string uniqueId);

        OperationResult<IRoulettePlayerDTO> GetPlayerById(int customerId);

        OperationResult<IRoulettePlayerDTO> UpdatePlayerBalance(IRoulettePlayerDTO playerDTO);

        OperationResult<IRoulettePlayerDTO> BlockAmount(IRoulettePlayerDTO playerDTO);
    }
}
