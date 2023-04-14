using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;

namespace Udemy.AdvertisementApp.Service.ValidationRules
{
    public class AppUserLogInDtoValidator:AbstractValidator<AppUserLogInDto>
    {
        public AppUserLogInDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz.");
        }
    }
}
