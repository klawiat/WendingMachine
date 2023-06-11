using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WendingMachine.Api.Filters;
using WendingMachine.Api.Models.ViewModels;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;

namespace WendingMachine.Api.Controllers
{
    public class CoinController : BaseController
    {
        private readonly ICoinService service;
        public CoinController(IMapper mapper, ICoinService service) : base(mapper)
        {
            this.service = service;
        }
        [HttpGet("coins")]
        public async Task<ActionResult> GetCoins()
        {
            var coins = await service.GetCoins();
            return Ok(coins);
        }
        [TypeFilter(typeof(SecretCodeAttribute))]
        [HttpPost("coins")]
        public async Task<ActionResult> CreateCoin([FromBody] CoinDTO coin, [FromQuery] string Key)
        {
            await service.Create(coin);
            return Ok();
        }
        [TypeFilter(typeof(SecretCodeAttribute))]
        [HttpGet("coins/{id:int}/toggle")]
        public async Task<ActionResult> ChangeCoin([FromRoute]int id, [FromQuery] string Key)
        {
            await service.ChangeAvailable(id);
            return Ok();
        }
    }
}
