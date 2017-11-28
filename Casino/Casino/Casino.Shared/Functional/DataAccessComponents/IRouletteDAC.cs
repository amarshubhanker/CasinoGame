using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface IRouletteDAC : IDataAccessComponent
    {
        IRoulettePlayerDTO GetPlayerByUniqueId(string uniqueId);

        IRoulettePlayerDTO GetPlayerById(int customerId);

        IRoulettePlayerDTO UpdatePlayerBalance(IRoulettePlayerDTO playerDTO);

        IRoulettePlayerDTO BlockAmount(IRoulettePlayerDTO playerDTO);
    }
}
