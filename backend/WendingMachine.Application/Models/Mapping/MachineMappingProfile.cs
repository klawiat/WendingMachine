using AutoMapper;
using WendingMachine.Application.Models.DTOs;
using WendingMachine.Data.Entities;

namespace WendingMachine.Application.Models.Mapping
{
    public class MachineMappingProfile : Profile
    {
        public MachineMappingProfile()
        {
            this.CreateMap<MachineDTO, Machine>().ForMember(m => m.Id, opt => opt.Ignore());
            this.CreateMap<Machine, MachineDTO>();
        }
    }
}
