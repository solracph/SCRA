using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class PbpEntity
    {
        public int PbpId { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<ContractEntity> Contracts { get; set; }

        [NotMapped]
        public virtual ICollection<RuleEntity> Rules { get; set; }
    }
}
