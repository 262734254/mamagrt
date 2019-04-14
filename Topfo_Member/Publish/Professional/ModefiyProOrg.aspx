<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ModefiyProOrg.aspx.cs" Inherits="Publish_Professional_ModefiyProOrg" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="ucl" %>
<%@ Register Src="../../Controls/ServiesControl.ascx" TagName="ServiesControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
    <script src="../../offer/js/yanz.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>

<div class="member-right">
    <div class="publication">
     <h1><span class="fl"><span class="f_14px strong f_cen">修改专业信息需求</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
     
    
        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="publica">
            <tr>
                <td >
                    标&nbsp;&nbsp;&nbsp;&nbsp;题：<span class="f_red">*</span></td>
                <td align="left" >
                    <asp:TextBox ID="txtTitle" Height="22px" runat="server" Width="45%"></asp:TextBox>
                    <span id="spMerchantTopic" style="color: buttonshadow">填写5个字以上</span>
                    </td>
            </tr>
           
            <tr>
                <td >
                    所属地域：</td>
                <td>
                    <ucl:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td >
                    机构类别：</td>
                <td>
                    <asp:DropDownList ID="DropIndustry" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top" >
                    服务类别：</td>
                <td>
                    <asp:DropDownList ID="ddlServiceType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td >
                    企业规模：</td>
                <td style="height: 35px">
                    <input id="txtEmployeeCount" runat="server" type="text" style="width: 61px; height: 22px;" />人</td>
            </tr>
            <tr>
                <td >
                    注册资金：</td>
                <td>
                    <input id="txtRegistMoeny" runat="server" type="text" style="width: 60px; height: 22px;" />&nbsp;<select
                        name="select7">
                        <option>万元</option>
                    </select></td>
            </tr>
            <tr>
                <td >
                    创建时间：</td>
                <td>
                    <asp:TextBox ID="txtRegistYear"
                        runat="server" Height="20px" ReadOnly="true" Width="82px"></asp:TextBox>
                        <%-- onFocus="WdatePicker({lang:'zh-cn'})" CssClass="Wdate"--%>
                </td>
            </tr>
            <tr>
                <td >
                    营 业 额：</td>
                <td>
                    <input id="txtTurnover" runat="server" type="text" style="width: 60px" />
                    <select name="select7">
                        <option>万元</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td >
                    主营业务<br />
                    说明：</td>
                <td>
                    <asp:TextBox ID="txtBusinesDetails" runat="server" Height="71px" TextMode="MultiLine"
                        Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    有效期：
                </td>
                <td>
                    <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td  colspan="2" style="height: 34px">
                    <strong><span style="font-size: 10pt; color: #ff6705">联系人详细信息</span></strong></td>
            </tr>
            <tr>
                <td >
                    联 系 人：<span style="color: #ff6600">*</span></td>
                <td>
                    <input id="txtLinkMan" style="height: 24px" runat="server" type="text" />
                </td>
            </tr>
             <tr>
                <td >
                    单位名称：<span style="color: #ff6600">*</span></td>
                <td>
                    <input id="txtCompanyName" runat="server" style="height: 23px;" type="text" />
                </td>
            </tr>
            <tr>
                <td >
                    联系电话：<span style="color: #ff6600">*</span></td>
                <td>
                    <input id="txtLinkTel" style="height: 24px" runat="server" type="text" />
                     <span id="Span10" style="color: buttonshadow">为了方便联系，联系电话和手机至少填写一个</span>
                </td>
            </tr>
             <tr>
                <td>
                    手机<span class="f_red">*</span></td>
                <td>
                    <asp:TextBox ID="txtPhone" Height="22px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >
                    传真号码：</td>
                <td>
                    <input id="txtLinkFax" style="height: 24px" runat="server" type="text" /></td>
            </tr>
            <tr>
                <td >
                    电子邮件：</td>
                <td>
                    <input id="txtEmail" runat="server" type="text" style="height: 24px" />
                    <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
                    </td>
            </tr>
             <tr>
                <td >
                    联系地址：</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Columns="40" Width="224px"  Height="21px"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    网 &nbsp; 址：</td>
                <td>
                    <input id="txtWebSite" runat="server" type="text" style="width: 224px; height: 21px;" />
                     &nbsp; 如http://www.topfo.com
                    </td>
            </tr>
           
           <%-- <tr>
                <td align="left"  style="width: 13%">
                    验证码<span class="f_red">*</span></td>
                <td align="left" style="width: 106%">
                    <input type="text" id="validCode" />
                    <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged"
                        style="width: 80px; cursor: pointer" />
                </td>
            </tr>--%>
            <tr>
                <td colspan="2" align="center">
                    <br />
                    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" CssClass="btn-002" Text="修改" />
                    &nbsp;
                    <input type="button" id="Button3" onclick="history.back();" class="btn-002" value="返回" />
                </td>
            </tr>
        </table>
    

    <script language="javascript" type="text/javascript">
         function $id(obj)
        {
           return document.getElementById(obj);
        }
        function chkPost()
        {
        if($id("<%=txtTitle.ClientID %>").value==""){alert('请填写标题.');$id("<%=txtTitle.ClientID %>").focus();return false;}
            
            if($id("CountryListCN").value==""||$id("CountryListCN").value==0){alert('请选择国家.');$id("CountryListCN").focus();return false;}
            if($id("provinceCN").value==""||$id("provinceCN").value==0){alert('请选择省份.');$id("provinceCN").focus();return false;}
            if($id("capitalCN").value==""||$id("capitalCN").value==0){alert('请选择城市.');$id("capitalCN").focus();return false;} 
            if($id("<%=DropIndustry.ClientID %>").value==""){alert('请选择机构.');return false;}
            if($id("<%=ddlServiceType.ClientID %>").value==""){alert('请选择服务类别.');return false;}
            if($id("<%=txtEmployeeCount.ClientID %>").value!="")
            {
                if(isNaN($id("<%=txtEmployeeCount.ClientID %>").value))
                { alert('企业规模请填写数字.');$id("<%=txtEmployeeCount.ClientID %>").focus();return false;}
            }
            if($id("<%=txtRegistMoeny.ClientID %>").value!="")
            {
                if(isNaN($id("<%=txtRegistMoeny.ClientID %>").value))
                { alert('注册资金请填写数字.');$id("<%=txtRegistMoeny.ClientID %>").focus();return false;}
            }
             if($id("<%=txtRegistYear.ClientID %>").value=="")
            {
                //if(isNaN($id("<%=txtRegistYear.ClientID %>").value))
                { alert('请填写注册年数.');$id("<%=txtRegistYear.ClientID %>").focus();return false;}
            }
             if($id("<%=txtTurnover.ClientID %>").value!="")
            {
                if(isNaN($id("<%=txtTurnover.ClientID %>").value))
                { alert('营业额请填写数字.');$id("<%=txtTurnover.ClientID %>").focus();return false;}
            }
            if($id("<%=txtLinkMan.ClientID %>").value==""){alert('请填写联系人.');$id("<%=txtLinkMan.ClientID %>").focus();return false;}
            if($id("<%=txtCompanyName.ClientID %>").value==""){alert("请填写公司名称.");$id("<%=txtCompanyName.ClientID %>").focus();return false;}
            //if($id("<%=txtLinkTel.ClientID %>").value==""){alert('请填写联系电话.');$id("<%=txtLinkTel.ClientID %>").focus();return false;}
            if($id("<%=txtLinkTel.ClientID %>").value.length==0&&$id("<%=txtPhone.ClientID %>").value.length==0)
            { alert('手机和电话至少填一个');$id("<%=txtPhone.ClientID %>").focus();return false;
             
            }else
            {
             if($id("<%=txtLinkTel.ClientID %>").value.length>0){
                var str = $id("<%=txtLinkTel.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/;
    	        if(!patn.test(str)){ alert('请正确填写您的联系电话'); $id("<%=txtLinkTel.ClientID %>").focus();return false}
    	      }else{
    	          if($id("<%=txtPhone.ClientID %>").value.length>0 &&$id ("<%=txtPhone.ClientID %>").value.length<11){alert('手机号码填写不正确.');$id("<%=txtPhone.ClientID %>").focus();return false;}
            }
    	            
            }
            //if($id("<%=txtEmail.ClientID %>").value==""){alert('请填写电子邮箱.');$id("<%=txtEmail.ClientID %>").focus();return false;}
             if($id("<%=txtEmail.ClientID %>").value!=""){
            var emailStr = document.getElementById("<%=txtEmail.ClientID %>").value;
                var emailPat=/^(.+)@(.+)$/;
                var matchArray = emailStr.match(emailPat);
                if (matchArray==null)
                {
                    alert("电子邮件的格式不正确！");
                    $id("<%=txtEmail.ClientID %>").focus();
                    return false;
                }
                }
//            if($id("validCode").value.toUpperCase() != code ) {   
//                  alert("验证码输入错误！");  createCode();//刷新验证码   
//                   $id("validCode").focus();return false;}   
//                document.getElementById("imgLoding").style.display="";
              }
//                  function ValidErr(){
//                        var c="ctl00_ContentPlaceHolder1_";
//                        alert('验证码错误,请重新输入！');
//        //                document.getElementById(c+"ImageCode").focus();//.ClientID
//        //                document.getElementById(c+"ImageCode").select();
//                          document.getElementById("ImageCode").focus();//
//                          document.getElementById("ImageCode").select();
//                    }

          function ChangeValidCode(id)
          {
             document.getElementById(id).src = "../../../ValidateNumber.aspx?r="+Math.random();
          }
 
    </script>
</div>
</div>
    <div id="imgLoding" style="position: absolute; display: none; background-color: #A9A9A9;
            top: -3px; left: 0px; width: 100%; height: 1000px; filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../images/loading42.gif" alt="Loading" />
            </div>
        </div>

    <script language="javascript" type="text/javascript">  createCode();</script>

   
</asp:Content>
