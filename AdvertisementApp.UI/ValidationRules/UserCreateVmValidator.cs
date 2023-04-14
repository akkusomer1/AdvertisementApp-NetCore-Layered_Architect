
using FluentValidation;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateVmValidator:AbstractValidator<UserCreateVm>
    {
        public UserCreateVmValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalıdır");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı min 3 karakter olmalıdır");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");
        }
    }
}
