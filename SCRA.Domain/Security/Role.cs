using System;
using System.Collections.Generic;

namespace SCRA.Domain.Security
{
    public class Role
    {     
        public Guid RoleId { get; set; }
        public string Name { get; set; }

        private ICollection<User> _users;

        public ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }
    }
}
