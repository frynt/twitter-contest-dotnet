using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twitter_contest_dotnet.Models
{
    public class Duel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public int TweeterALikes { get; set; }
        public int TweeterBLikes { get; set; }
        public string DuelId { get; set; }

        public string ContestId { get; set; }
        public string ResponseTweeterId { get; set; }
        public string ProposalTweeterAId { get; set; }
        public string ProposalTweeterBId { get; set; }
        public string UserProposalTweeterId { get; set; }

        [ForeignKey("ContestId")]
        public Contest Contest { get; set; }
        [ForeignKey("ResponseTweeterId")]
        public Tweeter ResponseTweeter { get; set; }
        [ForeignKey("ProposalTweeterAId")]
        public Tweeter ProposalTweeterA { get; set; }
        [ForeignKey("ProposalTweeterBId")]
        public Tweeter ProposalTweeterB { get; set; }
        [ForeignKey("UserProposalTweeterId")]
        public Tweeter UserProposalTweeter { get; set; }
    }
}
