using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WendingMachine.Data.Entities;

namespace WendingMachine.Infrastructure.Configurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Denomination).IsUnique();
            builder.Property(c=>c.isAvailable).HasDefaultValue(true).IsRequired();
            List<Coin> list = new List<Coin>() { 
                new Coin{Id=1,Denomination=1,isAvailable=true},
                new Coin{Id=2,Denomination=2,isAvailable=true},
                new Coin{Id=3,Denomination=5,isAvailable=true},
                new Coin{Id=4,Denomination=10,isAvailable=true},
            };
            builder.HasData(list);
        }
    }
}
