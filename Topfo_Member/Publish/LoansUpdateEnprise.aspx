<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoansUpdateEnprise.aspx.cs" Inherits="Publish_LoansUpdateEnprise" Title="Untitled Page" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../Register/Js/JScriptYanzheng.js" ></script>
        <script type ="text/javascript" language ="javascript" src="../Register/Js/JScriptpricename.js" ></script>
    <script language ="javascript" type="text/javascript" >

    </script>
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">修改企业贷款</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
            <tr>
                <td width="133" align="right" >
                    <span class="hong">*</span> <strong>贷款标题：</strong></td>
                <td width="625">
                    <strong>
                        <asp:TextBox ID="txtCapitalTitle" runat="server"
                         onblur="outpostcode(this,'showtitle')"   Width="299px"></asp:TextBox></strong>&nbsp;<div id="showtitle" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <span class="hong">*</span> <strong>地域：</strong></td>
                <td>
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    <span id="spCapitalType"></span><div id="showdiyu" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <span class="hong">*</span> <strong>贷款总金额：</strong></td>
                <td>
                    <asp:TextBox ID="txtCapitalMoney" onblur="outmoney(this,'showmoney')"  onkeydown="return checkinputshuzi(this,9,'showmoney')" onkeyup="return checkinputshuzi(this,9,'showmoney')" runat="server"></asp:TextBox> &nbsp;（万元）<div id="showmoney" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>贷款期限：</strong></td>
                <td width="625">
                  <input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
                </td>
            </tr>
           <tr>
                <td width="133" align="right"  style="height: 42px">
                    <span class="hong">* </span><strong>担保方式：</strong></td>
                <td width="625" style="height: 42px">
                    <asp:RadioButtonList ID="radiodanbao" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">担保</asp:ListItem>
                        <asp:ListItem Value="1">抵押</asp:ListItem>
                        <asp:ListItem Value="2">信用</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
           <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>项目有效期限：</strong></td>
                <td width="625">
                  <input id="Hidden1" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeSystem" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="Text1" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />

                </td>
            </tr>
            <tr>
                <td width="133" align="right" valign="top" >
                    <span class="hong">*</span> <strong>借款用途及还款说明：</strong>
                    <br /></td>
                <td width="625" valign="top">
                    <label>
                        <textarea  onblur="outpostcode(this,'showdescript')"  id="txtCapitalIntent"  runat="server"
                            cols="50" rows="10" style="width: 558px; height: 200px"></textarea>
                    </label>
                    &nbsp;<div id="showdescript" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
          <tr><td colspan=2> <span class="f_14px strong f_cen">联系方式：</span></td></tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">*</span><strong>企业名称：</strong></td>
                <td width="625">
                    <strong>
                        <asp:TextBox ID="txtenpricename" onblur="outpostcode(this,'showenpricename')" runat="server"
                            Width="299px"></asp:TextBox></strong> &nbsp;<div id="showenpricename" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
             
            <tr>
                <td width="133" align="right" >
                    <span class="hong">*</span><strong>联系人：</strong></td>
                <td width="625">
                    <strong>
                        <asp:TextBox ID="txtcontactsName" onblur="outpostcode(this,'showname')" runat="server"
                            Width="299px"></asp:TextBox></strong> &nbsp;<div id="showname" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <span class="hong"></span> <strong>手机号码：</strong></td>
                <td>
                    <asp:TextBox ID="txtcontactsphone"  onblur="outphone(this,'showMoblie')" onkeydown="return checkinputphone(this,11,'showMoblie')" onkeyup="return checkinputphone(this,11,'showMoblie')" runat="server"
                            Width="299px" ></asp:TextBox>
                    &nbsp;<div id="showMoblie" style ="display:none; color:Red ; font-size:12px">请输入数字</div>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <span class="hong">*</span> <strong>联系电话：</strong></td>
                <td>
                      <asp:TextBox ID="txtcontactsTel" MaxLength="4" Width ="80px"  onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"></asp:TextBox>-<asp:TextBox ID="txttel1" MaxLength ="8"  Width ="115px" onkeyup="value=value.replace(/[^\d]/g,'') " runat="server"></asp:TextBox>-<asp:TextBox ID="txttel2" MaxLength ="4" onkeyup="value=value.replace(/[^\d]/g,'') "  Width ="80px" runat="server"></asp:TextBox> &nbsp;(格式如:0755-89805588-8028)<div id="showtel" style ="display:none; color:Red ; font-size:12px">请输入数字</div><br/><font color="red" >（手机，电话至少填一个）</font>

                </td>
            </tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>邮件：</strong></td>
                <td width="625">
                <asp:TextBox ID="txtcontactsemail" onblur="outemail(this,'showemail')"  runat="server"
                            Width="299px"></asp:TextBox>&nbsp;<div id="showemail" style ="display:none; color:Red ; font-size:12px">请输入数字</div>
                </td>
            </tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong"></span><strong>
                        公司地址：</strong></td>
                <td width="625">
                <asp:TextBox ID="txtcontactsaddress" runat="server"
                            Width="299px"></asp:TextBox>
                </td>
            </tr>
         
          <tr><td colspan=2 align="center"><asp:Button ID="btnUpdate" runat="server" OnClientClick="return cheasdf()" OnClick="btnUpdate_Click" Text="修 改" /></td></tr>
        </table>

    </div>
     <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 2px; width: 134%;
   height:1334px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>
</asp:Content>

