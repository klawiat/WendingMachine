using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Services.Interfaces
{
    public interface ICoinService
    {
        public Task<IEnumerable<Coin>> GetCoins();
        public Task<IEnumerable<Coin>> GetAvailableCoins();
        public Task<bool> Exist(int denomination);
        public Task Create(CoinDTO coin);
        public Task ChangeAvailable(int id);
    }
}
