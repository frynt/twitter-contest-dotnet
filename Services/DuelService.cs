using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Services
{
    public class DuelService : IDuelService
    {
        public DuelLight[] GenerateDuelLights(List<Tweeter> tweeters, Dictionary<string, int> likesByTweeterId)
        {
            if (tweeters.Count <= 1)
            {
                return new DuelLight[0];
            }
            /*
             * tweeters : Tweeter 1 (5 likes), Tweeter 2(10), Tweeter 3(5), Tweeter 4(20), Tweeter 5(5)
             * =====> produce ====>
             * Result of duels : 
             * 1 vs 2
             * 2 vs 3
             * 2 vs 4
             * 4 vs 5
             */
            var result = new List<DuelLight>();
            var tweeterA = tweeters[0];
            var tweeterB = tweeters[1];
            int likesTweeterA;
            likesByTweeterId.TryGetValue(tweeterA.Id, out likesTweeterA);
            int likesTweeterB;
            likesByTweeterId.TryGetValue(tweeterB.Id, out likesTweeterB);
            // 1 vs 2
            DuelLight duelLight = new DuelLight()
            {
                LikesTweeterA = likesTweeterA,
                LikesTweeterB = likesTweeterB,
                TweeterA = tweeterA,
                TweeterB = tweeterB
            };
            result.Add(duelLight);
            var newTweeters = new List<Tweeter>();
            if (likesTweeterA > likesTweeterB)
            {
                newTweeters.Add(tweeterA);
            } else
            {
                newTweeters.Add(tweeterB);
            }
            tweeters.Remove(tweeterA);
            tweeters.Remove(tweeterB);
            // 2 3 4 5
            newTweeters.AddRange(tweeters);
            result.AddRange(this.GenerateDuelLights(newTweeters, likesByTweeterId));
            return result.ToArray();
        }

    }

}
