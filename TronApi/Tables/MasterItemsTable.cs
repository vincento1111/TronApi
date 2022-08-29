namespace TronApi.Tables
{
    public class MasterItemsTable
    {
        public int Itemid { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public bool ItemUnique { get; set; }
        public double OffensiveStat1 { get; set; }
        public double OffensiveStat2 { get; set; }
        public string Effect { get; set; } = string.Empty;


    }
}
