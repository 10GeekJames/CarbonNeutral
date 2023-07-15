// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
    return prompt(message, 'Type anything here');
  }
export function importCss() {
  var link = document.createElement("link");
  link.href = "/AccountModule.css";
  link.type = "text/css";
  link.rel = "stylesheet";
  link.media = "screen,print";
  document.getElementsByTagNam("head")[0].appendChild( link );

  var link2 = document.createElement("link");
  link2.href = "/js/bug-min.js";
  link2.type = "text/javascript";
  link2.rel = "script";
  link2.media = "screen,print";
 
//  document.getElementsByTagNam("body")[0].appendChild( link2 );  

//  prompt('oioi', 'Type anything here');
}

  