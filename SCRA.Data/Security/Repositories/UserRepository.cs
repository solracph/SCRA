using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Security.Models;
using SCRA.Domain.Security;

namespace SCRA.Data.Security.Repositories
{
    public class UserRepository : Repository<User>
    {
        internal UserRepository(SecurityDbContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return DbSet.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return DbSet.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return DbSet.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
