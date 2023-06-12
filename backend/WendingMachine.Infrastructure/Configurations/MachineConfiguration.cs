using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WendingMachine.Data.Entities;

namespace WendingMachine.Infrastructure.Configurations
{
    public class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Balance).HasDefaultValue(0);
            List<Machine> list = new List<Machine>();
            for (int i = 1; i < 5; i++)
            {
                list.Add(new Machine { Id = i, Balance = 0 });
            }
            builder.HasData(list);
        }
    }
}
