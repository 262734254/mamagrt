<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiesManageList.aspx.cs" Inherits="PayManage_ServiesManageList"  MasterPageFile="~/MasterPage.master"%>
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
                    PayManage_ServiesManageList.DeleteID(all[i].name);
                }
            }
            location.href="ServiesManageList.aspx";
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
		<div class="left">专业服务需求</div>
		<div class="clear"></div>
	</div>
	<!--专业服务需求-->
<div class="mycartbox">
		<div class="handtop">
			<ul>
				<li class="liwai">专业服务需求</li>
				<li><a href="StructManage.aspx" style="text-decoration: none">专业服务机构</a></li>
				<li><a href="serviesRCList.aspx">专业服务人才</a></li>
			</ul>
	</div>
    <div class="con cshibiank">

				<table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                    	<td width="4%"  align="center" class="tabtitle"><a href="#">选择</a></td>
                        <td class="tabtitle">需求名称</td>
                        <td width="18%" align="center" class="tabtitle">提交日期</td>
                        <td width="15%" align="center" class="tabtitle">需求状态</td>
                        <td width="25%" align="center" class="tabtitle">状态</td>
                    </tr>
					  <asp:Repeater runat="server" ID="ServiesList">
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                           <input id="Checkbox1" type="checkbox" name='<%#Eval("InfoID") %>' /> </td>
                                        <td class="tabb">
                                            <%#Eval("Title") %>
                                        </td>
                                        <td align="center" class="tabb">
                                             <%#getDate(Eval("CreateDate").ToString())%>
                                        </td>
                                        <td align="center" class="tabb">
                                            <%#getState(Eval("AuditStatus").ToString())%>
                                        </td>
                                          <td align="left" class="tabb">
                      <a href="ServiesManageList.aspx?Servies=<%#Eval("ServiesBID") %>&Title=<%#Eval("Title") %>" > 智能匹配</a> | <asp:LinkButton ID="LinkButton1" runat="server" Text="删除" CommandName='<%#Eval("InfoID") %>' OnClientClick='return confirm("删除后无法恢复!")' OnCommand="delete"></asp:LinkButton>|<a href="../Publish/PublishNavigateH.aspx?alt=1&InfoID=<%#Eval("InfoID") %>">修改</a>
                                          
                                <a href='http://Union.topfo.com/Shtml/ServiesShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'><%#((Eval("AuditStatus").ToString()=="1")?"查看":"")%></a>  </td>
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
						</cc1:AspNetPager></div>
						        <div class="clear"></div>
                            </div>

			<div style="border-bottom:1px solid #ccc dashed;" class="topzi">
				<div class="font14">&nbsp;■<strong>专业服务需求智能匹配结果：</strong></div>
				<div class="clear"></div>
			</div>
			<div style="padding:10px 0 5px 0;">&nbsp;&nbsp;●<span class="chengcu"><asp:Literal ID="Literal1" runat="server"></asp:Literal>专业服务机构</span>列表↓  <a href="http://union.topfo.com/ServicesH.aspx">更多</a></div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">
                <td width="4%"  align="center" class="tabtitle" style="height: 32px"></td>
                <td class="tabtitle" style="height: 32px">机构名称</td>
                <td width="18%" align="center" class="tabtitle" style="height: 32px">提交日期</td>
                <td width="15%" align="center" class="tabtitle" style="height: 32px">需求状态</td>
                <td width="20%" align="center" class="tabtitle" style="height: 32px">状态</td>
              </tr>
              <asp:Repeater runat="server" ID="StructList">
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                          </td>
                                        <td class="tabb">
                                            <%#Eval("CompanyName")%>
                                        </td>
                                        <td align="center" class="tabb">
                                             <%#getDate(Eval("SubmitDate").ToString())%>
                                        </td>
                                        <td align="center" class="tabb">
                                            <%#getState(Eval("AuditStatus").ToString())%>
                                        </td>
                                          <td align="center" class="tabb">
                                            <a href='http://Union.topfo.com/Shtml/StructShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'>查看</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
           
            </table>
			<div style="padding:20px 0 5px 0;">&nbsp;&nbsp;●<span class="chengcu"><asp:Literal
                ID="Literal2" runat="server"></asp:Literal>专业服务人才</span>列表↓ <a href="http://union.topfo.com/ProsessionList.aspx">更多</a></div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">
                <td width="4%"  align="center" class="tabtitle"></td>
                <td width="10%" class="tabtitle">姓名</td>
                <td class="tabtitle">单位</td>
                <td width="18%" align="center" class="tabtitle">提交日期</td>
                <td width="15%" align="center" class="tabtitle">需求状态</td>
                <td width="20%" align="center" class="tabtitle">状态</td>
              </tr>
              <asp:Repeater runat="server" ID="RC"><ItemTemplate>
              
              <tr>
                <td  align="center"></td>
                <td><%#Eval("RealName") %></td>
                <td><%#Eval("NnitName") %></td>
                <td align="center"><%#getDate(Eval("Regdate").ToString())%></td>
                <td align="center"><%#getState(Eval("IsChekUp").ToString())%></td>
                <td align="center"><a href='http://Union.topfo.com/ServiceProsession.aspx?Psid=<%#Eval("PSID") %>&Structid=<%#Eval("TalentType") %>'>查看</a></td>
              </tr>
              </ItemTemplate></asp:Repeater>
              
             
            </table>
    </div>    
  </div>
		
        <div class="blank20"></div>
</div>

</asp:Content>