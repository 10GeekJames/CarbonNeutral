// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
    return prompt(message, 'Type anything here');
  }
export function importCss() {
  var link = document.createElement("link");
  link.href = "/KnownAccounts-Module.css";
  link.type = "text/css";
  link.rel = "stylesheet";
  link.media = "screen,print";
  document.getElementsByTagNam("head")[0].appendChild( link );

  link = document.createElement("script");
  link.src = "/js/KnownAccountsModule3DCode.js";
  link.type = "javascript";
  document.getElementsByTagNam("head")[0].appendChild( link );

  link = document.createElement("script");
  link.src = "/js/KnownAccountsModuleCanvasCode.js";
  link.type = "javascript";
  document.getElementsByTagNam("head")[0].appendChild( link );

  link = document.createElement("script");
  link.src = "/js/KnownAccountsModuleSideKick.js";
  link.type = "javascript";
  document.getElementsByTagNam("head")[0].appendChild( link );
}

  