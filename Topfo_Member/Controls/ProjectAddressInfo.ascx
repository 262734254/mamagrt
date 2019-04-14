<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProjectAddressInfo.ascx.cs"
    Inherits="Tz888.Member.Controls.ProjectAddressInfo" %>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
    <tr>
        <td width="124" align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong><%=(this.type == 0)?"公司名称：":"招商机构名称：" %></strong></td>
        <td width="638">
            <asp:TextBox ID="txtCompanyName" onchange="CAcheckNavigate(1);" runat="server" Width="324px" />
            <%=(this.type==0)?"<div class='clear'></div><span class='hui'>  请用中文完整填写在工商局注册的公司全称。<a href=/Register/EnterpriseRegister.aspx>点此修改公司信息</a></span>":"<a href='../Register/GovernmentRegister.aspx'>修改招商机构信息</a>" %>
           <span id="spCAComName" ></span>
           </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系人：</strong></td>
        <td width="638">
            <div id="divContactMan" runat="server">
                <div id="divInit" runat="server">
                    姓名：<asp:TextBox id='txtName' onchange="CAcheckNavigate(2)" width="127px" runat="server" />&nbsp;&nbsp;手机：<asp:TextBox id='txtMobile' onchange="CAcheckNavigate(2)" width="127px" runat="server" />&nbsp;
                    <input type="button" onclick="JavaScript:<%=this.ClientID %>_AddContact.add();" value="添加更多联系人" />
                    <%=this.LinkOutputHTML %>
                </div>
            </div>
            <span id="splinkMan" ></span>
            <div class="clear"></div>
             <span class="hui">请填写该项目的直接负责人真实姓名，姓名必填，手机选填</span>
            <input id="initManList" type="hidden" size="1" runat="server" />
            <input id="deletedManList" type="hidden" size="1" runat="server" />
            <input id="hdinputCount" type="hidden" size="1" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>固定电话：</strong></td>
      <td width="638" valign="top">
            <menu class="menulw">
                国家</menu>
            <menu>
                城市区号</menu>
            <menu>
                电话号码</menu>
            <br />
            <asp:TextBox ID="txtTelCountry" onchange="CAcheckNavigate(5);" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode" onchange="CAcheckNavigate(5);" runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" onchange="CAcheckNavigate(5);" runat="server" size='18' />
          <span id="spTel" ></span><span class="hui"> 如果要输入多个号码，请使用&quot;,&quot;分隔；分机号码用&quot;－&quot;分隔</span> </td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>电子邮箱：</strong></td>
      <td width="638">
            <asp:TextBox ID="txtEmail" onchange="CAcheckNavigate(4)" runat="server" size='18' Width="269px" />
          <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>        </td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish" style='display:<%=(this.type == 0)?"block;":"none;" %>'>
        <td align="right" bgcolor="#F7F7F7" style="height: 44px">
            <strong>公司网址：</strong></td>
      <td width="638" style="height: 44px">
            http://
            <asp:TextBox ID="txtWebSite" runat="server" size='18' Width="269px" />
         <span class="hui">  如果您的公司没有网站，请在此<a href="http://co.topfo.com/manager/intro.aspx" target="_blank">建立企业展厅</a></td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>传 真</strong><strong>：</strong></td>
        <td width="638">
            <menu class="menulw">
                国家</menu>
            <menu>
                城市区号</menu>
            <menu>
                电话号码</menu>
            <br />
            <asp:TextBox ID="txtFaxCountry" onchange="CAcheckNavigate(6);" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtFaxZoneCode" onchange="CAcheckNavigate(6);" runat="server" size='7' />
            <asp:TextBox ID="txtFaxNumber" onchange="CAcheckNavigate(6);" runat="server" size='18' />
            <span id="spFax" ></span>
        </td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>联系地址：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
    <tr id="trswitchpublish" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7" style="height: 26px">
            <strong>邮政编码：</strong></td>
        <td width="638" style="height: 26px">
            <asp:TextBox ID="txtPostCode" runat="server" size='18' Width="72px" /></td>
    </tr>
</table>
    <script type="text/javascript" language="javascript" >
    
    function AddContact(inputCount,maxContacts,deletedContactListID,addContactsID,inputCountID,prefix,name){
		this.InputCount=inputCount;//已有的联系人数
		this.MaxContacts = maxContacts;//可添加的最大联系人个数
		this.DeletedContactListID = deletedContactListID;//删除联系人列表的隐藏域ID
		this.AddContactsID = addContactsID;//联系人容器ID
		this.InputCountID = inputCountID //联系人个数容器ID(后台取总数调用)
		this.Prefix = prefix;//生成DOM元素ID的前缀
		this.Name = name;//对象变量名
		
		this.CompanyNameID = "<%=this.txtCompanyName.ClientID %>";
	    this.MobileID = "<%=this.txtMobile.ClientID %>";
	    this.NameID = "<%=this.txtName.ClientID %>";
	    
	    this.TelCountryID = "<%=this.txtTelCountry.ClientID %>";
	    this.TelZoneCodeID = "<%=this.txtTelZoneCode.ClientID %>";
	    this.TelNumberID = "<%=this.txtTelNumber.ClientID %>";
        
        this.EmailID = "<%=this.txtEmail.ClientID %>";
        this.WebSiteID = "<%=this.txtWebSite.ClientID %>";
        
        this.FaxCountryID = "<%=this.txtFaxCountry.ClientID %>";
	    this.FaxZoneCodeID = "<%=this.txtFaxZoneCode.ClientID %>";
	    this.FaxNumberID = "<%=this.txtFaxNumber.ClientID %>";
	    
	    this.AddressID = "<%=this.txtAddress.ClientID %>";
	    this.PostCodeID = "<%=this.txtPostCode.ClientID %>";
	}
	AddContact.prototype.add = function(){
	    if(this.InputCount < this.MaxContacts){
	        var strTmp = '<div id="divContact">姓名：<input type="text" id="txtName" name="txtName" width="122px" />&nbsp;&nbsp;手机：<input type="text" id="txtMobile" name="txtMobile" width="122px" />&nbsp;&nbsp;<a href="javascript:Remove(\'divContact\');">移除</a><input type=hidden id="hdLink" name="hdLink" value="LinkID" /></div>';
	        var str = strTmp.replace(/divContact/g,this.Prefix +"DC" + this.InputCount);
			str = str.replace(/txtName/g,this.Prefix +"TN" + this.InputCount);
			str = str.replace(/txtMobile/g,this.Prefix +"TM" + this.InputCount);
			str = str.replace(/Remove/g,this.Name + ".remove");
			str = str.replace(/hdLink/g,this.Prefix + "HV" + this.InputCount);
			str = str.replace(/LinkID/g,"");
			var obj = document.getElementById(this.AddContactsID);
//			obj.insertAdjacentHTML("beforeEnd",str);
            obj.innerHTML += str;
			this.InputCount ++;
			document.getElementById(this.InputCountID).value = this.InputCount;
	    }
	    else{
	         alert("已经到达可添加最多联系人数!");
	    }
	}
	AddContact.prototype.remove = function(obj){
	    if(confirm( "您真的要将联系人移除吗?"))
		{
			var el = document.getElementById(obj);
			var el_parent = el.parentNode;
            el_parent.removeChild(el);
			this.InputCount--;
			document.getElementById(this.InputCountID).value = this.InputCount;
		}
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
    	var patn = /^[0-9,-\/]+$/;
    	if(!patn.test(str)) return 1;
    	return 0;
	}
	
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
	        return true;
	    }   
	}
	
	
	AddContact.prototype.checkLinkMan = function(){
	    var obj1 = document.getElementById(this.NameID);
	    
	    var str1 = obj1.value.trim();
	    while(str1.indexOf("，")!=-1){
	    	str1 = str1.replace("，",",");}
    	obj1.value = str1;
    	
	    var obj2 = document.getElementById(this.MobileID);
	    //var filter1=/^\s*[\u4e00-\u9fa5A-Za-z,]{1,20}\s*$/;
	    var filter1=/^\s*[\u4e00-\u9fa5A]{1,6}\s*$/;
	    var filter2 = /^[0-9]+$/;
	    
    	if((obj2.value==""&&filter1.test(obj1.value)) ||(filter1.test(obj1.value)&&filter2.test(obj2.value)&&obj2.value.length<=16&&obj2.value.length>=11))
    	{
    	    document.getElementById("splinkMan").innerHTML = "";
	        document.getElementById("splinkMan").className = "";
	        return true;
    	}
    	if(!filter1.test(obj1.value))
    	{
    	    document.getElementById("splinkMan").innerHTML = "&nbsp;&nbsp;&nbsp;请正确的填写联系人姓名[中文]！";	    
	        document.getElementById("splinkMan").className = "noteawoke";
	        obj1.focus();
	        return false;
    	}
    	else if((!(obj2.value.length<=16&&obj2.value.length>=11)) || (!filter2.test(obj2.value)))
	    {
	        document.getElementById("splinkMan").innerHTML = "&nbsp;&nbsp;&nbsp;请正确的填写联系人手机号！";
	        document.getElementById("splinkMan").className = "noteawoke";
	        obj2.focus();
	        return false;
	    }
	}
	
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
    	    document.getElementById("spEmail").innerHTML = "请填写您最常用的电子邮箱";
	        document.getElementById("spEmail").className = "hui";
	        return true;
    	}
	}
	
	AddContact.prototype.validatePhone = function(){
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
	        document.getElementById(this.TelNumberID).focus();
	        return false;
    	}
	}

	AddContact.prototype.validateFax = function(){
	    document.getElementById(this.FaxCountryID).value = document.getElementById(this.FaxCountryID).value.trim();
	    document.getElementById(this.FaxZoneCodeID).value = document.getElementById(this.FaxZoneCodeID).value.trim();
	    document.getElementById(this.FaxNumberID).value = document.getElementById(this.FaxNumberID).value.trim();
	    if(document.getElementById(this.FaxZoneCodeID).value==""&&document.getElementById(this.FaxNumberID).value==""){
	        document.getElementById("spFax").innerHTML = "";
	        document.getElementById("spFax").className = "";
	        return true;
	    }
    	if(this.validateArea(document.getElementById(this.FaxCountryID)) == 0 && this.validateArea(document.getElementById(this.FaxZoneCodeID)) == 0 && this.validateNumber(document.getElementById(this.FaxNumberID)) == 0){
    	    document.getElementById("spFax").innerHTML = "";
	        document.getElementById("spFax").className = "";
	        return true;
    	}else{
    	    document.getElementById("spFax").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写您的传真号码！";
	        document.getElementById("spFax").className = "noteawoke";
	        document.getElementById(this.TelCountryID).focus();
	        return false;
    	}
	}
	
	AddContact.prototype.checkMoreLinkMan = function(){
//	    var selectedItemCount = 0;
//        var liIndex = 0;
//        var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
//        while (currentListItem != null)
//        {
//            if (currentListItem.checked) selectedItemCount++;
//            liIndex++;
//            currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
//        }
//        return selectedItemCount;
//        
//        var nameControlID = this.Prefix + "TN" + i.toString();
//        var mobileControlID = this.Prefix + "TM" + i.toString();
//        var spMsgID = this.Prefix + "SP" + i.toString();
        return true;
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
	    if(!this.validateFax()){
//	        alert(5);
	        if(revlaue) revlaue = false;}
	    if(!this.checkMoreLinkMan()){
//	        alert(6);
	        if(revlaue) revlaue = false;}
	    return revlaue;
	}
	
	function tot(mobnumber){                        
    	while(mobnumber.indexOf("０")!=-1){
    		mobnumber = mobnumber.replace("０","0");}
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
	    while(mobnumber.indexOf("－")!=-1){
	    	mobnumber = mobnumber.replace("－","-");}
	    while(mobnumber.indexOf("／")!=-1){
	    	mobnumber = mobnumber.replace("／","/");}
	    while(mobnumber.indexOf("＿")!=-1){
	    	mobnumber = mobnumber.replace("＿","_");}
	    while(mobnumber.indexOf("，")!=-1){
	    	mobnumber = mobnumber.replace("，",",");}
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
	        case 3:
	            eval(classname + ".checkMoreLinkMan()");
	            break;
	        case 4:
	            eval(classname + ".checkEmail()");
	            break;
	        case 5:
	            eval(classname + ".validatePhone()");
	            break;
	        case 6:
	            eval(classname + ".validateFax()");
	            break;
	        default:
	            break;
	   }
	}
	
	var <%=this.ClientID %>_AddContact = new AddContact(<%=InputCount %>,<%=MaxContacts %>,"<%=deletedManList.ClientID %>","<%=divContactMan.ClientID %>","<%=hdinputCount.ClientID %>","<%=this.ClientID %>","<%=this.ClientID %>_AddContact");
	
	document.getElementById("<%=hdinputCount.ClientID %>").value = <%=InputCount %>;

</script>