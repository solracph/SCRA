using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;


namespace SCRA.Data.Clinical.Repositories
{
    public class ApplicationRepository : Repository<ApplicationEntity>
    {
        internal ApplicationRepository(DatabaseContext context)
            : base(context)
        {
        }
    }
}
