using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Shared
{
    public interface IRoulettePlayerDTO: IDTO
    {
        int CustomerId { get; set; }
        string Name { get; set; }
        decimal AccountBalance { get; set; }
        decimal BlockedAmount { get; set; }
        decimal WinAmount { get; set; }
        decimal BetAmount { get; set; }
    }
}
