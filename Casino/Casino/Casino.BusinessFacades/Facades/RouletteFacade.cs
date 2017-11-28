using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Shared;

namespace Casino.BusinessFacades
{
    public class RouletteFacade: FacadeBase, IRouletteFacade
    {
        public RouletteFacade() : base(FacadeType.RouletteFacade)
        {

        }

        public OperationResult<IRoulettePlayerDTO> GetPlayerByUniqueId(string uniqueId)
        {
            IRouletteBDC rouletteBDC = (IRouletteBDC)BDCFactory.Instance.Create(BDCType.RouletteBDC);
            return rouletteBDC.GetPlayerByUniqueId(uniqueId);
        }

        public OperationResult<IRoulettePlayerDTO> UpdatePlayerBalance(IRoulettePlayerDTO playerDTO)
        {
            IRouletteBDC rouletteBDC = (IRouletteBDC)BDCFactory.Instance.Create(BDCType.RouletteBDC);
            return rouletteBDC.UpdatePlayerBalance(playerDTO);
        }

        public OperationResult<IRoulettePlayerDTO> BlockAmount(IRoulettePlayerDTO playerDTO)
        {
            IRouletteBDC rouletteBDC = (IRouletteBDC)BDCFactory.Instance.Create(BDCType.RouletteBDC);
            return rouletteBDC.BlockAmount(playerDTO);
        }


        public OperationResult<IRoulettePlayerDTO> GetPlayerById(int customerId)
        {
            IRouletteBDC rouletteBDC = (IRouletteBDC)BDCFactory.Instance.Create(BDCType.RouletteBDC);
            return rouletteBDC.GetPlayerById(customerId);
        }
    }
}
