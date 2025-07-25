﻿using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class RegisterUserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterUserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignUpViewModel p)
		{
			if (!p.IsAcceptTheContract)
			{
				ModelState.AddModelError("IsAcceptTheContract",
					"Sayfamıza kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekmektedir.");
				return View(p);
			}
			if (ModelState.IsValid)
			{
				AppUser user = new AppUser()
				{
					Email = p.Mail,
					UserName = p.UserName,
					NameSurname = p.nameSurname,
				};
				var result=await _userManager.CreateAsync(user,p.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			
			}
	
			return View();
		}
	}
}
