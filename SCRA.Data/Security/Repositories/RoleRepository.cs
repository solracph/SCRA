using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SCRA.Data.Security.Models;
using SCRA.Domain.Security;
using SCRA.Data.Common.Repositories;

namespace SCRA.Data.Security.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        internal RoleRepository(SecurityDbContext context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            return DbSet.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
