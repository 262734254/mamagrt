    <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" EnableViewStateMac="false" CodeFile="NewsAudit.aspx.cs" Inherits="NewsAudit" Title="�����-��Ѷ����" %>

<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<script type="text/javascript">
  function BatchOperate(op)
  {
        chks = document.getElementsByName("chk");
        var count = 0;
        
        for(i=0; i < chks.length; i++)
        {
            if(chks[i].checked)
                count++;
        }
        
        if(count == 0)
        {    
            alert("����ѡ��Ҫ����"+op+"�������");
            return false;
        }
        else
        {
            if(op == "ɾ��")
                if(confirm("ɾ�����޷��ָ�����ȷ��Ҫɾ����"))
                {
                    frm  = document.getElementById("aspnetForm");
                    frm.action = "NewsAudit.aspx?op=del";
                    frm.submit();
                }  
        } 
        return true;
  }
 </script>   
<div class="mainconbox">
<div class="titled">
<div class="left">��Ѷ����</div>
<div class="clear"></div>
</div>
<div><ul class="handtop">
  <li class="liwai"><a href="NewsAudit.aspx">�����</a>  </li>
  <li><a href="NewsPass.aspx">��ͨ�����</a></li><li> <a href="NewsNopass.aspx">δͨ�����</a> </li> 
</ul>
</div>
<div class=" cshibiank">
<div class="search">
<div class="leight30 ">������ <span class="hong">
    <asp:Label ID="LblCount" runat="server" Text=""></asp:Label></span> ������е���Ѷ </div>
  <div class="lefts" style="width: 735px">��Ѷɸѡ��<asp:DropDownList ID="ddlTime" runat="server">
          <asp:ListItem Value="0">ѡ�񷢲�ʱ��</asp:ListItem>
          <asp:ListItem Value="1">�������</asp:ListItem>
          <asp:ListItem Value="2">���һ��</asp:ListItem>
          <asp:ListItem Value="3">�������</asp:ListItem>
          <asp:ListItem Value="4">����������</asp:ListItem>
      </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlType" DataTextField="NewsTypeName" DataValueField="NewsTypeID" runat="server" 
          Width="86px">
      </asp:DropDownList>
      <input id="txtKeyWord" runat="server" type="text" />&nbsp;<asp:DropDownList ID="ddlKind"
          runat="server">
          <asp:ListItem Value="1">ȫ��</asp:ListItem>
          <asp:ListItem Value="2">����</asp:ListItem>
      </asp:DropDownList>
      <asp:Button runat="server" ID="btnSelect" Text="ɸ ѡ" OnClick="btnSelect_Click" />
     
  </div>
  <div class="clear"></div>
</div> 
<asp:GridView ID="GridView1" DataKeyNames="InfoID" runat="server" Height="100%" width="100%" AutoGenerateColumns="False" PageSize="4" OnRowCommand="GridView1_RowCommand"
          BorderStyle="None" GridLines="None">
        <Columns>  
          <asp:TemplateField>
                <HeaderTemplate>ȫѡ</HeaderTemplate>
                <ItemTemplate>
                  <input type="checkbox" name="chk" id="chkId" value='<%#((System.Data.DataRowView)Container.DataItem)["InfoID"] %>'  />
                  <input type="hidden" runat="server" id="hidID" value='<%#((System.Data.DataRowView)Container.DataItem)["InfoID"] %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>����</HeaderTemplate>
                <ItemTemplate>
                    <a href="<%#Eval("strHref") %>" target="_blank">
                    <%#((System.Data.DataRowView)Container.DataItem)["Title"]%></a>
                   
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField> 
              <asp:TemplateField>
                <HeaderTemplate>����ʱ��</HeaderTemplate>
                <ItemTemplate>
                 <%# Convert.ToDateTime(Eval("publishT")).ToShortDateString()%> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>   
            <asp:BoundField HeaderText="����" DataField="NewsTypeName" >
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField>
                <HeaderTemplate>����</HeaderTemplate>
                <ItemTemplate>
                     <a href="<%#Eval("strHref") %>" target="_blank">�޸�</a>
                    <asp:LinkButton ID="LinkButton3" CommandName="cmdDelete" CommandArgument='<%#Eval("InfoID") %>' runat="server" OnClientClick="return confirm('ɾ�����޷��ָ���ȷʵҪɾ����')">ɾ��</asp:LinkButton>
                    
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <PagerSettings Visible="False" />
        <HeaderStyle CssClass="tabtitle"  Height="30px"/> 
    </asp:GridView> 
    <div id="NoMessage" style="display:none;height:100px;" runat="server" >
        ������<strong><span style="color: #ff9900">0</span></strong>����������е���Ѷ��<br /><a href="PublishNews.aspx">����������Ѷ</a>
</div>
</div>
<div class="pagebox">
     <div class="left" style="width: 227px" id="dvCheck" runat="server">
    <a href="javascript:void(0)" onclick="CheckAll(false,'chk')">ȫѡ</a>/<a href="javascript:void(0)" onclick="CheckAll(true,'chk')">��ѡ</a>&nbsp;��ѡ�е���Ѷ    
    <input type="button" class="buttomal" name="Submit32" onclick="BatchOperate('ɾ��','chk')" value="ɾ��" /> 
    </div>          
        <div class="right" id="pinfo2" runat="server" style="width: 361px"><table><tr><td><span id="pinfo" runat="server"></span></td><td><cc1:AspNetPager ID="AspNetPager" runat="server"  ShowFirstLast="false" ShowPageIndex="false" 
            NextPageText="��һҳ" OnPageChanged="AspNetPager_PageChanged" PrevPageText="��һҳ" ShowInputBox="Always" SubmitButtonText="GO">
						</cc1:AspNetPager> </td></tr></table>
        </div> 
       <div class="clear"></div>
</div> 
</div> 
</asp:Content>