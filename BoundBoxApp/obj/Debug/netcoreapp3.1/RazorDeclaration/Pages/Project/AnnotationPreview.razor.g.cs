#pragma checksum "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "376e988d3a1f5c99a4944c2ba2a328b892b69480"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BoundBoxApp.Pages.Project
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
#line 1 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using BoundBoxApp.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using Blazor.Extensions.Canvas.Canvas2D;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using Microsoft.AspNetCore.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
using System.IO;

#line default
#line hidden
#nullable disable
    public partial class AnnotationPreview : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "C:\Users\DesBelli\Desktop\Zavrsni rad\App\BoundBoxApp\Pages\Project\AnnotationPreview.razor"
       
    [Parameter]
    public Model.Project Project { get; set; }

    public Annotation curAnnotation;
    public string type;
    int curMarkerIndex = 0;

    int width;
    int height;

    ElementReference divCanvas;
    Blazor.Extensions.BECanvasComponent myCanvas;
    Canvas2DContext currentCanvasContext;

    public void OnClick(string direction)
    {
        if (direction == "right")
        {
            curMarkerIndex++;
            if (Project.Annotations.Count <= curMarkerIndex)
            {
                curMarkerIndex = 0;
            }
        }
        else if (direction == "left")
        {
            curMarkerIndex--;
            if (curMarkerIndex < 0)
            {
                curMarkerIndex = Project.Annotations.Count - 1;
            }
        }

        curAnnotation = Project.Annotations.ToList()[curMarkerIndex];

        if (curAnnotation.IsObjectDetection)
        {
            type = "Object Detection";
        }
        else
        {
            type = "Classification";
        }       
    }

    protected override Task OnInitializedAsync()
    {
        Bitmap img = new Bitmap(Path.Combine(environment.ContentRootPath, "wwwroot" + Project.Src), false);
        width = img.Width;
        height = img.Height;

        curAnnotation = null;
        type = null;
        if (Project.Annotations.Count > 0)
        {
            curAnnotation = Project.Annotations.ToList()[0];

            if (curAnnotation.IsObjectDetection)
            {
                type = "Object Detection";
            }
            else
            {
                type = "Classification";
            }
        }


        return base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        jsRuntime.InvokeVoidAsync("canvasSize", new object[] { width, height });

        if (Project.Annotations == null || Project.Annotations.Count == 0)
        {
            return base.OnAfterRenderAsync(firstRender);
        }


        DrawMarkers();

        return base.OnAfterRenderAsync(firstRender);

    }


    private async void DrawMarkers()
    {
        int markRadius = width / 160;
        currentCanvasContext = await myCanvas.CreateCanvas2DAsync();

        await currentCanvasContext.ClearRectAsync(0, 0, myCanvas.Width, myCanvas.Height);

        if (curAnnotation.Markers != null && curAnnotation.Markers.Count > 0)
        {
            await RenderLines(curAnnotation.Markers.ToList(), markRadius);
            await RenderMarkers(curAnnotation.Markers.ToList(), markRadius);
        }

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
                marker.XCoords - markRadius / 2, marker.YCoords - markRadius / 2, markRadius, markRadius);
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
