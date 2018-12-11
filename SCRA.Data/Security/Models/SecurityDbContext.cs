using System.Data.Entity;
using SCRA.Common.Utilities;
using SCRA.Data.Security.Setup;
using SCRA.Domain.Security;

namespace SCRA.Data.Security.Models
{
    internal class SecurityDbContext : DbContext
    {
        internal SecurityDbContext()
            : base(Settings.SCRAConnectionString)
        {
        }

        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }
        internal IDbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
        }
    }
}
