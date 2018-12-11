using System.Collections.Generic;

namespace SCRA.Data.Clinical.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<ApplicationEntity> Applications { get; set; }

        public virtual ICollection<RuleEntity> Rules { get; set; }
    }
}
