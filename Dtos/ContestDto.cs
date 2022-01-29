namespace twitter_contest_dotnet.Dto
{
    public class ContestDto
    {
       public  string Id { get; set; }
        public string[] PreviousDuelsIds { get; set; }
        public string[] NextDuelsIds { get; set; }
    }
}
