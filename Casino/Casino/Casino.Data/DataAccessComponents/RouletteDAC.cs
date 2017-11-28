using Casino.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.EntityDataModel;
using Casino.EntityDataModel.EntityModel;
using System.Data.Entity.Validation;


namespace Casino.Data
{
    public class RouletteDAC : DACBase, IRouletteDAC
    {
        public RouletteDAC()
            : base(DACType.RouletteDAC)
        {

        }

        public IRoulettePlayerDTO GetPlayerByUniqueId(string uniqueId)
        {
            IRoulettePlayerDTO retValPlayerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB customer = context.CasinoDBs.Where(c => c.UniqueId == uniqueId).SingleOrDefault();
                    if (customer != null)
                    {
                        retValPlayerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
                        EntityConverter.FillDTOFromEntity(customer, retValPlayerDTO);
                    }
                }
            }
                catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValPlayerDTO;
        }

        public IRoulettePlayerDTO BlockAmount(IRoulettePlayerDTO playerDTO)
        {
            IRoulettePlayerDTO retValPlayerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB player = context.CasinoDBs.Where(c => c.CustomerId == playerDTO.CustomerId).SingleOrDefault();
                    if(player != null && player.Balance >= playerDTO.BlockedAmount)
                    {
                        player.Balance -= playerDTO.BlockedAmount;
                        player.BloackedAmount += playerDTO.BlockedAmount;
                        if(context.SaveChanges() > 0) 
                        {
                            retValPlayerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
                            EntityConverter.FillDTOFromEntity(player, retValPlayerDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValPlayerDTO;
        }


        public IRoulettePlayerDTO UpdatePlayerBalance(IRoulettePlayerDTO playerDTO)
        {
            IRoulettePlayerDTO retValPlayerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB player = context.CasinoDBs.Where(c => c.CustomerId == playerDTO.CustomerId).SingleOrDefault();
                    if (player != null)
                    {
                        // TODO:Check upper limit
                        player.Balance += playerDTO.WinAmount;
                        player.BloackedAmount -= playerDTO.BetAmount;
                        if (context.SaveChanges() > 0)
                        {
                            retValPlayerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
                            EntityConverter.FillDTOFromEntity(player, retValPlayerDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValPlayerDTO;
        }


        public IRoulettePlayerDTO GetPlayerById(int customerId)
        {
            IRoulettePlayerDTO retValPlayerDTO = null;
            try
            {
                using (UserDBEntities context = new UserDBEntities())
                {
                    CasinoDB customer = context.CasinoDBs.Where(c => c.CustomerId == customerId).SingleOrDefault();
                    if (customer != null)
                    {
                        retValPlayerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
                        EntityConverter.FillDTOFromEntity(customer, retValPlayerDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return retValPlayerDTO;
        }
    }
}
