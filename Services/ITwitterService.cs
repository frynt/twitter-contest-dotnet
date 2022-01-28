namespace twitter_contest_dotnet.Services
{
    public interface ITwitterService
    {
        Task<User> getUserByUsernameAsync(string username);
    }

    public class User
    {
        public string Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Username { get; set; }

    }
}
