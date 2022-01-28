using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Services
{
    public class DuelService : IDuelService
    {
        public DuelLight[] GenerateDuelLights(Tweeter[] tweeter)
        {
            var result = new List<DuelLight>();
            return result.ToArray();
        }
    }

}
