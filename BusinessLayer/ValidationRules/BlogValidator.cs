﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogValidator : AbstractValidator<Blog>
	{
		public BlogValidator()
		{
			RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blok başlığını boş geçemezsiniz");
			RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blok İçeriğini boş geçemezsiniz");
			RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blok görselini boş geçemezsiniz");
			RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
			RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın");
		}
	}
}
