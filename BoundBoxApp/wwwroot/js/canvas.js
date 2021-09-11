function getDivCanvasOffsets(el, realWidth) {
    let container = document.getElementById("canvasContainer");
    let ratio = realWidth / container.offsetWidth;

    var obj = {};
    obj.offsetLeft = window.scrollX - el.offsetLeft;
    obj.offsetTop = window.scrollY - el.offsetTop;
    obj.ratio = ratio;
    return JSON.stringify(obj);
}

function canvasSize(width, height) {
    let container = document.getElementById("canvasContainer");
    let canvas = container.querySelector("canvas");

    canvas.style.width = '100%';
    canvas.style.height = '100%';
    canvas.style.display = "block";
}
