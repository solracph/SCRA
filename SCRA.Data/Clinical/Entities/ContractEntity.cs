﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCRA.Data.Clinical.Entities
{
    public class ContractEntity
    {
        public int ContractId { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public virtual ICollection<RuleEntity> Rules { get; set; }

        [NotMapped]
        public virtual ICollection<PbpEntity> Pbp { get; set; }

    }
}
