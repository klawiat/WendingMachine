namespace WendingMachine.Application.Models.DTOs
{
    public class MachineDTO
    {
        public int Balance { get; set; }
        public List<DrinkDTO> Drinks { get; set; }
    }
}
