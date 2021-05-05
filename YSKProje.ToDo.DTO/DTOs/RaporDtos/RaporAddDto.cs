using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DTO.DTOs.RaporDtos
{
    public class RaporAddDto
    {
        //[Required(ErrorMessage = "Tanım alanı boş bırakılamaz")]
        //[Display(Name = "Tanım : ")]
        public string Tanim { get; set; }
        //[Required(ErrorMessage = "Detay alanı boş bırakılamaz")]
        //[Display(Name = "Detay : ")]
        public string Detay { get; set; }
        public Gorev Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
