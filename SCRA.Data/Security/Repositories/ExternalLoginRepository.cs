using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Security.Models;
using SCRA.Domain.Security;

namespace SCRA.Data.Security.Repositories
{
    public class ExternalLoginRepository : Repository<ExternalLogin>
    {
        internal ExternalLoginRepository(SecurityDbContext context)
            : base(context)
        {
        }

        public ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey)
        {
            return DbSet.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey, cancellationToken);
        }
    }
}
