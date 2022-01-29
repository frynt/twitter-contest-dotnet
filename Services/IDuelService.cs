
using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Services
{
    public interface IDuelService
    {
        DuelLight[] GenerateDuelLights(List<Tweeter> tweeters, Dictionary<string, int> likesByTweeterId);
    }

    public class DuelLight
    {
        public Tweeter TweeterA { get; set; }
        public Tweeter TweeterB { get; set; }
        public int LikesTweeterA { get; set; }
        public int LikesTweeterB { get; set; }

    }
}
