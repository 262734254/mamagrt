<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectSee.aspx.cs" Inherits="Subject_SubjectSee" Title="Untitled Page" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function My(id,ad)
 {
    if(ad !="1")
    {
    var url;
    url="SubjectAdd.aspx?Sub=Modify&id="+id+"";
    window.location.href=url;
    }else
    {
       alert("该专题已经发布在展示，不能修改，如果要修改。\n\r请拨打服务热线电话0755-89805588");
    }
 } 
 function Record(id,ad)
 {
    if(ad =="1")
    {
        var url;
        url="SubjectRecordSee.aspx?id="+id+"";
        window.location.href=url;
    }else
    {
       alert("该专题不是审核通过状态，不存在访问者！\n\r如您希望尽快得到展示，请拨打服务热线电话0755-89805588");
    }
 }
 function Extend(id,ad)
 {
    if(ad =="1")
    {
        var url;
        url="ExtendAddressSee.aspx?id="+id+"";
        window.location.href=url;
    }else
    {
       alert("该专题不是审核通过状态，不存在有推广地址！\n\r如您希望尽快得到展示，请拨打服务热线电话0755-89805588");
    }
 }
</script>
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">专题推广</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
     <div class="manage" runat="server" id="pointId">

    </div>
<div  id="divId" runat="server" >
        <h2>
        <ul>
         <li  class="btn_on"  id="sh_btn_1">我的专题</li>
         <li ><a href="SubjectAdd.aspx?Sub=add">发布专题</a></li>
         </ul>
        </h2>
     <div class="manage" id="sh_con_1">
  <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
     <thead>
                <tr>
                    <td align="center"   width="20%">
                        专题标题
                    </td>
                    <td align="center"  width="15%">
                       发布时间
                    </td>
                    <td align="center"  width="10%">
                        状态</td>
                    <td align="center"  width="25%">
                        操作
                    </td>
                </tr>
                 </thead>
                <asp:Repeater id="dgMatching" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td >
                                <%#Eval("SubTitle") %>
                                </td>
                                <td align="left">
                                    <%#Eval("SubTime")%>
                                </td>
                                <td align="center">
                                    <%#this.Audit(Convert.ToString(Eval("Audit"))) %>
                                </td>
                                <td align="center">
                                   <a class="lan1" href='JavaScript:Extend(<%#Eval("SubID")%>,<%#Eval("Audit") %>)'>查看推广</a> 
                                   <a class="lan1" href='JavaScript:Record(<%#Eval("SubID")%>,<%#Eval("Audit") %>)'>查看访问者</a>
                                   <a class="lan1" href='JavaScript:My(<%#Eval("SubID")%>,<%#Eval("Audit") %>)'>修改</a> 
                                                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                         </table>
                         共<span id="pinfo" style="color:Red" runat="server"></span>条数据
                         <span class="fr">
               <cc1:AspNetPager ID="AspNetPager1" runat="server" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" 
                                    ShowInputBox="Always" ShowFirstLast="false" SubmitButtonText="GO" >
                                </cc1:AspNetPager>
                      </span><br />
     <input type="button" class="btn-002" value="添加" onclick="window.location.href='SubjectAdd.aspx?Sub=add'" />
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

