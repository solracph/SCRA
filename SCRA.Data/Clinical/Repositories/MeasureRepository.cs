using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class MeasureRepository : Repository<MeasureEntity>
    {
        internal MeasureRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
