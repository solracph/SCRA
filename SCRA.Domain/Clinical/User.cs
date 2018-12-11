using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRA.Domain.Clinical
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<Rule> Rules { get; set; }
    }
}
