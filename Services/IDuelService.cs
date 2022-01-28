
using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Services
{
    public interface IDuelService
    {
        DuelLight[] GenerateDuelLights(Tweeter[] tweeter);
    }

    public class DuelLight
    {
        public string TweeterA { get; set; }
        public string TweeterB { get; set; }
        public string LikesTweeterA { get; set; }
        public string LikesTweeterB { get; set; }

    }
}
