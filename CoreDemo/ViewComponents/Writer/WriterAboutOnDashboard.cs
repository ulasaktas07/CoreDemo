using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard:ViewComponent
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());

		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			var username = User.Identity.Name;
			ViewBag.v=username;
			var usermail=c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
			var writerID = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterID).FirstOrDefault();
			var values = wm.GetWriterById(writerID);
			return View(values);

		}
	}
}
