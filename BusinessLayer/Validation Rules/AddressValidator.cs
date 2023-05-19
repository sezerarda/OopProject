using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_Rules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.Description1).NotEmpty().WithMessage("Açıklama 1 boş geçilmez");
            RuleFor(p => p.Description2).NotEmpty().WithMessage("Açıklama 2 boş geçilmez");
            RuleFor(p => p.Description3).NotEmpty().WithMessage("Açıklama 3 boş geçilmez");
            RuleFor(p => p.Description4).NotEmpty().WithMessage("Açıklama 4 boş geçilmez");
            RuleFor(p => p.MapInfo).NotEmpty().WithMessage("map info boş olamaz");
        }
    }
}
