#pragma checksum "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30be75993d3558dff0bd68970fc09dcf7e702900"
// <auto-generated/>
#pragma warning disable 1591
namespace BoundBoxApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using BoundBoxApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\_Imports.razor"
using BoundBoxApp.Shared;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href>BoundBoxApp</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(7, "\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(17);
            __builder.AddAttribute(18, "Roles", "Admin, User");
            __builder.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(20, "\r\n            ");
                __builder2.OpenElement(21, "li");
                __builder2.AddAttribute(22, "class", "nav-item px-3");
                __builder2.AddMarkupContent(23, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(24);
                __builder2.AddAttribute(25, "class", "nav-link");
                __builder2.AddAttribute(26, "href", "project");
                __builder2.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(28, "\r\n                    <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> New Project\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(29, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(31, "\r\n\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(32);
            __builder.AddAttribute(33, "Roles", "Admin");
            __builder.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(35, "\r\n            ");
                __builder2.OpenElement(36, "li");
                __builder2.AddAttribute(37, "class", "nav-item px-3");
                __builder2.AddMarkupContent(38, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(39);
                __builder2.AddAttribute(40, "class", "nav-link");
                __builder2.AddAttribute(41, "href", "claims");
                __builder2.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(43, "\r\n                    <span class=\"oi oi-list-rich\" aria-hidden=\"true\"></span> User Claims\r\n                ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(44, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(45, "\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(46, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n\r\n}\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
