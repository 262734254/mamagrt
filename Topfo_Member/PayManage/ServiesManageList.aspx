<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServiesManageList.aspx.cs" Inherits="PayManage_ServiesManageList"  MasterPageFile="~/MasterPage.master"%>
<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server" >

 <script type="text/javascript">
        function checkall()//ȫѡ
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].type == "checkbox"){
                   all[i].checked = true;
                }
            }
        }
    
        function checknull()//��ѡ
        {
            var all = document.getElementsByTagName("input");
            for(var i=0;i<all.length;i++){
                if(all[i].checked){
                   all[i].checked = false;
                }
                else{all[i].checked = true;}
            }
        }
        
        function deleteAll()//ɾ��ѡ���
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
            var bool = confirm("ɾ�����޷��ָ�!");
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
		<div class="left">רҵ��������</div>
		<div class="clear"></div>
	</div>
	<!--רҵ��������-->
<div class="mycartbox">
		<div class="handtop">
			<ul>
				<li class="liwai">רҵ��������</li>
				<li><a href="StructManage.aspx" style="text-decoration: none">רҵ�������</a></li>
				<li><a href="serviesRCList.aspx">רҵ�����˲�</a></li>
			</ul>
	</div>
    <div class="con cshibiank">

				<table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                    	<td width="4%"  align="center" class="tabtitle"><a href="#">ѡ��</a></td>
                        <td class="tabtitle">��������</td>
                        <td width="18%" align="center" class="tabtitle">�ύ����</td>
                        <td width="15%" align="center" class="tabtitle">����״̬</td>
                        <td width="25%" align="center" class="tabtitle">״̬</td>
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
                      <a href="ServiesManageList.aspx?Servies=<%#Eval("ServiesBID") %>&Title=<%#Eval("Title") %>" > ����ƥ��</a> | <asp:LinkButton ID="LinkButton1" runat="server" Text="ɾ��" CommandName='<%#Eval("InfoID") %>' OnClientClick='return confirm("ɾ�����޷��ָ�!")' OnCommand="delete"></asp:LinkButton>|<a href="../Publish/PublishNavigateH.aspx?alt=1&InfoID=<%#Eval("InfoID") %>">�޸�</a>
                                          
                                <a href='http://Union.topfo.com/Shtml/ServiesShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'><%#((Eval("AuditStatus").ToString()=="1")?"�鿴":"")%></a>  </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                  
			</table>

            <div><div style="float:left;"><a href="javascript:checkall()" class="Aorange02">ȫѡ</a>&nbsp;|&nbsp;<a href="javascript:checknull()"
                                    class="Ablue02">��ѡ</a>&nbsp;|&nbsp;<a class="btn" href="javascript:deleteAlloK()">ɾ��</a>
                                �ܼ�¼��<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>��
                                ҳ�Σ�<asp:Literal ID="lblCurrPage" runat="server" Text="1"></asp:Literal>/<asp:Literal
                                    ID="lblPageCount" runat="server" Text="1"></asp:Literal>ҳ</div>
                                <div style="float:right;"><cc1:AspNetPager ID="AspNetPager" runat="server"  ShowFirstLast="false" ShowPageIndex="false" 
            NextPageText="��һҳ"  PrevPageText="��һҳ" OnPageChanged="AspNetPager_PageChanged"  ShowInputBox="Always" SubmitButtonText="GO">
						</cc1:AspNetPager></div>
						        <div class="clear"></div>
                            </div>

			<div style="border-bottom:1px solid #ccc dashed;" class="topzi">
				<div class="font14">&nbsp;��<strong>רҵ������������ƥ������</strong></div>
				<div class="clear"></div>
			</div>
			<div style="padding:10px 0 5px 0;">&nbsp;&nbsp;��<span class="chengcu"><asp:Literal ID="Literal1" runat="server"></asp:Literal>רҵ�������</span>�б��  <a href="http://union.topfo.com/ServicesH.aspx">����</a></div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">
                <td width="4%"  align="center" class="tabtitle" style="height: 32px"></td>
                <td class="tabtitle" style="height: 32px">��������</td>
                <td width="18%" align="center" class="tabtitle" style="height: 32px">�ύ����</td>
                <td width="15%" align="center" class="tabtitle" style="height: 32px">����״̬</td>
                <td width="20%" align="center" class="tabtitle" style="height: 32px">״̬</td>
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
                                            <a href='http://Union.topfo.com/Shtml/StructShtml/<%#Eval("InfoID") %>.shtml?InfoID=<%#Eval("InfoID") %>'>�鿴</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
           
            </table>
			<div style="padding:20px 0 5px 0;">&nbsp;&nbsp;��<span class="chengcu"><asp:Literal
                ID="Literal2" runat="server"></asp:Literal>רҵ�����˲�</span>�б�� <a href="http://union.topfo.com/ProsessionList.aspx">����</a></div>
            <table width="100%" align="center" cellspacing="0" class="taba">
              <tr class="tabtitle">
                <td width="4%"  align="center" class="tabtitle"></td>
                <td width="10%" class="tabtitle">����</td>
                <td class="tabtitle">��λ</td>
                <td width="18%" align="center" class="tabtitle">�ύ����</td>
                <td width="15%" align="center" class="tabtitle">����״̬</td>
                <td width="20%" align="center" class="tabtitle">״̬</td>
              </tr>
              <asp:Repeater runat="server" ID="RC"><ItemTemplate>
              
              <tr>
                <td  align="center"></td>
                <td><%#Eval("RealName") %></td>
                <td><%#Eval("NnitName") %></td>
                <td align="center"><%#getDate(Eval("Regdate").ToString())%></td>
                <td align="center"><%#getState(Eval("IsChekUp").ToString())%></td>
                <td align="center"><a href='http://Union.topfo.com/ServiceProsession.aspx?Psid=<%#Eval("PSID") %>&Structid=<%#Eval("TalentType") %>'>�鿴</a></td>
              </tr>
              </ItemTemplate></asp:Repeater>
              
             
            </table>
    </div>    
  </div>
		
        <div class="blank20"></div>
</div>

</asp:Content>