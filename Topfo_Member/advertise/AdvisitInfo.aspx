<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="AdvisitInfo.aspx.cs" Inherits="advertise_AdvisitInfo" Title="查看已访问的信息" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
  function chakan(Login)
  {
     var url="";
     var name=document.getElementById("ctl00_ContentPlaceHolder1_AdvId").value;
     url="SelLoginName.aspx?Login="+Login+"&adv="+name;
     window.location.href=url;
  }
</script>
<input id="AdvId" runat="server" type="hidden" />
    <div class="mainconbox">

        <div class=" cshibiank">
            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <th width="8%" align="center" class="tabtitle" style="height: 32px">
                        访问者帐号                  </th>
                    <th width="24%" align="center" class="tabtitle" style="height: 32px">
                        访问日期                   </th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <a href="#" onclick='JavaScript:chakan("<%#Eval("LoginID").ToString().Trim()%>");' ><%#Eval("LoginID")%></a>
                            </td>
                             <td align="center">
                               <%#Convert.ToDateTime(Eval("VDate")).ToString()%>
                            </td>
                    </ItemTemplate>
                </asp:Repeater>
          </table>
        </div>
       <div class="pagebox">
           
            <div class="right">
                <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                    PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                    UseCustomDataSource="False" ShowCount="true" SortColumn="PublishT" SortType="DESC"
                    TableViewName="MainInfoVIW" ContentPlaceHolder="ContentPlaceHolder1" KeyColumn="InfoID"
                    ShowPageCount="true"></cc1:Pager>
                &nbsp;</div>
            <div class="clear">
            </div>
        </div>
        </div>
</asp:Content>