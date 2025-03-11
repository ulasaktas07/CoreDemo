using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
	public class UserSignUpViewModel
	{
		[Display(Name = "Ad Soyad")]
		[Required(ErrorMessage = "Lütfen ad soyad giriniz")]
		public string nameSurname { get; set; }

		[Display(Name = "Şifre")]
		[Required(ErrorMessage = "Lütfen şifre giriniz")]
		public string Password { get; set; }

		[Display(Name = "Şifre Tekrar")]
		[Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
		public string ConfirmPassqord { get; set; }

		[Display(Name = "Mail Adresi")]
		[Required(ErrorMessage = "Lütfen mail giriniz")]
		public string Mail { get; set; }

		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "Lütfen kullanıcı adıınızı giriniz")]
		public string UserName { get; set; }

		[Display(Name = "Check")]
		public bool IsAcceptTheContract { get; set; }
	}
}
