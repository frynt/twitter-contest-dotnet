using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Web;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters;

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
        public async Task<User> GetUserByUsername(string username)
        {
            var userResponse = await _twitterClient.Execute.RequestAsync<UserV2Response>(query =>
            {
                query.Url = $"https://api.twitter.com/2/users/by/username/{username}?user.fields=profile_image_url";
            });
            if (userResponse == null)
            {
                return null;
            }
            return new User
            {
                Id = userResponse.Model.User.Id,
                ProfilePictureURL =userResponse.Model.User.ProfileImageUrl,
                Username = userResponse.Model.User.Username,
                Name = userResponse.Model.User.Name
            };
        }
        public async Task<User[]> GetUsersByIds(string[] ids)
        {
            var idsString = String.Join(',', ids);
            var userResponse = await _twitterClient.Execute.RequestAsync<UsersV2Response>(query =>
            {
                query.Url = $"https://api.twitter.com/2/users?ids={idsString}&user.fields=profile_image_url";
            });
            if (userResponse == null)
            {
                return new User[0];
            }
            return userResponse.Model.Users.Select(userResponse => new User
            {
                Id = userResponse.Id.ToString(),
                ProfilePictureURL = userResponse.ProfileImageUrl,
                Username = userResponse.Username,
                Name = userResponse.Name
            }).ToArray();
        }
    }
}
