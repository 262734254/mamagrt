self.onError = null;
currentX = currentY = 0; 
whichIt = null; 
lastScrollX = 0; lastScrollY = 0;
NS = (document.layers) ? 1 : 0;
IE = (document.all) ? 1: 0;
<!-- STALKER CODE -->
function heartBeat(objectid) {
	if(IE) { diffY = document.body.scrollTop; diffX = document.body.scrollLeft; }
	if(NS) { diffY = self.pageYOffset; diffX = self.pageXOffset; }
	if(diffY != lastScrollY) {
		percent = .1 * (diffY - lastScrollY);
		if(percent > 0) percent = Math.ceil(percent);
		else percent = Math.floor(percent);
		if(IE) {
			objectid = objectid.split(";"); 
			for (i = 0; i < objectid.length; i++) eval("document.all."+objectid[i]).style.pixelTop += percent;
		}	
		if(NS) {
			objectid = objectid.split(";"); 
			for (i = 0; i < objectid.length; i++) eval("document."+objectid[i]).top += percent; 
		}	
		lastScrollY = lastScrollY + percent;
	}
	if(diffX != lastScrollX) {
		percent = .1 * (diffX - lastScrollX);
		if(percent > 0) percent = Math.ceil(percent);
		else percent = Math.floor(percent);
		if(IE) {
			objectid = objectid.split(";"); 
			for (i = 0; i < objectid.length; i++) eval("document.all."+objectid[i]).style.pixelLeft += percent;
		}	
		if(NS) {
			objectid = objectid.split(";"); 
			for (i = 0; i < objectid.length; i++) eval("document."+objectid[i]).left += percent; 			
		}	
		lastScrollX = lastScrollX + percent;
	} 	
}
<!-- /STALKER CODE -->
if(NS || IE) action = window.setInterval("heartBeat('floater1;floater2;floater3;floater4;floater5;floater6')", 6);
if (IE){
	document.write("<DIV id='floater1' style='LEFT: 5px; TOP: 320px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://www.tyfo.com/10399/2006/wt/tyfo/html/index.html' target='_blank'><IMG src='http://download.tfol.com/ad/200610/100X100.gif' height='100' width='100' border='0'></a></DIV>")
	document.write("<DIV id='floater2' style='right: 5px; TOP: 320px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://topic.tfol.com/activity/starInvestigation/index.aspx' target='_blank'><IMG src='http://www.tfol.com/10518/tfol/html/100_100.gif' height='100' width='100' border='0'></a></DIV>")
	document.write("<DIV id='floater3' style='LEFT: 5px; TOP: 430px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://www.tz888.cn' target='_blank'><IMG src='http://www.tz888.cn/images/xiala.gif' height='100' width='100' border='0'></a></DIV>")
	document.write("<DIV id='floater4' style='right: 5px; TOP: 430px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://www.tz888.cn' target='_blank'><IMG src='http://www.tz888.cn/images/xiala.gif' height='100' width='100' border='0'></a></DIV>")
	document.write("<DIV id='floater5' style='LEFT: 5px; TOP: 110px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://sc.vnet.cn/zhuanti/061124_1jdh/061124_1j.htm' target='_blank'><IMG src='http://sc.vnet.cn/06vnet_images/061124_nie_1jdh.gif' height='100' width='100' border='0'></a></DIV>")
    document.write("<DIV id='floater6' style='right: 5px; TOP: 110px; POSITION: absolute; WIDTH: 83; VISIBILITY: visible; Z-INDEX: 10;'><a href='http://sc.vnet.cn/zhuanti/061124_1jdh/061124_1j.htm' target='_blank'><IMG src='http://sc.vnet.cn/06vnet_images/061124_nie_1jdh.gif' height='100' width='100' border='0'></a></DIV>")

}
if (NS){
	document.write("<layer id=myleft top=400 width=80 height=80></layer>");
}