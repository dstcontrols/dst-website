// JavaScript Document

function switchColors(it1,it2,it3,it4,it5,it6,it7,it8,it9,it10,it11,it12,it13,it14) {
	var vColor=new Array("start",it1,it2,it3,it4,it5,it6,it7,it8,it9,it10,it11,it12,it13,it14);
	  for(var i=1; i<17; i++) {
		  if (vColor[i] != 0 ) {
			  document.getElementById("chgColor"+i).style.color="#FC6907";
		  }
	  }
}
		
function restoreColors()  {
	for (var i=1; i<17; i++) {
		document.getElementById("chgColor"+i).style.color="#09F";
	}
} 