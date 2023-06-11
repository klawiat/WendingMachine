namespace WendingMachine.Application.Models.DTOs
{
    public class DrinkDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public bool isAvailable { get; set; }
        public string ImagePath { get; set; }
    }
}
