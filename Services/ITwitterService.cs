namespace twitter_contest_dotnet.Services
{
    public interface ITwitterService
    {
        Task<User> GetUserByUsername(string username);
        Task<User[]> GetUsersByIds(string[] ids);
    }

    public class User
    {
        public string Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

    }
}
