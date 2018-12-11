using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class RuleEntity
    {
        public int RuleId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public virtual ICollection<SegmentEntity> Segments { get; set; }

        public virtual ICollection<ContractEntity> Contracts { get; set; }

        public virtual ICollection<PbpEntity> Pbp { get; set; }

        public virtual ICollection<TinEntity> Tin { get; set; }

        public virtual ICollection<MeasureEntity> Measures { get; set; }

        public virtual ICollection<ApplicationEntity> Applications { get; set; }

        [NotMapped]
        public virtual ICollection<UserEntity> Users { get; set; }

    }
}
