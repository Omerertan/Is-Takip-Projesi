﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelpers : TagHelper
    {
        public int AppUserId { get; set; }
        private readonly IGorevService _gorevService;
        public GorevAppUserIdTagHelpers(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Gorev> gorevler = _gorevService.GetirileAppUserId(AppUserId);

            int tamamlananGorevSayisi = gorevler.Where(I => I.Durum).Count();
            int ustundeCalistigiGorevSayisi = gorevler.Where(I => !I.Durum).Count();

            string htmlString = $" <strong>Tamamladığı görev sayısı : </strong> {tamamlananGorevSayisi} <br /> <strong> Üstünde çalıştığı görev sayısı : </strong> {ustundeCalistigiGorevSayisi} ";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
