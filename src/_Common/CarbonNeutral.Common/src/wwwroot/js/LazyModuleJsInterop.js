// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.
export function requestFullScreen(component) {
  if(component != null) {
    component.requestFullscreen();
  }
}

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}
export function importCss() {
  var link = document.createElement("link");
  link.type = "text/css";
  link.rel = "stylesheet";
  link.media = "screen,print";
  link.href = "./_content/CarbonNeutral.Common/app.css";
  document.getElementsByTagName("head")[0].appendChild(link);
}
/* 
window.browserResize = {
  getBrowserDimensions: function () {
    return {
      width: window.innerWidth,
      height: window.innerHeight
    };
  },
  registerResizeCallback: function () {
    window.addEventListener("resize", browserResize.resized);
  },
  resized: function () {
    DotNet.invokeMethodAsync("LazyGameBrainsModuleJsInterop", 'OnBrowserResize').then(data => data);
  }
} */