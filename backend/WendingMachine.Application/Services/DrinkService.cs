using AutoMapper;
using FluentValidation;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;
using WendingMachine.Data.Entities;
using WendingMachine.Infrastructure.Interfaces;

namespace WendingMachine.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository repository;
        private readonly IMapper mapper;
        private readonly IValidator<DrinkDTO> validator;
        public DrinkService(IDrinkRepository repository, IMapper mapper, IValidator<DrinkDTO> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<Drink> Create(DrinkDTO drink, int machineId)
        {
            validator.ValidateAndThrow(drink);
            Drink drinkForDb = mapper.Map<Drink>(drink);
            drinkForDb.MachineId = machineId;
            await repository.Create(drinkForDb);
            await repository.Save();
            return drinkForDb;
        }

        public async Task Delete(int id)
        {
            await repository.DeleteById(id);
            await repository.Save();
        }

        public async Task<Drink> GetDrinkById(int id)
        {
            Drink drink = await repository.GetById(id);
            return drink;
        }

        public async Task<IEnumerable<Drink>> GetDrinks()
        {
            var drinks = await repository.GetAll();
            return drinks;
        }

        public async Task<IEnumerable<Drink>> GetDrinksByMachine(int machineId)
        {
            var drinks = await repository.GetFiltered(d => d.MachineId == machineId);
            return drinks;
        }

        public async Task<Drink> Update(int id, DrinkDTO drink)
        {
            validator.ValidateAndThrow(drink);
            Drink drinkForDb = mapper.Map<Drink>(drink);
            drinkForDb.Id = id;
            drinkForDb.MachineId = (await repository.GetById(id)).MachineId;
            await repository.Update(drinkForDb);
            await repository.Save();
            return drinkForDb;
        }
    }
}
