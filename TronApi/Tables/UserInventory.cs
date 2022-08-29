namespace TronApi.Tables
{
    public class UserInventory
    {
        public int InventoryId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int ItemAmount { get; set; }
        public bool Stackable { get; set; }
    }
}
