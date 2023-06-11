namespace WendingMachine.Data.Entities
{
    public class Machine : BaseEntity
    {
        public int Balance { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
