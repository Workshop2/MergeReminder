using System.Data.Entity;

namespace MergeReminder.Logic
{
    public class Db : DbContext
    {
        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }
        public DbSet<BranchStore> Branches { get; set; }
    }
}