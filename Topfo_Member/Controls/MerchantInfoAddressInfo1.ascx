<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MerchantInfoAddressInfo1.ascx.cs" 
Inherits="Tz888.Member.Controls.MerchantInfoAddressInfo1" %>
<!--添加的发布招商信息的提示部分-->   
   <!-- <div>
   <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:20px; margin:15px 0;" class="f_14">
  <tr>
    <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
    <td width="125" style="background:url(../images/member_bg1_off.gif) no-repeat;">第一步<br />
      填写项目信息</td>
    <td width="50"><img src="images/member_icon1.gif" /></td>
    <td width="125" style="background:url(../images/member_bg1_on.gif) no-repeat;" class="f_red strong">第二步<br />
      确认联系方式</td>
    <td>&nbsp;</td>
  </tr>
</table></div> -->
   <div>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank">

    
    <tr>
        <td width="124" align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>招商机构名称：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtCompanyName" onchange="CAcheckNavigate(1);" runat="server" Width="324px" />
         <!--<a href="../Register/GovernmentRegister.aspx">修改招商机构信息</a>-->
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish">
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
            <span id="linkMan"></span>
        </td>
    </tr>
      <tr>
     
       <td align="right" bgcolor="#F7F7F7">
        <span class="hong">*</span> <strong>职位：</strong>
       </td>
     
      <td><asp:TextBox ID="txtPosition" onchange="CAcheckNavigate(6)" width="127px" runat="server" />
      <span id="spPosition"></span>
      </td>
      </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系电话：</strong></td>
        <td width="638" valign="top">
          
           
            固话<asp:TextBox ID="txtTelCountry" onchange="CAcheckNavigate(5);" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode" onchange="CAcheckNavigate(5);" runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" onchange="CAcheckNavigate(5);" runat="server" size='18' />
            <span id="spTel" ></span>
            手机<asp:TextBox id='txtMobile' onchange="CAcheckNavigate(5);" width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>       
        </td>
    </tr>
    <tr id="tr1" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>电子邮箱：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtEmail" onchange="CAcheckNavigate(4)" runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
   
    
    <tr id="trswitchpublish1" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>联系地址：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
  
    
</table>

<script type="text/javascript" language="javascript">
    
    function AddContact(){
	
		this.CompanyNameID = "<%=this.txtCompanyName.ClientID %>";
	    this.MobileID = "<%=this.txtMobile.ClientID %>";
	    this.NameID = "<%=this.txtName.ClientID %>";
	    
	    this.TelCountryID = "<%=this.txtTelCountry.ClientID %>";
	    this.TelZoneCodeID = "<%=this.txtTelZoneCode.ClientID %>";
	    this.TelNumberID = "<%=this.txtTelNumber.ClientID %>";
        
        this.EmailID = "<%=this.txtEmail.ClientID %>";
      
	    this.AddressID = "<%=this.txtAddress.ClientID %>";
	    //检查职位
	    this.Position="<%=this.txtPosition.ClientID%>";
	    //检查电话
	    this.TelMobile="<%=this.txtMobile.ClientID %>"
	    //联系人
	    this.LinkMan="<%=this.txtName.ClientID%>";
	}
	AddContact.prototype.checkByteLength = function(str,minlen,maxlen) {
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
	
	AddContact.prototype.validateArea = function(obj){
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
	
	AddContact.prototype.validateNumber = function(obj){
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
	AddContact.prototype.checkComName = function(){
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
	
	//检查联系人的姓名与号码
	AddContact.prototype.checkLinkMan = function(){
	   
	  var obj = document.getElementById(this.LinkMan);
    	var str = obj.value;
    	var len=str.length;
    	if(len<=0)
    	{
    	   document.getElementById("linkMan").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写您的姓名";
	        document.getElementById("linkMan").className = "noteawoke";
	       obj.focus();
	       return false; 
    	}
    	else
    	{
    	    document.getElementById("linkMan").innerHTML = "";
	        document.getElementById("linkMan").className = "";
	        obj.focus();
    	  return true;
    	}
	}
	
	//检查邮箱
	AddContact.prototype.checkEmail = function(){
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
    	    document.getElementById("spEmail").innerHTML = "";
	        document.getElementById("spEmail").className = "";
	        return true;
    	}
	}
	//检查电话
	AddContact.prototype.validatePhone = function(){
	    document.getElementById(this.TelCountryID).value = document.getElementById(this.TelCountryID).value.trim();
	    document.getElementById(this.TelZoneCodeID).value = document.getElementById(this.TelZoneCodeID).value.trim();
	    document.getElementById(this.TelNumberID).value = document.getElementById(this.TelNumberID).value.trim();
	    //新加的
    	document.getElementById(this.TelMobile).value = document.getElementById(this.TelMobile).value.trim();
    	
    	if(this.validateArea(document.getElementById(this.TelCountryID)) == 0 && this.validateArea(document.getElementById(this.TelZoneCodeID)) == 0 && this.validateNumber(document.getElementById(this.TelNumberID)) == 0 && this.validateNumber(document.getElementById(this.TelMobile)) == 0){
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
	 AddContact.prototype.checkPosi=function()
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
    	    document.getElementById("spPosition").innerHTML = "";
	        document.getElementById("spPosition").className = "";
	        obj.focus();
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
	
	function CAcheckNavigate(i)
	{
	   var classname = "<%=this.ClientID %>_AddContact";
	   switch(i)
	   {
	        case 1:
	            eval(classname + ".checkComName()");
	            break;
	        case 2:
	            eval(classname + ".checkLinkMan()");
	            break;
	       
	        case 4:
	            eval(classname + ".checkEmail()");
	            break;
	        case 5:
	            eval(classname + ".validatePhone()");
	            break;
	            //职位
	        case 6:
	           eval(classname+".checkPosi()");
	        default:
	            break;
	   }
	}
	
	var <%=this.ClientID %>_AddContact = new AddContact();

</script>
</div>