#pragma checksum "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Component.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bea6763eee2a82c9d849c654e09457f26e39755"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BoundBoxApp.Pages
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
#nullable restore
#line 2 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Component.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Component.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/claims")]
    public partial class Component : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Component.razor"
       
    private string _authMessage;
    private string _surnameMessage;
    private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

    private async Task GetClaimsPrincipalData()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
        {
            _authMessage = $"{user.Identity.Name} is authenticated.";
            _claims = user.Claims;
            _surnameMessage =
                $"Surname: {user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";
        }
        else
        {
            _authMessage = "The user is NOT authenticated.";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591