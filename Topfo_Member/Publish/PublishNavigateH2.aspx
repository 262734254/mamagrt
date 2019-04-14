<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PublishNavigateH2.aspx.cs" Inherits="PublishNavigateH2" Title="Untitled Page" %>
<%@ Register Src="~/Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="ucl" %>
<%@ Register Src="~/Controls/ServiesControl.ascx" TagName="ServiesControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="../css/common.css" rel="stylesheet" type="text/css">
 <div class="applist">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td style="padding:5px 10px;" class="f_14"><span class="f_red strong">申请提供专业服务</span><span class="f_gray">（带<span class="f_red">*</span>字符号的为必填项）</span></td>
                      </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" class="mem_tab1">
                        <tr>
                            <td class="tdbg">
                                单位名称：</td>
                            <td>
                                <input id="txtCompanyName" runat="server" style="width: 298px" type="text" />
                                <span style="color: #ff6600">*</span></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                所属地域：</td>
                            <td>
                                <ucl:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                机构类别：</td>
                            <td>
                                <asp:DropDownList ID="DropIndustry" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="tdbg">
                                服务类别：</td>
                            <td>
                                <uc2:ServiesControl ID="ServiesMoreControl1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg" style="height: 35px">
                                企业规模：</td>
                            <td style="height: 35px">
                                <input id="txtEmployeeCount" runat="server" type="text" style="width: 61px" />人</td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                注册资金：</td>
                            <td>
                                <input id="txtRegistMoeny" runat="server" type="text" style="width: 60px" />&nbsp;<select
                                    name="select7">
                                    <option>万元</option>
                                </select></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                创建时间：</td>
                            <td>
                                <input id="txtRegistYear" runat="server" type="text" style="width: 60px" />
                                年</td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                营 业 额：</td>
                            <td>
                                <input id="txtTurnover" runat="server" type="text" style="width: 60px" />
                                <select name="select7">
                                    <option>万元</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                主营业务<br />
                                说明：</td>
                            <td>
                                <asp:TextBox ID="txtBusinesDetails" runat="server" Height="71px" TextMode="MultiLine"
                                    Width="400px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="tdbg" style="height: 34px">
                                网 &nbsp; 址：</td>
                            <td style="height: 34px">
                                &nbsp;<input id="txtWebSite" runat="server" type="text" style="width: 246px" /></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                联 系 人：</td>
                            <td>
                                &nbsp;<input id="txtLinkMan" runat="server" type="text" />
                                <span style="color: #ff6600">*</span></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                联系电话：</td>
                            <td>
                                &nbsp;<input id="txtLinkTel" runat="server" type="text" />
                                <span style="color: #ff6600">*</span></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                传真号码：</td>
                            <td>
                                &nbsp;<input id="txtLinkFax" runat="server" type="text" /></td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                电子邮件：</td>
                            <td>
                                &nbsp;<input id="txtEmail" runat="server" type="text" />
                                <span style="color: #ff6600">*</span></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <br />
                                &nbsp;<asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="提交申请" />  &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="修改" /> 
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<input type="reset" name="Submit2"
                                    onclick="" value="重填" /><br />
                              
                            </td>
                        </tr>
                    </table>
                </div>
    <script language="javascript" type="text/javascript">
         function $id(obj)
        {
           return document.getElementById(obj);
        }
        function chkPost()
        {
            if($id("ctl00_ContentPlaceHolder1_txtCompanyName").value==""){alert("请填写公司名称.");$id("ctl00_ContentPlaceHolder1_txtCompanyName").focus();return false;}
            
            if($id("ctl00_ContentPlaceHolder1_DropIndustry").value==""){alert('请选择机构.');return false;}
            if($id("ctl00_ContentPlaceHolder1_ServiesMoreControl1_hdselectBValue").value==""){alert('请选择服务类别.');return false;}
            if($id("ctl00_ContentPlaceHolder1_txtEmployeeCount").value!="")
            {
                if(isNaN($id("ctl00_ContentPlaceHolder1_txtEmployeeCount").value))
                { alert('企业规模请填写数字.');$id("ctl00_ContentPlaceHolder1_txtEmployeeCount").focus();return false;}
            }
            if($id("ctl00_ContentPlaceHolder1_txtRegistMoeny").value!="")
            {
                if(isNaN($id("ctl00_ContentPlaceHolder1_txtRegistMoeny").value))
                { alert('注册资金请填写数字.');$id("ctl00_ContentPlaceHolder1_txtRegistMoeny").focus();return false;}
            }
             if($id("ctl00_ContentPlaceHolder1_txtRegistYear").value!="")
            {
                if(isNaN($id("ctl00_ContentPlaceHolder1_txtRegistYear").value))
                { alert('注册年数请填写数字.');$id("ctl00_ContentPlaceHolder1_txtRegistYear").focus();return false;}
            }
             if($id("ctl00_ContentPlaceHolder1_txtTurnover").value!="")
            {
                if(isNaN($id("ctl00_ContentPlaceHolder1_txtTurnover").value))
                { alert('营业额请填写数字.');$id("ctl00_ContentPlaceHolder1_txtTurnover").focus();return false;}
            }
            if($id("ctl00_ContentPlaceHolder1_txtLinkMan").value==""){alert('请填写联系人.');$id("ctl00_ContentPlaceHolder1_txtLinkMan").focus();return false;}
            if($id("ctl00_ContentPlaceHolder1_txtLinkTel").value==""){alert('请填写联系电话.');$id("ctl00_ContentPlaceHolder1_txtLinkTel").focus();return false;}
            if($id("ctl00_ContentPlaceHolder1_txtEmail").value==""){alert('请填写电子邮箱.');$id("ctl00_ContentPlaceHolder1_txtEmail").focus();return false;}
        }
         
        </script>
</asp:Content>

