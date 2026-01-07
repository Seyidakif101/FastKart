using System.ComponentModel.DataAnnotations;

namespace Abi.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required,MaxLength(50),MinLength(3)]
        public string FullName { get; set; } = string.Empty;
        [Required, MaxLength(50), MinLength(3)]
        public string UserName { get; set; }=string.Empty;
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required,MaxLength (50),DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty;
        [Required, MaxLength(50), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }= string.Empty;

    }
}
