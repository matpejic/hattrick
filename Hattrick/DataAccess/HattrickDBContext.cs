using System.Data.Entity;
using Hattrick.Models.DbModels;
using Hattrick.Configurations;


namespace Hattrick.DataAccess
{
    public class HattrickDBContext : DbContext
    {

        public HattrickDBContext() : base("HattrickDBContext")
        {
            Database.SetInitializer(new HattrickInitialization());
        }

        public  DbSet<Football> Footballs { get; set; }
        public  DbSet<Wallet> Wallets { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}