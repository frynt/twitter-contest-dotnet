namespace twitter_contest_dotnet.Dto
{
    public class ContestDto
    {
       public  string Id { get; set; }
        public string[] PreviousDuelIds { get; set; }
        public string[] NextDuelIds { get; set; }
    }
}
