namespace WendingMachine.Web.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool isAvailable { get; set; }
        public string ImagePath { get; set; }
        public int MachineId { get; set; }
    }
}
