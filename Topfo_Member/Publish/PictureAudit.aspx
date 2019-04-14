<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="审核中-图片管理" CodeFile="PictureAudit.aspx.cs" Inherits="PictureAudit" %>

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
            alert("请先选择要进行"+op+"操作的项。");
            return false;
        }
        else
        {
            if(op == "删除")
                if(confirm("删除后将无法恢复，您确定要删除？"))
                {
                    frm  = document.getElementById("aspnetForm");
                    frm.action = "PictureAudit.aspx?op=del";
                    frm.submit();
                }  
        } 
        return true;
  }
 </script> 
<div class="mainconbox">
<div class="titled">
<div class="left">
    图片管理</div>
<div class="clear"></div>
</div>
<div><ul class="handtop">
  <li class="liwai"><a href="PictureAudit.aspx">审核中</a>  </li>
  <li ><a href="PicturePass.aspx">已通过审核</a></li><li> <a href="PictureNoPass.aspx">未通过审核</a> </li> 
</ul>
</div>
<div class=" cshibiank">
<div class="search">
<div class="leight30 ">您共有 <span class="hong">
    <asp:Label ID="LblCount" runat="server" Text=""></asp:Label></span> 条审核中的图片 </div>
  <div class="lefts">资讯筛选：<asp:DropDownList ID="ddlTime" runat="server">
          <asp:ListItem Value="0">选择上传时间</asp:ListItem>
          <asp:ListItem Value="1">最近三天</asp:ListItem>
          <asp:ListItem Value="2">最近一月</asp:ListItem>
          <asp:ListItem Value="3">最近三月</asp:ListItem>
          <asp:ListItem Value="4">三个月以上</asp:ListItem>
      </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlPicType"  runat="server">
          <asp:ListItem Value="1">全部图片</asp:ListItem>
          <asp:ListItem Value="2">原创</asp:ListItem>
          <asp:ListItem Value="3">转载</asp:ListItem>
      </asp:DropDownList>
      <input id="txtKeyWord" runat="server" type="text" />&nbsp;<asp:DropDownList ID="ddlKind"
          runat="server">
          <asp:ListItem Value="1">标题</asp:ListItem>
          <asp:ListItem Value="2">简介</asp:ListItem>
          <asp:ListItem Value="3">标签</asp:ListItem>
      </asp:DropDownList>
      <asp:Button runat="server" ID="btnSelect" Text="筛 选" OnClick="btnSelect_Click" />
     
  </div>
  <div class="clear"></div>
</div> 
<asp:GridView ID="GridView1" DataKeyNames="InfoID" runat="server" Height="100%" width="100%" AutoGenerateColumns="False" PageSize="4" OnRowCommand="GridView1_RowCommand"
           BorderStyle="None" GridLines="None">
        <Columns>  
          <asp:TemplateField>
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                  <input type="checkbox" name="chk" id="chkId" value='<%#((System.Data.DataRowView)Container.DataItem)["InfoID"] %>'  />
                  <input type="hidden" runat="server" id="hidID" value='<%#((System.Data.DataRowView)Container.DataItem)["InfoID"] %>' />
                </ItemTemplate>
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>缩略图</HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="miniImage" runat="server" ImageUrl='<%#((System.Data.DataRowView)Container.DataItem)["MiniatureUrl"]%>' /> 
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField> 
            <asp:TemplateField>
                <HeaderTemplate>图片标题</HeaderTemplate>
                <ItemTemplate>
                    <a href="UpdatePicture.aspx?id=<%#((System.Data.DataRowView)Container.DataItem)["InfoID"] %>" target="_blank">
                    <%#((System.Data.DataRowView)Container.DataItem)["Title"]%></a>
                    <span class="hui"><%#((System.Data.DataRowView)Container.DataItem)["publishT"]%></span>
                </ItemTemplate> 
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            <asp:BoundField HeaderText="类型" DataField="Origin" >
               <HeaderStyle HorizontalAlign="center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField>
                <HeaderTemplate>操作</HeaderTemplate>
                <ItemTemplate>
                    <a href="UpdatePicture.aspx?id=<%#Eval("InfoID") %>" target="_blank">修改</a>
                    <asp:LinkButton ID="LinkButton3" CommandName="cmdDelete" CommandArgument='<%#Eval("InfoID") %>' runat="server" OnClientClick="return confirm('删除后将无法恢复，确实要删除？')">删除</asp:LinkButton>
                    
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="center" />
                <ItemStyle HorizontalAlign="Center" />
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
    <div id="NoMessage" style="display:none; height:100px;" runat="server" >
        您共有<strong><span style="color: #ff9900">0</span></strong>条正在审核中的图片！<br /><a href="PublishPicture.aspx">立即上传图片</a>
</div>
</div>
<div class="pagebox">
     <div class="left" style="width: 227px" id="dvCheck" runat="server">
    <a href="javascript:void(0)" onclick="CheckAll(false,'chk')">全选</a>/<a href="javascript:void(0)" onclick="CheckAll(true,'chk')">反选</a>&nbsp;将选中的图片
    <input type="button" class="buttomal" name="Submit32" onclick="BatchOperate('删除','chk')" value="删除" /> 
    </div>          
        <div class="right" id="pinfo2" runat="server" style="width: 361px"><table><tr><td><span id="pinfo" runat="server"></span></td><td><cc1:AspNetPager ID="AspNetPager" runat="server"  ShowFirstLast="false" ShowPageIndex="false" 
            NextPageText="下一页" OnPageChanged="AspNetPager_PageChanged" PrevPageText="上一页" ShowInputBox="Always" SubmitButtonText="GO">
						</cc1:AspNetPager> </td></tr></table>
        </div> 
       <div class="clear"></div>
</div> 
</div>
</asp:Content>