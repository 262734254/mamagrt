<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StructManage.aspx.cs" Inherits="PayManage_StructManage" MasterPageFile="~/MasterPage.master"%>

<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server" >

 <script type="text/javascript">
        function checkall()//全选
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].type == "checkbox"){
                   all[i].checked = true;
                }
            }
        }
    
        function checknull()//反选
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].checked){
                   all[i].checked = false;
                }
                else{all[i].checked = true;}
            }
        }
        
        function deleteAll()//删除选择的
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++)
            {
                if(all[i].checked)
                {
                    PayManage_StructManage.DeleteID(all[i].name);
                }
            }
            location.href="StructManage.aspx";
        }
 
        function deleteAlloK() {
            var bool = confirm("删除后无法恢复!");
            if (bool == true)
            { deleteAll(); }
        }
        
        
      

        
    </script>
    <script language="javascript" type="text/javascript">
       function a()
        {
         alter("hello");
        }
    </script>
  <div class="mainconbox">
	<div class="topzi">
		<div class="left">专业服务机构</div>
		<div class="clear"></div>
	</div>
	<!--专业服务机构-->
<div class="mycartbox">
		<div class="handtop">
			<ul>
				<li><a href="ServiesManageList.aspx">专业服务需求</a></li>
				<li class="liwai">专业服务机构</li>
				<li><a href="serviesRCList.aspx">专业服务人才</a></li>
			</ul>
	</div>
    <div class="con cshibiank">

				<table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                    	<td width="4%"  align="center" class="tabtitle"><a href="#">选择</a></td>
                        <td class="tabtitle">机构名称</td>
                        <td width="18%" align="center" class="tabtitle">提交日期</td>
                        <td width="15%" align="center" class="tabtitle">状态</td>
                        <td width="30%" align="center" class="tabtitle">状态</td>
                    </tr>
				<asp:Repeater runat="server" ID="StructList">
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                           <input id="Checkbox1" type="checkbox" name='<%#Eval("InfoID") %>' /> </td>
                                        <td class="tabb">
                                           <%#Eval("CompanyName")%>
                                        </td>
                                        <td align="center" class="tabb">
                                             <%#getDate(Eval("SubmitDate").ToString())%>
                                        </td>
                                        <td align="center" class="tabb">
                                              <%#getState(Eval("AuditStatus").ToString())%>
                                        </td>
                                          <td align="left" class="tabb" >
                                            <a href="StructManage.aspx?Servies=<%#Eval("ServiesBID") %>&company=<%#Eval("CompanyName")%>" > 智能匹配</a> | <asp:LinkButton ID="LinkButton1" runat="server" Text="删除"  OnClientClick='return confirm("删除后无法恢复!")' CommandName='<%#Eval("InfoID") %>' OnCommand="delete"></asp:LinkButton>|
                                            <a href="../Publish/PublishNavigateH2.aspx?alt=1&InfoID=<%#Eval("InfoID") %>">修改</a> <a href='http://Union.topfo.com/Shtml/StructShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'><%#((Eval("AuditStatus").ToString()=="1")?"查看":"")%></a></td>
</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                 
			</table>
         
                            <div><div style="float:left;"><a href="javascript:checkall()" class="Aorange02">全选</a>&nbsp;|&nbsp;<a href="javascript:checknull()"
                                    class="Ablue02">反选</a>&nbsp;|&nbsp;<a class="btn" href="javascript:deleteAlloK()">删除</a>
                                总记录：<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条
                                页次：<asp:Literal ID="lblCurrPage" runat="server" Text="1"></asp:Literal>/<asp:Literal
                                    ID="lblPageCount" runat="server" Text="1"></asp:Literal>页</div>
                                <div style="float:right;"><cc1:AspNetPager ID="AspNetPager" runat="server"  ShowFirstLast="false" ShowPageIndex="false" 
            NextPageText="下一页"  PrevPageText="上一页" OnPageChanged="AspNetPager_PageChanged"  ShowInputBox="Always" SubmitButtonText="GO">
						</cc1:AspNetPager>
                                   
                                </div>
						        <div class="clear"></div>
                            </div>
			<div style="border-bottom:1px solid #ccc dashed;" class="topzi">
				<div class="font14">&nbsp;■<strong>专业服务智能匹配结果：</strong></div>
				<div class="clear"></div>
			</div>
			<div style="padding:10px 0 5px 0;">&nbsp;&nbsp;●<span class="chengcu"><asp:Literal
                ID="Literal1" runat="server"></asp:Literal>专业服务需求</span>列表↓<a href="http://union.topfo.com/SetServicesH.aspx">更多</a></div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">
                <td width="15%" class="tabtitle">服务大类</td>
                <td width="17%" class="tabtitle">服务小类</td>
                <td class="tabtitle">单位</td>
                <td width="15%" align="center" class="tabtitle">提交日期</td>
                <td width="10%" align="center" class="tabtitle">价格</td>
                <td width="10%" align="center" class="tabtitle">状态</td>
              </tr>
              
              <asp:Repeater runat="server" ID="ServiesList">
                                <ItemTemplate>
                                    <tr>
                                        <td class="tabb">
                                          <%#getsetServiesBigName(Eval("ServiesBID").ToString())%>  </td>
                                        <td class="tabb">
                                            <%#getServiesSmallName(Eval("ServiesMID").ToString())%>
                                        </td>
                                        <td class="tabb">
                                             <%#Eval("Title").ToString()%>
                                        </td>
                                         <td class="tabb">
                                             <%#getDate(Eval("CreateDate").ToString())%>
                                        </td>
                                         <td class="tabb">
                                             <%#Eval("Price").ToString()%>
                                        </td>
                                        <td class="tabb">
                                          <a href='http://member.topfo.com/PayManage/shopcar.aspx?InfoID=<%#Eval("InfoID") %>'>购买</a>|<a href='http://Union.topfo.com/Shtml/ServiesShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'>查看</a>
                                        </td>
                                          
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
             
             
             
            </table>
    </div>    
  </div>
		
        <div class="blank20"></div>
</div>

</asp:Content>