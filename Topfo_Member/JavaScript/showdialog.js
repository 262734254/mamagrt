var boolreturn=null ;
function dialog(){
	var titile = '';
	var width = 200;
	var height = 100;
	var src = "";
	var path = "http://www.91vc.com/images/";
	var sFunc  = '<input id="dialogOk" type="button"  value="确认" onclick="new dialog().reset();" />';
    var sFunc1 = '<input id="dialogCancel" type="button"  value="取消" onclick="new dialog().reset();" />';
	var sClose = '<input type="image" id="dialogBoxClose" onclick="new dialog().reset();" src="' + path + 'close.gif" border="0" width="17" height="17" onmouseover="this.src=\'' + path + 'close.gif\';" onmouseout="this.src=\'' + path + 'close.gif\';" align="absmiddle" />';
	var sBody = '\
		<table id="dialogBodyBox" border="0" align="center" cellpadding="0" cellspacing="0">\
			<tr height="10"><td colspan="4"></td></tr>\
			<tr>\
				<td width="10"></td>\
				<td width="80" align="center" valign="absmiddle"><img id="dialogBoxFace" src="' + path + 'han.gif" /></td>\
				<td id="dialogMsg" style="font-size:12px;color:#000;"></td>\
				<td width="10"></td>\
			</tr>\
			<tr height="10"><td colspan="4" align="center"></td></tr>\
			<tr><td id="dialogFunc" colspan="3" align="center">' + sFunc + '</td>\
			<td id="dialogFunc1"  align="center">' + sFunc1+'</td>\
			</tr>\
			<tr height="10"><td colspan="4" align="center"></td></tr>\
		</table>\
	';
	var sBox = '\
		<table id="dialogBox" width="' + width + '" border="0" cellpadding="0" cellspacing="0" style="border:1px solid #000;display:none;z-index:1000;">\
			<tr height="1" bgcolor="#D6E3EB"><td></td></tr>\
			<tr height="25" bgcolor="#c8d9e4">\
				<td>\
					<table onselectstart="return false;" style="-moz-user-select:none;" width="100%" border="0" cellpadding="0" cellspacing="0">\
						<tr>\
							<td width="6"></td>\
							<td id="dialogBoxTitle" onmousedown="new dialog().moveStart(event, \'dialogBox\')" style="color:#000;cursor:move;font-size:12px;font-weight:bold;">&nbsp;</td>\
							<td id="dialogClose" width="27" align="right" valign="middle">\
								' + sClose + '\
							</td>\
							<td width="6"></td>\
						</tr>\
					</table>\
				</td>\
			</tr>\
			<tr height="2" bgcolor="#E2E2E2"><td></td></tr>\
			<tr id="dialogHeight" style="height:' + height + '">\
				<td id="dialogBody" bgcolor="#ffffff">' + sBody + '</td>\
			</tr>\
		</table>\
		<div id="dialogBoxShadow" style="display:none;z-index:9;"></div>\
	';
	var sBG = '\
		<div id="dialogBoxBG" style="position:absolute;top:0px;left:0px;width:100%;height:100%;"></div>\
			';

	function $(_sId){return document.getElementById(_sId)}
	this.show = function(){
		this.middle('dialogBox');
		this.shadow();		
	}

	this.reset = function(){$('dialogBox').style.display='none';$('dialogBoxBG').style.display='none';$('dialogBoxShadow').style.display = "none";$('dialogBody').innerHTML = sBody;}

	this.reset1 = function(){  $('dialogBox').style.display='none';$('dialogBoxBG').style.display='none';$('dialogBoxShadow').style.display = "none";$('dialogBody').innerHTML = sBody; window.returnValue = true;   }  //alert(true);  window.returnValue = true;
	this.reset2 = function(){  $('dialogBox').style.display='none';$('dialogBoxBG').style.display='none';$('dialogBoxShadow').style.display = "none";$('dialogBody').innerHTML = sBody; window.returnValue = false; return false;   } //alert(false); window.returnValue = false;showfalse();
	
	this.init = function(){
		$('dialogCase') ? $('dialogCase').parentNode.removeChild($('dialogCase')) : function(){};
		var oDiv = document.createElement('span');
		oDiv.id = "dialogCase";
		oDiv.innerHTML = sBG + sBox;

		
		document.body.appendChild(oDiv);

		
	}
	this.button = function(_sId, _sFuc){
		if($(_sId)){
			$(_sId).style.display = '';
			if($(_sId).addEventListener){
				if($(_sId).act){$(_sId).removeEventListener('click', function(){eval($(_sId).act)}, false);}
				$(_sId).act = _sFuc;
				$(_sId).addEventListener('click', function(){eval(_sFuc)}, false);
			}else{
				if($(_sId).act){$(_sId).detachEvent('onclick', function(){eval($(_sId).act)});}
				$(_sId).act = _sFuc;
				$(_sId).attachEvent('onclick', function(){eval(_sFuc)});
			}
		}
	}
	this.shadow = function(){
		var oShadow = $('dialogBoxShadow');
		var oDialog = $('dialogBox');
		oShadow['style']['position'] = "absolute";
		oShadow['style']['background']	= "#000";
		oShadow['style']['display']	= "";
		oShadow['style']['opacity']	= "0.2";
		oShadow['style']['filter'] = "alpha(opacity=20)";
		oShadow['style']['top'] = oDialog.offsetTop + 6;
		oShadow['style']['left'] = oDialog.offsetLeft +6;
		oShadow['style']['width'] = oDialog.offsetWidth;
		oShadow['style']['height'] = oDialog.offsetHeight;
	}

	this.open = function(_sUrl, _sMode){
		this.show();
		if(!_sMode || _sMode == "no" || _sMode == "yes"){
			$("dialogBody").innerHTML = "<iframe width='100%' height='100%' src='" + _sUrl + "' frameborder='0' scrolling='" + _sMode + "'></iframe>";
		}
	}

	





this.event = function(_sMsg, _sClose,_title){




		$('dialogFunc').innerHTML = sFunc;
		$('dialogFunc1').innerHTML = sFunc1;
		$('dialogClose').innerHTML = sClose;
		$('dialogBodyBox') == null ? $('dialogBody').innerHTML = sBody : function(){};
		$('dialogMsg') ? $('dialogMsg').innerHTML = _sMsg  : function(){};

		  if (_title)
	{
			  $('dialogCancel').style.display = 'block';
			  $('dialogBoxClose').style.display = 'none';			 						  
			  $('dialogCancel').attachEvent('onclick', function(){(new dialog().reset2())});
			  $('dialogOk').attachEvent('onclick', function(){(new dialog().reset1())});			  
			
			
		//	if (! window.returnValue);			
		//	event.returnValue = false;		
			
		//	alert('event');		
			  
	}
		  else
	{
			  $('dialogCancel').style.display = 'none';
  	  		  $('dialogBoxClose').style.display = 'block';


	}



	
		this.show();
	}


	



	this.set = function(_oAttr, _sVal){
		var oShadow = $('dialogBoxShadow');
		var oDialog = $('dialogBox');
		var oHeight = $('dialogHeight');

		if(_sVal != ''){
			switch(_oAttr){
				case 'title':
					$('dialogBoxTitle').innerHTML = _sVal;
					title = _sVal;
					break;
				case 'width':
					oDialog['style']['width'] = _sVal;
					width = _sVal;
					break;
				case 'height':
					oHeight['style']['height'] = _sVal;
					height = _sVal;
					break;
				case 'src':
					if(parseInt(_sVal) > 0){
						$('dialogBoxFace') ? $('dialogBoxFace').src = path + _sVal + '.gif' : function(){};
					}else{
						$('dialogBoxFace') ? $('dialogBoxFace').src = _sVal : function(){};
					}
					src = _sVal;
					break;
			}
		}
		this.middle('dialogBox');
		oShadow['style']['top'] = oDialog.offsetTop + 6;
		oShadow['style']['left'] = oDialog.offsetLeft + 6;
		oShadow['style']['width'] = oDialog.offsetWidth;
		oShadow['style']['height'] = oDialog.offsetHeight;
	}

//使用鼠标移动窗口
	this.moveStart = function (event, _sId){
		var oObj = $(_sId);
		oObj.onmousemove = mousemove;
		oObj.onmouseup = mouseup;
		oObj.setCapture ? oObj.setCapture() : function(){};
		oEvent = window.event ? window.event : event;
		var dragData = {x : oEvent.clientX, y : oEvent.clientY};
		var backData = {x : parseInt(oObj.style.top), y : parseInt(oObj.style.left)};

		function mousemove(){
			var oEvent = window.event ? window.event : event;
			var iLeft = oEvent.clientX - dragData["x"] + parseInt(oObj.style.left);
			var iTop = oEvent.clientY - dragData["y"] + parseInt(oObj.style.top);
			oObj.style.left = iLeft;
			oObj.style.top = iTop;
			$('dialogBoxShadow').style.left = iLeft + 6;
			$('dialogBoxShadow').style.top = iTop + 6;
			dragData = {x: oEvent.clientX, y: oEvent.clientY};			
		}

		function mouseup(){
			var oEvent = window.event ? window.event : event;
			oObj.onmousemove = null;
			oObj.onmouseup = null;
			if(oEvent.clientX < 1 || oEvent.clientY < 1 || oEvent.clientX > document.body.clientWidth || oEvent.clientY > document.body.clientHeight){
				oObj.style.left = backData.y;
				oObj.style.top = backData.x;
				$('dialogBoxShadow').style.left = backData.y + 6;
				$('dialogBoxShadow').style.top = backData.x + 6;
			}
			oObj.releaseCapture ? oObj.releaseCapture() : function(){};
		}
	}
	
	//窗口显示位置
	this.middle = function(_sId){
		var sClientWidth = parent ? parent.document.documentElement.clientWidth:document.documentElement.clientWidth;//parent ? parent.document.body.clientWidth : document.body.clientWidth;
		var sClientHeight = parent ?parent.document.documentElement.clientHeight:document.documentElement.clientHeight;//parent ? parent.document.body.clientHeight : document.body.clientHeight;
		var sScrollTop = parent ?parent.document.documentElement.scrollTop:document.documentElement.scrollTop;//parent ? parent.document.body.scrollTop : document.body.scrollTop;
		document.getElementById(_sId)['style']['display'] = '';
		document.getElementById(_sId)['style']['position'] = "absolute";
		document.getElementById(_sId)['style']['left'] = (document.body.clientWidth / 2) - (document.getElementById(_sId).offsetWidth / 2);
		var sTop = 80+(sClientHeight / 2 + sScrollTop) - (document.getElementById(_sId).offsetHeight / 2) - 150;
		document.getElementById(_sId)['style']['top'] = sTop > 0 ? sTop : (sClientHeight / 2 + sScrollTop) - (document.getElementById(_sId).offsetHeight / 2);
	}
}

/*function Alert(msg)
{
	alert(msg);
}
*/
function Alert(msg)
{
    var click = click ? click : ' ';
    var icon = icon ? icon : '';
    var title = title ? title : '系统提示信息';
    switch (icon)
    {    
    case '':
        icon = 'http://www.91vc.com/images/han.gif';
        break;
    }

    dg=new dialog();
    dg.init();
    dg.set('src', icon);
    dg.set('title', title);
    dg.event(msg,click);
}


function Alert(msg,icon)
{
    var click = click ? click : ' ';
    var icon = icon ? icon : '';
    var title = title ? title : '系统提示信息';
    switch (icon)
    {   
    
    case '1':    
       icon = 'http://www.91vc.com/images/1.gif'; 
    case '2':
       icon = 'http://www.91vc.com/images/2.gif'; 
    case '3':
      icon = 'http://www.91vc.com/images/3.gif'; 
    case '4':
       icon = 'http://www.91vc.com/images/4.gif'; 
       
       
    case '':
       icon = 'http://www.91vc.com/images/han.gif';
       break;
    }

    dg=new dialog();
    dg.init();
    dg.set('src', icon);
    dg.set('title', title);
    dg.event(msg,click);
}


function Alert(msg,icon,title)
{
    var click = click ? click : ' ';
    icon = icon ? icon : '';
    title = title ? title : '温馨提示';
    switch (icon)
    {   
    
    case '1':    
       icon = 'http://www.91vc.com/images/1.gif'; 
    case '2':
       icon = 'http://www.91vc.com/images/2.gif'; 
    case '3':
      icon = 'http://www.91vc.com/images/3.gif'; 
    case '4':
       icon = 'http://www.91vc.com/images/4.gif'; 
       
       
    case '':
       icon = 'http://www.91vc.com/images/han.gif';
       break;
    }

    dg=new dialog();
    dg.init();
    dg.set('src', icon);
    dg.set('title', title);
    dg.event(msg,click);
}



function Confirm(msg)
{
   var click = click ? click : ' ';
   var icon = icon ? icon : '';
var   title =  '系统提示信息';
    switch (icon)
    {
    
    
    
    case '':
        icon = 'http://www.91vc.com/images/han.gif';
        break;
    }

    dg=new dialog();
    dg.init();
    dg.set('src', icon);
    dg.set('title', title); 
	dg.event(msg,'',click);
	
	



	
	
}










