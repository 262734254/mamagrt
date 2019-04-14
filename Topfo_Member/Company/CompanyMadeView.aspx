<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyMadeView.aspx.cs" 
Inherits="Company_CompanyMadeView" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function DelNav(madeID,audit)
{
   var url="";
   url="CompanyMadeView.aspx?MadeId="+madeID+"&Audit="+audit+"";
 
   window.location.href=url;
}



</script>
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">广告定制</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="http://emarketing.topfo.com/ADbusiness/index.html" target="_blank" class="publica-fbxq">广告服务</a></span></h1>
     <div class="manage" id="sh_con_1">
     <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
     <thead>
                <tr>
                    <td width="20%" align="center" >
                        广告定制名称                   </td>
                    <td width="10%" align="center"  >
                        总价格                    </td>
                     <td width="10%" align="center" >
                       发布时间                   </td>
                    <td width="12%" align="center"  >
                        广告开始日期                  </td>
                    <td width="12%" align="center" >
                        广告结束日期</td>
                      <td width="10%" align="center" >
                        审核状态</td>  
                   <%-- <td width="7%" align="center" >
                    点击率</td>
                    <td width="9%" align="center" >
                    浏览次数</td>--%>
                    <td width="10%" align="center">
                    管理
                    </td>
                    
                </tr>
                 </thead>
                <asp:Repeater ID="RfList" runat="server" >
                   <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#this.CompanyName(Convert.ToString(Eval("CompanyID")))%>
                            </td>
                             <td align="center">
                               <span class="hong"><%#Eval("SumPrice")%></span>元
                            </td>
                            <td align="center">
                                 <%#this.SetTime(Convert.ToString(Eval("CreateDate")))%>
                          </td>
                            <td align="center">
                                <%#this.SetTime(Convert.ToString(Eval("BeginTime")))%>
                          </td>
                          <td>
                            <%#this.SetTime(Convert.ToString(Eval("EndTime")))%>
                          </td>
                          <td>
                            <%#this.AuditName(Convert.ToInt32(Eval("Audit")))%>
                          </td>
                          <%--<td align="center">
                                <%#Convert.ToString(Eval("Hit"))==""?0:Eval("Hit")%>
                          </td>
                            <td>
                            <%#Convert.ToString(Eval("VisitHit"))==""?0:Eval("VisitHit")%>
                          </td>   --%>
                          <td>
                          <span runat="server" id="SpanID"><%#this.afram(Convert.ToInt32(Eval("Audit")), Convert.ToInt32(Eval("MadeID")))%></span> 
                          <a class="lan1" href="../advertise/ADlaunchInfoView.aspx">查看</a>
                          </td>
                            
                    </ItemTemplate>
                </asp:Repeater>
                </table>

                    <table border="0" width="100%" cellpadding="0" class="fr" cellspacing="0" align="center"  >
                <tr>
                    <td style="width: 20%;" align="left">
                    共<span id="pinfo" style="color:Red" runat="server"></span>个数据
                    </td>
                    <td style="width:80%">
                    <cc1:AspNetPager ID="AspNetPager1" runat="server" ShowFirstLast="false"
                                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页"
                                    ShowInputBox="Always" SubmitButtonText="GO"  Width="479px">
                                </cc1:AspNetPager>
                    </td>
                </tr>
                <tr>
                <td colspan="2" align="left">
                    <input type="button" id="btnAdd" class="btn-002" value="添加" onclick="window.location.href='CompanyMade.aspx'"/>
                </td>
                </tr>
            </table>

    </div>

      </div>
</div>
</asp:Content>

