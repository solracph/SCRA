using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class ContractRepository : Repository<ContractEntity>
    {
        internal ContractRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
