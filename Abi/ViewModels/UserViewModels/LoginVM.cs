using System.ComponentModel.DataAnnotations;

namespace Abi.ViewModels.UserViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required, MaxLength(50), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsRememberMe { get; set; }
    }
}
