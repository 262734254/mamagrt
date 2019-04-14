<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_upload_file.aspx.cs" Inherits="Member_p_upload_file" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>资料上传</title>
    <link href="../css/test.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript">
    var ALIBABA_SERVER_URL="http://china.alibaba.com";
	var IMG_SERVER_URL="http://img.china.alibaba.com";
</script>

    <script type="text/javascript" language="javascript">
    function showEncrypt(obj,id)
    {
        if(obj.checked == true)
            document.getElementById(id).style.display = "";
        else
            document.getElementById(id).style.display = "none";
    }
    
    var infoboxOkClass		= "notetrue";
	var infoboxWarningClass	= "notetrue";
	var infoboxErrorClass	= "noteawoke";
	var infoboxHintClass	= "note";
	//default classes for input field
	var inputWarningClass	= "note";
	var inputErrorClass		= "noteawoke";
	var inputOkClass		= "notetrue";
	var inputNormalClass	= "note";
	/////////////////////////////////////////////////////////////
	//                Initialize Form
	/////////////////////////////////////////////////////////////
	document.onkeydown=function(evnt){
		if(isIE()&&window.event.keyCode==13){
			$("Submit").focus();
		}
	}
    
    function initForm(){	
		//initialize form UI and add triggers
		var infobox;
		var x = document.getElementById("fileUpload");
		if(!x) return;
		var y = x.getElementsByTagName("input");
		for (var i=0;i<y.length;i++){
			if(y[i].type == 'text' || y[i].type == 'password'){
			initStatus(y[i],true);
			setFiledWidth(y[i]);
			y[i].onfocus	= getFocus;
			y[i].onblur		= lostFocus;
    		}
	    }
	}
	
	function setFiledWidth(obj){
    	//obj.style.width=(19/3)*obj.size+11;
	}
	
	function initStatus(obj,isInput){
    	if(isInput){
        	if(isRequired(obj)) showStatus(obj,"Warning");
        	else showStatus(obj,"Normal");
    	}
    	var infobox = getInfobox(obj);
    	var errorCode = getInitStatus(obj);
    	if(infobox){
        	if(!errorCode || errorCode == 0){
            	infobox.className	= infoboxHintClass;
            	infobox.innerHTML	= getErrorMsg(obj,0);
            	//alert(infobox.innerHTML);
        	}
        	if(errorCode >0){
            	infobox.className	= infoboxErrorClass;
            	infobox.innerHTML	= getErrorMsg(obj,errorCode);
        	}
    	}	
   }
   
   function showStatus(obj,stat)
    	//Show the status of user currently inputting field
    	//3 Statuses: Warning|Error|Ok
    	{
        	switch(stat){
        	   case "Warning":
        	      obj.className = inputWarningClass;
        	      break;
        	   case "Error":
        	      obj.className = inputErrorClass;
        	      break;
        	   case "Ok":
        	      obj.className = inputOkClass;
        	      break;
        	   default:
        	      obj.className = inputNormalClass;
        	      break;
    	}
	}
	
	function checkByteLength(str,minlen,maxlen) {
		if (str == null) return false;
		var l = str.length;
		var blen = 0;
		for(i=0; i<l; i++) {
			if ((str.charCodeAt(i) & 0xff00) != 0) {
				blen ++;
			}
			blen ++;
		}
		if (blen > maxlen || blen < minlen) {
			return false;
		}
		return true;
	}      
   
   function getInitStatus(obj){
    	if(obj.id){
        	if(eval(obj.id).s || eval(obj.id).s==0 ) return eval(obj.id).s;
	    }
	    return;
	}
    
    function formEle(required,datatype,parameter,infobox,errormsg,combine,status){
    	this.r	= required;	
    	this.d	= datatype;
    	this.p	= parameter;
    	this.i	= infobox;
    	this.e	= errormsg;
    	this.c = combine;
    	this.s = status;
	} 
	
	function isRequired(obj){
    	//alert((obj.id).r);
    	if(obj.id){
        	if(eval(obj.id).r) return eval(obj.id).r;
	    }
	    return false;
	}
	function isCombine(obj){
    	if(obj.id){
    	    if(eval(obj.id).c) return eval(obj.id).c;
    	}
    	return false;
	}
	function getDatatype(obj){
    	if(obj.id){
        	if(eval(obj.id).d) return eval(obj.id).d;
    	}
    	return false;
	}
	function getInfobox(obj){
    	//alert(obj.id);
    	if(obj.id){
        	if(eval(obj.id).i && document.getElementById(eval(obj.id).i)) return document.getElementById(eval(obj.id).i);
    	}
    	return;
	}
	function getErrorMsg(obj,errorCode){
    	if(obj.id){
        	if(eval(obj.id).e[errorCode]) return eval(obj.id).e[errorCode];
    	}
    	return;
	}
	function getHintMsg(obj){
    	if(obj.id){
        	if(eval(obj.id).e[0]) return eval(obj.id).e[0];
    	}
    	return;
	}
	function getInitStatus(obj){
    	if(obj.id){
        	if(eval(obj.id).s || eval(obj.id).s==0 ) return eval(obj.id).s;
	    }
	    return;
	}
	function getAttrName(str){
    	var s=str.split("=");
    	return s[0];
	}
	function getAttrValue(str){
    	var s=str.split("=");
    	return s[1];
	}
	function getAttrValueByName(obj,str){
    	var para;
    	if(obj.id){
        	if(eval(obj.id).p) para=eval(obj.id).p;
        	else return;
        	}else{
        	return;
    	}
    	var s = para.split(",");
    	for(var i=0;i<s.length;i++){
    		if(getAttrName(s[i]) == str){
        		if(getAttrValue(s[i]))
        		return getAttrValue(s[i]);
        		else
        		return;
    		}
    	}
    	return;
	}
	
	function validateValue(obj){
    	//trim
    	var patn = /(^\s)|(\s$)/;
    	//if(patn.test(obj.value)) obj.value = obj.value.trim();
    	//switcher
    	var errorCode = -1;
    	switch(getDatatype(obj)){
        	case "password":
            	errorCode = validatePassword(obj);
            	break;
        	case "confirm_password":
            	errorCode = validateSafePassword(obj);
            	break;
        	default:
            	errorCode = -1;
            	break;
    	}
    	return errorCode;
	}
	
	function isIE() {
    	if(document.all) return true;
    	return false;
	}
	
	function showInfo(obj,errorCode,forcible)
	{
	   var infobox = getInfobox(obj);
	   if(infobox){
	       if(infobox.className != infoboxErrorClass || forcible){
	            if(errorCode == 0 ){
                	//alert(infobox.innerHTML);
                	infobox.innerHTML	= getErrorMsg(obj,errorCode);
                	if(infobox.innerHTML != '&nbsp;'){
                  	   infobox.className	= infoboxWarningClass;
	                }
	            }
                if(errorCode >0){
                    infobox.className	= infoboxErrorClass;
                    infobox.innerHTML	= getErrorMsg(obj,errorCode);
                }
            	if(errorCode <0){
            		infobox.className	= infoboxHintClass;
            	}
		    }
	    }	
    }
    
	
	//去掉打勾的
	function removeDraw(obj){
	  if(obj.id && eval(obj.id).c && document.getElementById(eval(obj.id).c)){
    	if(document.getElementById(eval(obj.id).c).innerHTML.indexOf("img") > 0 ){
        	var start =  document.getElementById(eval(obj.id).c).innerHTML.indexOf('>');
        	var end = document.getElementById(eval(obj.id).c).innerHTML.length;
        	document.getElementById(eval(obj.id).c).innerHTML = document.getElementById(eval(obj.id).c).innerHTML.substring(start +1,end);
        }
      }
	}
	//打上勾
	function addDraw(obj){
	     if(eval(obj.id).c && document.getElementById(eval(obj.id).c)){
             if(document.getElementById(eval(obj.id).c).innerHTML.indexOf("img") < 0 ){ 
                document.getElementById(eval(obj.id).c).innerHTML = "&nbsp;<img src=\""+IMG_SERVER_URL+"/images/cn/member/icon_right_19x19.gif\" width=\"19\" height=\"16\" align=\"absmiddle\"> " + document.getElementById(eval(obj.id).c).innerHTML;
             }
		 }
	}
	
	function validatePassword(obj){
    	var str = obj.value;
    	if(!checkByteLength(str,6,20)) return 1;															
    	var patn1 =   /^[a-zA-Z0-9_]+$/;
    	if(!patn1.test(str) ) return 1;
    	return 0; 
	}
	
	function validateSafePassword(obj){
    	var str = obj.value;
    	if(str != document.getElementById("password").value) return 1;
    	return 0;
	}
	
	function getFocus(evnt)
	{
    	var obj;
    	if (isIE()) {
        	obj = event.srcElement;
    	}else {
        	obj = evnt.target;
    	}
    	showInfo(obj,0);
	}
	
	function lostFocus(evnt)
	{
    	var obj;
    	if (isIE()) {
    	   obj = event.srcElement;
    	}else {
    	   obj = evnt.target;
	    }		
	    showInfo(obj,-1);
    	if(obj.value == ''){
    	      removeDraw(obj);
			  //当密码为空时，确认密码也为空
    	      if(obj.id && eval(obj.id).c && document.getElementById(eval(obj.id).c)){
        	      var infobox = getInfobox(obj);
        	      var errorCode = getInitStatus(obj);
                  if(infobox){
                    	if(infobox.className == infoboxErrorClass){
                           	infobox.className	= "note";
                            infobox.innerHTML	= getErrorMsg(obj,0);				
        	            }
        	      }
    	      }
    	     return;
	     }
				
    	errorCode = validateValue(obj);
    	//alert(errorCode);
    	if(errorCode == 0){

            if(obj.id == 'password'){
		        initStatus(document.getElementById('confirm_password'),true);
             	document.getElementById('confirm_password').value="";
				removeDraw(document.getElementById('confirm_password'));
            	removeDraw(obj);
		    }

        	if(obj.id){
        	    addDraw(obj);
           		document.getElementById(eval(obj.id).i).className = 'note';
           		document.getElementById(eval(obj.id).i).innerHTML = '填写正确。'
        	}
       	}
		if(errorCode >= 1){
    		if(obj.id){
        		//alert(eval(obj.id).i);
        		if(eval(obj.id).i && document.getElementById(eval(obj.id).i)) 
        		document.getElementById(eval(obj.id).i).className = 'noteawoke';
        		document.getElementById(eval(
					obj.id).i).innerHTML = (eval(obj.id).e)[errorCode];
    		}
			removeDraw(obj);
		}
		if(errorCode < 0 && eval(obj.id)){
			removeDraw(obj);
			if(obj.id){
    			//alert(eval(obj.id).i);
    			if(eval(obj.id).i && document.getElementById(eval(obj.id).i) ) 
    			document.getElementById(eval(obj.id).i).className = 'note';
    			document.getElementById(eval(obj.id).i).innerHTML = (eval(obj.id).e)[0];
			}
	    }
    }
    
    function tot(mobnumber){                        
    	while(mobnumber.indexOf("０")!=-1){           
    		mobnumber = mobnumber.replace("０","0");        
    	}                                               
    	while(mobnumber.indexOf("１")!=-1){             
	    	mobnumber = mobnumber.replace("１","1");}       
    	while(mobnumber.indexOf("２")!=-1){             
	    	mobnumber = mobnumber.replace("２","2");}       
    	while(mobnumber.indexOf("３")!=-1){             
	    	mobnumber = mobnumber.replace("３","3");}       
    	while(mobnumber.indexOf("４")!=-1){             
	    	mobnumber = mobnumber.replace("４","4");}       
    	while(mobnumber.indexOf("５")!=-1){             
	    	mobnumber = mobnumber.replace("５","5");}       
    	while(mobnumber.indexOf("６")!=-1){             
	    	mobnumber = mobnumber.replace("６","6");}       
    	while(mobnumber.indexOf("７")!=-1){             
	    	mobnumber = mobnumber.replace("７","7");}       
    	while(mobnumber.indexOf("８")!=-1){             
	    	mobnumber = mobnumber.replace("８","8");}       
    	while(mobnumber.indexOf("９")!=-1){             
	    	mobnumber = mobnumber.replace("９","9");}       
    	return mobnumber;                               
	}
	
		function validateAll(formObj){
    	var obj,infobox,pass;
    	pass = true;
    	var x = formObj;
    	if(!x) return;
    	var y = x.getElementsByTagName("input");
    	for (var i=0;i<y.length;i++){
    		if(y[i].type != 'hidden' && y[i].type != 'file'&& y[i].type!='submit'){
        		obj = y[i];	
        		//obj.value = obj.value.trim();
                if(obj.type != 'checkbox')
                    infobox = getInfobox(y[i]);
                
    	    	
    		    if(obj.type == 'text' || obj.type == 'password'){
            		if(!isRequired(obj) && obj.value == ""){
    		            continue;
    		        }
            		if(isRequired(obj) && obj.value == ""){
                		pass = false;
                		obj.parentNode.focus();//提交出错时定位
                		showStatus(obj,"Error");
                		infobox.className	= infoboxErrorClass;
                		infobox.innerHTML	= "<h1>"+requireErrorInfo + getErrorMsg(obj,0) + "<\/h1>";
						removeDraw(obj);
                		//if(isCombine(obj)) break;
                		continue;
            		}
            		if(validateValue(obj)>0){
                		pass = false;
                		obj.parentNode.focus();//提交出错时定位
                		showStatus(obj,"Error");
                		showInfo(obj,validateValue(obj),true);
						removeDraw(obj);
                		//if(isCombine(obj)) break;
                		continue;
            		}
        		
            		if(obj.id == 'password'){
            			//if(validatePasswordSafe() > 0 && validateValue(obj)== 0){
            			if(validateValue(obj)!= 0){
            				pass = false;
							removeDraw(obj);
            				showInfo(obj,2,true);
							document.getElementById(eval(obj.id).i).focus();
            				continue;
            			}
            		 }
        		
            		if(validateValue(obj)==0){
                		//showStatus(obj,"Ok");
                		//infobox.className	= infoboxHintClass;
                		//infobox.innerHTML	= validatedInfo;
                		continue;
            		}
    		    }
    	    }
        }//for

		return pass;
	}
	function isNumberContinue(str){
        var patn1 =   /^[0-9_]+$/;
        var ascendNumber=0;
        var descendNumber=0;
        
        for (var i = 1; i < str.length; i++) {
            if (str.charAt(i).charCodeAt() != (str.charAt(i-1).charCodeAt() + 1)) {
                ascendNumber = 1;
                break;
            }
        }	
        
        for (i = 0; i < (str.length - 1); i++) {
            if (str.charAt(i).charCodeAt() != (str.charAt(i+1).charCodeAt() + 1)) {
                descendNumber = 1;
                break;
            }
        }
        if(descendNumber == 0 || ascendNumber == 0){
            return 1;
        }else{
            return 0;
        }
    }

    function isSameLetter(str){
        var sameNumberFlag = 1;
        var patn1 =   /^[0-9]+$/;
        if(patn1.test(str) ){
            for (var i = 0; i < str.length; i++) {
              if (str.charAt(0) != str.charAt(i)) {
                  sameNumberFlag = 0;
                  break;
              }
            }          
        } else {
           for (var i = 0; i < str.length; i++) {
              if (str.charAt(0) != str.charAt(i)) {
                  sameNumberFlag = 0;
        	      break;
               }
            }
        }
        return sameNumberFlag;
    }

	function validatePasswordSafe(){
    	if(isNumberContinue(document.getElementById("password").value) == 1){
    	   return 1;
    	}
    	
    	if(isSameLetter(document.getElementById("password").value) == 1){
        	return 1;
    	}
    	return 0;
	}
    
    function submitForm(obj) {
    	if(document.getElementById('cbxIsEncrypt').checked == false)
    	    return true;
    	var ret = validateAll(obj);
    	if (ret == true) {
    		if (document.form.Submit) {
    		   document.form.Submit.disabled = true;
    		}
    	}
    	return ret;
    }

	document.ondragstart = function(){
    	return false;
	}
	
	var validatedInfo		= "填写正确。";
	var requireErrorInfo	= "<span class=\"R\">此项为必填项。</span><br \/>";
	var msgInfo	= new Array();
	
	msgInfo[1]				= new Array('密码由6-20个英文字母(区分大小写)或数字组成，建议采用易记、难猜的英文数字组合。',
	'<h1><span class=\"R\">您设置的密码有误。<\/span>密码由6-20个英文字母(区分大小写)或数字组成<\/h1>','<h1>您设置的密码不够安全，请您重新设置密码！','',validatedInfo);
	var password	 		= new formEle(true,"password",null,"password_info",msgInfo[1],"password_info_check");
	
	msgInfo[2]				= new Array('请再输入一遍您上面填写的密码。','<h1><span class=\"R\">两次输入的密码不一致！<\/span>请再输入一遍您上面填写的密码。<\/h1>');
	var confirm_password	= new formEle(true,"confirm_password","sameas=password","confirm_password_info",msgInfo[2],"confirm_password_info_check");
	
	
	var parentIframe = "<%=this.ParentIframe %>";
	
	function resize()
	{
	    parent.document.all(parentIframe).style.height=document.body.scrollHeight; 
        parent.document.all(parentIframe).style.width=document.body.scrollWidth; 
    }
    
    window.onresize = resize;
    </script>

</head>
<body>
    <form id="form" onsubmit="return submitForm(this);" runat="server">
        <div id="fileUpload">
            <table width="600" border="0" align="center" cellpadding="5" cellspacing="0" class="cshibiank">
                <tr>
                    <td style="width: 500px;" align="left">
                        <div style="padding-left: 60px; padding-top:10px;">
                            <input type="file" id="fileuploadothers" runat="server" style="width: 345px; height: 20px" /></div>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <div style="padding-left: 60px;">
                                <input type="checkbox" id="cbxIsEncrypt" name="cbxIsEncrypt" onclick="showEncrypt(this,'IsEncrypt');" />
                            我要加密 <a href="#" class="lanlink">什么是加密？</a></div>
                    </td>
                </tr>
                <tr id="IsEncrypt" style="display: none;">
                    <td align="left">
                        <div class="content">
                            <div id="name">
                                <div class="text" id="password_info_check">
                                    &nbsp;密码</div>
                                <div class="redstar">
                                    *</div>
                            </div>
                            <div class="input">
                                <input class="note" id="password" style="width: 180px" type="password" size="35"
                                    value="" /></div>
                            <div class="note" id="password_info">
                            </div>
                            <div class="HackBox">
                            </div>
                        </div>
                        <div class="content">
                            <div id="name">
                                <div class="text" id="confirm_password_info_check">
                                    &nbsp;重复输入密码</div>
                                <div class="redstar">
                                    *</div>
                            </div>
                            <div class="input">
                                <input class="note" id="confirm_password" style="width: 180px" type="password" size="35"
                                    value="" /></div>
                            <div class="note" id="confirm_password_info">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 22px">
                    <div style="padding-top:10px; padding-bottom:10px;">
                        <input id="btnSubmit" type="submit" value="上传" runat="server" width="70px" style="width: 107px" onserverclick="btnSubmit_ServerClick" /></div></td>
                </tr>
            </table>
        </div>
        <script type="text/javascript" language="javascript">
        initForm();
        </script>
    </form>
</body>
</html>
