using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Это поле обязательно")]
		[Display(Name = "Email")]
		[RegularExpression(@"[A-Za-z0-9-_]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Это поле обязательно")]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Запомнить меня")]
		public bool RememberMe { get; set; }
	}
}
