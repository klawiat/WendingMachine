using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WendingMachine.Api.Models.ViewModels;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;

namespace WendingMachine.Api.Controllers
{
    public class MachineController : BaseController
    {
        private readonly IMachineService service;
        public MachineController(IMapper mapper, IMachineService service) : base(mapper)
        {
            this.service = service;
        }
        [HttpGet("machines")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Data.Entities.Machine> machines = await service.GetAll();
            IEnumerable<MachineVM> vms = mapper.Map<IEnumerable<MachineVM>>(machines);
            return Ok(vms);
        }
        [HttpGet("machines/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Data.Entities.Machine machine = await service.GetById(id);
            MachineVM vm = mapper.Map<MachineVM>(machine);
            return Ok(machine);
        }
        [HttpPatch("machines/deposit/")]
        public async Task<IActionResult> DepositToBalance([FromBody] AddToBalanceDTO dto)
        {
            Data.Entities.Machine machine = await service.AddToBalanceById(dto);
            MachineVM vm = mapper.Map<MachineVM>(machine);
            return Ok(vm);
        }
        [HttpPost("machines/order/")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            await service.CreateOrder(dto);
            return Ok();
        }
        [HttpGet("machines/change/{id:int}")]
        public async Task<IActionResult> GetChange([FromRoute] int id)
        {
            Dictionary<int, int> change = await service.GetChange(id);
            return Ok(change);
        }
    }
}
