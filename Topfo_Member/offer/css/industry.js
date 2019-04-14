//隐藏元素
function HideElement(strElementTagName){
	try{
		for(i=0;i<window.document.all.tags(strElementTagName).length; i++){
			var objTemp = window.document.all.tags(strElementTagName)[i];
			objTemp.style.visibility = "hidden";
		}
	}catch(e){
		alert(e.message);
	}
}

//显示元素
function ShowElement(strElementTagName){
	try{
		for(i=0;i<window.document.all.tags(strElementTagName).length; i++){
			var objTemp = window.document.all.tags(strElementTagName)[i];
			objTemp.style.visibility = "visible";
		}
	}catch(e){
		alert(e.message);
	}
}

function hideElementAll(){
	HideElement("SELECT");
	HideElement("OBJECT");
	HideElement("IFRAME");
}

function showElementAll(){
	ShowElement("SELECT");
	ShowElement("OBJECT");
	ShowElement("IFRAME");
}

//元素插入另一个元素之后
function insertAfter(newElement, targetElement) 
{ 
    var parent = targetElement.parentNode; 
    if(parent.lastChild == targetElement)  
    { 
        parent.appendChild(newElement); 
    }  
    else 
    { 
        parent.insertBefore(newElement, targetElement.nextSibling); 
    } 
}
//删除一个元素
function deletElement(obj) 
{ 
    if(obj == null)
        return;
    var parent = obj.parentNode; 
    parent.removeChild(obj);
}
//获取滚动条的高度
function getPageScroll(){
	var yScroll;
	if (self.pageYOffset) {
		yScroll = self.pageYOffset;
	} else if (document.documentElement && document.documentElement.scrollTop){	 // Explorer 6 Strict
		yScroll = document.documentElement.scrollTop;
	} else if (document.body) {// all other Explorers
		yScroll = document.body.scrollTop;
	}
	arrayPageScroll = new Array('',yScroll) 
	return arrayPageScroll;
}
//获取页面实际大小
function getPageSize(){ 
     
    var xScroll, yScroll; 
    
    if (window.innerHeight && window.scrollMaxY) {    
        xScroll = document.body.scrollWidth; 
        yScroll = window.innerHeight + window.scrollMaxY; 
    } else if (document.body.scrollHeight > document.body.offsetHeight){ // all but Explorer Mac 
        xScroll = document.body.scrollWidth; 
        yScroll = document.body.scrollHeight; 
    } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari 
        xScroll = document.body.offsetWidth; 
        yScroll = document.body.offsetHeight; 
    } 
    
    var windowWidth, windowHeight; 
    if (self.innerHeight) {    // all except Explorer 
        windowWidth = self.innerWidth; 
        windowHeight = self.innerHeight; 
    } else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode 
        windowWidth = document.documentElement.clientWidth; 
        windowHeight = document.documentElement.clientHeight; 
    } else if (document.body) { // other Explorers 
        windowWidth = document.body.clientWidth; 
        windowHeight = document.body.clientHeight; 
    }    
    
    // for small pages with total height less then height of the viewport 
    if(yScroll < windowHeight){ 
        pageHeight = windowHeight; 
    } else {  
        pageHeight = yScroll; 
    } 
  
    // for small pages with total width less then width of the viewport 
    if(xScroll < windowWidth){    
        pageWidth = windowWidth; 
    } else { 
        pageWidth = xScroll; 
    } 
  
    arrayPageSize = new Array(pageWidth,pageHeight,windowWidth,windowHeight)  
    return arrayPageSize; 
}
//关闭弹出层
function closeLayer(obj)
{
	obj.style.display = "none";
	document.getElementById("bodybg1").style.display = "none";
	return false;
}
//拖动函数
function mousedown(e)
{
	var obj = document.getElementById("popupIndustry");
	var e = window.event ? window.event : e;
	obj.startX = e.clientX - obj.offsetLeft;
	obj.startY = e.clientY - obj.offsetTop;
	
	document.onmousemove = mousemove;
	var temp = document.attachEvent ? document.attachEvent("onmouseup",mouseup) : document.addEventListener("mouseup",mouseup,"");
}
function mousemove(e)
{
	var obj = document.getElementById("popupIndustry");
	var e = window.event ? window.event : e;
	with(obj.style)
	{
		left = e.clientX - obj.startX + "px";
		top = e.clientY - obj.startY + "px";
	}
}
function mouseup(e)
{
	document.onmousemove = "";
	var temp = document.detachEvent ? document.detachEvent("onmouseup",mouseup) : document.addEventListener("mouseup",mouseup,"");
}
function openIndustryLayer(){
    hideElementAll();
    //创建一个div元素
	var _popupDiv = document.createElement("div");
	
	//给这个元素设置属性与样式
	_popupDiv.setAttribute("id","popupIndustry")
	_popupDiv.style.border = "1px solid #ccc";
	_popupDiv.style.width = "370px";
	_popupDiv.style.height = "180px";
	_popupDiv.style.background = "#fff";
	_popupDiv.style.zIndex = 999;
	_popupDiv.style.position = "absolute";
	
	//让弹出层在页面中垂直左右居中
	var arrayPageSize = getPageSize();
	var arrayPageScroll = getPageScroll();
	
	_popupDiv.style.top = (arrayPageScroll[1] + ((arrayPageSize[3] - 35 - 180) / 2) + 'px') ;
	_popupDiv.style.left = (((arrayPageSize[0] - 20 - 370) / 2) + 'px');
	
	//创建背景层
	var _bodyBack = document.createElement("div");
	_bodyBack.setAttribute("id","bodybg1")
	_bodyBack.style.width = arrayPageSize[0];
	_bodyBack.style.height = (arrayPageSize[1] + 35 + 'px');
	_bodyBack.style.zIndex = 998;
	_bodyBack.style.position = "absolute";
	_bodyBack.style.top = 0;
	_bodyBack.style.left = 0;
	
	_bodyBack.style.filter = "alpha(opacity=20)";
	_bodyBack.style.opacity = 0.2;
	_bodyBack.style.background = "#000";
	
	//收工插入到目标元素之后
	var mybody = document.getElementById("selectindustry");
	insertAfter(_popupDiv,mybody);
	insertAfter(_bodyBack,mybody);
	
	//弹出层内容
	_popupDiv.innerHTML = indHTML();
	init_check();
}

var isIE = /msie/.test(navigator.userAgent.toLowerCase()); 
var containerID = "container";
var floatID = "float_lay";

function indHTML(){
    //文字
	var TITLE = "请选择行业 你最多能选择 5 项";
	var CLOSE = '<span style="cursor:pointer;" onclick="javascript:closeLayer(this.parentNode.parentNode.parentNode.parentNode);write_result();">[确定]</span>';
	
	//图片地址
	var TITLEBG = "http://images.topfo.com/common/title_bg.gif";
	var ICN = "http://images.topfo.com/common/icn.gif";
	var htmlDiv = '';
	htmlDiv += '<div style="width:100%;font-size:12px;">';
	
	//头部
	htmlDiv += '<div style="background:url('+TITLEBG+') repeat-x;height:40px;color:#fff;cursor:move;" onmousedown="mousedown(arguments[0])">';
	htmlDiv += '<span style="line-height:30px;padding-left:22px;float:left;background:url('+ ICN +') no-repeat 6px 8px;">';
	htmlDiv += TITLE;
	htmlDiv += '</span>';
	htmlDiv += '<span style="float:right;padding-right:12px;line-height:30px;">';
	htmlDiv += CLOSE;
	htmlDiv += '</span>';
	htmlDiv += '</div>';
	//END头部
	
	//内容部分
	htmlDiv += '<div id="container" style="width:370px;height:180px;" class="divcheck"></div>';
	htmlDiv += '<div id="float_lay"></div>';
	//END内容部分
	htmlDiv += '</div>';
	return htmlDiv;
}


function init_check(){
	_container = document.getElementById(containerID);
	_float = document.getElementById(floatID);
	_float.onmouseover = function(){this.style.display = 'block';}
	_float.onmouseout = function(){this.style.display = 'none';}
	
	_selectIndustry = document.createElement("div");
	_selectIndustry.id = "select_Industry";
	_selectIndustry.style.display = 'none';
	if(document.getElementById("result").getElementsByTagName("input").length == 0){
	    _selectIndustry.innerHTML = '';
	}
	else{
	    _selectIndustry.innerHTML = document.getElementById("result").innerHTML;
	    var _input_s = _selectIndustry.getElementsByTagName("input");
    	
	    for (var i = 0 ; i < _input_s.length; i++){
		    _input_s[i].checked = true;
		    _input_s[i].onclick = function(){
			    var _input_m = _allIndustry.getElementsByTagName("input");
    			
			    for(var j=0; j<_input_m.length; j++)
				    if(_input_m[j].value == this.value)
					    _input_m[j].checked = false;
			    _selectIndustry.removeChild(this.parentNode);
		    }
	    }
	}
	
	_allIndustry = document.createElement("div");
	_allIndustry.id = "all_Industry";
	
	_container.appendChild(_allIndustry);
	_container.appendChild(_selectIndustry);
	
	AjaxMethod.GetIndustryList(IndustryListCall,_allIndustry);
}

function IndustryListCall(response,obj){
    if(response.value == null)
        return ;
//    alert(response.value);
    var indArray = response.value.split(",");
    
    var input  = [],span = [];
    for(var i=0;i<indArray.length;i++)
    {
        var ary1 = indArray[i].toString().split("|");
        try
        {
            input[i] = document.createElement("input");
		    input[i].type = "checkbox";
		    input[i].value = ary1[0].toString();
		    span[i] = document.createElement("span");
		    span[i].appendChild(input[i]);
		    span[i].appendChild(document.createTextNode(ary1[1].toString()));
		    document.getElementById("all_Industry").appendChild(span[i]);
        }
        catch(e){
            alert(e.message);
        }
    }
    check_in_select();
    init_check_event();
}

//allIndustry中的checkbox的事件相应
function init_check_event(){
	var _input_m = _allIndustry.getElementsByTagName("input");
	for(var i=0 ; i < _input_m.length; i++)
		_input_m[i].onclick = function(){
			if(this.checked && check_num(this)){
				var span = this.parentNode.cloneNode(true);
				_selectIndustry.appendChild(span);
				change_float_check(this.value);
				if(isIE) select_true();
				//已选中的checkbox的事件相应
				span.getElementsByTagName("input")[0].onclick = function(){
					for(var j=0; j<_input_m.length; j++)
						if(_input_m[j].value == this.value)
							_input_m[j].checked = false;
					change_float_check(this.value);
					_selectIndustry.removeChild(this.parentNode);
				}
			} else {
				var _input_s = _selectIndustry.getElementsByTagName("input");
				for (var j=0; j < _input_s.length; j++){
					if(_input_s[j].value == this.value)
						_selectIndustry.removeChild(_input_s[j].parentNode);
				}
				change_float_check(this.value);
			}
		}
}

function check_in_select(value){
	var _input_s = _selectIndustry.getElementsByTagName("input");
	var _input_a = _allIndustry.getElementsByTagName("input");
	for (var i = 0 ; i < _input_s.length ; i++){
		for (var l=0 ; l < _input_a.length ; l++){
			if(_input_a[l].value == _input_s[i].value)
				_input_a[l].checked = true;
		}
	}
}

function check_num(obj){
	var _input_s = _selectIndustry.getElementsByTagName("input");
	if(_input_s.length < 5)	return true;
	else{
		obj.checked = false;
		alert("最多只能选择5个选项");
		return false;
	}
}

function select_true(){
	var _input_s = _selectIndustry.getElementsByTagName("input");
	for (var i = 0 ; i < _input_s.length; i++)
		_input_s[i].checked = true;
}
function change_float_check(value){
	var _input_f = _float.getElementsByTagName("input");
	for (var i = 0 ; i < _input_f.length; i++){
		if(_input_f[i].value == value)
			if(!_input_f[i].checked)
				_input_f[i].checked = true;
			else
				_input_f[i].checked = false;
	}
}

function setindustrysubmit()
{
    var _result = document.getElementById("result");
   	var _resulthide = document.getElementById("<%=hideindustry.ClientID %>");
   	_resulthide.value = "";
   	var _result_input = _result.getElementsByTagName("input");
   	for (var i = 0 ; i < _result_input.length; i++){
		    _resulthide.value += _result_input[i].value + ",";
	}
	checkIndustry();
	//alert(document.getElementById("<%=hideindustry.ClientID %>").value);
}

function write_result(){
	var _result = document.getElementById("result");
	_result.innerHTML = _selectIndustry.innerHTML;
	var _result_input = _result.getElementsByTagName("input");

	for (var i = 0 ; i < _result_input.length; i++){
		_result_input[i].checked = true;
		_result_input[i].onclick = function(){
			_result.removeChild(this.parentNode);
			setindustrysubmit();
		}
    }
	setindustrysubmit();
	showElementAll();
	deletElement(document.getElementById("popupIndustry"));
	deletElement(document.getElementById("bodybg1"));
}

                    <input id="selectindustry" onclick="openIndustryLayer()" type="button" value="选择行业" class='btn2'/>
                    <span id="spIndustry"></span>
                    <div id="result"></div>
                    <input type="hidden" id="hideindustry" onchange="JavaScrpit:checkIndustry();" runat="server" />