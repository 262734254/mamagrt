<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false"  AutoEventWireup="true" CodeFile="ADlaunchInfoView.aspx.cs" Inherits="advertise_ADlaunchInfoView" Title="广告管理" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <link href="../css/CRM.css" rel="stylesheet" type="text/css" />--%>
    <script language="javascript" type="text/javascript">
     function DelSee(id)
     {
        var url="";
        url="AdvisitInfo.aspx?adv="+id;
        window.location.href=url;
        
     }
    </script>
        <div class="mainconbox">
 <h1><span class="fl"><span class="f_14px strong f_cen">广告管理</span></span><span class="fr"><img src="images/biao_01.gif" align="absmiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
        <div class=" cshibiank">

            <table width="100%" border="0" align="center" class="one_table"  cellpadding="0" cellspacing="0">
                <tr>
                    <th width="8%" align="center" class="tabtitle" style="height: 32px">
                        频道名称                   </th>
                    <th width="24%" align="center" class="tabtitle" style="height: 32px">
                        广告名称                    </th>
                     <th width="10%" align="center" class="tabtitle" style="height: 32px">
                       广告序号                   </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        开始日期                  </th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                        结束日期</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    访问量</th>
                    <th width="10%" align="center" class="tabtitle" style="height: 32px">
                    备注</th>
                    <th width="15%" align="center" class="tabtitle" style="height: 32px">
                        管理
                    </th>
                </tr>
                <asp:Repeater ID="RfList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#this.SelBName(Convert.ToInt32(Eval("BID")))%>
                            </td>
                             <td align="center">
                               <%#Eval("TypeName")%>
                            </td>
                            <td align="center">
                                 <%#Eval("SerialID")%>
                          </td>
                            <td align="center">
                                <%#this.selTime(Convert.ToDateTime(Eval("Stardate")))%>
                          </td>
                          <td>
                            <%#this.selTime(Convert.ToDateTime(Eval("enddate")))%>
                          </td>
                          <td align="center">
                                <%#Eval("countID")%>
                          </td>
                            <td>
                            <%#this.StrLength(Eval("addoc"))%>
                          </td>   
                            <td align="center">
                            <a href='JavaScript:DelSee("<%#Eval("advertiserID") %>");'>查看</a>

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
                    ShowPageCount="true" ></cc1:Pager>
                &nbsp;</div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
