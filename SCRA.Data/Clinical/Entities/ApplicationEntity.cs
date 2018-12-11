using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class ApplicationEntity
    {
        public int ApplicationId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public virtual ICollection<UserEntity> Users { get; set; }

        [NotMapped]
        public virtual ICollection<RuleEntity> Rules { get; set; }
    }
}
