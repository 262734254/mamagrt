<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoansInfoPerson.aspx.cs" Inherits="Publish_LoansInfoPerson" Title="Untitled Page" %>
<%@ Register Src="../Controls/CapitalAddressInfo.ascx" TagName="CapitalAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../offer/css/member.css" rel="stylesheet" type="text/css" />
    <script type ="text/javascript" language ="javascript" src ="../Register/Js/JScriptYanzheng.js" ></script>
        <script type ="text/javascript" language ="javascript" src="../Register/Js/JScriptInsertPerson.js" ></script>
    <script type="text/javascript" language ="javascript" >

    </script>
  <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布个人贷款需求</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
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
                    <span id="spCapitalType"></span>&nbsp;<div id="showdiyu" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td align="right" >
                    <span class="hong">*</span> <strong>借款总金额：</strong></td>
                <td>
                    <asp:TextBox ID="txtCapitalMoney" onblur="outmoney(this,'showmoney')"  onkeydown="return checkinputshuzi(this,9,'showmoney')" onkeyup="return checkinputshuzi(this,9,'showmoney')" runat="server"></asp:TextBox> &nbsp;（万元）<div id="showmoney" style ="display:none; color:Red ; font-size:12px">*</div>
                </td>
            </tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>借款期限：</strong></td>
                <td width="625">
                  <input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
                </td>
            </tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>还款方式：</strong></td>
                <td align="left" width="625">
                    <asp:RadioButtonList ID="radiohaiMoney" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">月</asp:ListItem>
                        <asp:ListItem Value="1">季</asp:ListItem>
                        <asp:ListItem Value="2">年</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
           <tr>
                <td width="133" align="right"  style="height: 42px">
                    <span class="hong">* </span><strong>担保方式：</strong></td>
                <td width="625" style="height: 42px">
                    <asp:RadioButtonList ID="radiodanbao" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
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
         <tr><td colspan=2><span class="f_14px strong f_cen">联系方式：</span></td></tr>
            <tr>
                <td width="133" align="right" >
                    <span class="hong">*</span><strong>姓名：</strong></td>
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
                    <span class="hong">*</span> <strong>电话：</strong></td>
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
                    <span class="hong"></span><strong>联系地址：</strong></td>
                <td width="625">
                <asp:TextBox ID="txtcontactsaddress" runat="server"
                            Width="299px"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td width="133" align="right" >
                    <span class="hong">* </span><strong>验证：</strong></td>
                <td width="625">
                <input  type="text" id="txtyanzheng" onblur ="outpostcode(this,'showpostcode')" /> 
                   <input type="text"  onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />&nbsp;<div id="showpostcode" style ="display:none; color:Red ; font-size:12px">*</div>
     <!-- </label>-->
                </td>
            </tr>
          <tr><td colspan="2" align="center"> <input name="" type="checkbox" value="" checked />
             <a href="#" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
         
            <asp:ImageButton ID="IbtnSubmit" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
             OnClientClick="return checkinsert()"    OnClick="IbtnSubmit_Click" /></td></tr>
        </table>
    </div>
           <script type="text/javascript" language="javascript">  createCode();</script>
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

