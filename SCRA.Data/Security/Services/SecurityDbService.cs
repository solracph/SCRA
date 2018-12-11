using System.Threading.Tasks;
using SCRA.Data.Security.Models;
using SCRA.Data.Security.Repositories;

namespace SCRA.Data.Security.Services
{
    public class SecurityDbService
    {
        #region Fields
        private readonly SecurityDbContext _context;
        private ExternalLoginRepository _externalLoginRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;
        #endregion

        #region Constructors
        public SecurityDbService()
        {
            _context = new SecurityDbContext();
        }
        #endregion

        #region IUnitOfWork Members
        public ExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public RoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public UserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();          
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
