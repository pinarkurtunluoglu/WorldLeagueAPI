namespace WorldLeagueAPI.Models
{
    public class GroupTeamMapping
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeamId { get; set; }
        public Group Group { get; set; }
        public Team Teams { get; set; }
    }
}
