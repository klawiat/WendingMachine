using AutoMapper;
using FluentValidation;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;
using WendingMachine.Data.Entities;
using WendingMachine.Infrastructure.Interfaces;

namespace WendingMachine.Application.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository machineRepository;
        private readonly IDrinkRepository drinkRepository;
        private readonly ICoinService coinService;
        private readonly IMapper mapper;
        private readonly IValidator<MachineDTO> validator;
        public MachineService(IMachineRepository machineRepository, IDrinkRepository drinkRepository, ICoinService coinService, IMapper mapper, IValidator<MachineDTO> validator)
        {
            this.machineRepository = machineRepository;
            this.drinkRepository = drinkRepository;
            this.coinService = coinService;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<Machine> AddToBalanceById(AddToBalanceDTO dto)
        {
            if (!await coinService.Exist(dto.coin))
                throw new Exception();
            Machine machine = await machineRepository.GetById(dto.machineId);
            if (machine == null)
                throw new ArgumentNullException();
            machine.Balance += dto.coin;
            await machineRepository.Update(machine);
            await machineRepository.Save();
            return machine;
        }

        public async Task CreateOrder(CreateOrderDTO dto)
        {
            Machine machine = await machineRepository.GetById(dto.idMachine);
            Drink drink = (await drinkRepository
                .GetFiltered(d => d.Id == dto.idDrink && d.MachineId == dto.idMachine && d.isAvailable, tracking: false))
                .First();

            if (machine is null || drink is null) throw new ArgumentNullException();

            machine.Balance -= drink.Price;
            drink.Count--;

            if (machine.Balance < 0 || drink.Count < 0) throw new InvalidOperationException();

            await machineRepository.Update(machine);
            await machineRepository.Save();
            await drinkRepository.Update(drink);
            await drinkRepository.Save();
        }

        public async Task<IEnumerable<Machine>> GetAll()
        {
            IEnumerable<Machine> machines = await machineRepository.GetAll();
            return machines;
        }

        public async Task<Machine> GetById(int id)
        {
            Machine machine = await machineRepository.GetById(id);
            return machine;
        }

        public async Task<Dictionary<int, int>> GetChange(int id)
        {
            Machine? machine = await machineRepository.GetById(id);
            if (machine is null)
                throw new ArgumentNullException();
            int balance = machine.Balance;
            IOrderedEnumerable<int> coins = (await coinService.GetAvailableCoins()).Select(x => x.Denomination).OrderByDescending(x => x);
            int temp = 0;
            Dictionary<int, int> change = new Dictionary<int, int>();
            foreach (int coin in coins)
            {
                temp = (int)Math.Floor((decimal)(balance / coin));
                balance = balance - temp * coin;
                if (temp > 0)
                    change.Add(coin, temp);
            }
            machine.Balance = 0;
            await machineRepository.Update(machine);
            await machineRepository.Save();
            return change;
        }
    }
}
