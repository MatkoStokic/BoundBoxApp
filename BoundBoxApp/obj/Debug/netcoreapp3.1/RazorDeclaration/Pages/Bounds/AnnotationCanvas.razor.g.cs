#pragma checksum "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6e2011b8a3733d6ad7b75d758608f39cbecea94"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BoundBoxApp.Pages.Bounds
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
#nullable restore
#line 1 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Blazor.Extensions.Canvas.Canvas2D;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
using BoundBoxApp.Model;

#line default
#line hidden
#nullable disable
    public partial class AnnotationCanvas : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Bounds\AnnotationCanvas.razor"
       
    [Parameter]
    public string ImageSrc { get; set; }

    public static List<Marker> markers = new List<Marker>();
    private static bool processing = false;

    int width;
    int height;

    ElementReference divCanvas;
    Blazor.Extensions.BECanvasComponent myCanvas;
    Canvas2DContext currentCanvasContext;

    async void OnClick(MouseEventArgs eventArgs)
    {
        if(processing)
        {
            return;
        }
        processing = true;

        double mouseX = 0;
        double mouseY = 0;

        if (divCanvas.Id?.Length > 0)
        {
            int markRadius = width / 160;
            string data = await jsRuntime.InvokeAsync<string>("getDivCanvasOffsets",
                new object[] { divCanvas, width });
            JObject offsets = (JObject)JsonConvert.DeserializeObject(data);
            mouseX = eventArgs.ClientX + offsets.Value<double>("offsetLeft");
            mouseY = eventArgs.ClientY + offsets.Value<double>("offsetTop");
            mouseX *= offsets.Value<double>("ratio");
            mouseY *= offsets.Value<double>("ratio");

            bool contains = false;

            foreach (Marker marker in markers)
            {
                if (isOnMarker(mouseX, marker.XCoords, markRadius)
                    && isOnMarker(mouseY, marker.YCoords, markRadius))
                {
                    contains = true;
                    if (eventArgs.Button == 2)
                    {
                        markers.Remove(marker);
                    }
                    break;
                }
            }

            if (!contains)
            {
                markers.Add(new Marker() { XCoords = mouseX, YCoords = mouseY });
            }

            currentCanvasContext = await myCanvas.CreateCanvas2DAsync();

            await currentCanvasContext.ClearRectAsync(0, 0, myCanvas.Width, myCanvas.Height);
            await RenderLines(markers, markRadius);
            await RenderMarkers(markers, markRadius);
            processing = false;
        }
    }

    protected override Task OnInitializedAsync()
    {
        Bitmap img = new Bitmap(Path.Combine(environment.ContentRootPath, "wwwroot" + ImageSrc), false);
        width = img.Width;
        height = img.Height;

        markers = new List<Marker>();
        processing = false;

        return base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        jsRuntime.InvokeVoidAsync("canvasSize", new object[] { width, height });
        return base.OnAfterRenderAsync(firstRender);
    }

    private bool isOnMarker(Double mouseCoord, Double markerCoord, int dist)
    {
        return Math.Abs(mouseCoord - markerCoord) < dist;
    }

    private async Task RenderLines(List<Marker> markers, int markRadius)
    {
        await currentCanvasContext.SetFillStyleAsync("rgb(244, 26, 26)");
        await currentCanvasContext.SetStrokeStyleAsync("rgb(244, 26, 26)");
        await currentCanvasContext.SetLineWidthAsync(markRadius / 2);

        await currentCanvasContext.BeginPathAsync();
        await currentCanvasContext.MoveToAsync(markers[0].XCoords, markers[0].YCoords);
        foreach (Marker marker in markers)
        {
            await currentCanvasContext.LineToAsync(marker.XCoords, marker.YCoords);
        }
        await currentCanvasContext.ClosePathAsync();

        await currentCanvasContext.SetGlobalAlphaAsync(.5f);
        await currentCanvasContext.FillAsync();
        await currentCanvasContext.SetGlobalAlphaAsync(1f);
        await currentCanvasContext.StrokeAsync();
    }


    private async Task RenderMarkers(List<Marker> markers, int markRadius)
    {
        foreach (Marker marker in markers)
        {
            await currentCanvasContext.SetFillStyleAsync("rgb(195, 12, 12)");
            await currentCanvasContext.FillRectAsync(
                marker.XCoords - markRadius, marker.YCoords - markRadius, markRadius * 2, markRadius * 2);
            await currentCanvasContext.SetFillStyleAsync("rgb(252, 252, 252)");
            await currentCanvasContext.FillRectAsync(
                marker.XCoords - markRadius/2, marker.YCoords - markRadius/2, markRadius, markRadius);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IWebHostEnvironment environment { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}
#pragma warning restore 1591
