<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MatchInfoList.ascx.cs"
    Inherits="Manage_MatchInfoList" %>
<div class="titled">
    <div class="left">
        <%=this.GetTitle() %>
    </div>
    <div class="clear">
    </div>
</div>
<div class=" cshibiank" style="font-size:13px;">
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" style="font-size:13px;">
        <tbody>
            <tr>
                <td class="tabtitle" style="width: 5%; height: 30px; text-align:center;"> 
                   对比
                  
                </td>
                <td class="tabtitle" align="middle" width="20%" style="height: 30px;text-align:center;">
                    标题
                </td>
                <td class="tabtitle" align="middle" width="10%" style="height: 30px;text-align:center;">
                    发布时间</td>
                    <!--发布行业与区域-->
                   <td class="tabtitle" align="middle" style="width:14%; height:30px;text-align:center;">
                    所属行业</td>
                    <td class="tabtitle" align="middle" width="14%" style="height:30px;text-align:center;">
                    所属区域</td>
                   <td class="tabtitle" align="middle" width="7%" style="height: 30px;text-align:center;">
                    资源价格</td>
                    <td class="tabtitle" align="middle" style="height: 30px; width:7%;text-align:center;">
                        资源保障</td>
                    <!--结束处-->
                <td class="tabtitle" align="middle" style="width:13%; height: 30px;text-align:center;">
                    发布者
                </td>
                <td class="tabtitle" align="middle" style="width:10%; height: 30px;text-align:center;">
                   操作</td>
            </tr>
            <asp:Repeater ID="RfInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="tab" align="middle">
                        <asp:CheckBox ID="CheckBox1" runat="server" /><input  type="hidden"  id="txtID"   runat="server"   value='<%# Eval("InfoID")%>'/>
                        </td>
                        <td class="tab" align="left">
                            <a href="<%#this.wwwdomain + @"/" + Eval("HtmlFile") %>" target="_blank">
                                <%#Eval("Title") %>
                            </a><a href="#"></a>
                        </td>
                        <td class="tab" align="middle">
                            <%#Convert.ToDateTime(Eval("PublishT")).ToString("yyyy-MM-dd") %>
                        </td>
                        <!--区域与行业-->
                        <td class="tab" align="middle">
                      
                        <%#GetIndustry(Eval("IndustryBID").ToString().Trim())%>
                        </td>
                        
                        <td class="tab" align="middle">
                       
                        <%#GetCounty(Eval("ProvinceID").ToString().Trim())%>
                        </td>
                        <td class="tab" align="middle">
                       <%#Eval("MainPointCount")%>   
                        </td>
                        <td class="tab" align="middle">
                       <%#GetRenZheng(Eval("AuditingStatus"))%>
                        
                        </td>
                        <!--结束处-->
                        
                        <td class="tab" align="middle">
                            <label title="">
                                <%#Eval("LoginName")%>
                            </label>
                        </td>
                        <td class="tab" align="middle">
                            &nbsp;<a href='../helper/CollectingInfo.aspx?infoid=<%#Eval("InfoID") %>'>收藏</a>&nbsp;<a href="<%#this.wwwdomain + @"/" + Eval("HtmlFile") %>" target="_blank">查看</a></td>
                    </tr>
                   
                </ItemTemplate>
                <FooterTemplate> 
                
                </FooterTemplate>
            </asp:Repeater>
            
                
               
        </tbody>
    </table>
              
               <ul style="list-style-type:none; width:600px; float:left; margin:0px; margin-top:10px;">
               <li style=" width:180px; height:25px; float:left; margin:0px;">
               <img src="../images/MessageManage/biao_01.gif" width="14" height="16" />
          <label>
            <asp:LinkButton ID="btnMore" runat="server" Text = "查看更多相关资源"></asp:LinkButton>
           </label></li>
               <li style=" width:100px; height:25px; float:left; margin:0px; line-height:23px;">将选中的资源</li>
               
               <li style=" width:100px; height:25px; float:left; margin:0px;"><asp:Button ID="Button1" runat="server" Text="对比资源" OnClick="Button1_Click" /></li>
                <li style=" width:100px; height:25px; float:left; margin:0px;"><asp:Button ID="BtnGouWuCar" runat="server" Text="放入购物车" OnClick="BtnGouWuCar_Click" /></li>
                <li style=" width:100px; height:25px; float:left; margin:0px;"><asp:Button ID="BtnQGou" runat="server" Text="马上购买" OnClick="BtnQGou_Click" /></li>
                </ul>
                
                

</div>
<div class="blank10">&nbsp;</div>