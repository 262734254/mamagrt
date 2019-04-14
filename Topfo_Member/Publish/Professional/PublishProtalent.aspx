<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishProtalent.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Publish_Professional_PublishProtalent" %>

<%--MasterPageFile="~/MasterPage.master"--%>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="ucl" %>
<%@ Register Src="../../Controls/ServiesControl.ascx" TagName="ServiesControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />

    <script src="../../offer/js/yanz.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../../My97DatePicker/WdatePicker.js"></script>

    <%--<form runat="server" id="Form1">--%>
    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen">专业人才需求</span></span><span class="fr"><img
                    src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle" />
                    <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="publica">
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>标题：</td>
                    <td align="left" >
                        <asp:TextBox ID="txtTitle" Height="22px" runat="server" Width="40%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        所属地域：</td>
                    <td>
                        <ucl:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        服务类型：</td>
                    <td>
                        <asp:DropDownList ID="ddlServiceType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        人才类别：</td>
                    <td>
                        <asp:DropDownList ID="DropIndustry" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>职务：
                    </td>
                    <td>
                        <input id="txtPosition" runat="server" type="text" style="width: 113px; height: 23px;" /></td>
                </tr>
                <%--<tr>
                    <td  >
                        创建时间：</td>
                    <td>
                        <asp:TextBox id="txtRegistYear"  onFocus="WdatePicker({lang:'zh-cn'})" CssClass="Wdate" runat="server" Height="23px" Width="119px"></asp:TextBox>
                       
                        </td>
                </tr>--%>
                <tr>
                    <td class="publica-td-left">
                        有效期：
                    </td>
                    <td >
                        <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr id="imageDis" runat="server" style="display: none">
                    <td class="publica-td-left">
                        个人照片：
                    </td>
                    <td valign="middle" >
                        <asp:Image ID="Image1" runat="server" Height="106px" Width="98px"></asp:Image>
                        <%-- <asp:label id="lblImages" runat="server" backcolor="White" bordercolor="White" forecolor="#C00000"></asp:label>--%>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        个人照片：</td>
                    <td>
                        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />
                        &nbsp;<asp:Button ID="btnUpload2" runat="server" CssClass="btn-002" OnClick="btnUpload2_Click"
                            Text="上 传" />
                        <asp:Label ID="LblMessage2" runat="server" BackColor="White" BorderColor="White"
                            ForeColor="#C00000"></asp:Label>
                        <br />
                        <span class="hui">图片须为jpg、bmp、gif格式，大小不超过500K </span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>个人简历：</td>
                    <td>
                        <asp:TextBox ID="txtresume" runat="server" Height="97px" TextMode="MultiLine" Width="543px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>个人特长：</td>
                    <td>
                        <asp:TextBox ID="txtspecialty" runat="server" Height="84px" TextMode="MultiLine"
                            Width="543px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>成功案例：</td>
                    <td>
                        <asp:TextBox ID="txtSuccess" runat="server" Height="84px" TextMode="MultiLine" Width="543px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 22px">
                        <strong><span style="font-size: 10pt; color: #ff6705">联系人详细信息</span></strong></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>联 系 人：</td>
                    <td>
                        <input id="txtLinkMan" style="height: 24px" runat="server" type="text" /></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>单位名称：</td>
                    <td>
                        <input id="txtCompanyName" runat="server" style="height: 21px;" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>手机：</td>
                    <td>
                        <asp:TextBox ID="txtPhone" Height="22px" runat="server"></asp:TextBox>
                        (<span style="color: #808080">为了方便联系，手机和联系电话至少填写一个)</span></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>联系电话：</td>
                    <td>
                        <asp:TextBox ID="txtcontactsTel" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="43px"></asp:TextBox>-
                        <asp:TextBox ID="txtLinkTel" MaxLength="8" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="95px"></asp:TextBox>-
                        <asp:TextBox ID="txttel2" MaxLength="4" Height="20px" onkeyup="value=value.replace(/[^\d]/g,'') "
                            runat="server" Width="41px"></asp:TextBox><span style="color: #808080">请输入数字</span>
                        格式如:0755-89805588-8028)<font color="red"><span
                            style="color: #808080"> </span></font>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        传真号码：</td>
                    <td>
                        <input id="txtLinkFax" style="height: 24px" runat="server" type="text" /></td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>电子邮件：</td>
                    <td>
                        <input id="txtEmail" runat="server" type="text" style="height: 24px" />
                        <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        联系地址：</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Columns="40" Height="21px" Width="261px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        网 &nbsp; 址：</td>
                    <td>
                        <input id="txtWebSite" runat="server" type="text" style="width: 261px; height: 21px;" />
                        &nbsp; 如http://www.topfo.com
                    </td>
                </tr>
                <tr>
                    <td class="publica-td-left">
                        <span class="f_red">*</span>验证码</td>
                    <td >
                        <input type="text" id="validCode" />
                        <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged"
                            style="width: 80px; cursor: pointer" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <br />
                        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" CssClass="btn-002" Text="提交申请" />
                        <%--&nbsp;
                        <input type="reset" name="Submit2" onclick="" class="btn-002" value="重填" /><br />--%>
                        <input type="button" id="Button3" onclick="history.back();" class="btn-002" value="返回" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

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
            if($id("<%=DropIndustry.ClientID %>").value==""){alert('请选择人才类别.');$id("<%=DropIndustry.ClientID %>").focus();return false;}
            if($id("<%=txtPosition.ClientID %>").value==""){alert('请填写职务.');$id("<%=txtPosition.ClientID %>").focus();return false;}
            
            if($id("<%=txtresume.ClientID %>").value==""){alert('请填写个人简历');$id("<%=txtresume.ClientID %>").focus();return false;}
            
            if($id("<%=txtspecialty.ClientID %>").value==""){alert('请填写个人特长');$id("<%=txtspecialty.ClientID %>").focus();return false;}
            if($id("<%=txtSuccess.ClientID %>").value==""){alert('请填写成功案例');$id("<%=txtSuccess.ClientID %>").focus();return false;}
            
            if($id("<%=txtLinkMan.ClientID %>").value==""){alert('请填写联系人.');$id("<%=txtLinkMan.ClientID %>").focus();return false;}
             if($id("<%=txtCompanyName.ClientID %>").value==""){alert("请填写公司名称.");$id("<%=txtCompanyName.ClientID %>").focus();return false;}
           // if($id("<%=txtLinkTel.ClientID %>").value==""){alert('请填写联系电话.');$id("<%=txtLinkTel.ClientID %>").focus();return false;}
            if($id("<%=txtLinkTel.ClientID %>").value.length==0&&$id("<%=txtPhone.ClientID %>").value.length==0)
            { alert('手机和电话至少填一个');$id("<%=txtPhone.ClientID %>").focus();return false;
             
            }else
            {
             if($id("<%=txtLinkTel.ClientID %>").value.length>0){
                var str = $id("<%=txtLinkTel.ClientID %>").value;
    	        var patn = /^[\+0-9]+$/; 
    	        //var patn=/^(13|15|18)[0-9]{9}$/;
    	        if(!patn.test(str)){ alert('请正确填写您的联系电话'); $id("<%=txtLinkTel.ClientID %>").focus();return false}
    	      }else{
    	      var pat1=/^(13|15|18)[0-9]{9}$/;
    	      var strPhone = $id("<%=txtPhone.ClientID %>").value;
    	      if(!pat1.test(strPhone)){alert('手机号码填写不正确');$id("<%=txtPhone.ClientID %>").focus();return false;}
    	          
    	       }    
            }
             if($id("<%=txtEmail.ClientID %>").value==""){alert('电子邮件不能为空');$id("<%=txtEmail.ClientID %>").focus();return false;}
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
            if($id("validCode").value.toUpperCase() != code ) {   
                  alert("验证码输入错误！");  createCode();//刷新验证码   
                   $id("validCode").focus();return false;}   
                document.getElementById("imgLoding").style.display="";
                }
                  function ValidErr(){
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
             
            <div style="position:absolute; left: 436px; top: 375px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../images/loading42.gif" alt="Loading" />
            </div>
        </div>

    <script language="javascript">  createCode();</script>

</asp:Content>
<%--</form>
--%>
