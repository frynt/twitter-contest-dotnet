#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Data
{
    public class twitter_contest_dotnetContext : DbContext
    {
        public twitter_contest_dotnetContext (DbContextOptions<twitter_contest_dotnetContext> options)
            : base(options)
        {
        }

        public DbSet<twitter_contest_dotnet.Models.Tweeter> Tweeter { get; set; }
    }
}
