#pragma checksum "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6273d8e1da727e848487489e6f7beda2b650c58b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\_ViewImports.cshtml"
using TwitterApi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\_ViewImports.cshtml"
using TwitterApi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
using TwitterApi.Controllers.Twitter;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6273d8e1da727e848487489e6f7beda2b650c58b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"713355cee58e768174ca15de010251aebc206f99", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

    var twitterName = TwitterFeeds.TwitterName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""b-example-divider""></div>
<div class=""bg-dark text-secondary px-4 py-5 text-center"">
    <div class=""py-5"">
        <h1 class=""display-5 fw-bold text-white"">Twitter API Channels</h1>

        <div class=""col-lg-6 mx-auto"">
            <p class=""fs-5 mb-4"">A quick and simple Web App utilizing Twitters API to show recent tweets of assigned channels/programs.</p>
            <div class=""d-grid gap-2 d-sm-flex justify-content-sm-center"">
                <button type=""button""");
            BeginWriteAttribute("onclick", " onclick=\"", 632, "\"", 707, 4);
            WriteAttributeValue("", 642, "window.open(\'", 642, 13, true);
#nullable restore
#line 16 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
WriteAttributeValue("", 655, Url.Action("TwitterHome", "Home"), 655, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 689, "\',", 689, 2, true);
            WriteAttributeValue(" ", 691, "target=\'_self\')", 692, 16, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-info btn-lg px-4 me-sm-3 fw-bold\">Show Tweets</button>\r\n                <button type=\"button\" data-toggle=\"modal\" data-target=\"#addTwitterModal\" data-twitter-recipient=\"");
#nullable restore
#line 17 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
                                                                                                            Write(twitterName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""btn btn-outline-light btn-lg px-4"">Add Tweets</button>
            </div>
        </div>

        <a class=""col-md-5"" href=""https://developer.twitter.com/en"">
            <div class=""text-center rounded"">
                <svg class=""bi"" width=""1em"" height=""1em"" fill=""currentColor"">
                    <use xlink:href=""bootstrap-icons.svg#twitter""></use>
                    <svg xmlns=""http://www.w3.org/2000/svg"" fill=""currentColor"" class=""bi bi-twitter"" viewBox=""0 0 16 16"" id=""twitter""><path d=""M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0016 3.542a6.658 6.658 0 01-1.889.518 3.301 3.301 0 001.447-1.817 6.533 6.533 0 01-2.087.793A3.286 3.286 0 007.875 6.03a9.325 9.325 0 01-6.767-3.429 3.289 3.289 0 001.018 4.382A3.323 3.323 0 01.64 6.575v.045a3.288 3.288 0 002.632 3.218 3.203 3.203 0 01-.865.115 3.23 3.23 0 01-.614-.057 3.283 3.283 0 003.067 2.277A6.588 6.588 0 01.78 13.58a6.32 6.32 0 01-.78-.045A9.344 9.344 0 005.026 15z""></path></svg>
                </svg");
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"name text-muted text-decoration-none text-center pt-1\">twitter docs</div>\r\n        </a>\r\n\r\n");
            WriteLiteral("        ");
#nullable restore
#line 32 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
   Write(await Html.PartialAsync("_AddTwitterModal"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(\"#addTwitterUserName\").click(function (e) {\r\n            var userName = $(\"#twitterUserNameTxt\").val();\r\n            window.location.href = \"");
#nullable restore
#line 41 "C:\Users\user\source\repos\TwitterApi\TwitterApi\Views\Home\Index.cshtml"
                               Write(Url.Action("TwitterHome", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"/\" + userName;\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
