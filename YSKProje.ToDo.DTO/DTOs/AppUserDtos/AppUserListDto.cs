using System;
using System.Collections.Generic;
using System.Text;

namespace YSKProje.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Kullanıcı alanı boş bırakılamaz")]
        //[Display(Name = "Ad : ")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Kullanıcı alanı boş bırakılamaz")]
        //[Display(Name = "Soyad : ")]
        public string SurName { get; set; }
        //[Display(Name = "Email : ")]
        public string Email { get; set; }
        //[Display(Name = "Resim : ")]
        public string Picture { get; set; }
    }
}
