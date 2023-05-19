using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_Rules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            //RuleFor(x => x.Title).NotEmpty().WithMessage("Takım arkadaşını boş geçemezsin");
            //RuleFor(x => x.Title).NotEmpty().WithMessage("Title Boş geçilemez.");

            //RuleFor(x => x.Description).MaximumLength(50).WithMessage("50 den az olmalı");
            //RuleFor(x => x.Description).MinimumLength(10).WithMessage("10 dan fazla olmalı");
        }
    }
}
