using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRA.Domain.Clinical
{
    public class Rule
    {
        public int? RuleId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public ICollection<Segment> Segments { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public ICollection<Pbp> Pbp { get; set; }

        public ICollection<Tin> Tin { get; set; }

        public ICollection<Measure> Measures { get; set; }

        public  ICollection<Application> Applications { get; set; }
    }
}
