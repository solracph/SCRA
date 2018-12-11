using SCRA.Data.Common.Models;
using SCRA.Data.Common.Repositories;
using SCRA.Data.Clinical.Entities;

namespace SCRA.Data.Clinical.Repositories
{
    public class UserRepository : Repository<UserEntity>
    {
        internal UserRepository(DatabaseContext context)
          : base(context)
        {
        }
    }
}
