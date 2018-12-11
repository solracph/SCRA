using System;
using System.Net;

namespace SCRA.Common.Net
{
    [Serializable]
    public class DirectoryCredential : ICredentials
    {
        public DirectoryCredential(string userName, string password, string domain)
        {
            UserName = userName;
            Password = password;
            Domain = domain;
        }

        public DirectoryCredential(string userName, string password)
            : this(userName, password, string.Empty)
        {
        }

        public DirectoryCredential(NetworkCredential credential)
            : this(credential.UserName, credential.Password, credential.Domain)
        {
        }

        public NetworkCredential GetCredential(Uri uri, string authType)
        {
            return new NetworkCredential(UserName, Password, Domain);
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Domain { get; private set; }
    }
}
