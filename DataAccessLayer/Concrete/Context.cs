﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context :IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=MELYAT;Database=CoreBlogDb;User Id=sa;Password=1;");

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Message2>()
				.HasOne(x => x.SenderUser)
				.WithMany(y => y.WriterSender)
				.HasForeignKey(z => z.SenderID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message2>()
				.HasOne(x => x.ReceiverUser)
				.WithMany(y => y.WriterReceiver)
				.HasForeignKey(z => z.ReceiverID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			base.OnModelCreating(modelBuilder);
		}
		public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<BlogRayting> BlogRaytings { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Message2> Message2s { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}
