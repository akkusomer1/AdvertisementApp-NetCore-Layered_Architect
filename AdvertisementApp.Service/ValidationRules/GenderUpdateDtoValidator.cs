using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;

namespace Udemy.AdvertisementApp.Service.ValidationRules
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Bu alanı lütfen boş bırakmayınız");
            RuleFor(x => x.Defination).NotEmpty().WithMessage("Bu alanı lütfen boş bırakmayınız");
        }
    }
}
