using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel alanı boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat alanı boş geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("bitirme oranı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje Adı en az 5 karekter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje Adı en az 5 karekter olmalıdır.");
        }
    }
}
