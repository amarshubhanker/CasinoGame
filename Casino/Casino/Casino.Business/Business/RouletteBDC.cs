using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Business
{
    public class RouletteBDC : BDCBase, IRouletteBDC
    {
        public RouletteBDC() : base(BDCType.RouletteBDC)
        {

        }
        
        public OperationResult<IRoulettePlayerDTO> GetPlayerByUniqueId(string uniqueId)
        {
            OperationResult<IRoulettePlayerDTO> retValPlayerDTO = null;
            IRouletteDAC rouletteDAC = (IRouletteDAC)DACFactory.Instance.Create(DACType.RouletteDAC);
            IRoulettePlayerDTO resValPlayerDTO = rouletteDAC.GetPlayerByUniqueId(uniqueId);
            if (resValPlayerDTO != null)
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateSuccessResult(resValPlayerDTO, "Success");
            }
            else
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateFailureResult("Failure");
            }
            return retValPlayerDTO;
        }

        public OperationResult<IRoulettePlayerDTO> UpdatePlayerBalance(IRoulettePlayerDTO playerDTO)
        {
            OperationResult<IRoulettePlayerDTO> retValPlayerDTO = null;
            IRouletteDAC rouletteDAC = (IRouletteDAC)DACFactory.Instance.Create(DACType.RouletteDAC);
            IRoulettePlayerDTO resValPlayerDTO = rouletteDAC.UpdatePlayerBalance(playerDTO);
            if (resValPlayerDTO != null)
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateSuccessResult(resValPlayerDTO, "Success");
            }
            else
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateFailureResult("Failure");
            }
            return retValPlayerDTO;
        }

        public OperationResult<IRoulettePlayerDTO> BlockAmount(IRoulettePlayerDTO playerDTO)
        {
            OperationResult<IRoulettePlayerDTO> retValPlayerDTO = null;
            IRouletteDAC rouletteDAC = (IRouletteDAC)DACFactory.Instance.Create(DACType.RouletteDAC);
            IRoulettePlayerDTO resValPlayerDTO = rouletteDAC.BlockAmount(playerDTO);
            if (resValPlayerDTO != null)
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateSuccessResult(resValPlayerDTO, "Success");
            }
            else
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateFailureResult("Failure");
            }
            return retValPlayerDTO;
        }


        public OperationResult<IRoulettePlayerDTO> GetPlayerById(int customerId)
        {
            OperationResult<IRoulettePlayerDTO> retValPlayerDTO = null;
            IRouletteDAC rouletteDAC = (IRouletteDAC)DACFactory.Instance.Create(DACType.RouletteDAC);
            IRoulettePlayerDTO resValPlayerDTO = rouletteDAC.GetPlayerById(customerId);
            if (resValPlayerDTO != null)
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateSuccessResult(resValPlayerDTO, "Success");
            }
            else
            {
                retValPlayerDTO = OperationResult<IRoulettePlayerDTO>.CreateFailureResult("Failure");
            }
            return retValPlayerDTO;
        }
    }
}