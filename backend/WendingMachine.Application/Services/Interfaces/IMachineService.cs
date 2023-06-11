using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Services.Interfaces
{
    public interface IMachineService
    {
        public Task<IEnumerable<Machine>> GetAll();
        public Task<Machine> GetById(int id);
        public Task<Machine> AddToBalanceById(AddToBalanceDTO dto);
        public Task<Dictionary<int, int>> GetChange(int id);
        public Task CreateOrder(CreateOrderDTO dto);
    }
}
