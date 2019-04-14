<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rztopfoAdd.aspx.cs" Inherits="Company_rztopfoAdd" Title="Untitled Page" ValidateRequest="false" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
       <%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="http://member.topfo.com/css/publish.css" rel="stylesheet" type="text/css" />
    <link href="http://member.topfo.com/offer/css/member.css" rel="stylesheet" type="text/css" />

    <script src="http://member.topfo.com/offer/js/yanz.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    //定义整个js命名
function jg(id)
{
   return document.getElementById("ctl00_ContentPlaceHolder1_"+id);
}
//判断
function bus()
{
    var pwd=/\w{5,20}/;
    if(jg("txtUserPwd").value.length==0)
    {
    alert("密码不能为空！");
    jg("txtUserPwd").focus();
            return false;
    }else
    {
        if(!pwd.test(strTrim(jg("txtUserPwd").value)))
        {
            alert("输入的密码格式不正确！");
            jg("txtUserPwd").focus();
            return false;
        }
    }
   // var mob=/^(13\d|15[1,2,5,6,8,9]{1}|18[6,8,9])\d{8}$/;
   var mob=/^(13|15|18)[0-9]{9}$/;
    if(strTrim(jg("txtMobile").value).length!=0)
    {
       if(!mob.test(strTrim(jg("txtMobile").value)))
       {
          alert("输入手机号码格式不正确！");
          jg("txtMobile").focus();
          return false;
       }
   }
   else
   {
        alert("手机不能为空！");
        jg("txtMobile").focus();
        return false;
   }
    var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    if(!filtEmial.test(strTrim(jg("txtEmail").value)))
    {
         alert("电子邮箱格式不正确，请重新输入");
         jg("txtEmail").focus();
         return false;
     }
  if(jg("txtCompanyName").value.length==0)
    {
    alert("企业名称不能为空！");
    jg("txtCompanyName").focus();
    return false;
    }
     if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
	        {
	          alert("请选择所属区域");
	          Zone.focus();
	          return false;
	        }
	        
	                      var Industry = document.getElementById(IndustryId);

	        if(document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	        {
	         alert("请选择所属行业");
	         Industry.focus();
	         return false;
	        }
	        
   var inputCode = document.getElementById("validCode").value;   
   if(inputCode.length <=0)   
   {   
       alert("请输入验证码！"); 
       document.getElementById("validCode").focus();
   	   return false;  
   }   
   else if(inputCode.toUpperCase() != code )   
   {   
      alert("验证码输入错误！");   
      createCode();//刷新验证码   
      document.getElementById("validCode").focus();
   	  return false;
   } 
   jg("imgLoding").style.display="block";
}
//除去字符串中的输入的空格
function strTrim(str){
 str = str.replace(/(^\s*)|(\s*$)/g, "");
 return str;
}
 

    </script>

    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen" runat="server" id="txtTop">融资拓富通申请</span>(带<span
                    class="hong">*</span>为必填项)</span><span class="fr"><img alt="" src="http://img2.topfo.com/member/images/biao_01.gif"
                        align="absMiddle" />
                        <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
            <asp:Panel runat="server" ID="PointOut" Width="602px">
                <span runat="server" id="SpanMessage"></span>
            </asp:Panel>
            <asp:Panel runat="server" ID="CompanyAdd">
                <table width="100%" cellpadding="0" cellspacing="0" class="publica">
                    <tr>
                        <td class="publica-td-left">
                            用户帐号：</td>
                        <td>
                            <span id="txtUserName" runat="server" class="hong"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span class="hong">*</span>用户密码：</td>
                        <td>
                            <input type="password" id="txtUserPwd" runat="server" style="width: 178px" />
                            <span class="hong">请输入会员相同的密码</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span class="hong"></span>电话号码：</td>
                        <td>
                            <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" />
                            <input id="txtTelZoneCode" runat="server" type="text" size='7' />
                            <input id="txtTelNumber" runat="server" type="text" size='18' />
                        </td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span class="hong">*</span>手机号码：</td>
                        <td>
                            <input type="text" id="txtMobile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span class="hong">*</span>电子邮箱：</td>
                        <td>
                            <input type="text" id="txtEmail" runat="server" />
                            <span class="hong">示例:xxxx@xx.com</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span style="color: #ff0000">*</span>企业名称：</td>
                        <td>
                            <input type="text" id="txtCompanyName" runat="server" style="width: 201px" /></td>
                    </tr>
                    <tr>
                        <td class="publica-td-left">
                            <span class="hong">*</span>所属区域：</td>
                        <td style="height: 22px">
                            <uc1:zoneselectcontrol id="ZoneSelectControl1" runat="server" />
                            <input type="text" runat="server" id="ZoneId" style="width: 0; border-color: #FFFFFF;
                                border: 1px solid #FFFFFF" />
                        </td>
                    </tr>
                      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属行业：</td>
        <td>
        <input type="text" runat="server" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF; height:2px;" />
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
            </td>
      </tr>
                    <tr>
                        <td class="publica-td-left">
                            验证码：</td>
                        <td>
                            <input type="text" id="validCode" />
                            <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged"
                                style="width: 80px; cursor: pointer" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" id="pub-tongyi">
                            <input name="" type="checkbox" value="" checked="checked" />
                            <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" class="publica-fbxq">我已阅读并同意《拓富中国招商投资网服务协议》</a>
                            <br />
                            <asp:ImageButton ID="IbtnSubmit" OnClientClick="return bus();" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg"
                                runat="server" OnClick="IbtnSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
        top: 0px; left: 0px; width: 100%; height: 2500px; filter: alpha(opacity=60);"
        runat="server">
        <div class="content" id="llll">
            <p>
                数据正在提交,请稍候...</p>
            <img src="http://member.topfo.com/images/loading42.gif" alt="Loading" />
        </div>
    </div>

    <script language="javascript" type="text/javascript">  createCode();</script>
</asp:Content>

