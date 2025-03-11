using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		CategoryManager cm=new CategoryManager(new EfCategoryRepository());
		public IActionResult Index(int page=1)
		{
			var values = cm.GetList().ToPagedList(page,3);	
			return View(values);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			CategoryValidator cv= new CategoryValidator();
			ValidationResult results=cv.Validate(category);
			if (results.IsValid)
			{
				category.CategoryStatus = true;
				cm.TAdd(category);
				return RedirectToAction("Index","Category");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult StatusCategory(int id)
		{
		var value=cm.TGetByID(id);
			value.CategoryStatus = true;
			return View();
		}

	}
}
