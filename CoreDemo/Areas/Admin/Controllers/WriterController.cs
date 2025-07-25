﻿using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WriterController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterList	()
		{
			var jsonWriters=JsonConvert.SerializeObject(writers);
			return Json(jsonWriters);
		}
		public IActionResult GetWriterById(int writerid)
		{
			var findWriter=writers.FirstOrDefault(x=>x.Id== writerid);
			var jsonWriters = JsonConvert.SerializeObject(findWriter);
			return Json(jsonWriters);
		}
		[HttpPost]
		public IActionResult AddWriter(WriterClass w)
		{
			writers.Add(w);
			var jsonWriters=JsonConvert.SerializeObject(w);
			return Json(jsonWriters);
		}
		public static List<WriterClass> writers = new List<WriterClass>()
		{
			
			new WriterClass
			{
				Id = 1,
				Name = "Ayşe",
			},
			new WriterClass
			{
				Id = 2,
				Name = "Ahmet",
			},
			new WriterClass
			{
				Id = 3,
				Name = "Buse",
			}
		};
	}
}
