using Tweetinvi;
using Tweetinvi.Models.V2;

namespace twitter_contest_dotnet.Services
{
    public class TwitterService : ITwitterService

    {
        TwitterClient _twitterClient;
        public TwitterService(IConfiguration configuration)
        {
            _twitterClient = new TwitterClient(
                consumerKey: configuration.GetValue<string>("TwitterApiSettings:Key"),
                consumerSecret: configuration.GetValue<string>("TwitterApiSettings:Secret"),
                bearerToken: configuration.GetValue<string>("TwitterApiSettings:BearerToken")
            );
        }
        public async Task<User> getUserByUsernameAsync(string username)
        {
            var userResponse = await _twitterClient.Execute.RequestAsync<UserV2Response>(query =>
            {
                query.Url = $"https://api.twitter.com/2/users/by/username/{username}";
            });
            if (userResponse == null)
            {
                return null;
            }
            return new User
            {
                Id = userResponse.Model.User.Id,
                ProfilePictureURL =userResponse.Model.User.ProfileImageUrl,
                Username = userResponse.Model.User.Name
            };
        }
    }
}
