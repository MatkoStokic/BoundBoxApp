#pragma checksum "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3851d9c0a2f6ff7c72c60880b8ee1c0314c0e637"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Project_Project), @"mvc.1.0.razor-page", @"/Pages/Project/Project.cshtml")]
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
#line 1 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\_ViewImports.cshtml"
using BoundBoxApp.Areas.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/project")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3851d9c0a2f6ff7c72c60880b8ee1c0314c0e637", @"/Pages/Project/Project.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f25985018e8558d1889161aa03528e9656696b10", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Project_Project : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
  
    List<BoundBoxApp.Model.Project> projects = 
        ViewData["Projects"] as List<BoundBoxApp.Model.Project>;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h2>Projects</h2>\r\n\r\n<table>\r\n    <tr>\r\n        <th>Title</th>\r\n        <th>Category</th>\r\n        <th></th>\r\n    </tr>\r\n");
#nullable restore
#line 19 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
     foreach (var project in projects)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
           Write(project.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
           Write(project.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a class=\"btn\"");
            BeginWriteAttribute("href", " href=\"", 502, "\"", 529, 2);
            WriteAttributeValue("", 509, "/project/", 509, 9, true);
#nullable restore
#line 25 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
WriteAttributeValue("", 518, project.Id, 518, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 28 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\Project.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BoundBoxApp.Pages.Project.ProjectModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoundBoxApp.Pages.Project.ProjectModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BoundBoxApp.Pages.Project.ProjectModel>)PageContext?.ViewData;
        public BoundBoxApp.Pages.Project.ProjectModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
