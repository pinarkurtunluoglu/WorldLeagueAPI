namespace WorldLeagueAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int GroupCount { get; set; }
        public List<Team> Teams { get; set; }
    }
}
