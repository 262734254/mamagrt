<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishProfessional.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Publish_Professional_PublishProfessional" %>

<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
    <link href="../../offer/css/member.css" rel="stylesheet" type="text/css" />

    <script src="../../offer/js/yanz.js" type="text/javascript"></script>

    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen">发布专业服务需求</span></span><span class="fr"><img
                    src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle" />
                    <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
            <table class="publica" border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>标&nbsp;&nbsp;题：</td>
                    <td>
                        <asp:TextBox ID="txtTitle" Height="22px" runat="server" Width="40%"></asp:TextBox>
                        <span id="spMerchantTopic" style="color: buttonshadow">填写5个字以上</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>所属地域：</td>
                    <td>
                        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>服务类别：</td>
                    <td>
                        <asp:DropDownList ID="ddlServiceType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>申请说明：</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" Height="95px" Width="424px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>项目有效期：</td>
                    <td>
                        <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <strong><span style="font-size: 10pt; color: #ff6705">联系人详细信息</span></strong></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>申 请 人：</td>
                    <td>
                        <asp:TextBox ID="txtLinkMan" Height="22px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>单位名称：</td>
                    <td>
                        <asp:TextBox ID="txtCompany" Height="22px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>手机：</td>
                    <td>
                        <asp:TextBox ID="txtPhone" Height="22px" runat="server"></asp:TextBox>
                        (<span style="color: #808080">为了方便联系，手机和联系电话至少填写一个)</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>联系电话：</td>
                    <td>
                        <asp:TextBox ID="txtcontactsTel" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="43px"></asp:TextBox>-
                        <asp:TextBox ID="txtTel" MaxLength="8" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="95px"></asp:TextBox>-
                        <asp:TextBox ID="txttel2" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="41px"></asp:TextBox><span style="color: #808080">请输入数字</span>
                        格式如:0755-89805588-8028)<font color="red"><span style="color: #808080"> </span></font>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        传真号码</td>
                    <td>
                        <asp:TextBox ID="txtFax" Height="22px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>电子邮箱：</td>
                    <td>
                        <asp:TextBox ID="txtEmail" Height="22px" runat="server"></asp:TextBox>
                        <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        地&nbsp;&nbsp;&nbsp;&nbsp;址：</td>
                    <td>
                        <asp:TextBox ID="txtAddress" Height="21px" Width="239px" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        网址：</td>
                    <td>
                        <asp:TextBox ID="txtSite" runat="server" Height="21px" Width="239px"></asp:TextBox>
                        &nbsp; 如http://www.topfo.com
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>验证码：</td>
                    <td>
                        <input type="text" id="validCode" />
                        <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged"
                            style="width: 80px; cursor: pointer" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="提交申请" CssClass="btn-002" OnClick="btnSubmit_Click" />&nbsp;
                        <%--<asp:Button  ID="Update" runat="server" Text="修改" OnClick="btnUpdate_Click" />--%>
                        <input type="button" id="Button3" onclick="history.back();" class="btn-002" value="返回" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
       
        function CheckForm(){
            if($("<%=txtTitle.ClientID %>").value==""){alert('请填写标题.');$("<%=txtTitle.ClientID %>").focus();return false;}
            
           
            if($("CountryListCN").value==""||$("CountryListCN").value==0){alert('请选择国家.');$("CountryListCN").focus();return false;}
             
            if($("provinceCN").value==""||$("provinceCN").value==0){alert('请选择省份.');$("provinceCN").focus();return false;}
            if($("capitalCN").value==""||$("capitalCN").value==0){alert('请选择城市.');$("capitalCN").focus();return false;} 
            if($("<%=txtContent.ClientID %>").value==""){alert('请填写说明.');$("<%=txtContent.ClientID %>").focus();return false;}
            if($("<%=txtLinkMan.ClientID %>").value==""){alert('请填写申请人.');$("<%=txtLinkMan.ClientID %>").focus();return false;}
            if($("<%=txtCompany.ClientID %>").value==""){alert('请填写单位名称.');$("<%=txtCompany.ClientID %>").focus();return false;}
            
            if($("<%=txtTel.ClientID %>").value.length==0&&$("<%=txtPhone.ClientID %>").value.length==0)
            { alert('手机和电话至少填一个');$("<%=txtPhone.ClientID %>").focus();return false;
             
            }else
            {
             if($("<%=txtTel.ClientID %>").value.length>0){
                var str = $("<%=txtTel.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/; 
    	        //var patn=/^(13|15|18)[0-9]{9}$/;
    	        if(!patn.test(str)){ alert('请正确填写您的联系电话'); $("<%=txtTel.ClientID %>").focus();return false}
    	      }else{
    	      
    	          var pat1=/^(13|15|18)[0-9]{9}$/;
    	      var strPhone = $id("<%=txtPhone.ClientID %>").value;
    	      if(!pat1.test(strPhone)){alert('手机号码填写不正确');$id("<%=txtPhone.ClientID %>").focus();return false;}
            
    	            }
            }
//            if($("<%=txtFax.ClientID %>").value==""){alert('请填写传真号码.');$("<%=txtFax.ClientID %>").focus();return false;}
            if($("<%=txtFax.ClientID %>").value!="")
            {
                var str1 = document.getElementById("<%=txtFax.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/;
    	        if(!patn.test(str1)){ alert('请正确填写您的传真号码'); $("<%=txtFax.ClientID %>").focus();return false}
    	    }
            if($("<%=txtEmail.ClientID %>").value==""){alert('请填写电子邮箱.');$("<%=txtEmail.ClientID %>").focus();return false;}
             if($("<%=txtEmail.ClientID %>").value!="")
             {
                var emailStr = document.getElementById("<%=txtEmail.ClientID %>").value;
                var emailPat=/^(.+)@(.+)$/;
                var matchArray = emailStr.match(emailPat);
                if (matchArray==null)
                {
                    alert("电子邮件的格式不正确！");
                    $("<%=txtEmail.ClientID %>").focus();
                    return false;
                }
            }
              
        if($("validCode").value.toUpperCase() != code )   
       {   
          alert("验证码输入错误！");  createCode();//刷新验证码   
           $("validCode").focus();
       	    return false;
       }   
        document.getElementById("imgLoding").style.display="";
 
        }
          function ValidErr()
            {
                var c="ctl00_ContentPlaceHolder1_";
                alert('验证码错误,请重新输入！');
//                document.getElementById(c+"ImageCode").focus();//.ClientID
//                document.getElementById(c+"ImageCode").select();
                  document.getElementById("ImageCode").focus();//
                  document.getElementById("ImageCode").select();
            }

  function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../../ValidateNumber.aspx?r="+Math.random();
  }
 
    </script>

    <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
        top: 0px; left: 0px; width: 1800px; height: 1559px; filter: alpha(opacity=60);">
        <%--<div class="content">--%>
        <div style="position: absolute; left: 436px; top: 375px;">
            <p>
                数据正在提交,请稍候...</p>
            <img src="../../images/loading42.gif" alt="Loading" />
        </div>
    </div>

    <script language="javascript" type="text/javascript">  createCode();</script>

</asp:Content>
