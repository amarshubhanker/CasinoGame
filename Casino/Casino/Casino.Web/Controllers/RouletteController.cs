using Casino.Shared;
using Casino.Web.Models;
using Casino.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Casino.Web.Controllers
{
    public class RouletteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody]Customer customer)
        {
            IRouletteFacade rouletteFacade = (IRouletteFacade)FacadeFactory.Instance.Create(FacadeType.RouletteFacade);
            OperationResult<IRoulettePlayerDTO> loginResult = rouletteFacade.GetPlayerByUniqueId(customer.UniqueId);
            if (loginResult.IsValid())
            {
                var data = new { UserId = loginResult.Data.CustomerId,
                                 UserName = loginResult.Data.Name,
                                 UserBalance = loginResult.Data.AccountBalance
                };
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IHttpActionResult GetUser([FromBody]Customer customer)
        {
            IRouletteFacade rouletteFacade = (IRouletteFacade)FacadeFactory.Instance.Create(FacadeType.RouletteFacade);
            OperationResult<IRoulettePlayerDTO> loginResult = rouletteFacade.GetPlayerById(customer.CustomerId);
            if (loginResult.IsValid())
            {
                var data = new
                {
                    UserId = loginResult.Data.CustomerId,
                    UserName = loginResult.Data.Name,
                    UserBalance = loginResult.Data.AccountBalance
                };
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Block([FromBody]RoulettePlayer player)
        {
            IRouletteFacade rouletteFacade = (IRouletteFacade)FacadeFactory.Instance.Create(FacadeType.RouletteFacade);
            IRoulettePlayerDTO playerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
            DTOConverter.FillDTOFromViewModel(playerDTO, player);
            OperationResult<IRoulettePlayerDTO> blockResult = rouletteFacade.BlockAmount(playerDTO);
            if (blockResult.IsValid())
            {
                var data = new {UserId = blockResult.Data.CustomerId,
                    UserBalance = blockResult.Data.AccountBalance
                };
                return Ok(data); 
            }
            else
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateBalance([FromBody]RoulettePlayer player)
        {
            IRouletteFacade rouletteFacade = (IRouletteFacade)FacadeFactory.Instance.Create(FacadeType.RouletteFacade);
            IRoulettePlayerDTO playerDTO = (IRoulettePlayerDTO)DTOFactory.Instance.Create(DTOType.RoulettePlayerDTO);
            DTOConverter.FillDTOFromViewModel(playerDTO, player);
            OperationResult<IRoulettePlayerDTO> updateResult = rouletteFacade.UpdatePlayerBalance(playerDTO);
            if (updateResult.IsValid())
            {
                var data = new
                {
                    UserBalance = updateResult.Data.AccountBalance
                };
                return Ok(data);
            }
            else
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
        }
    }
}
