<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="发布资讯" CodeFile="PublishNews.aspx.cs" Inherits="PublishNews" %>

<%@ Register Src="../Controls/TPZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<%--<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
        <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />--%>
<script language="javascript" type="text/javascript"> 
    function checkedTypeOK()
    {  
        var temp=document.getElementsByName("ctl00$ContentPlaceHolder1$radioType"); 
        var objhidradioType=document.getElementById("ctl00_ContentPlaceHolder1_hidradioType");
        var objdv1=document.getElementById("ctl00_ContentPlaceHolder1_tb1"); 	       
	    var objdv2=document.getElementById("ctl00_ContentPlaceHolder1_dvpublish2");  
        for (i=0;i<temp.length;i++)
        {  
           if(temp[i].checked)      
	        {   
	           if(temp[i].value=='67')
	           {    
	                   objdv1.style.display="none";
	                   objdv2.style.display="block"; 
	                    
	           }
	           else
	           { 
	                   objdv1.style.display="block";             
	                   objdv2.style.display="none"; 
	           }        
	           objhidradioType.value=temp[i].value;  //选择资讯类别 
   	        }  	
        }
    } 
 
    function cancel()
   {
       document.getElementById("ctl00_ContentPlaceHolder1_txtName").value="";
       document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value=""; 
        document.getElementById("ctl00_ContentPlaceHolder1_txtSource").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").value=""; 
        document.getElementById("ctl00_ContentPlaceHolder1_txtAddress").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_stime").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtHostUnit").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtHandleUnit").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtContent2").value="";  
        document.getElementById("ctl00_ContentPlaceHolder1_txtRemarks").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtNam").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtPhone").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneCityCode").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneNum").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtFaxCityCode").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtFaxNum").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtAddres").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtZipCode").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtNet").value="";
   }
   
	function chkInput()               
	{ 
       var temp=document.getElementsByName("ctl00$ContentPlaceHolder1$radioType");  
       var status = "false";
        for (i=0;i<temp.length;i++)
        {  
           if(temp[i].checked)      
	        {    
	           if(temp[i].value=='67')
	           {    
	              status="true";
	           }
	        }
	    } 
       if(status=="true")
       {
         var i;var j;
        var lenName = 0;
//        var lenRemarks=0;
        var objName=document.getElementById("ctl00_ContentPlaceHolder1_txtName").value;
//        var objRemarks=document.getElementById("txtRemarks").value;
        
        if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
        {
                alert('请选择所属地区!'); 
                document.getElementById("ZoneId").focus();
			    return false; 
        }
        for (i=0;i<objName.length;i++)
        { 
            if (objName.charCodeAt(i)>255) lenName+=2; else lenName++;
        }

        if(lenName==0||lenName>70) 
        {
                alert('活动名称不为空且不超过35个汉字!');
                document.getElementById("ctl00_ContentPlaceHolder1_txtName").focus();
			    return false; 
        } 
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtAddress").value=="")
		{
			alert("活动地址不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtAddress").focus();
			return false;
		}  
		if(document.getElementById("ctl00_ContentPlaceHolder1_stime").value=="")
		{
		    alert("活动起始时间不为空!"); 
			return false;
		} 
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtHostUnit").value=="")
		{
			alert("主办单位不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtHostUnit").focus();
			return false;
		} 
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtContent2").value=="")
		{
			alert("活动简介不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtContent2").focus();
			return false;
		}  
  
	    if(document.getElementById("ctl00_ContentPlaceHolder1_txtNam").value=="")
		{
			alert("联系人姓名不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtNam").focus();
			return false;
		} 
	 	var objMobile = document.getElementById("ctl00_ContentPlaceHolder1_txtPhone").value;
		if(objMobile !="")
		{
		    	
                    var patn =  /^(13|15|18)[0-9]{9}$/;
                    if(!patn.test(objMobile)) 
                    {
                        alert("手机号码填写不正确!");
	                    document.getElementById("ctl00_ContentPlaceHolder1_txtFaxNum").focus();
	                    return false;			    
                    } 
                 
		}

		var objcountrycode=document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneCountryCode").value;
		var objZoneCode = document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneCityCode").value;
		var objNumber = document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneNum").value;
		if(objcountrycode=="" || objZoneCode =="" ||  objNumber=="")
		{
		    alert("电话号码不能为空!");
		    document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneNum").focus();
			return false;
		 }
		 else
		 {
    	    var patn = /^[0-9-\/]+$/;
    	    if(!patn.test(objNumber)) 
    	    {
    	        alert("电话号码填写不正确!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtPhoneNum").focus();
			    return false;			    
    	    } 
    	 }	  
		var objfaxZoneCode = document.getElementById("ctl00_ContentPlaceHolder1_txtFaxCityCode").value;
		var objfaxNumber = document.getElementById("ctl00_ContentPlaceHolder1_txtFaxNum").value;
		if( objfaxZoneCode !="" ||  objfaxNumber!="")
		{ 
    	    var patn = /^[0-9-\/]+$/;
    	    if(!patn.test(objfaxNumber)) 
    	    {
    	        alert("传真号填写不正确!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtFaxNum").focus();
			    return false;			    
    	    } 
    	 }	 
    	 
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value!="")
		{
          pathemail= /^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,3})$/;
          if(!pathemail.test(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value))
          {
              alert ('你输入的电子邮箱不正确，请重新输入！'); 
              document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
              return false; 
          }
          
		} 
	    
	    var objWebSite = document.getElementById("ctl00_ContentPlaceHolder1_txtNet").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("网址填写不正确!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtNet").focus();
                return false;
             }
		}　
		document.getElementById("imgLoding").style.display = "block";
       }
       else
       {
       
            var i;var j;
            var lenTitle = 0;
            var lenInstruction=0;
            var objTitle=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle"); 
            var objInstruction=document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").value;
            for (i=0;i<objTitle.value.length;i++)
            { 
                if (objTitle.value.charCodeAt(i)>255) lenTitle+=2; else lenTitle++;
            }
            for (j=0;j<objInstruction.length;j++)
            {
                if (objInstruction.charCodeAt(i)>255) lenInstruction+=2; else lenInstruction++;
            }
            if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
            {
                    alert('请选择所属地区!'); 
                    document.getElementById("ZoneId").focus();
			        return false; 
            }
            if(lenTitle==0||lenTitle>70) 
            {
                    alert('标题不为空且不超过35个汉字!');
                    document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
			        return false; 
            } 
            if(lenInstruction>80) 
            {
                    alert('图片说明不超过40个汉字!');
                    document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").focus();
			        return false; 
            } 
		    if(document.getElementById("ctl00_ContentPlaceHolder1_txtSource").value=="")
		    {
			    alert("资讯来源不为空!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtSource").focus();
			    return false;
		    }  
		    if(document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value=="")
		    {
		        alert("资讯内容不为空!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtContent").focus();
			    return false;
		    }
		      document.getElementById("imgLoding2").style.display = "block";
		}
   
	}
	function checkMobile(strValue)
	{
	    /*^13\d{5,9}$/ //130–139。至少5位，最多9位
        /^153\d{4,8}$/ //联通153。至少4位，最多8位
        /^159\d{4,8}$/ //移动159。至少4位，最多8位 */
        var mobile=strValue;
        var reg0 = /^13\d{5,9}$/;
        var reg1 = /^153\d{4,8}$/;
        var reg2 = /^159\d{4,8}$/;
        var reg3 = /^0\d{10,11}$/;
        var my = false;
        if (reg0.test(mobile))my=true;
        if (reg1.test(mobile))my=true;
        if (reg2.test(mobile))my=true;
        if (reg3.test(mobile))my=true;
        
              
        return my;	
	}	
   
 
	
	function HidPeo()
	{
	        var objspPeo=document.getElementById("ctl00_ContentPlaceHolder1_spPeo");
	        if(objspPeo.style.display=="none")
	        {
	            objspPeo.style.display="block";
	        }
	        else
	        {
	            objspPeo.style.display="none";
	        }
	}
</script>
<input type="hidden" id="hidradioType" name="hidradioType" value="01" runat="server" /> 
<div class="mainconbox"  id="mainconbox">
<div class="titled">
<div class="left"> 发布资讯 </div>
<div class="clear"></div>
</div>

<div>前面标有“<span class="hong">*</span>”的为必填选项</div>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
  <tr>
    <td align="right" bgcolor="#F7F7F7" style="width: 158px"><span class="hong">* </span><strong>资讯类别：</strong></td>
    <td width="606"> 
      <input name="radioType" type="radio" value="01" id="radioType01" runat="server"    onclick="checkedTypeOK()"/>   
      招商动态  <input type="radio" name="radioType" id="radioType64" value="64" runat="server"   onclick="checkedTypeOK()" />   
      投资环境  <input type="radio" id="radioType65" name="radioType" value="65" runat="server"   onclick="checkedTypeOK()" />   
      招商政策  <input type="radio" name="radioType" id="radioType66" runat="server" value="66" onclick="checkedTypeOK()"  />   
      投资指南  <input type="radio" name="radioType" id="radioType67" value="67" runat="server"  onclick="checkedTypeOK()"/>   
      招商活动  </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 158px"><span class="hong">*</span> <strong>所属区域：</strong></td>
    <td width="606"> 
<uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server"></uc1:ZoneSelectControl>  
<input name="ZoneId" type="text" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
</td>
  </tr>
  </table>
  <table border="1" id="tb1" style="display:block; border-top-style:none" runat="server" cellpadding="0" cellspacing="0" class="tabbiank">
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 206px"><span class="hong">*</span> <strong>标题：</strong></td>
    <td valign="top"><input name="txtTitle" type="text" id="txtTitle" value="" size="45" runat="server"  />
        <p class="hui">标题长度不超过25个汉字，两个字母或数字为一个汉字。</p></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 206px"><span class="hong">*</span> <strong>来源：</strong></td>
    <td width="606" valign="top">
     
      <input name="txtSource" type="text" id="txtSource" value="" size="45" runat="server" />
      <p class="hui">请填写您此篇文章的出处，如果该文为您的原创内容，来源可填写您的姓名。</p></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="height: 208px; width: 206px;"><span class="hong">*</span> <strong>正文：</strong></td>
    <td valign="top" style="height: 208px"><textarea name="txtContent" rows="12" cols="70" id="txtContent" runat="server" style="width: 481px"></textarea></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 206px"><strong>上传图片：</strong></td>
    <td valign="top">
        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload"
            runat="server" OnClick="btnUpload_Click" Text="上 传" />
        <asp:Label ID="LblMessage" runat="server" ForeColor="#C00000"></asp:Label><br />
   
          <span class="hui">图片须为jpg或gif格式，大小不超过100K </span></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 206px"><strong>图片说明：</strong></td>
    <td valign="top"><input name="txtInstruction" type="text" id="txtInstruction" value="" size="45" runat="server" />
      <br />
      <span class="hui">图片说明不超过40个汉字</span></td>
  </tr>
</table>
  <div id="dvpublish2" runat="server"  style="display:none;border-top-style:none"> 
  <table border="1" id="tab2" runat="server" cellpadding="0" cellspacing="0" class="tabbiank" width="100%">
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px"><span class="hong">*</span> <strong>活动名称：</strong></td>
    <td><input name="txtName" type="text" id="txtName" value="" size="45"  runat="server"/>
      <p class="hui">名称长度不超过25个汉字，两个字母或数字为一个汉字</p></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px"><span class="hong">*</span> <strong>活动地点：</strong></td>
    <td><input name="txtAddress" type="text" id="txtAddress" value="" size="45" runat="server" /></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px"><span class="hong">*</span> <strong>活动时间：</strong></td>
    <td><input type="text" name="stime" id="stime" runat="server" style="width: 250px" /> </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px"><span class="hong">*</span> <strong>主办单位</strong>：</td>
    <td>
    <textarea name="txtHostUnit" rows="4" cols="70" id="txtHostUnit" runat="server" style="width: 481px"></textarea>
    
    </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px">
        <strong>承办单位</strong>：</td>
    <td><textarea name="txtHandleUnit" rows="4" cols="70" id="txtHandleUnit" runat="server" style="width: 481px"></textarea> </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 149px"><span class="hong">*</span> <strong>活动简介：</strong></td>
    <td><textarea name="txtContent" rows="12" cols="70" id="txtContent2" runat="server" style="width: 481px"></textarea></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 149px"><strong>上传图片：</strong></td>
    <td valign="top">        <asp:FileUpload ID="uploadPic2" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload2"
            runat="server" OnClick="btnUpload2_Click" Text="上 传" />
        <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White" ForeColor="#C00000"></asp:Label><br />
        <span class="hui">图片须为jpg或gif格式，大小不超过100K </span></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 149px"><strong>备注：</strong></td>
    <td valign="top"><TEXTAREA style="WIDTH: 481px" id="txtRemarks" name="txtRemarks" rows=4 cols=70 runat="server"></TEXTAREA></td>
  </tr>
</table>
<!--联系方式 --><!--申请域名 建立我的展厅 -->
<div class="blank0"></div>
<div class="infozi"><strong>联系方式:</strong></div>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><span class="hong">*</span> <strong>联系人：</strong></td>
    <td width="608">姓名：
      <input id="txtNam" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone" name="txtPhone" size="19"  runat="server" />
 
          <a style="cursor: hand; color: blue; text-decoration: underline;" onclick="HidPeo();">添加更多联系人</a><br /><span id ="spPeo" runat="server" style="display:none;">姓名：
      <input id="txtNam1" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone1" name="txtPhone" size="19"  runat="server" /><br />
          姓名：
      <input id="txtNam2" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone2" name="txtPhone" size="19"  runat="server" /><br />
          姓名：
      <input id="txtNam3" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone3" name="txtPhone" size="19"  runat="server" /><br />
          姓名：
      <input id="txtNam4" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone4" name="txtPhone" size="19"  runat="server" /><br />
          姓名：
      <input id="txtNam5" type="text" name="txtNam" size="19"  runat="server"  />

      手机：
          <input type="text" id="txtPhone5" name="txtPhone" size="19"  runat="server" /></span><br />
          <span class="hui">请填写活动的直接负责人真实姓名，姓名必填，手机选填  </span></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><span class="hong">*</span> <strong>固定电话：</strong></td>
<td width="608" valign="top"><%-- <menu>
    国家 &nbsp; &nbsp; &nbsp; &nbsp;城市区号 &nbsp; &nbsp;电话号码</menu> --%>
    <ul>
                        <li class="liwai" style="width: 66px;">国家</li><li style="width: 70px;">城市区号</li><li>电话号码</li></ul><br />
       
              <input type="text" id="txtPhoneCountryCode" size="4" name="86" value="086"  runat="server" />
              <input type="text" id="txtPhoneCityCode" size="7" runat="server"  />
              <input type="text" id="txtPhoneNum" size="18"  runat="server" />
              <br />
              <span class="hui">如果要输入多个号码，请使用","分隔；分机号码用"－"分隔 
      </span></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><strong>传 真：</strong></td>
<td width="608"> <ul>
                        <li class="liwai" style="width: 66px;">国家</li><li style="width: 70px;">城市区号</li><li>电话号码</li></ul><br /><%--<menu>
    国家城市区号传真号码</menu> <br />--%>
           
              <input type="text" size="4" value="086" id="txtFaxCountryCode" runat="server" />
              <input type="text" size="7" id="txtFaxCityCode" runat="server" />
               <input type="text" id="txtFaxNum" size="18" runat="server"/>           </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><strong>地址：</strong></td>
    <td><input  id="txtAddres" name="txtAddres" type="text" size="45"  runat="server" />    </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><strong>邮政编码：</strong></td>
    <td><input type="text" id="txtZipCode" name="txtZipCode"  size="18" runat="server"  />
    </td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><strong>E-mail：</strong></td>
    <td><input type="text" id="txtEmail" name="txtEmail" size="51"  runat="server" />
        <span class="hui">请填写您最常用的电子邮箱 
      </span></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 166px"><strong>网址：</strong></td>
    <td width="608">
      <input type="text" id="txtNet" name="txtNet" size="45" runat="server"  />  </td>
  </tr> 
</table>  
</div> 
<div class="blank0"></div>
<div class="pad_1" align="center"><asp:Button ID="btnOK" runat="server" CssClass="buttomal" Text="提 交"  OnClientClick="return chkInput();" OnClick="btnOK_Click"></asp:Button>  
<input type="button" value="清 空" onclick="cancel();"  class ="buttomal"/>
</div> 
</div>　
  <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2009px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>  
     <div id="imgLoding2" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1350px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>  
</asp:Content>