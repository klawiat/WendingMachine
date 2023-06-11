using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WendingMachine.Api.Filters;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;

namespace WendingMachine.Api.Controllers
{
    public class DrinkController : BaseController
    {
        private readonly IDrinkService service;
        public DrinkController(IMapper mapper, IDrinkService service) : base(mapper)
        {
            this.service = service;
        }

        [HttpGet("drinks")]
        public async Task<IActionResult> GetAll()
        {
            var drinks = await service.GetDrinks();
            return Ok(drinks);
        }
        [HttpGet("drinks/{id:int}")]
        public async Task<IActionResult> GetDrink([FromRoute] int id)
        {
            var drink = await service.GetDrinkById(id);
            return Ok(drink);
        }

        [HttpGet("drinks/machine/{machineId:int}")]
        public async Task<IActionResult> GetDrinksOfMachine([FromRoute] int machineId)
        {
            var drinks = await service.GetDrinksByMachine(machineId);
            return Ok(drinks);
        }

        [TypeFilter(typeof(SecretCodeAttribute))]
        [HttpPost("drink/{machineId:int}")]
        public async Task<IActionResult> CreateDrink([FromBody] DrinkDTO drink, [FromRoute] int machineId, [FromQuery] string Key)
        {
            await service.Create(drink, machineId);
            return Ok();
        }

        [TypeFilter(typeof(SecretCodeAttribute))]
        [HttpPut("drink/{Id:int}")]
        public async Task<IActionResult> UpdateDrink([FromRoute] int Id, [FromBody] DrinkDTO drink, [FromQuery] string Key)
        {
            await service.Update(Id, drink);
            return Ok();
        }
        [TypeFilter(typeof(SecretCodeAttribute))]
        [HttpDelete("drink/{Id:int}")]
        public async Task<IActionResult> DeleteDrink([FromRoute] int Id, [FromQuery] string Key)
        {
            await service.Delete(Id);
            return Ok();
        }
    }
}
