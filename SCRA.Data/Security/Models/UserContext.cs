using System;
using System.Collections.Generic;

namespace SCRA.Data.Security.Models
{
    public class UserContext
    {
        public UserContext(string userName, string email, IList<string> roles, bool isAuthenticated, int? sessionExpireIn)
        {
            UserName = userName;
            Email = email;
            Roles = roles;
            IsAuthenticated = isAuthenticated;
            SessionExpireIn = sessionExpireIn;
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public IList<string> Roles { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public int? SessionExpireIn { get; private set; }

        public DateTime Timestamp
        {
            get { return DateTime.Now; }
        }
    }
}
