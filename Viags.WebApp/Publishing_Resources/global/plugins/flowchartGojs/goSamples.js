// Highlight.js:
if (window.require) {
    require(["/Publishing_Resources/global/plugins/flowchartGojs/highlight.js"], function () {
    //This function is called after some/script.js has loaded.
  });
} else {
    document.write('<script src="/Publishing_Resources/global/plugins/flowchartGojs/highlight.js"></script>');
}

var link = document.createElement("link");
link.type = "text/css";
link.rel = "stylesheet";
link.href = "/Publishing_Resources/global/plugins/flowchartGojs/css/highlight.css";
document.getElementsByTagName("head")[0].appendChild(link);

/* Copyright (C) 1998-2015 by Northwoods Software Corporation. All Rights Reserved. */

function goSamples() {
  // save the body for goViewSource() before we modify it
  window.bodyHTML = document.body.innerHTML;
  window.bodyHTML = window.bodyHTML.replace(/</g, "&lt;");
  window.bodyHTML = window.bodyHTML.replace(/>/g, "&gt;");

  // look for links to API documentation and convert them
  _traverseDOM(document);

  // add standard footers
  window.hdr = document.createElement("div");  // remember for hiding in goViewSource()
  // var samplename = location.pathname.substring(location.pathname.lastIndexOf("/") + 1);
  var samplediv = document.getElementById("sample") || document.body;
  samplediv.appendChild(hdr);
  var ftr = document.createElement("div");
  ftr.className = "footer";
  var msg = "";
  if (window.go && window.go.version) {
    msg = "";
  }
  ftr.innerHTML = msg;
  samplediv.appendChild(ftr);

  // add list of samples for navigation
  // var menu = document.createElement("div");
  // menu.id = "menu";
  // menu.innerHTML = myMenu;
  // document.body.insertBefore(menu, document.body.firstChild);

  // when the page loads, change the class of navigation LI's
  var url = window.location.href;
  var lindex = url.lastIndexOf('/');
  url = url.slice(lindex+1).toLowerCase();  // include "/" to avoid matching prefixes
  // var lis = document.getElementById("sections").getElementsByTagName("li");
  // var l = lis.length;
  // var listed = false;
  // for (var i = 0; i < l; i++) {
    // var li = lis[i].parentNode;
    // if (!li.href) continue;
    // var lowerhref = li.href.toLowerCase();
    // if (lowerhref.indexOf(url) !== -1) {
      // lis[i].className = "selected";
      // listed = true;
    // }
  // }
  // if (!listed) {
    // lis[lis.length -1].className = "selected";
  // }

}

// Traverse the whole document and replace <a>TYPENAME</a> with:
//    <a href="../api/symbols/TYPENAME.html">TYPENAME</a>
// and <a>TYPENAME.MEMBERNAME</a> with:
//    <a href="../api/symbols/TYPENAME.html#MEMBERNAME">TYPENAME.MEMBERNAME</a>
function _traverseDOM(node) {
  if (node.nodeType === 1 && node.nodeName === "A" && !node.getAttribute("href")) {
    var text = node.innerHTML.split(".");
    if (text.length === 1) {
      node.setAttribute("href", "../api/symbols/" + text[0] + ".html");
      node.setAttribute("target", "api");
    } else if (text.length === 2) {
      node.setAttribute("href", "../api/symbols/" + text[0] + ".html" + "#" + text[1]);
      node.setAttribute("target", "api");
    } else {
      alert("Unknown API reference: " + node.innerHTML);
    }
  }
  for (var i = 0; i < node.childNodes.length; i++) {
    _traverseDOM(node.childNodes[i]);
  }
}

function goViewSource() {
  // show the code:
  var script = document.getElementById("code");
  if (!script) {
    var scripts = document.getElementsByTagName("script");
    script = scripts[scripts.length - 1];
  }
  var sp1 = document.createElement("pre");
  sp1.setAttribute("data-language", "javascript");
  sp1.innerHTML = script.innerHTML;
  var samplediv = document.getElementById("sample") || document.body;
  samplediv.appendChild(sp1);

  // show the body:
  var sp2 = document.createElement("pre");
  sp2.setAttribute("data-language", "javascript");
  sp2.innerHTML = window.bodyHTML;
  samplediv.appendChild(sp2);

  window.hdr.children[0].style.display = "none"; // hide the "View Source" link

  // apply formatting
  hljs.highlightBlock(sp1);
  hljs.highlightBlock(sp2);
  window.scrollBy(0,100);
}

(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
})(window,document,'script','http://www.google-analytics.com/analytics.js','ga');

// ga('create', 'UA-1506307-5', 'gojs.net');
// ga('send', 'pageview');

// commented out sample pages are listed in unlisted.html
