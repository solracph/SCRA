using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class SegmentRepository : Repository<SegmentEntity>
    {
        internal SegmentRepository(DatabaseContext context)
           : base(context)
        {
        }
    }
}
