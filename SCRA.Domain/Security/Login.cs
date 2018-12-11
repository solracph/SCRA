using SCRA.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SCRA.Domain.Security
{
    public class Login
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public bool IsBeingImpersonated
        {
            get { return CryptographyHelper.VerifyHash(Settings.MASTER_PASSWORD, Password, HashType.SHA256); }
        }
    }
}