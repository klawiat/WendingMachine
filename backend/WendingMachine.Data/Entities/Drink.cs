namespace WendingMachine.Data.Entities
{
    public class Drink : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool isAvailable { get; set; }
        public string? ImagePath { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
