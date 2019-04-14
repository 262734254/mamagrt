<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMachingMessage.aspx.cs" Inherits="helper_TestMachingMessage" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">搜索定阅</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
    <div class="jl-wxts" runat="server" id="pt">
    <h3><img src="http://img2.topfo.com/member/img/icon_tishi.gif" align="absMiddle" /> 如何设置搜索订阅</h3>
         <p>如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />
            第一时间抢占先机，万千财富滚滚来！ <br />
            如果你想拥有无限数量的订阅，请 <a href="/Register/VIPMemberRegister_In.aspx">申请拓富通会员</a><br />
           </p>
      </div>
      <div runat="server" id="tft" class="jl-wxts">
      <p> 您是拓富通会员，享有无限数量的免费订阅权限 </p>
      </div>
        <h2>
        <ul>
         <li  class="btn_on"  id="sh_btn_1">搜索的订阅</li>
         <li  id="Li1"><a href="MatchingInfo.aspx">我的订阅</a></li>
         </ul>
        </h2>
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
     <div class="manage" id="sh_con_1">
     <asp:UpdatePanel id="UpdatePanel1" runat="server">
       <contenttemplate>
  <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
     <thead>
                <tr>
                    <td align="center"   width="40%">
                        标题
                    </td>
                    <td align="center"  width="18%">
                       发布时间
                    </td>
                    <td align="center"  width="15%">
                        发布人</td>
                    <td align="center"  width="8%">
                        会员价
                    </td>
                    <td align="center"  width="5%">
                        
                    </td>
                    <td align="center"  width="13%">
                        
                    </td>
                </tr>
                 </thead>
                <asp:Repeater id="dgMatching" runat="server">
                        <ItemTemplate>
                            <tr>
                                
                                <td height="9" align="left">
                                    <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        <%#Eval("Title") %>
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%#Eval("PublishT") %>
                                </td>
                                <td height="9" align="center">
                                   <%#Eval("LoginName")%>                                       
                                </td>
                                <td height="9" align="center" style="color:Red;">
                                   <%# isMianFei(Eval("MainPointCount"), "num", Eval("InfoID"))%> 
                                </td>
                                <td height="9" align="center">
                                    <a style="text-decoration:none;" target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        查看
                                    </a>
                                </td>
                                <td height="9" align="center">
                                        <%# isMianFei(Eval("MainPointCount"), "a",Eval("InfoID"))%>
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                               
                                <td height="9" align="left">
                                    <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        <%#Eval("Title") %>
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%#Eval("PublishT") %>
                                </td>
                                <td height="9" align="center">
                                     <%#Eval("LoginName")%>            
                                </td>
                                <td height="9" align="center" style="color:Red;">
                                   <%# isMianFei(Eval("MainPointCount"), "num", Eval("InfoID"))%>
                                                                
                                </td>
                                <td height="9" align="center">
                                    <a style="text-decoration:none;" target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                        查看
                                    </a>
                                </td>
                                <td height="9" align="center">
                                    <%# isMianFei(Eval("MainPointCount"), "a",Eval("InfoID"))%>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                         </table>
         <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tfoot>
          <tr>
            <td colspan="6">
              <span class="fr">
               <cc1:Pager id="Pager1" runat="server" BorderStyle="None" Width="679px" SortType="DESC"
                     PagingMode="NonCached" KeyColumn="InfoID" ControlToAjaxPanel="ListDiv" SortColumn="InfoID" 
                     ShowCount="True" PagerStyle="CustomAndNumeric" ControlToPaginate="dgMatching"
                      ContentPlaceHolder="ContentPlaceHolder1" BackColor="White" PageSize="10" CurrentPageIndex="0"></cc1:Pager> 
                      </span></td>
            </tr>
        </tfoot>
     </table>
</contenttemplate>
            </asp:UpdatePanel>
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
    </form>
</body>
</html>
