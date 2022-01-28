namespace twitter_contest_dotnet.Dto
{
    public class DuelDto
    {
        public string Id { get; set; }
        public string ProposalTweeterAId { get; set; }
        public string ProposalTweeterBId { get; set; }
        public string UserProposalTweeterId { get; set; }
        public int? TweeterALikes { get; set; }
        public int? TweeterBLikes { get; set; }
    }
}
