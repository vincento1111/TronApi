namespace TronApi.Tables
{
    public class UserStats
    {
        public int StatId { get; set; }
        public string Userid { get; set; } = string.Empty;
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Life { get; set; }
        public int Money { get; set; }
    }
}
