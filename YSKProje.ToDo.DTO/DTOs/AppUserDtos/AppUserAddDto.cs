using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserAddDto
    {
        //[Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        //[Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Parola adı boş bırakılamaz")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Parola :")]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Paralolar eşleşmiyor")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Parola Tekrarı :")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Geçersiz email")]
        //[Display(Name = "Email :")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        //[Display(Name = "Ad :")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        //[Display(Name = "Soyad :")]
        public string SurName { get; set; }
    }
}
