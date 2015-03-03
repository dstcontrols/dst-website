// JavaScript Document
function preloader() {
  if (document.images) {
    var img1 = new Image();
    var img2 = new Image();
    var img3 = new Image();
    var img4 = new Image();
    var img5 = new Image();
    var img6 = new Image();
    var img7 = new Image();
    var img8 = new Image();
    var img9 = new Image();
    var img10 = new Image();
    img1.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_home1.png";
    img2.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_about1.png";
    img3.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_contPanel1.png";
    img4.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_contInt1.png";
    img5.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_indData1.png";
    img6.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_menuButtons3/gn_contact1.png";
    img7.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_indDataButtons/dk_but1.png";
    img8.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_indDataButtons/dk_but2.png";
    img9.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_indDataButtons/dk_but3.png";
    img10.src = "http://www.industrial-marketing-service.com/DSTweb2/_images/_indDataButtons/dk_but4.png";
  }
}

function addLoadEvent(func) {
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function () {
      if (oldonload) {
        oldonload();
      }
      func();
    }
  }
}
addLoadEvent(preloader);