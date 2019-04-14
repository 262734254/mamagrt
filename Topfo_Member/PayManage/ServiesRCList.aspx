<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiesRCList.aspx.cs" Inherits="PayManage_ServiesRCList"  MasterPageFile="~/MasterPage.master"%>

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
		<div class="left">专业服务人才</div>
		<div class="clear"></div>
	</div>
	<!--专业服务需求-->
<div class="mycartbox">
		<div class="handtop">
			<ul>
				<li><a href="serviesManageList.aspx">专业服务需求</a></li>
				<li><a href="structManage.aspx">专业服务机构</a></li>
				<li class="liwai">专业服务人才</li>
			</ul>
	</div>
    <div class="con cshibiank">
				<table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">

                        <td align="center" class="tabtitle">姓   名</td>
                        <td align="center" class="tabtitle">提交日期</td>
                        <td align="center" class="tabtitle">状态</td>
                        <td align="center" class="tabtitle">状态</td>
                    </tr>
					
              
              <tr>

                <td class="tabb">
                    <asp:Literal ID="Name" runat="server"></asp:Literal></td>
                <td align="center" class="tabb"> <asp:Literal ID="date" runat="server"></asp:Literal></td>
                <td align="center" class="tabb"> <asp:Literal ID="state" runat="server"></asp:Literal> </td>
                <td align="center" class="tabb">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal><asp:Literal ID="Literal3" runat="server"></asp:Literal> <asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
              </tr>
             
            
                 
	  </table>
           
			<div style="border-bottom:1px solid #ccc dashed;" class="topzi">
				<div class="font14">&nbsp;■<strong>专业服务智能匹配结果：</strong></div>
				<div class="clear"></div>
			</div>
			<div style="padding:10px 0 5px 0;">&nbsp;&nbsp;●<span class="chengcu"><asp:Literal
                ID="Literal1" runat="server"></asp:Literal>专业服务需求</span>列表↓</div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">

                <td width="15%" class="tabtitle">服务大类</td>
                <td width="17%" class="tabtitle">服务小类</td>
                <td class="tabtitle">服务需求名称</td>
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