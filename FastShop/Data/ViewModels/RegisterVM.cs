using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Это поле обязательно")]
		[Display(Name = "Email")]
		[RegularExpression(@"[A-Za-z0-9-_]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Это поле обязательно")]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Это поле обязательно")]
		[Display(Name = "Подтвердите пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string PasswordConfirm { get; set; }
	}
}
