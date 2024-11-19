using System.ComponentModel.DataAnnotations;

namespace FilmLens.MVC.Models
{
	public class RegisterViewModel
	{
		[Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

		[Required]
		[EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [Display(Name = "Пароль повторно")]
        public string ConfirmPassword { get; set; }
	}
}
