#pragma checksum "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a29220f060dfd1d3b171f33200a6a5d41ecde4fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KupacProfil_Prikazi), @"mvc.1.0.view", @"/Views/KupacProfil/Prikazi.cshtml")]
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
#line 1 "C:\Users\User\source\repos\intpokusaj\Kino\Views\_ViewImports.cshtml"
using Fakture;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\intpokusaj\Kino\Views\_ViewImports.cshtml"
using Fakture.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
using Kino.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a29220f060dfd1d3b171f33200a6a5d41ecde4fc", @"/Views/KupacProfil/Prikazi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57bd2022bb5d1dc911e3124010d05cfb023c5634", @"/Views/_ViewImports.cshtml")]
    public class Views_KupacProfil_Prikazi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KupacIndexVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Obrisi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
  
    ViewData["title"] = "Prikazi";
    Layout = "_Layout";
    //int brojacStranica = (int)TempData["trenutna"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 style=""text-align: center; font-style:italic; "">Kupci</h2>
<br />
<br />

<table id=""table_id"" class=""row-border"" style=""width:100%"">
    <thead>
        <tr>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Grad</th>
            <th>Broj telefona</th>
            <th>Datum rodjenja</th>
            <th> </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 25 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
         foreach (var x in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
               Write(x.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
               Write(x.Prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
               Write(x.NazivGrada);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
               Write(x.BrojTelefona);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
               Write(x.Datum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <span");
            BeginWriteAttribute("id", " id=\"", 873, "\"", 909, 2);
            WriteAttributeValue("", 878, "confirmDeleteSpan_", 878, 18, true);
#nullable restore
#line 34 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
WriteAttributeValue("", 896, x.KorisnikId, 896, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:none\">\r\n                        <span>Da li ste sigurni da želite obrisati? </span>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a29220f060dfd1d3b171f33200a6a5d41ecde4fc6718", async() => {
                WriteLiteral("DA");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
                                                 WriteLiteral(x.KorisnikId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"#\" class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 1177, "\"", 1252, 4);
            WriteAttributeValue("", 1215, "confirmDelete(\'", 1215, 15, true);
#nullable restore
#line 38 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
WriteAttributeValue("", 1230, x.KorisnikId, 1230, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1243, "\',", 1243, 2, true);
            WriteAttributeValue(" ", 1245, "false)", 1246, 7, true);
            EndWriteAttribute();
            WriteLiteral(">NE</a>\r\n                    </span>\r\n\r\n                    <span");
            BeginWriteAttribute("id", " id=\"", 1318, "\"", 1347, 2);
            WriteAttributeValue("", 1323, "deleteSpan_", 1323, 11, true);
#nullable restore
#line 41 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
WriteAttributeValue("", 1334, x.KorisnikId, 1334, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <a href=\"#\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 1409, "\"", 1483, 4);
            WriteAttributeValue("", 1447, "confirmDelete(\'", 1447, 15, true);
#nullable restore
#line 43 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
WriteAttributeValue("", 1462, x.KorisnikId, 1462, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1475, "\',", 1475, 2, true);
            WriteAttributeValue(" ", 1477, "true)", 1478, 6, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"far fa-trash-alt\"></i> Obriši</a>\r\n                    </span>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 47 "C:\Users\User\source\repos\intpokusaj\Kino\Views\KupacProfil\Prikazi.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KupacIndexVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
