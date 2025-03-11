using DataAccessLayer.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
	[Area("Admin")]
	public class Statistic2:ViewComponent
	{
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
			var writerid = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.WriterID).Take(1).FirstOrDefault();
			ViewBag.v2 = c.Writers.Where(x => x.WriterID == writerid).Select(x => x.WriterName).FirstOrDefault();
			return View();
		}
	}
}
