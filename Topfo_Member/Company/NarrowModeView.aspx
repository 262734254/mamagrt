<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NarrowModeView.aspx.cs" Inherits="Company_NarrowModeView" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function DelNav(madeID)
{
   var url="";
   url="NarrowModeView.aspx?AdID="+madeID+"";
 
   window.location.href=url;
}
</script>
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">窄告定制</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absmiddle"/> <a href="http://emarketing.topfo.com/ADbusiness/index.html" target="_blank" class="publica-fbxq">广告服务</a></span></h1>
     <div class="manage" id="sh_con_1">
     <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
     <thead>
                <tr>
                    <td width="18%" align="center" >
                        窄告标题                   </td>
                    <td width="7%" align="center"  >
                        会员类型                    </td>
                     <td width="10%" align="center" >
                       发布时间                   </td>
                    <td width="12%" align="center"  >
                        所对应省                  </td>
                       <td width="12%" align="center"  >
                        管理                  </td> 
                </tr>
                 </thead>
                <asp:Repeater ID="RfList" runat="server" >
                   <ItemTemplate>
                        <tr>
                            <td align="center">
                               <a href="NarrowName.aspx?AdID=<%#Eval("AdID") %>" class="lan1"><%#Eval("Title")%></a>
                            </td>
                             <td align="center">
                               <%#this.TypeName(Convert.ToString(Eval("InfoTypeName")))%>
                            </td>
                            <td align="center">
                                 <%#this.Time(Convert.ToString(Eval("CreateDate")))%>
                          </td>
                            <td align="center">
                                <%#this.ProvinceName(Convert.ToString(Eval("ProvinceID")))%>
                          </td>
                          <td>
                          <a class="lan1" href='JavaScript:DelNav(<%#Eval("AdID") %>);' onclick= "if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} ">删除</a>
                          </td>
                    </ItemTemplate>
                </asp:Repeater>
                </table>

                    <table border="0" width="100%" cellpadding="0" class="fr" cellspacing="0" align="center"  >
                <tr>
                    <td style="width: 20%;" align="left">
                    共<span id="pinfo" style="color:Red" runat="server"></span>条数据
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
                    <input type="button" id="btnAdd" class="btn-002" value="添加" onclick="window.location.href='NarrowAdd.aspx'"/>
                </td>
                </tr>
            </table>

    </div>

      </div>
</div>
</asp:Content>

