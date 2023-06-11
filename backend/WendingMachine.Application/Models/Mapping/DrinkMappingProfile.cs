using AutoMapper;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Models.Mapping
{
    public class DrinkMappingProfile : Profile
    {
        public DrinkMappingProfile()
        {
            this.CreateMap<DrinkDTO, Drink>().ForMember(d => d.Id, opt => opt.Ignore());
            this.CreateMap<Drink, DrinkDTO>();
        }
    }
}
