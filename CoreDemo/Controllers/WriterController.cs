using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		UserManager userManager = new UserManager(new EfUserRepository());
		WriterManager wm = new WriterManager(new EfWriterRepository());
		private readonly UserManager<AppUser> _userManager;
		Context c = new Context();

		public WriterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			var usermail = User.Identity.Name;
			ViewBag.v = usermail;
			Context c = new Context();
			var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
			ViewBag.v2 = writerName;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		public IActionResult WriterMail()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{
		
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel model = new UserUpdateViewModel();
			model.mail = values.Email;
			model.namesurname = values.NameSurname;
			model.imageurl = values.ImageUrl;
			model.username = values.UserName;
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.NameSurname = model.namesurname;
			values.ImageUrl = model.imageurl;
			values.Email = model.mail;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
			var result=await _userManager.UpdateAsync(values);
			return RedirectToAction("Index", "Dashboard");
			//var pas1 = Request.Form["pass1"];
			//var pas2 = Request.Form["pass2"];

			//if (pas1 == pas2)
			//{
			//	p.PasswordHash = pas2;
			//	//WriterValidator wl = new WriterValidator();
			//	//ValidationResult results = wl.Validate(p);

			//	//if (results.IsValid)
			//	//{

			//	//}
			//	//else
			//	//{
			//	//	foreach (var item in results.Errors)
			//	//	{
			//	//		ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			//	//	}
			//	//}
			//	userManager.TUpdate(p);
			//	return RedirectToAction("Index", "Dashboard");
			//}
			//else
			//{
			//	ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
			//}

		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage writer)
		{
			Writer w = new Writer();
			var pas1 = Request.Form["pass1"];
			var pas2 = Request.Form["pass2"];

			if (pas1 == pas2)
			{
				writer.WriterPassword = pas2;

				if (writer.WriterImage != null)
				{
					var extension = Path.GetExtension(writer.WriterImage.FileName);
					var newimagename = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
					var stream = new FileStream(location, FileMode.Create);
					writer.WriterImage.CopyTo(stream);
					w.WriterImage = newimagename;
				}
				w.WriterMail = writer.WriterMail;
				w.WriterName = writer.WriterName;
				w.WriterPassword = writer.WriterPassword;
				w.WriterStatus = true;
				w.WriterAbout = writer.WriterAbout;
				wm.TAdd(w);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
			}
			return View();
		}
	}
}
