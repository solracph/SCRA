using SCRA.Data.Common.Models;
using System.Threading.Tasks;

namespace SCRA.Data.Common.Services
{
    public class BaseDbService
    {
        private DatabaseContext _dbContext; 
        public BaseDbService(string connString)
        {
            DbContext = new DatabaseContext(connString);
        }

        public DatabaseContext DbContext { get; }

        public virtual void Dispose()
        {
            DbContext.Dispose();
        }

        public virtual int Save()
        {
            return DbContext.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
