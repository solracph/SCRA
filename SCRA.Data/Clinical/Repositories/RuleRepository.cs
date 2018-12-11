using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class RuleRepository : Repository<RuleEntity>
    {
        internal RuleRepository(DatabaseContext context)
           : base(context)
        {
        }
    }
}
