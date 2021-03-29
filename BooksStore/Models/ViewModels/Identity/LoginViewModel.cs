using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        [Display(Name = "User Name")]

        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина строки должна быть от 6 до 20 символов")]

        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}