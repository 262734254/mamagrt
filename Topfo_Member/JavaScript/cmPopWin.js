function cmAddEvent(obj, evenTypeName, fn){
 if (obj.addEventListener){
    obj.addEventListener(evenTypeName, fn, true);
    return true;
 } else if (obj.attachEvent){
    return obj.attachEvent("on"+evenTypeName, fn);
 } else {
    return false;
 }
}

function pwGetViewportHeight() {
	if (window.innerHeight!=window.undefined) return window.innerHeight;
	if (document.compatMode=='CSS1Compat') return document.documentElement.clientHeight;
	if (document.body) return document.body.clientHeight; 
	return window.undefined; 
}
function pwGetViewportWidth() {
	if (window.innerWidth!=window.undefined) return window.innerWidth; 
	if (document.compatMode=='CSS1Compat') return document.documentElement.clientWidth; 
	if (document.body) return document.body.clientWidth; 
	return window.undefined; 
}

var gPopupContainer = null;
var gPopFrame = null;
var gReturnFunc;
var gPopupIsShown = false;
var gHideSelects = false;

var gTabIndexes = new Array();
var gTabbableTags = new Array("A","BUTTON","TEXTAREA","INPUT","IFRAME");	

function pwInit() {
	
	gPopupMask = document.getElementById("popupMask");
	gPopupContainer = document.getElementById("popup_Container_div");
	gPopFrame = document.getElementById("popup_Frame_iframe");	
	
	var brsVersion = parseInt(window.navigator.appVersion.charAt(0), 10);
	if (brsVersion <= 6 && window.navigator.userAgent.indexOf("MSIE") > -1) {
		gHideSelects = true;
	}
}
cmAddEvent(window, "load", pwInit);

function pwShow(url, width, height,nPos,returnFunc) {
		
	if(gPopupContainer==null){
	
		pwInit();
	
	}
	gPopupIsShown = true;
	pwDisableTabIndexes();
	gPopupMask.style.display = "block";
	gPopupContainer.style.display = "block";
	pwSetPos(width, height,nPos);
		
	document.getElementById("popup_Title_div").innerHTML="加载中载中"
	var nTitleBarHeight = parseInt(document.getElementById("popup_TitleBar_div").offsetHeight, 10);
	if (navigator.product == 'Gecko') { width = width + 6; height = height+6; }
	
	gPopupContainer.style.width = width + "px";
	gPopupContainer.style.height = (height+nTitleBarHeight) + "px";
	gPopFrame.style.width =parseInt(document.getElementById("popup_TitleBar_div").offsetWidth, 10) + "px";
	gPopFrame.style.height = parseInt(height) + "px";
	
	gPopFrame.src = url;
	
	gReturnFunc = returnFunc;
	
	if (gHideSelects == true) {
		pwHideSelectBoxes();
	}

	window.setTimeout("pwSetTitle();", 600);
}

var gi = 0;
function pwSetPos(width, height,nPos) {
	if( nPos==null){
		nPos=1;
	}
	if (gPopupIsShown == true) {
		if (width == null || isNaN(width)) {
			width = gPopupContainer.offsetWidth;
		}
		if (height == null) {
			height = gPopupContainer.offsetHeight;
		}
		
		var fullHeight = pwGetViewportHeight();
		var fullWidth = pwGetViewportWidth();
		
		var theBody = document.documentElement;
		
		var scTop = parseInt(theBody.scrollTop,10);
		var scLeft = parseInt(theBody.scrollLeft,10);
				
		gPopupMask.style.height = fullHeight + "px";
		gPopupMask.style.width = fullWidth + "px";
		gPopupMask.style.top = scTop + "px";
		gPopupMask.style.left = scLeft + "px";
		
		window.status = gPopupMask.style.top + " " + gPopupMask.style.left + " " + gi++;
						
		var nTitleBarHeight = parseInt(document.getElementById("popup_TitleBar_div").offsetHeight, 10);
		
		gPopupContainer.style.top = (scTop + ((fullHeight - (height+nTitleBarHeight)) / 2)) + "px";
		
		var nLeftOffset=0;
		switch(nPos){
		case 0: // 靠左
			nLeftOffset=0;	
			break;
		case 1: // 居中
			nLeftOffset=(fullWidth - width) / 2
			break;
		case 2: // 靠右
			nLeftOffset=(fullWidth - width)-25;	
			break;
		default:
			break;
		}
	
		gPopupContainer.style.left =  (scLeft + nLeftOffset) + "px";
	}
}
cmAddEvent(window, "resize", pwSetPos);
//cmAddEvent(window, "scroll", pwSetPos);
window.onscroll = pwSetPos;

function pwHide(callReturnFunc) {
	gPopupIsShown = false;
	pwRestoreTabIndexes();
	if (gPopupMask == null) {
		return;
	}
	gPopupMask.style.display = "none";	
	if (gPopupContainer == null) {
		return;
	}
	gPopFrame.src = '/capital/cmPopWinLoading.html';
	gPopupContainer.style.display = "none";
	if (callReturnFunc == true && gReturnFunc != null) {
		gReturnFunc(window.frames["popup_Frame_iframe"].returnVal);
	}
	if (gHideSelects == true) {
		pwDisplaySelectBoxes();
	}
}

function pwSetTitle() {
	if (window.frames["popup_Frame_iframe"].document.title == null) {
		window.setTimeout("pwSetTitle();", 10);
	} else {
		document.getElementById("popup_Title_div").innerHTML = window.frames["popup_Frame_iframe"].document.title;
	}
}

function pwKeyDownHandler(e) {
    if (gPopupIsShown && e.keyCode == 9)  return false;
}
if (!document.all) {
	document.onkeypress = pwKeyDownHandler;
}

function pwDisableTabIndexes() {
//	if (document.all) {
//		var i = 0;
//		for (var j = 0; j < gTabbableTags.length; j++) {
//			var tagElements = document.getElementsByTagName(gTabbableTags[j]);
//			for (var k = 0 ; k < tagElements.length; k++) {
//				gTabIndexes[i] = tagElements[k].tabIndex;
//				tagElements[k].tabIndex="-1";
//				i++;
//			}
//		}
//	}
}

function pwRestoreTabIndexes() {
	if (document.all) {
		var i = 0;
		for (var j = 0; j < gTabbableTags.length; j++) {
			var tagElements = document.getElementsByTagName(gTabbableTags[j]);
			for (var k = 0 ; k < tagElements.length; k++) {
				tagElements[k].tabIndex = gTabIndexes[i];
				tagElements[k].tabEnabled = true;
				i++;
			}
		}
	}
}

function pwHideSelectBoxes() {
	for(var i = 0; i < document.forms.length; i++) {
		for(var e = 0; e < document.forms[i].length; e++){
			if(document.forms[i].elements[e].tagName == "SELECT") {
				document.forms[i].elements[e].style.visibility="hidden";
			}
		}
	}
}

function pwDisplaySelectBoxes() {
	for(var i = 0; i < document.forms.length; i++) {
		for(var e = 0; e < document.forms[i].length; e++){
			if(document.forms[i].elements[e].tagName == "SELECT") {
			document.forms[i].elements[e].style.visibility="visible";
			}
		}
	}
}