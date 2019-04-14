<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectRecordSee.aspx.cs" Inherits="Subject_SubjectRecordSee" Title="Untitled Page" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function Login(name)
{
var sub=document.getElementById("ctl00_ContentPlaceHolder1_ComID").value;
   var url;
   url="SubjectRecordName.aspx?LoginName="+name+"&Sub="+sub+"";
   window.location.href=url;
}
</script>
<input type="hidden" runat="server" id="ComID" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">专题推广</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
     <div class="manage" runat="server" id="pointId">

    </div>
<div  id="divId" runat="server" >
        <h2>
        <ul>
         <li  class="btn_on"  id="sh_btn_1">访问者记录信息</li>
          <li id="Li1"><a href="SubjectSee.aspx">我的专题</a></li>
         </ul>
        </h2>
     <div class="manage" id="sh_con_1">
  <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
     <thead>
                <tr>
                    <td align="center"   width="20%">
                        访问者
                    </td>
                    <td align="center"  width="20%">
                       访问时间
                    </td>
                    <td align="center"  width="20%">
                        访问IP</td>
                    <td align="center"  width="25%">
                        访问对应城市
                    </td>
                    <td align="center" width="10%">
                       操作
                    </td>
                </tr>
                 </thead>
                <asp:Repeater id="dgMatching" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td >
                               <a href='JavaScript:Login("<%#Eval("RecordName")%>")'class="lan1"><%#Eval("RecordName")%></a>
                                </td>
                                <td align="left">
                                    <%#Eval("RecordTime")%>
                                </td>
                                <td align="center">
                                    <%#Eval("RecordIP")%>
                                </td>
                                <td align="center">
                                  <%#Eval("RecordCity")%>                                
                                </td>
                                <td align="center">
                                <a href='JavaScript:Login("<%#Eval("RecordName")%>")' class="lan1">查看</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                         </table>
                         共<span id="pinfo" style="color:Red" runat="server"></span>个访问者
                         <span class="fr">
               <cc1:AspNetPager ID="AspNetPager1" runat="server" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" 
                                    ShowInputBox="Always" ShowFirstLast="false" SubmitButtonText="GO" >
                                </cc1:AspNetPager>
                      </span><br />
    </div>
</div>
    <div class="zhuyi">
     <h3><span class="fl" style="margin:2px 10px 0 0"><img src="http://img2.topfo.com/member/images/manage_23.jpg"  /></span> <span class="fl" >注意事项</span></h3>
   <p>
                · 您可以修改您发布的需求，但修改后的内容需要经过我们的审核才能出现在网上。
                <br>
                · 经常刷新您发布的需求，可以让需求尽量排在同类信息的前面！刷新功能为拓富通会员专享。1元钱体验拓富通会员服务 <a href="/Register/VIPMemberRegister.aspx" target="_blank" class="publica-fbxq">申请拓富通</a>
                <br>
                · 您可以通过设置，指示系统将匹配的资源通过邮件或站内短信的形式发送给您！<a href="/helper/Notice.aspx" class="publica-fbxq">点此立即设置 </a>
                <br>

            </p>
    </div>
      </div>
</div>
</asp:Content>

