using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class TinRepository : Repository<TinEntity>
    {
        internal TinRepository(DatabaseContext context)
          : base(context)
        {
        }
    }
}
