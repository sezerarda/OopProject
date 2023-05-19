using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_Rules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım arkadaşını boş geçemezsin");
            RuleFor(x => x.PersonName).MaximumLength(20).MinimumLength(3).WithMessage("uzunluğa dikkat et");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Boş geçilemez.");
        }
    }
}
