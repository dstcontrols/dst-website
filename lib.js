/*****************************************************************************
Copyright (c) 2004 Digital Canyon Consulting -- 650-773-5777
******************************************************************************/
var range,styleObj;
var a="a";
var backprop=".bgColor";
var docObj="document.layers.";
var docImg="document.images.";
var styleObj="";
var Nav4 = eval(document.layers);
var isIE40r5 = eval(document.all);
var ns6 = ((document.getElementById)&&(!document.all))?true:false;
var agt=navigator.userAgent.toLowerCase();
var isMac=(agt.indexOf("mac")!=-1);
var isOpera=(agt.indexOf("opera")!= -1); 
var dtime,utime,vmid,oMid,oIid = null;
var tabID=null;
var PNV = false;
var dhid = 800;
var dbhid = 300;
var dbsm = 100;
var tabID=null;
var currDat = new Date();
var d0IN=new Image();
var d1IN=new Image();
var d2IN=new Image();
var d3IN=new Image();
var d4IN=new Image();
var d5IN=new Image();
var d0AC=new Image();
var d1AC=new Image();
var d2AC=new Image();
var d3AC=new Image();
var d4AC=new Image();
var d5AC=new Image();

d0IN.src="images/n_home_off.gif";
d1IN.src="images/n_intserv_off.gif";
d2IN.src="images/n_industry_off.gif";
d3IN.src="images/n_appstor_off.gif";
d4IN.src="images/n_prod_off.gif";
d5IN.src="images/n_about_off.gif";

d0AC.src="images/n_home_on.gif";
d1AC.src="images/n_intserv_on.gif";
d2AC.src="images/n_industry_on.gif";
d3AC.src="images/n_appstor_on.gif";
d4AC.src="images/n_prod_on.gif";
d5AC.src="images/n_about_on.gif";


var errorMsg="";
var bgBad = "#ffffff";
var bgGood = "#cccccc'";


function changeImage(img,stat)
{
	eval("document.images['e"+img+"'].src=d"+img+stat+".src");
}


if(ns6)
{
	docImg="document.images.";
	docObj="document.getElementById('";styleObj="').style";
}

if(isIE40r5)
{
	docObj="document.all.";
	range=".all";
	styleObj=".style";
	backprop=".background";
	docImg="";
	var is_ie5=(agt.indexOf("msie 5.0")!=-1);
}

function rsiz()
{
	if(Nav4)
	{
		var iw=window.innerWidth ;
		var ih = window.innerHeight;
		if(iw!=window.innerWidth||ih!=window.innerHeight)
		{
			if(isMac){
				window.setInterval(redo, 1000 );
			}else{
				redo();
			}
		}
	}
}

function redo(){window.location.reload();}

function FindImageTop(imageID)
{

	if(isOpera){var realCoord=80;
	}else{
		var ImagePosition = document.images[imageID].width;
		var imageHeight=document.images[imageID].height;
		imgobj=document.images[imageID];
		var imageTopCoord = docjslib_getImageYfromTop(imgobj);
		var thiscord = eval(imageTopCoord + imageHeight);
		var realCoord = eval(thiscord + 0);
	}
		return realCoord;

}

function docjslib_getImageYfromTop(imgID)
{
	if (Nav4)
	{
		return eval(imgID).y
	}else{
		return docjslib_getRealTop(imgID);
	}
}

function docjslib_getImageXfromLeft(imgID) 
{
  	if (Nav4)
	{ 
		return eval(imgID).x
	}else{
		 return docjslib_getRealLeft(imgID);
	}
}	


function docjslib_getRealLeft(imgElem) {
	var xPos = eval(imgElem).offsetLeft;
	var tempEl = eval(imgElem).offsetParent;
  	while (tempEl != null) {
  		xPos += tempEl.offsetLeft;
  		tempEl = tempEl.offsetParent;
  	}
	return xPos;
}




function docjslib_getRealTop(imgElem)
{
	var yPos = eval(imgElem).offsetTop;
	var tempEl = eval(imgElem).offsetParent;
	var oldTempEl;
	while(tempEl != null)
	{
		yPos+=tempEl.offsetTop;
		oldTempEl = tempEl;
		tempEl = tempEl.offsetParent;
	}
	var topMargin = oldTempEl.topMargin;
	if(isIE40r5 & isMac)
	{
		yPos += 1 * topMargin;
	}
	return (yPos);
}



function elem(url,title)
{
	this.url = url;
	this.title = title;
}







var a0=new Array();				//   Home
// no drop down

var a1=new Array(); 			//	Integration Services
a1[0]=new elem('controleng.html','Control&nbsp;Engineering&nbsp;');
a1[1]=new elem('electricaleng.html','Electrical&nbsp;Engineering&nbsp;');
a1[2]=new elem('ctrlpnl_osm.html','Control&nbsp;Panel&nbsp;Assembly&nbsp;');
a1[3]=new elem('ctrlpnl_osm.html','Sub&nbsp;System&nbsp;Manufacturing&nbsp;');
a1[4]=new elem('valdoc.html','Validation&nbsp;and&nbsp;Documentation&nbsp;');
a1[5]=new elem('techspecwriting.html','Technical&nbsp;and&nbsp;Specification&nbsp;Writing&nbsp;');
a1[6]=new elem('install_start.html','Installation,&nbsp;Start&nbsp;up,&nbsp;and&nbsp;Training&nbsp;');
a1[7]=new elem('fieldsvc.html','24&nbsp;x&nbsp;7&nbsp;Field&nbsp;Service&nbsp;');
a1[8]=new elem('safety.html','Machine&nbsp;and&nbsp;Process&nbsp;Safety&nbsp;');

var a2=new Array();				//  Industries Served
a2[0]=new elem('biopharm.html','Life&nbsp;Sciences&nbsp;and&nbsp;Pharmaceutical&nbsp;');
a2[1]=new elem('semiconductor.html','Semiconductor&nbsp;Manufacturing&nbsp;');
a2[2]=new elem('energy.html','Natural&nbsp;Gas&nbsp;');
a2[3]=new elem('energy.html','Refinery&nbsp;and&nbsp;Pipeline&nbsp;');
a2[4]=new elem('energy.html','Power&nbsp;Generation&nbsp;and&nbsp;Transmission&nbsp;');
a2[5]=new elem('foodbev.html','Food&nbsp;and&nbsp;Beverage&nbsp;');
a2[6]=new elem('waterwaste.html','Water&nbsp;and&nbsp;Waste&nbsp;Treatment&nbsp;');
a2[7]=new elem('mathandling.html','Material&nbsp;Handling&nbsp;');
a2[8]=new elem('DST-SOLAR-WEBSITE/index.html','PV&nbsp;Solar&nbsp;');

var a3=new Array();				//  Application Stories
a3[0]=new elem('articles.html','Articles&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;');
//a3[1]=new elem('#','Application&nbsp;of&nbsp;the&nbsp;Month&nbsp;&nbsp;');

var a4=new Array();				//  Partners
// no drop down

var a5=new Array();				//  About Us
a5[0]=new elem('careers.html','Careers&nbsp;');
a5[1]=new elem('contact.html','Contact&nbsp;Us&nbsp;');
a5[2]=new elem('quality.pdf','Quality&nbsp;Policy&nbsp;');





function makeNav(tabid,showTag)
{

tabID=tabid;

var e = '<table width="766" border="0" cellspacing="0" cellpadding="0"><tr>';
			e+='<td width="130" height="140" valign="middle"><a href="index.html"><img src="images/dst_logo_130.gif" width="140" height="107" alt="" border="0"></a></td>';
			e+='<td width="636">';
			e+='<table width="636" border="0" cellspacing="0" cellpadding="0"><tr><td height="15"></td></tr>';
			e+='<tr><td width="636" align="right" valign="top">';
			e+='<table width="585" border="0" cellspacing="0" cellpadding="0">';
			e+='<tr>';
			e+='<td><a href="index.html" onMouseOver="MouseOverMenu(0,1,1);" onMouseOut="MouseOutMenu(0);"><img name="e0" src="images/n_home_off.gif" width="85" height="25" alt="" border="0"></a></td>';
			e+='<td width="1"></td>';
			e+='<td><a href="#" onMouseOver="MouseOverMenu(1,2,2);" onMouseOut="MouseOutMenu(0);"><img name="e1" src="images/n_intserv_off.gif" width="100" height="25" alt="" border="0"></a></td>';
			e+='<td width="1"></td>';
			e+='<td><a href="#" onMouseOver="MouseOverMenu(2,3,3);" onMouseOut="MouseOutMenu(0);"><img name="e2" src="images/n_industry_off.gif" width="100" height="25" alt="" border="0"></a></td>';
			e+='<td width="1"></td>';
			e+='<td><a href="#" onMouseOver="MouseOverMenu(3,4,4);" onMouseOut="MouseOutMenu(0);"><img name="e3" src="images/n_appstor_off.gif" width="100" height="25" alt="" border="0"></a></td>';
			e+='<td width="1"></td>';
			e+='<td><a href="products.html" onMouseOver="MouseOverMenu(4,5,5);" onMouseOut="MouseOutMenu(0);"><img name="e4" src="images/n_prod_off.gif" width="100" height="25" alt="" border="0"></a></td>';
			e+='<td width="1"></td>';
			e+='<td><a href="about.html" onMouseOver="MouseOverMenu(5,6,6);" onMouseOut="MouseOutMenu(0);"><img name="e5" src="images/n_about_off.gif" width="95" height="25" alt="" border="0"></a></td>';
			e+='</tr>';
			e+='</table>';
			e+='</td></tr>';
			e+='<tr><td height="40"></td></tr>';
			e+='<tr><td height="20" valign="middle"><img src="images/blueBar.gif" width="636" height="7" alt="" border="0"></td></tr>';
			e+='<tr><td height="20"></td></tr>';
			
	if(showTag && tabid ==0)
	{
		e+='<tr><td height="20" align="right" valign="middle"><img src="images/tagline.gif" width="500" height="16" alt="" border="0"></td></tr></table>';
	}else{
		e+='<tr><td height="20"></td></tr></table>';
	
	
	}
			
			e+='</td></tr></table>';
	e+='<div id="menu0"></div><div id="menu1"></div><div id="menu2"></div><div id="menu3"></div><div id="menu4"></div><div id="menu5"></div>';
document.write(e);
changeImage(tabid,'AC')

}

function Eurl(u)
{
	if(Nav4)
	{
		 Furl(u)
	}
}
function Furl(u)
{
	eval("top.location.href='"+u+"'");
}


function MakeDIV(id,width)
{
  if(id !=0 && id !=4)
  {
	var q = eval(a+id+".length");
	var url = eval(a+id+"[0].url");
	var desc = eval(a+id+"[0].title");
	var e=0;
	var d=0;
	if(!Nav4)
	{
		var str ="<table bgcolor='#D6E4F2' border=0 cellspacing=1 cellpadding=0>";
	}else{
		var str ="<table bgcolor='#D6E4F2' border=0 cellspacing=0 cellpadding=1>";
	}
	while(e < q)
	{
		var url = eval(a+id+"["+d+"].url");
		var desc = eval(a+id+"["+d+"].title");

		if(!Nav4)
		{
		str += "<tr>";
		str += "<td NOWRAP bgcolor='#F6F7FD' height='17' width="+width+" class=submenu valign=middle NOWRAP onClick=\"Furl('"+url+"');\" onMouseOut=\"MouseOutItem(this,"+id+","+e+");\" onMouseOver=\"MouseOverItem(this,"+id+","+e+");\">";
	//	str += "<ilayer ID='dd"+e+"'>";
	//	str += "<layer height='17' ID='ldd"+e+"' valign='middle' onMouseOver=\"MouseOverItem(this,"+id+","+e+");\" onMouseOut=\"MouseOutItem(this,"+id+","+e+");\">";
		str += "&nbsp;<a href=\"javascript:Furl('"+url+"');\" class='submenu'>";
		str += desc+"</a>";
	//	str += "</layer>";
	//	str += "</ilayer>";
		str += "</td></tr>";

	
		}else{

			str += "<tr>";
			str += "<td>";
			str += "<table border=0 cellspacing=0 cellpadding=0>";
			str += "<tr>";
			str += "<td bgcolor='#F6F7FD' height='17' width="+width+" class=submenu valign=middle NOWRAP onClick=\"Furl('"+url+"');\" onMouseOut=\"MouseOutItem(this,"+id+","+e+");\" onMouseOver=\"MouseOverItem(this,"+id+","+e+");\">";
			str += "<ilayer ID='dd"+e+"'>";
			str += "<layer width='210' height='17' ID='ldd"+e+"' valign='middle' onMouseOver=\"MouseOverItem(this,"+id+","+e+");\" onMouseOut=\"MouseOutItem(this,"+id+","+e+");\">";
			str += "&nbsp;<a href=\"javascript:Furl('"+url+"');\" class='submenu'>";
			str += desc+"</a></layer></ilayer></td></tr></table></td></tr>";
		
		}
		e++;
		d++;
	}
		str += "</table>";
		
		
		var mydoc = eval(docObj + "menu" + id + styleObj);

		if(Nav4)
		{
			mydoc.document.open();
			mydoc.document.write(str);
			mydoc.document.close();
		}else{
			if(document.getElementById)
			{
				mydoc=document.getElementById('menu' +id);
			}
			mydoc.innerHTML=str + "\n";
		}
	}	
}

function LayerReference(layer)
{
	var ref;
	while(layer.parentLayer)
	{
		var layerref ="document.layers." + layer.name;
		if(ref != null)
		{
			ref = layerref + "." + ref;
		}else{
			ref = layerref;
		}
		layer = layer.parentLayer;
	}
	return ref;
}



function MouseOverMenu(menuId,left,width)
{

	if(dtime != null)
	{
		clearTimeout(dtime);
		dtime = null;
	}
	oMid=menuId;
	if((vmid == null) && PNV)
	{
		ShowMenu(menuId,left,width);
	}else{
		if(utime != null)
		{
			clearTimeout(utime);
			utime = null;
		}

		var delay;
		if(vmid == null)
		{
			delay = dbsm;
		}else{
			delay = dbhid;
		}
		var exp = "ShowMenu("+menuId+","+left+","+width+")";
		utime = setTimeout(exp, delay);
		}
}

function ShowMenuDelayed(objref,type,bgcolor,menuId,color,left)
{
	var obj = eval(objref);
	ShowMenu(obj,type,bgcolor,menuId,color,left);
}

function ShowMenu(menuId,left,width)
{
	ShowSubMenu(menuId,left);
	MakeDIV(menuId,width)
}

function ShowSubMenu(menuId,left)
{
	var imgid = "e"+menuId;

	//var leftPos = left;
	var imgobj=document.images[imgid];
	var leftPos = docjslib_getImageXfromLeft(imgobj);
	
	if(isMac){leftPos = eval(left -10);}
	var imgID = "e"+menuId;
	var loCat = FindImageTop(imgID);
	eval(docObj + "menu" + menuId + styleObj + ".top ='" + loCat + "'");
	eval(docObj + "menu" + menuId + styleObj + ".left ='" + leftPos + "'");
	eval(docObj + "menu" + menuId + styleObj + ".visibility ='visible'");
	changeImage(tabID,'IN')
	changeImage(menuId,'AC')
	HideOtherMenus(menuId);
	vmid = menuId;
}


function MouseOutMenu(menuId)
{
	oMid=null;
	dtime=setTimeout("HideAllMenus()", dhid);
	if(utime != null)
	{
		clearTimeout(utime);
		utime = null;
	}
}

//highlight color on submenu
function MouseOverItem(obj,menuId,itemId)
{
	var bgcolor = "#D6E4F2";
	obj.bgColor = bgcolor;
	oMid = menuId;
	oIid = itemId;
	if(dtime != null)
	{
		clearTimeout(dtime);
		dtime = null;
	}
}
//mouseout - return to main submenu color
function MouseOutItem(obj,menuId,itemId)
{
var bgcolor="#F6F7FD";
	obj.bgColor = bgcolor;
	oMid = null;
	oIid = null;
	if(dtime == null)
	{
		dtime = setTimeout("HideAllMenus()",dhid);
	}
}

function HideAllMenus()
{
	HideOtherMenus(tabID);
	changeImage(tabID,'AC')
}


function HideOtherMenus(menuId)
{
	if(vmid != null)
	{
		var p = vmid;
		eval(docObj + "menu" + p + styleObj + ".visibility ='hidden'");
		changeImage(p,'IN')
		vmid = null;
	}
}


function setColor(sty, bg)
{
	if (sty.style) sty.style.backgroundColor = bg;
}

function winPop(parentWindow,popUpWindow) 
{
	top.location.href=parentWindow;
	leftPos = 0;
	if(screen) 	{
		leftPos = screen.width-280
	}
	w=window.open(popUpWindow, 'article','scrollbars=yes,resizable=yes,toolbar=no,height=688,width=270,left='+leftPos+',top=0');
	if(window.focus) 	
	{
		w.focus();
	}
}

function makeFooter()  
{
var e = '<br><br>';
e+='<table width="760" border="0" cellspacing="0" cellpadding="0"><tr><td class="footer">';
e+='<hr size="1" noshade color="#CCCCCC">';
e+='<a href="index.html" class="footer">Home</a> &nbsp;&nbsp;|&nbsp;&nbsp; <a href="contact.html" class="footer">Contact Us</a> &nbsp;&nbsp;|&nbsp;&nbsp; <a href="mailto:sales@DSTControls.com" class="footer">sales@DSTControls.com</a>';
e+='<hr size="1" noshade color="#CCCCCC">';
e+='<b>651 Stone Road, Benicia, CA 94510 &nbsp;&nbsp;&nbsp;&nbsp; (707) 745-5117 &nbsp;&nbsp;&nbsp;&nbsp; (800) 251-0773 &nbsp;&nbsp;&nbsp;&nbsp; fax (707) 745-8952</b>';
e+='<hr size="1" noshade color="#CCCCCC">';
e+='&copy; 2011 DST Controls. All rights reserved.';
e+='</td></tr></table><br><br>';
document.write(e);
}

