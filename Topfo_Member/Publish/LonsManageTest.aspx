<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LonsManageTest.aspx.cs" Inherits="Publish_LonsManageTest" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" align="center" >
    <tr>
        <td align="center" style="height: 24px">编号：
            <input id="txtNuber"  style="width:100px;" type="text"  runat="server" /></td>
        
        <td  align="center" style="height: 24px; width: 122px;">
            类型：
            <asp:DropDownList ID="ddlType" runat="server" >
            <asp:ListItem Value ='2' Selected="True">请选择</asp:ListItem>
                <asp:ListItem Value="0">个人</asp:ListItem>
                <asp:ListItem Value="1">企业</asp:ListItem>
      </asp:DropDownList></td>
       
        <td align="center" style="height: 24px; width: 148px;">状态：
            <asp:DropDownList ID="ddlStatus" runat="server">
             <asp:ListItem Value ='2' Selected="True">请选择</asp:ListItem>
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">审核已通过</asp:ListItem>
                <asp:ListItem Value="3">审核未通过</asp:ListItem>
            </asp:DropDownList></td>
                    <td  align="center" style="height: 24px">
        </td>
        <td   align="center" style="height: 24px">
            <asp:Button ID="btnSearch"   runat="server" Text="搜 索" OnClick="btnSearch_Click" />&nbsp;
            </td>
    </tr>
    </table>
         <table border="0" cellpadding="0" cellspacing="0" align="center" class="one_table"  >
                <tr  style="background:#bcd9e7; height:27px;">
                     <th align="center" class="tabtitle" style="height: 32px; width: 10%;">
                        选择</th>
                      <th width="5%" align="center" class="tabtitle" style="height: 32px">
                        编号</th>
                        <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        标题</th>
                        <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        类型</th>
                         <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        状态</th>
                          <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        发布日期</th>
                          <th width="20%" align="center" class="tabtitle" style="height: 32px">
                        管理</th>
                       
                </tr>
                <asp:Repeater ID="NewsList" runat="server">
                    <ItemTemplate>
                         <tr  onmouseover="this.style.backgroundColor='#f5f5f5';" onmouseout="this.style.backgroundColor=''" >
                        <td style="width: 100px">
                          <label>
                                <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("LoansInfoID")%>" />
                       
                          </label>
                           </td>
                            
                            <td style="width: 100px">
                                        <%#(Eval("LoansInfoID"))%>
                       
                            <td style="width: 180px">
                      <asp:Label ID="Label2" runat="server" ToolTip='<%#Eval("LoansTitle") %>' Text='<%# Eval("LoansTitle").ToString().Length>10?Eval("LoansTitle").ToString().Substring(0,10) + ".....":Eval("LoansTitle").ToString()%>'></asp:Label>

                            </td>
                            <td style="width: 100px">

                                <asp:Label ID="labType" runat="server" Text='<%# GetType(Convert.ToInt32(Eval("BorrowingType"))) %>'></asp:Label>
                            </td>
                            <td style="width: 100px">
                             <asp:Label ID="labstatu" runat="server" Text='<%# GetStatu(Convert.ToInt32(Eval("AuditID"))) %>'></asp:Label>
                            </td>
                               <td style="width: 100px">
                                   <asp:Label ID="Label1" runat="server" Text='<%# GetTime(Convert.ToString(Eval("loansdate"))) %>'></asp:Label> 
                            </td>
                               <td style="width: 140px">          
                           <a href='JavaScript:DelNav("<%#Eval("LoansInfoID") %>");' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                               <a href="javascript:updateloans(<%# Eval("BorrowingType") %>,<%#Eval("LoansInfoID") %>);">修改</a>&nbsp;<a href ="#">匹配</a>&nbsp;<a href ="#">跟进项目</a>
                            </td>
                         
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        <div class="pagebox"> <a href="Javascript:SelectAll();">全选</a>/<a
                    href="Javascript:ReSelect();">反选</a>&nbsp;<asp:Button ID="Button1" runat="server"
                          Text="批量删除"  OnClick="Button1_Click"    /><div style="text-align:right">
            <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                PagerStyle="CustomAndNumeric" ControlToPaginate="NewsList" PagingMode="NonCached"
                UseCustomDataSource="False" ShowCount="True" SortColumn="loansdate" SortType="DESC"
                TableViewName="LoansInfoTab" KeyColumn="LoansInfoID"
                ShowPageCount="False"></cc1:Pager>
                &nbsp;</div>
                </div>
    </div>
    </form>
</body>
</html>
