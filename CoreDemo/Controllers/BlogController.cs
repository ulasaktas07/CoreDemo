using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	public class BlogController : Controller
	{
		Context c = new Context();
		BlogManager bm = new BlogManager(new EfBlogRepository());
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());

		[AllowAnonymous]
		public IActionResult Index()
		{
			var valus = bm.GetBlogListWithCategory();
			return View(valus);
		}
		[AllowAnonymous]

		public IActionResult BlogReadAll(int id)
		{
			ViewBag.i = id;
			var values = bm.GetBlogByID(id);
			return View(values);
		}
		public IActionResult BlogListByWriter()
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			var values = bm.GetListWithCategoryByWriterBm(writerID);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
			List<SelectListItem> categoryvalue = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value =x.CategoryID.ToString()
												  }).ToList();
			ViewBag.cv=categoryvalue;
			return View();
		}
		[HttpPost]
		public IActionResult BlogAdd(Blog blog)
		{

			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			BlogValidator bv = new BlogValidator();
			ValidationResult resutls = bv.Validate(blog);
			if (resutls.IsValid)
			{
				blog.BlogStatus = true;
				blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				blog.WriterID = writerID;
				bm.TAdd(blog);
				return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{
				foreach (var item in resutls.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult DeleteBlog(int id)
		{
			var blogvalue=bm.TGetByID(id);
			bm.TDelete(blogvalue);
			return RedirectToAction("BlogListByWriter");
		}
		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			List<SelectListItem> categoryvalue = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString()
												  }).ToList();
			ViewBag.cv = categoryvalue;
			var blogvalue = bm.TGetByID(id);
			return View(blogvalue);
		}
		[HttpPost]
		public IActionResult EditBlog(Blog blog)
		{
			var username = User.Identity.Name;
			var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
			blog.WriterID= writerID;
			blog.BlogStatus = true;
			bm.TUpdate(blog);
			return RedirectToAction("BlogListByWriter");
		}
	}
}
