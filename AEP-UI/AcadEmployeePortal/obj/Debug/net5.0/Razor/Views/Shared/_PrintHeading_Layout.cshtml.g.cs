#pragma checksum "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27b08fb223e00d4971a297e8c44688c5be3651a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PrintHeading_Layout), @"mvc.1.0.view", @"/Views/Shared/_PrintHeading_Layout.cshtml")]
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
#line 1 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\_ViewImports.cshtml"
using EmployeePortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\_ViewImports.cshtml"
using EmployeePortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27b08fb223e00d4971a297e8c44688c5be3651a0", @"/Views/Shared/_PrintHeading_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff87853e2a87a18ff71e5404c7f0684e8facf25c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__PrintHeading_Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/avatar2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded float-end"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("MC logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/avatar3.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded float-start"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("MCC logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
 switch (ViewData["Role"])
{
    case "Dean":

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-2\">         \r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "27b08fb223e00d4971a297e8c44688c5be3651a05888", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""col-10 align-items-center"">
            <h2>Republic of the Philippines</h2>
            <h3>City of Mandaue</h3>
            <h3>Mandaue City College</h3>
            <h3>Don Andres Soriano Ave., Centro Mandaue City</h3>
        </div>
        <div class=""col-2"">           
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "27b08fb223e00d4971a297e8c44688c5be3651a07418", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 21 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
        break;
    case "Teacher":

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 746, "\"", 796, 1);
#nullable restore
#line 24 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
WriteAttributeValue("", 753, Url.Action("TeacherCourseList", "Teacher"), 753, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                <i class=\"far fa-circle nav-icon\"></i>\r\n                <p>My Courses</p>\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 986, "\"", 1036, 1);
#nullable restore
#line 30 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
WriteAttributeValue("", 993, Url.Action("CourseStudentList", "Teacher"), 993, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                <i class=\"far fa-circle nav-icon\"></i>\r\n                <p>My Students</p>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 35 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
        break;
    case "AcademicHead":

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1269, "\"", 1321, 1);
#nullable restore
#line 38 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
WriteAttributeValue("", 1276, Url.Action("ManageCalendar", "AcademicHead"), 1276, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                <i class=\"far fa-circle nav-icon\"></i>\r\n                <p>Manage Calendar</p>\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1516, "\"", 1566, 1);
#nullable restore
#line 44 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
WriteAttributeValue("", 1523, Url.Action("CourseStudentList", "Teacher"), 1523, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                <i class=\"far fa-circle nav-icon\"></i>\r\n                <p>My Students</p>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 49 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
        break;
    default:

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"nav-item\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1787, "\"", 1823, 1);
#nullable restore
#line 52 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
WriteAttributeValue("", 1794, Url.Action("Index", "Login"), 1794, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nav-link\">\r\n                <i class=\"far fa-circle nav-icon\"></i>\r\n                <p>Courses</p>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 57 "C:\Users\RICHE\Desktop\Riche Files\Source Codes\Academic Employee Portal\AEP-UI\AcadEmployeePortal\Views\Shared\_PrintHeading_Layout.cshtml"
        break;
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591