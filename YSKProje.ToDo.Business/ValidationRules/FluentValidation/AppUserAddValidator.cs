using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;

namespace YSKProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı alanı boş bırakılamaz");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş bırakılamaz");

            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Paralo onay alanı boş bırakılamaz");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolanız eşleşmiyor.");

            RuleFor(I => I.Email).NotNull().WithMessage("Email alanı boş bırakılamaz").EmailAddress().WithMessage("Geçersiz email adresi");
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(I => I.SurName).NotNull().WithMessage("Soyad alanı boş bırakılamaz");
        }
    }
}
