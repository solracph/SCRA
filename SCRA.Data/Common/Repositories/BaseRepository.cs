using System.Data.Entity;

namespace SCRA.Data.Common.Repositories
{
    public abstract class BaseRepository
    {
        protected BaseRepository(DbContext dataContext)
        {
            DataContext = dataContext;
        }
        protected DbContext DataContext { get; }
    }
}
