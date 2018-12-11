﻿using System;

namespace SCRA.Domain.Security
{
    public class ExternalLogin
    {
        private User _user;
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual User User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }
    }
}
