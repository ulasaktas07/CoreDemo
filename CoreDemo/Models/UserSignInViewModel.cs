using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage ="Lütfen kuullanıcı adınızı giriniz")]
		public string usuername { get; set; }
		[Required(ErrorMessage = "Lütfen şifrenizi  giriniz")]
		public string password { get; set; }
	}
}
