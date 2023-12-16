namespace WorldLeagueAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CountryId { get; set; }
        public string TeamName { get; set; }
        public Country Country { get; set; }
    }
}
