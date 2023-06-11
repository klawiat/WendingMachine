using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Services.Interfaces
{
    public interface IDrinkService
    {
        public Task<IEnumerable<Drink>> GetDrinks();
        public Task<IEnumerable<Drink>> GetDrinksByMachine(int machineId);
        public Task<Drink> GetDrinkById(int id);
        public Task<Drink> Create(DrinkDTO drink, int machineId);
        public Task<Drink> Update(int id, DrinkDTO drink);
        public Task Delete(int id);
    }
}
