using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class PbpRepository : Repository<PbpEntity>
    {
        internal PbpRepository(DatabaseContext context)
           : base(context)
        {
        }
    }
}
