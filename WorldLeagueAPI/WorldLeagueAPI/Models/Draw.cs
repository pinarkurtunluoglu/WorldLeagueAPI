namespace WorldLeagueAPI.Models
{
    public class Draw
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int DrawerUserId { get; set; }
        public int GroupCount { get; set; }
        public List<Team> Teams { get; set; }
        public Group Group { get; set; }
        public User DrawerUser { get; set; }
    }
}
