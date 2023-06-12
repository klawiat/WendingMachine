using AutoMapper;
using FluentValidation;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Application.Services.Interfaces;
using WendingMachine.Data.Entities;
using WendingMachine.Infrastructure.Interfaces;

namespace WendingMachine.Application.Services
{
    public class CoinService : ICoinService
    {
        private readonly ICoinRepository repository;
        private readonly IMapper mapper;
        private readonly IValidator<CoinDTO> validator;
        public CoinService(ICoinRepository repository, IMapper mapper, IValidator<CoinDTO> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task ChangeAvailable(int id)
        {
            Coin coin = await repository.GetById(id);
            if (coin == null)
                throw new ArgumentNullException();
            coin.isAvailable = !coin.isAvailable;
            await repository.Update(coin);
            await repository.Save();
        }

        public async Task Create(CoinDTO coin)
        {
            validator.ValidateAndThrow(coin);
            Coin coinForDb = mapper.Map<Coin>(coin);
            await repository.Create(coinForDb);
            await repository.Save();
        }

        public async Task<bool> Exist(int denomination)
        {
            IEnumerable<Coin> coins = await repository.GetFiltered(x => x.Denomination == denomination, tracking: false);
            return coins.Any();
        }

        public async Task<IEnumerable<Coin>> GetAvailableCoins()
        {
            IEnumerable<Coin> coins = await repository.GetFiltered(c => c.isAvailable, tracking: false);
            return coins;
        }

        public async Task<IEnumerable<Coin>> GetCoins()
        {
            return await repository.GetAll();
        }
    }
}
