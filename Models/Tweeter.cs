using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace twitter_contest_dotnet.Models
{
    public class Tweeter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string TwitterUserId { get; set; }
        public string Name { get; set; }
    }
}
