#pragma checksum "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3e10e1d9884d3c376e77cd3770fed4cf550a8b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_IsEmri_GorevlendirPersonel), @"mvc.1.0.view", @"/Areas/Admin/Views/IsEmri/GorevlendirPersonel.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YSKProje.ToDo.DTO.DTOs.AciliyetDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YSKProje.ToDo.DTO.DTOs.BildirimDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YSKProje.ToDo.DTO.DTOs.GorevDtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\_ViewImports.cshtml"
using YSKProje.ToDo.DTO.DTOs.AppUserDtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3e10e1d9884d3c376e77cd3770fed4cf550a8b3", @"/Areas/Admin/Views/IsEmri/GorevlendirPersonel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8af2779da0148f888ce5db6596ce61b732904477", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_IsEmri_GorevlendirPersonel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PersonelGorevlendirListDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded mx-auto d-block w-50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtaPersonel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::YSKProje.ToDo.Web.TagHelpers.GorevAppUserIdTagHelpers __YSKProje_ToDo_Web_TagHelpers_GorevAppUserIdTagHelpers;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
  
    ViewData["Title"] = "GorevlendirPersonel";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row mt-2"">

    <div class=""col-md-4"">
        <div class=""card shadow-sm mb-5 bg-white rounded"">
            <div class=""card-header"">
                <h4 class=""text-center lead pt-2"">Görev Bilgileri</h4>
            </div>
            <div class=""card-body"">
                <h5 class=""card-title""> ");
#nullable restore
#line 15 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                   Write(Model.Gorev.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">\r\n                    ");
#nullable restore
#line 17 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
               Write(Model.Gorev.Aciklama);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n                <p class=\"card-text\">\r\n                    <strong>Aciliyet Durumu : </strong> <span class=\"badge badge-primary\">");
#nullable restore
#line 20 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                                                                     Write(Model.Gorev.Aciliyet.Tanim);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </p>
            </div>
        </div>
    </div>
    <div class=""col-md-8"">

        <div class=""card shadow  bg-white rounded mb-3"">
            <div class=""card-header"">
                <h5 class=""card-title"">Personel Bilgileri</h5>
            </div>
            <div class=""row no-gutters"">
                <div class=""col-md-4"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d3e10e1d9884d3c376e77cd3770fed4cf550a8b37792", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1162, "~/img/", 1162, 6, true);
#nullable restore
#line 33 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
AddHtmlAttributeValue("", 1168, Model.AppUser.Picture, 1168, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
AddHtmlAttributeValue("", 1197, Model.AppUser.Name, 1197, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-8\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 37 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                          Write(Model.AppUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 37 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                                              Write(Model.AppUser.SurName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("getirGorevAppUserId", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e10e1d9884d3c376e77cd3770fed4cf550a8b310741", async() => {
            }
            );
            __YSKProje_ToDo_Web_TagHelpers_GorevAppUserIdTagHelpers = CreateTagHelper<global::YSKProje.ToDo.Web.TagHelpers.GorevAppUserIdTagHelpers>();
            __tagHelperExecutionContext.Add(__YSKProje_ToDo_Web_TagHelpers_GorevAppUserIdTagHelpers);
#nullable restore
#line 39 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
__YSKProje_ToDo_Web_TagHelpers_GorevAppUserIdTagHelpers.AppUserId = Model.AppUser.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("app-user-id", __YSKProje_ToDo_Web_TagHelpers_GorevAppUserIdTagHelpers.AppUserId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </p>\r\n                        <p class=\"card-text\">\r\n                            <small class=\"text-muted\">");
#nullable restore
#line 42 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                                 Write(Model.AppUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"col-md-12 text-center\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e10e1d9884d3c376e77cd3770fed4cf550a8b312830", async() => {
                WriteLiteral("\r\n            <p class=\"lead\">Yukarıdaki göreve ilgili personel atanacaktır. Bu işlemi gerçekleştirmek istediğinizden emin misiniz?</p>\r\n            <div class=\"form-group \">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3e10e1d9884d3c376e77cd3770fed4cf550a8b313287", async() => {
                    WriteLiteral(" <i class=\"fas fa-chevron-left mr-1\"></i> Vazgeç");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
                                              WriteLiteral(Model.Gorev.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                <input type=\"hidden\" name=\"PersonelId\"");
                BeginWriteAttribute("value", " value=\"", 2386, "\"", 2411, 1);
#nullable restore
#line 56 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
WriteAttributeValue("", 2394, Model.AppUser.Id, 2394, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"GorevId\"");
                BeginWriteAttribute("value", " value=\"", 2468, "\"", 2491, 1);
#nullable restore
#line 57 "C:\Users\Omer\source\repos\UdemyToDo\YSKProje.ToDo.Web\Areas\Admin\Views\IsEmri\GorevlendirPersonel.cshtml"
WriteAttributeValue("", 2476, Model.Gorev.Id, 2476, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                <button type=\"submit\" class=\"btn btn-info\"> <i class=\"fas fa-check mr-1\"></i> Evet Görevlendir</button>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersonelGorevlendirListDto> Html { get; private set; }
    }
}
#pragma warning restore 1591