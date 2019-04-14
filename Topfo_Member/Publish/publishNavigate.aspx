<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="publishNavigate.aspx.cs" Inherits="Publish_publishNavigate" Title="需求发布" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<link href="/css/publish.css" rel="stylesheet" type="text/css" />

    <link href="../css/common.css" rel="stylesheet" type="text/css" />--%>
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布需求 </div>
            <div class="right">
                </div>
            <div class="clear">
            </div>
        </div>
        <div class="titlesbox">
            <img src="../images/icon_yb.gif" width="17" height="17" />
            请选择发布类型
        </div>
        <!--创业发布 -->
        <div class="blank20">
            <div class="titlepub">
                融资·招商·投资</div> 
        </div>
        <div class="publisha ">
            金额<span class="hong">100万元人民币以上</span>的招投融需求请在此栏发布


            <p>
              <asp:Panel CssClass="float_all"  Width="170px" id="plProject" runat="server"  >
                <asp:ImageButton ID="IbtnPublishProject" ImageUrl="../images/publish/buttom_project1.gif" runat="server" OnClick="IbtnPublishProject_Click"   />
                <asp:ImageButton ID="ImageButton1" ImageUrl="../images/publish/buttom_project2.gif" runat="server" OnClick="ImageButton1_Click"    />
               </asp:Panel>
             
               <asp:Panel id="plCapital" runat="server" Width="170px" CssClass="float_all">
                <asp:ImageButton ID="IbtnPublishCapital" ImageUrl="../images/publish/buttom_capital.gif" runat="server" OnClick="IbtnPublishCapital_Click" />
               </asp:Panel>
           </p>
		   <div class="clear"></div>
        </div>
        <div class="blank20">
            <div class="titlepub">
                创业</div>
        </div>
        <div class="publisha">
            金额<span class="hong">100万元人民币以内</span>的创业需求请在此栏发布


            <div class="incdiv">
              
                <div class="left">
                    包括：各种<a href="PublishCarveOutFindFund.aspx" target="_blank" class="lanlink">创业资金</a>需求和<a href="PublishCarveOutFindProject.aspx" target="_blank" class="lanlink">创业项目</a>需求</div>
                <div class="right">
                    <a href="PublishCarveOutFindFund.aspx" target="_blank" class="lanlink">我要找资金</a></div><div class="right"> <a href="PublishCarveOutFindProject.aspx" target="_blank" class="lanlink">我要找项目</a></div>
                <div class="clear">
                </div>
          </div>
        </div>
        <!--商机发布 -->
        <div class="blank20">
            <div class="titlepub">
                商机</div>
        </div>
        <div class="publisha">
            <div class="incdiv">
                <div class="left">
                    包括：各种产品供求、代理、加盟、技术、服务等需求发布<strong> </strong>
                </div>
                <div class="right">
                    <a href="http://www.topfo.com/Member/Info/PublishOppor.aspx" target="_blank" class="lanlink">立即发布</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>

