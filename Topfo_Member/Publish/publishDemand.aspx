<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="publishDemand.aspx.cs" Inherits="Publish_publishDemand"  Title="招商需求-发布招商需求" %>


<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css" >
.trnone{
    display:none;
    }
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.infomsg{

    padding-left:20px;
    padding-right:20px;
    fong-size:12px;
    color:#777777;
    background:#83BDC0;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>

    <script type="text/javascript" language="javascript">
function GetCheckBoxListCheckNum(checkobjectid)
{
    var selectedItemCount = 0;
    var liIndex = 0;
    var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    while (currentListItem != null)
    {
        if (currentListItem.checked) selectedItemCount++;
        liIndex++;
        currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    }
    return selectedItemCount;
}

function GetCheckNum(checkobjectname)
{
	var truei2 = 0;
	checkobject = document.getElementsByName(checkobjectname);
	var inum = checkobject.length;
	if (isNaN(inum))
	{
		inum = 0;
	}
	for(i=0;i<inum;i++){
		if (checkobject[i].checked == 1){
			truei2 = truei2 + 1;
		}
	}
	return truei2;
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

//招商类别
function checkMerchantType()
{    
    
    var rblCapitalTypeID = "<%=this.rblMerchantType.ClientID %>";
    if(GetCheckNum(rblCapitalTypeID.replace(/_/g,"$")) <= 0){
        document.getElementById("spMerchantType").innerHTML = "&nbsp;&nbsp;&nbsp;请选择招商类别！";
        document.getElementById("spMerchantType").className = "noteawoke";
        document.getElementById(rblCapitalTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spMerchantType").innerHTML = "";
        document.getElementById("spMerchantType").className = "";
		return true;
	}
}

//意向有效期限
function checkValiditeTerm()
{    
     var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";
     if(GetCheckNum(rdlValiditeTermID.replace(/_/g,"$")) <= 0)
    {
        document.getElementById("spValiditeTerm").innerHTML = "&nbsp;&nbsp;&nbsp;请选择有效期";
        document.getElementById("spValiditeTerm").className = "noteawoke";
        document.getElementById(rdlValiditeTermID).focus();
		return false;
		alert("false");
		
	}
	else
	{
	    document.getElementById("spValiditeTerm").innerHTML = "";
        document.getElementById("spValiditeTerm").className = "";
		return true;
	}
}



function ShowInfoMsg(msg,css)
{
    document.getElementById("spMerchantTypeInfo").innerHTML = msg;
    document.getElementById("spMerchantTypeInfo").className = css;
}

function checkMerchantTopic()
{    
    var txtCapitalNameID = "<%=this.txtMerchantTopic.ClientID %>";
    var obj = document.getElementById(txtCapitalNameID);
    if(obj.value == "")
    {
        document.getElementById("spMerchantTopic").innerHTML = "&nbsp;&nbsp;&nbsp;招商主题必须填写！";
        document.getElementById("spMerchantTopic").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,1,100))
    {
        document.getElementById("spMerchantTopic").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写招商主题，限50字以内！";
        document.getElementById("spMerchantTopic").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spMerchantTopic").innerHTML = "";
        document.getElementById("spMerchantTopic").className = "";
        return true;
    }
}
//检查行业
function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()");
}

检查用户所填的联系信息
function checkcontactinfo()
{ 

}


//合作方式
function checkCooperationDemand()
{    
    var cblCooperationDemandTypeID = "<%=this.cblCooperationDemandType.ClientID %>";
    
    if(GetCheckBoxListCheckNum(cblCooperationDemandTypeID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;请至少选择一种合作方式！";
        document.getElementById("spCooperationDemand").className = "noteawoke";
        document.getElementById(cblCooperationDemandTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCooperationDemand").innerHTML = "";
        document.getElementById("spCooperationDemand").className = "";
		return true;
	}
}
//检查投资额
function checkCapitalTotal()
{  
    var id = "<%=this.txtCapitalTotal.ClientID %>";
    var str=document.getElementById(id);
    filter = /^\d+(\.\d+)*$/;
    if(str.value == "" || filter.test(str.value)){
        document.getElementById("spCapitalTotal").innerHTML = "";
        document.getElementById("spCapitalTotal").className = "";
        return true;
    }
    else{
        document.getElementById("spCapitalTotal").innerHTML = "&nbsp;&nbsp;&nbsp;总投资额必须为数字，请正确填写！";
        document.getElementById("spCapitalTotal").className = "noteawoke";
        document.getElementById("spCapitalTotal").focus();
        return false;
    }
}

function checkZoneAbout()
{
    var id = "<%=this.txtZoneAboutBrief.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAbout").innerHTML = "";
        document.getElementById("spZoneAbout").className = "";
        return true;
    }
}

function checkKeyword()
{
    var key1ID = "<%=this.txtKeyword1.ClientID %>";
    var key2ID = "<%=this.txtKeyword2.ClientID %>";
    var key3ID = "<%=this.txtKeyword3.ClientID %>";
    
    var revalue = true;
    var filter=/^\s*[\u4e00-\u9fa5A-Za-z0-9_]{0,10}\s*$/;
    if(filter.test(document.getElementById(key1ID).value)&&filter.test(document.getElementById(key2ID).value)&&filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "";
        document.getElementById("spKeyMsg").className = "";
        return true;
    }
    if (!filter.test(document.getElementById(key1ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key1ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key2ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key2ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key3ID).focus();
        return false;
    }
}

function checkMerchantInfoAddress()
{
}
//招商项目简介
function checkZoneAboutB()
{
    var id = "<%=this.txtZoneAbout.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutB").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutB").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutB").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutB").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutB").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutB").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutB").innerHTML = "";
        document.getElementById("spZoneAboutB").className = "";
        return true;
    }
}

//检查地方经济指标描述
function checkZoneAboutJ()
{
    var id = "<%=this.txtEconomicIndicators.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutC").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutC").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutC").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutC").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutC").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutC").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutC").innerHTML = "";
        document.getElementById("spZoneAboutC").className = "";
        return true;
    }
}


//投资环境描述
function checkZoneAboutT()
{
//txtInvestmentEnvironment
 var id = "<%=this.txtInvestmentEnvironment.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutD").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutD").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutD").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutD").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutD").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutD").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutD").innerHTML = "";
        document.getElementById("spZoneAboutD").className = "";
        return true;
    }

}
//项目现状及规划
function checkZoneAboutX()
{
 //id="txtProjectStatus" 
 var id = "<%=this.txtProjectStatus.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutE").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutE").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutE").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutE").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutE").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutE").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutE").innerHTML = "";
        document.getElementById("spZoneAboutE").className = "";
        return true;
    }
}

//项目优势及市场分析

function checkZoneAboutY()
{
 var id = "<%=this.txtMarket.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutF").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutF").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutF").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutF").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutF").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutF").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutF").innerHTML = "";
        document.getElementById("spZoneAboutF").className = "";
        return true;
    }

}
//经济效益分析
function checkZoneAboutZ()
{

 var id = "<%=this.txtBenefit.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAboutG").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAboutG").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spZoneAboutG").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAboutG").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spZoneAboutG").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在5000字以内！";
        document.getElementById("spZoneAboutG").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAboutG").innerHTML = "";
        document.getElementById("spZoneAboutG").className = "";
        return true;
    }

}
//检查是否阅读
function CheckCheck()
{
  var ckbCheckID = "<%=this.ckbCheck.ClientID %>";
    var obj = document.getElementById(ckbCheckID);
    if(!obj.checked){
        document.getElementById("spCheck").innerHTML = "发布前请阅读并接受接受服务协议";
        document.getElementById("spCheck").className = "noteawoke";
        obj.focus();
		return false;
	}
	else
	{
	    document.getElementById("spCheck").innerHTML = "";
        document.getElementById("spCheck").className = "";
		return true;
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
	
	 function validateArea(obj){
    	var str1 = obj.value.trim();
    	var str = tot(str1); 
    	obj.value = str;
    	if(str.length == 0){
        	return -1;
	    }
    	var patn = /^[\+0-9]+$/;
    	if(!patn.test(str)) return 1;
    	return 0; 
	}
	
	function validateNumber(obj){
    	var str1 = obj.value.trim();
    	var str = tot(str1); 
    	obj.value = str;
    	if(str.length == 0){
    	    return -1;
    	}
    	var patn = /^[0-9-\/]+$/;
    	if(!patn.test(str)) return 1;
    	return 0;
	}
	//检查机构名称
	 function checkComName(){
	    var value = document.getElementById(this.CompanyNameID).value;
	    if(!this.checkByteLength(value,1,30)){
	        document.getElementById("spCAComName").innerHTML = "&nbsp;&nbsp;&nbsp;请正确投资机构名称，30字以内！";
	        document.getElementById("spCAComName").className = "noteawoke";
	        document.getElementById(this.CompanyNameID).focus();
	        return false;
	    }
	    else
	    {
	        document.getElementById("spCAComName").innerHTML = "";
	        document.getElementById("spCAComName").className = "";
	        document.getElementById(this.CompanyNameID).focus();
	        return true;
	    }   
	}
	
	
	//检查邮箱
	function checkEmail(){
	    var obj = document.getElementById(this.EmailID);
    	var str = obj.value;
    	var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    	if(str !=0 &&!filter.test(str))
    	{
    	    document.getElementById("spEmail").innerHTML = "&nbsp;&nbsp;&nbsp;电子邮件格式不正确，请输入正确的电子邮件地址！";
	        document.getElementById("spEmail").className = "noteawoke";
	        obj.focus();
	        return false;
    	}
    	else
    	{
    	    document.getElementById("spEmail").innerHTML = "请填写您最常用的电子邮箱";
	        document.getElementById("spEmail").className = "";
	        return true;
    	}
	}
	//检查电话
	function validatePhone(){
	    document.getElementById(this.TelCountryID).value = document.getElementById(this.TelCountryID).value.trim();
	    document.getElementById(this.TelZoneCodeID).value = document.getElementById(this.TelZoneCodeID).value.trim();
	    document.getElementById(this.TelNumberID).value = document.getElementById(this.TelNumberID).value.trim();
    	if(this.validateArea(document.getElementById(this.TelCountryID)) == 0 && this.validateArea(document.getElementById(this.TelZoneCodeID)) == 0 && this.validateNumber(document.getElementById(this.TelNumberID)) == 0){
    	    document.getElementById("spTel").innerHTML = "";
	        document.getElementById("spTel").className = "";
	        return true;
    	}else{
    	    document.getElementById("spTel").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写您的联系电话！";
	        document.getElementById("spTel").className = "noteawoke";
	        document.getElementById(this.TelCountryID).focus();
	        return false;
    	}
	}
    
	 //2010-06-24(检查职位是否填写)
	 function checkPosi()
	 {
	   var obj = document.getElementById(this.Position);
    	var str = obj.value;
    	var len=str.length;
    	if(len<=0)
    	{
    	   document.getElementById("spPosition").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写您的职位";
	        document.getElementById("spPosition").className = "noteawoke";
	       obj.focus();
	       return false; 
    	}
    	else
    	{
    	  return true;
    	}
	   
	 }
	  
	
	AddContact.prototype.checkAll = function(){
	    
	    var revlaue =true;
	    if(!this.checkComName()){
//	        alert(1);
	        if(revlaue) revlaue = false;}
	    if(!this.checkLinkMan()){
//	        alert(2);
	        if(revlaue) revlaue = false;}
	    if(!this.checkEmail()){
//	        alert(3);
	        if(revlaue) revlaue = false;}
	    if(!this.validatePhone()){
//	        alert(4);
	        if(revlaue) revlaue = false;}
	        
	         if(!this.checkPosi()){
//	        alert(4);
	        if(revlaue) revlaue = false;}
	        
	    return revlaue;
	}
	//检查置换号码数字
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

function CheckForm()
{
    var revalue = true;
    
    
    if(!checkMerchantType()){
        if(revalue) revalue = false;}
        
    if(!checkMerchantTopic()){
        if(revalue) revalue = false;}
    if(!checkIndustry()){
        if(revalue) revalue = false;}
        
        //检查用户所添联系信息
      if(!checkcontactinfo()){
       if(revalue) revalue=false;}
         
    if(!checkCooperationDemand()){
        if(revalue) revalue = false;}
    if(!checkCapitalTotal()){
        if(revalue) revalue = false;}    
    if(!checkZoneAbout()){
        if(revalue) revalue = false;}
    if(!checkKeyword()){
        if(revalue) revalue = false;}  
    if(!checkMerchantInfoAddress()){
        if(revalue) revalue = false;}  
    if(!checkZoneSelect(true)){
        if(revalue) revalue = false;}
      //以下是 新加的
        if(!checkZoneAboutZ()){
        if(revalue) revalue = false;}
        
         if(!checkZoneAboutY()){
        if(revalue) revalue = false;}
        
         if(!checkZoneAboutX()){
        if(revalue) revalue = false;}
        
         if(!checkZoneAboutT()){
        if(revalue) revalue = false;}
        
         if(!checkZoneAboutJ()){
        if(revalue) revalue = false;}
        
        if(!checkZoneAboutB()){
        if(revalue) revalue = false;}
          //服务协议
       if(!CheckCheck())
        {
        if(revalue) revalue = false;
        } 
         //意向有效期限   
       if(!checkValiditeTerm())
        {
        if(revalue) revalue = false;
        }
         //检查机构名称
        if(!checkComName()){
        if(revalue) revalue = false;
        }
        //检查邮箱
        if(!checkEmail()){
        if(revalue) revalue = false;
        }
        //检查电话
        if(!validatePhone()){
        if(revalue) revalue = false;
        }
        //检查职位
        if(!checkPosi())
        {
        if(revalue) revalue=false;
        }
       if(revalue)
         {
           document.getElementById("ctl00_ContentPlaceHolder1_imgLoding").style.display =""; 
          }
     return revalue;
    
    
}

document.getElementById("frmsearch").onsubmit = CheckForm;
    </script>

    <script type="text/javascript" language="javascript">
        function switchPublish()
        {
            var tag = document.getElementById("hdswitchpublish").value;
            var objs = document.getElementsByName("trswitchpublish");
            if(objs == null)
                return;
            var style = "";
            if(tag == 1){
                style = "trnone";  
                document.getElementById("hdswitchpublish").value = 0;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }
    </script>
    <!--这里是后来添加的控制信息显示有联系方式的js-->
    <script type="text/javascript">
    //function ShowContactInfo()
     //   {
      ///    document.getElementById("ProjectDiv").style.display="none";
      //    document.getElementById("ContactDiv").style.display="block";
            
      //  }
   //  function PreShow()
     //   {
           
      ///      document.getElementById("ProjectDiv").style.display="block";
      //      document.getElementById("ContactDiv").style.display="none";
     //   }
    
    </script>
    


    <input type="hidden" id="hdswitchpublish" value="1" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布政府招商需求

            </div>
            
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle" />
                 <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>            </div>
            <div class="clear">
            </div>
        </div>
        <asp:Panel ID="plTitle" runat='server'>
        <div class='stepsbox'>
            <ul>
                <li>第1步 登记招商机构 </li>
                <li class="liimg">
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='liwai'>第2步 填写招商项目信息</li>
                <li class='liimg'>
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='lishort'>第3步 发布成功</li>
            </ul>
            <div class='clear'>
            </div>
            <div class='blank0'>
            </div>
            <div class='suggestbox lightc'>
                "招商机构已经登记，接下来请您填写招商项目信息</div>
        </div>
        </asp:Panel>
        <div  id="switchtext">
            带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）</div>
			 <div class='dottedlline'>  </div>
			  <div class="blank6"> </div>
			 <!--这是后来招商信息的div-->
			 <div id="ProjectDiv" style="display:block;" >
			
        <div class="infozi">
            填写招商项目信息</div>
            <!--以下是修改的部分-->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>招商项目标题：</strong></td>
                <td>
                    <asp:TextBox ID="txtMerchantTopic" onchange="checkMerchantTopic();" runat="server" Width="270px"></asp:TextBox>
                    <span id="spMerchantTopic"></span>
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7" style="height: 2px">
                    <span class="hong">* </span><strong>招商类别：</strong></td>
                <td width="618">
                    <asp:RadioButtonList ID="rblMerchantType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <span id="spMerchantTypeInfo"></span>
                    <span id="spMerchantType" class="infomsg"></span>
                </td>
            </tr>
           
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                <td width="618">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                <td width="630">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>合作方式：</strong></td>
                <td valign="top">
                    <asp:CheckBoxList ID="cblCooperationDemandType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:CheckBoxList>&nbsp; <span class="hui">(可多选)</span> <span id="spCooperationDemand">
                    </span>
                </td>
            </tr>
            <tr id="trswitchpublish1" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>总投资：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlCapitalCurrency" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal" onchange="checkCapitalTotal();" runat="server"
                        Width="75px"></asp:TextBox>
                    万元 <span id="spCapitalTotal"></span>
                </td>
            </tr>
            <tr id="trswitchpublish2" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>引资金额：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlMerchantCurrency" runat="server">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlMerchantTotal" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>招商项目摘要：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAboutBrief"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAbout"></span>
                            <br />
                            <span class="hui">请用简明扼要的语言描述招商项目要点，建议字数在200字以内 ！</span>
                </td>
            </tr>
            <!--以下是要添加的部分-->
              <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>招商项目简介：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAbout" onchange="checkZoneAboutB();" runat="server" cols="50"
                        rows="10" style="width: 558px; height:100px"></textarea><span id="spZoneAboutB"></span>
                           
                </td>
            </tr>
              <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>地方经济指标描述：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtEconomicIndicators" runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAboutC"></span>
                </td>
            </tr>
            
             <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>投资环境描述：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtInvestmentEnvironment" runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAboutD"></span>
                </td>
            </tr>
             <tr><td colspan="2"><span class="f_red strong">※ 项目详细资料</span><span class="f_gray">（完善的资料可以得到投资方更多信任，请完善以下信息！）</span></td></tr>
            
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>项目现状及规划：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtProjectStatus"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAboutE"></span>
                </td>
            </tr>
             <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>项目优势及市场分析：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtMarket"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAboutF"></span>
                </td>
            </tr>
            
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>经济效益分析：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtBenefit"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span id="spZoneAboutG"></span>
                </td>
            </tr>
           
            <!--结束处-->
            <tr id="trswitchpublish" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>招商关键字：</strong></td>
                <td width="630" valign="top">
                    <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    <br />
                    <span id="spKeyMsg"></span><span class="hui">用户现在更多地通过搜索来寻找资源，定义相关的关键字能让您的需求更容易被潜在合作方找到。</span>
                </td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <strong>上传附件：</strong></td>
                <td width="618" valign="top" class="nonepad">
                    <uc3:FilesUploadControl ID="FilesUploadControl1" InfoType="Merchant"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>项目有效期：</strong></td>
                <td width="630">
                   <!-- <asp:DropDownList ID="ddlValiditeTerm" runat="server">
                        <asp:ListItem Value="3">三个月内</asp:ListItem>
                        <asp:ListItem Value="6">半年内</asp:ListItem>
                        <asp:ListItem Value="12">一年内</asp:ListItem>
                    </asp:DropDownList>-->
                    
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" Height="2px" >
                      </asp:RadioButtonList>
                     <span id="spValiditeTerm" class="infomsg"></span>
                       
                           
                    
                    </td>
            </tr>
        </table>
        <div class="blank0">
        </div>
         <!--重新添加一个按纽记录上一步的值以上是注释部分-->
         <!-- <div id="nextDiv" style="display:block; text-align:center;">
              <input id="ShowInfo" type="button" value="下一步：确认联系方式"  /></div>
         </div> -->
         <!--招商基本信息的div结束处-->
         
        <!--联系方式开始将之隐藏 -->
        <div id="ContactDiv" style="display:block;">
        <div class="infozi">
            <strong>联系方式确认</strong></div>
            <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">

    
    <tr>
        <td width="124" align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>招商机构名称：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtCompanyName" onchange="checkComName();" runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr id="tr2" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>项目承办单位：</strong></td>
        <td width="622">
            <asp:TextBox ID="txtUndertaker" runat="server" Width="324px" /></td>
    </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系人：</strong></td>
        <td width="638">
          
            <asp:TextBox id='txtName' onchange="CAcheckNavigate(2)" width="127px" runat="server" />
        </td>
    </tr>
      <tr>
     
       <td align="right" bgcolor="#F7F7F7">
        <span class="hong">*</span> <strong>职位：</strong>
       </td>
     
      <td><asp:TextBox ID="txtPosition" onchange="checkPosi();" width="127px" runat="server" />
      <span id="spPosition"></span>
      </td>
      </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系电话：</strong></td>
        <td width="638" valign="top">
          
           
            固话<asp:TextBox ID="txtTelCountry" onchange="validatePhone();" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode" onchange="validatePhone();" runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" onchange="validatePhone();" runat="server" size='18' />
            <span id="spTel" ></span>
            手机<asp:TextBox id='txtMobile'  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>       
        </td>
    </tr>
    <tr id="tr3" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>电子邮箱：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtEmail" onchange="checkEmail();" runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
   
    
    <tr id="tr4" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>联系地址：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
  
    
</table>
      </div>
          <!--这里是添加验证码的地方-->
       <div style="width:758px;  border:1px solid #cccccc; border-top:0px;">
       <table>
       <tr>
       <td style="font-weight:bold; width:126px; background-color:#F7F7F7; text-align:right;">
      验证码：&nbsp;&nbsp;</td>
      <td>
      <asp:TextBox ID="ImageCode"  runat="server" Width="120px"></asp:TextBox> <img src="../ValidateNumber.aspx"  onclick="this.src='../ValidateNumber.aspx?temp=' + (new Date())" />
       </td>
       
       </tr></table>
       </div>
        
        <!--申请域名 建立我的展厅 -->
        <div class="blank0">
        </div>
        <div class="mbbuttom">
           <p>
            <asp:CheckBox ID="ckbCheck" onclick="JavaScript:CheckCheck();" Checked="true" runat="server" />
           <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">我已阅读并同意《拓富中国招商投资网服务》</a></p>
           <span id="spCheck"></span>
            <asp:ImageButton ID="IbtnSubmit" ImageUrl="../images/publish/buttom_tywftk.gif" runat="server"
                OnClick="IbtnSubmit_Click" />
        </div>
        </div>
          
     </div>
    
     <div id="imgLoding" style="position:absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            bottom:0px;
            left: 0px; 
            width: 1000px; 
            height:3000px; 
            filter:alpha(opacity=60);" runat="server">
            <div class="content" style="margin-left:500px; margin-top:500px;">
               <img src="../../img/img-loading.gif" alt="Loading..." />
                <p>数据正在提交,请稍候...</p></div>
        </div>
</asp:Content>
