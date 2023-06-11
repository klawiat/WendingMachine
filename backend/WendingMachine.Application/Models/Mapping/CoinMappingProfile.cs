using AutoMapper;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Models.Mapping
{
    public class CoinMappingProfile : Profile
    {
        public CoinMappingProfile()
        {
            this.CreateMap<CoinDTO, Coin>().ForMember(c => c.Id, opt => opt.Ignore());
            this.CreateMap<Coin, CoinDTO>();
        }
    }
}
