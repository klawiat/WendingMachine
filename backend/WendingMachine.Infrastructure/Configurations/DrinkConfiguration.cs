using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WendingMachine.Data.Entities;

namespace WendingMachine.Infrastructure.Configurations
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new { d.Name, d.MachineId }).IsUnique();
            builder.Property(d => d.isAvailable).HasDefaultValue(true);
            builder.Property(d => d.Price).IsRequired();
            Random r = new Random();
            List<string> names = new List<string>() { "Coca Cola", "Fanta", "Sprite" };
            Dictionary<string, string> dic = new Dictionary<string, string>{
                { names[0], "https://coca-cola.by/uploads/media/01/cocacola.png" },
                { names[1], "https://cdn0.woolworths.media/content/wowproductimages/large/032812.jpg" },
                { names[2], "https://m.media-amazon.com/images/I/51uyMSzdbBL.jpg" },
            };
            List<Drink> drinks = new List<Drink>();
            for (int i = 0; i < 10; i++)
            {
                string name = names[i % 3];
                Drink drink = new Drink
                {
                    Id = i + 1,
                    Count = r.Next(1, 1000),
                    Price = r.Next(30, 50),
                    Name = name,
                    ImagePath = dic[name],
                    isAvailable = true,
                    MachineId = i % 4 + 1
                };
                drinks.Add(drink);
            }
            builder.HasData(drinks);
        }
    }
}
