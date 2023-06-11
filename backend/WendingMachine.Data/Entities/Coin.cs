namespace WendingMachine.Data.Entities
{
    public class Coin : BaseEntity
    {
        public int Denomination { get; set; }
        public bool isAvailable { get; set; }
    }
}
