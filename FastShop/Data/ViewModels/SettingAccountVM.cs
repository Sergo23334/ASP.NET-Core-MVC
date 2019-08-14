using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastShop.Data.ViewModels
{
	public class SettingAccountVM
	{
		[Required(ErrorMessage = "Это обязательное поле")]
		[Display(Name = "Старый пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		public string OldPass { get; set; }

		[Required(ErrorMessage = "Это обязательное поле")]
		[Display(Name = "Новый пароль")]
		[DataType(DataType.Password)]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		public string NewPass { get; set; }

		[Required(ErrorMessage = "Это обязательное поле")]
		[Display(Name = "Повторите пароль")]
		[DataType(DataType.Password)]
		[Compare("NewPass", ErrorMessage = "Пароли не совпадают")]
		[StringLength(30, MinimumLength = 7, ErrorMessage = "Допустимая длинна от 7 до 30 символов")]
		public string ConfirmPass { get; set; }
	}
}
