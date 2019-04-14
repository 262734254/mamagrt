<%@ Page Language="C#" EnableEventValidation="false" ViewStateEncryptionMode="Never"
    AutoEventWireup="true" CodeFile="OrgCollection.aspx.cs" Inherits="helper_OrgCollection"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
<link href="../css/common.css" rel="stylesheet" type="text/css" />


    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的收藏</div>
            <div class="right">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="http://www.topfo.com/help/favorite.shtml#50" target="_blank">如何使用我的收藏</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="InfoCollection.aspx">资源收藏</a></li><li class="liwai">网上展厅收藏</li><li class="linonec">
                    <asp:TextBox ID="tbKey" runat="server" Width="193px">请输入公司名称、发布者等</asp:TextBox>&nbsp;<asp:Button
                        ID="btSearch" runat="server" Text="查询" OnClick="btSearch_Click" /></li></ul>
        </div>
        <div class=" cshibiank">
            <div class="search">
                <div class="lefts">
                    您现在查看的是： &nbsp;<asp:DropDownList ID="ddCreateTime" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddCreateTime_SelectedIndexChanged">
                        <asp:ListItem Value="3">三天内</asp:ListItem>
                        <asp:ListItem Value="7">七天内</asp:ListItem>
                        <asp:ListItem Value="30">一个月内</asp:ListItem>
                        <asp:ListItem Value="90">三个月内</asp:ListItem>
                        <asp:ListItem Value="91">三个月以上</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="rights">
                    每页显示：<asp:LinkButton ID="lbtn10" runat="server" OnClick="lbtn10_Click">10</asp:LinkButton>
                    条
                    <asp:LinkButton ID="lbtn20" runat="server" OnClick="lbtn20_Click">20</asp:LinkButton>
                    条
                    <asp:LinkButton ID="lbtn30" runat="server" OnClick="lbtn30_Click">30</asp:LinkButton>
                    条</div>
                   </div>
                 <div class="left">
              </div>
            </div>
        </div>
        <div id="ListDiv">
            <asp:GridView ID="dgCollection" runat="server" AutoGenerateColumns="False"
                Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                           <a href="javascript:;" onclick="SelectAll()">选择</a>
                        </HeaderTemplate>
                         <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                        <ItemTemplate>
                            <input type="checkbox" name="checkbox" id="checkbox" value='<%#Eval("ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="公司名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CollectOrgName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="Label4" runat="server"  NavigateUrl='<%# Bind("Remrk") %>' Text='<%# Bind("CollectOrgName") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布者">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" ></asp:Label>
                             <%#GetMember(Eval("ContactLoginName"))%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="主营行业">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                             <%#GetIndustry(Eval("IndustryBID"))%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="所属区域">
                   <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                           <%#SetAddress(Eval("CountryCode"), Eval("ProvinceID"), Eval("CityID"), Eval("CountyID"))%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>			
            <asp:Label ID="lbMessage" runat="server"></asp:Label><br />
      
        <div class="pagebox">
          <div class="left" style="width:200px"> <img src="../images/MessageManage/biao_01.gif" width="14" height="16" align="absbottom" /> <a href="javascript:;"
                            onclick="SelectAll()">全选</a>/<a href="javascript:;" onclick="SelectAll()">反选</a> 将选中的资源
         
            <input name="button2" type="button" class="buttomal" id="button2" value="删除" onclick="goRecycle()" />
            
          </div><div class="right" style="width:535px">
                  <cc1:Pager ID="Pager1" runat="server" BackColor="White" BorderStyle="None" ContentPlaceHolder="ContentPlaceHolder1"
                  ControlToAjaxPanel="ListDiv" ControlToPaginate="dgCollection" KeyColumn="ID"
                  PagerStyle="CustomAndNumeric" PagingMode="NonCached" ShowCount="True" SortColumn="CreateDate"
                  SortType="DESC" TableViewName="OrgCollectionTab" Width="504px" /></div>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
       function SelectAll()
       {
	      var a = document.getElementsByTagName("input"); 
	      for (var i=0; i<a.length; i++)
	      {
		    if (a[i].type=="checkbox") 
	         a[i].checked =!a[i].checked;
	      }
	    }
	    function goRecycle()
		{	
			 
			var a = document.getElementsByTagName("input");
			var str="";
			for (var i=0; i<a.length; i++) 
			{
				if (a[i].type == "checkbox")
				{
					if(a[i].checked)
					{
						str+=a[i].value+",";
					}
				}
			}
			if(str!="")
			{
				if(confirm("确定操作吗?将不能恢复"))
				{
					helper_OrgCollection.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("请选选择所要删除的项");
			}
		}
		function backres(res)
		{
		    if(res.value=="ok")
		    {
		        window.location.reload();
		    }
		    else
		    {
		        alert("删除失败!");
		    }
		}
    </script>
</asp:Content>