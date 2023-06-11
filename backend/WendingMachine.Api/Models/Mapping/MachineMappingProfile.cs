using AutoMapper;
using WendingMachine.Api.Models.ViewModels;
using WendingMachine.Data.Entities;

namespace WendingMachine.Api.Models.Mapping
{
    public class MachineMappingProfile : Profile
    {
        public MachineMappingProfile()
        {
            this.CreateMap<MachineVM, Machine>()
                .ForMember(m => m.Drinks, opt => opt.Ignore());
            this.CreateMap<Machine, MachineVM>();
        }
    }
}
