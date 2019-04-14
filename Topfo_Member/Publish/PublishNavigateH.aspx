<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishNavigateH.aspx.cs" Inherits="PublishNavigateH"  MasterPageFile="~/MasterPage.master"%>
<%@ Register Src="~/Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server" >
 <link href="../css/common.css" rel="stylesheet" type="text/css">
    <script language="javascript" type="text/javascript">
        function GetpSmallType(val)
        {
            document.all('<%=slServerMDrop.ClientID %>').options.length=0;
            document.all('<%=slServerMDrop.ClientID %>').options.add( new Option("请选择服务小类","0"));
            var dt=  PublishNavigateH.GetSmallTypes(val).value;
            
            if (dt  !=   null   &&   typeof (dt)  ==   "object"   &&  dt.Rows.length >0 )
            {   
                for (i = 0; i < dt.Rows.length; i++) 
                {
                    var  myName = dt.Rows[i]["ServiesMName"];
                    var  myId = dt.Rows[i]["ServiesMID"];
                    var item = new Option(myName,myId);
               
                    document.all('<%=slServerMDrop.ClientID %>').options.add( item);
                }
            }
            var objSelect = document.all('<%=slServerMDrop.ClientID %>');
            var objItemValue = '<%=selectsmallvalue%>';
            for (var i = 0; i < objSelect.options.length; i++) {        
                if (objSelect.options[i].value == objItemValue) {        
                    objSelect.options[i].selected = true;
                }        
            }        
        }
        function setun()
        {
            event.returnValue=false;
        }
    </script>
 <div class="area">
            <div class="rightmeun">
                <div class="mar10">
                    <table class="mem_tab1" border="0" cellspacing="0" cellpadding="0" width="90%">
                        <tr>
                            <td valign="top" colspan="2" class="redfuhao" align="left">
                                <span class="f_red strong">发布专业服务需求</span><span class="f_gray">（以下信息均为必填项）</span></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%; height: 8px">
                                标&nbsp;&nbsp;&nbsp;&nbsp;题<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%; height: 8px">
                                <asp:TextBox ID="txtTitle" runat="server" Width="40%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%">
                                服务类别<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%">
                                <asp:DropDownList ID="slServerBDrop" runat="server" onchange="javascript:GetpSmallType(this.value);">
                                </asp:DropDownList>
                                &nbsp;
                                <asp:DropDownList ID="slServerMDrop" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%; height: 103px;">
                                申请说明<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%; height: 103px;">
                                <asp:TextBox ID="txtContent" runat="server" Height="95px" Width="424px" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%; height: 24px;">
                                申 请 人<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%; height: 24px;">
                                <asp:TextBox ID="txtLinkMan" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%">
                                所属地域<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%">
                                <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%; height: 8px">
                                单位名称<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%; height: 8px">
                                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%">
                                地&nbsp;&nbsp;&nbsp;&nbsp;址<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%">
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%">
                                联系电话<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%">
                                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%; height: 24px;">
                                传真号码<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%; height: 24px;">
                                <asp:TextBox ID="txtFix" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" align="left" style="width: 13%">
                                电子邮箱<span class="f_red">*</span></td>
                            <td align="left" style="width: 106%">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2" align="center">
                                
                             <asp:Button ID="btnSubmit" runat="server" Text="提交申请" OnClick="btnSubmit_Click"/>&nbsp;<asp:Button  ID="Update" runat="server" Text="修改"  OnClick="btnUpdate_Click"/>
                               &nbsp;<input type="reset" name="reset" value="重新填写" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <script language="javascript" type="text/javascript">
        function $(id)
        {
            return document.getElementById(id);
        }
       
        function CheckForm(){
            if($("ctl00_ContentPlaceHolder1_txtTitle").value==""){alert('请填写标题.');$("ctl00_ContentPlaceHolder1_txtTitle").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_slServerBDrop").value==""||$("ctl00_ContentPlaceHolder1_slServerBDrop").value==0){alert('请选择服务大类.');$("ctl00_ContentPlaceHolder1_slServerBDrop").focus();return false;}
          //  if($("ctl00_ContentPlaceHolder1_slServerMDrop").value==""||$("ctl00_ContentPlaceHolder1_slServerMDrop").value==0){alert('请选择服务小类.');$("ctl00_ContentPlaceHolder1_slServerMDrop").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtContent").value==""){alert('请填写说明.');$("ctl00_ContentPlaceHolder1_txtContent").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtLinkMan").value==""){alert('请填写申请人.');$("ctl00_ContentPlaceHolder1_txtLinkMan").focus();return false;}
            if($("CountryListCN").value==""||$("CountryListCN").value==0){alert('请选择国家.');$("CountryListCN").focus();return false;}
            if($("provinceCN").value==""||$("provinceCN").value==0){alert('请选择省份.');$("provinceCN").focus();return false;}
            if($("capitalCN").value==""||$("capitalCN").value==0){alert('请选择城市.');$("capitalCN").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtCompany").value==""){alert('请填写单位名称.');$("ctl00_ContentPlaceHolder1_txtCompany").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtAddress").value==""){alert('请填写地址.');$("ctl00_ContentPlaceHolder1_txtAddress").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtTel").value==""){alert('请填写联系电话.');$("ctl00_ContentPlaceHolder1_txtTel").focus();return false;}
            if($("ctl00_ContentPlaceHolder1_txtFix").value==""){alert('请填写传真号码.');$("ctl00_ContentPlaceHolder1_txtFix").focus();return false;}
            
            
            if($("ctl00_ContentPlaceHolder1_txtEmail").value==""){alert('请填写电子邮箱.');$("ctl00_ContentPlaceHolder1_txtEmail").focus();return false;}
            var emailStr = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value;
            var emailPat=/^(.+)@(.+)$/;
            var matchArray = emailStr.match(emailPat);
            if (matchArray==null)
            {
                alert("电子邮件的格式不正确！");
                $("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return false;
            }
        }
        </script>
</asp:Content>