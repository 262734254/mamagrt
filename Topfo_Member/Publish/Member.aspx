<%@ Page Language="C#" MasterPageFile="~/Page20110314.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Publish_Member" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布政府招商需求</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>项目标题：</td>
        <td><input name="" type="text" /></td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属区域：</td>
        <td style="height: 22px">
    </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属行业：</td>
        <td>
    </td>
      </tr>
      <tr>
          <td class="publica-td-left" >
          <span class="hong">*</span>总投资：</td>
                <td>

                    <input name="txtCapitalTotal" id="txtCapitalTotal" onkeyup="value=value.replace(/[^\d]/g,'') " style="width: 75px;" type="text">
                    万元 <span id="spCapitalTotal"></span>          </td>
          </tr>
            <tr>
              <td class="publica-td-left">
              <span class="hong">*</span>项目有效期：</td>
                <td>
                      </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 招商项目简介：</td>
                <td width="618">
                    <textarea name="txtZoneAbout" id="txtZoneAbout" cols="50" rows="10" style="width: 558px; height: 100px;"></textarea><span id="spZoneAboutB"></span>              </td>
            </tr>
          <tr>
          <td class="publica-td-left" valign="top" >
            上传图片：</td>
                <td class="nonepad" valign="top" width="618">
                    </td>
            </tr>
            <tr>
            <td colspan="2">
            <span class="f_14px strong f_cen">联系人详细信息</span>
            </td>
            </tr>
            
       <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span> 招商机构名称：</td>
        <td >
            <asp:TextBox ID="txtCompanyName" runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
       </tr>
       <tr id="tr2" name="trswitchpublish">
        <td class="publica-td-left" >
            项目承办单位：</td>
        <td >
            <asp:TextBox ID="txtUndertaker" runat="server" Width="324px" /></td>
       </tr>
      <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系人：</td>
        <td >
          
            <asp:TextBox id="txtName"  width="127px" runat="server" />
        </td>
      </tr>
      <tr>
       <td class="publica-td-left" >
        <span class="hong">*</span> 职位：
       </td>
     
      <td><asp:TextBox ID="txtPosition"   width="127px" runat="server" />
      <span id="spPosition"></span>
      </td>
      </tr>
    <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系电话：</td>
        <td >
            固话<asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber"  runat="server" size='18' />
            <span id="spTel" ></span>     
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            手机：</td>
        <td >
            <asp:TextBox id="TextBox1"  width="127px" runat="server" />
            <span id="Span1" class="hui">（固定电话或手机至少填写一项）</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            电子邮箱：</td>
        <td >
            <asp:TextBox ID="txtEmail"   runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            联系地址：</td>
        <td >
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
    <tr>
       <td class="publica-td-left">
      验证码：</td>
      <td>
      <asp:TextBox ID="ImageCode"  runat="server" Width="120px"></asp:TextBox> <img src="../ValidateNumber.aspx"  onclick="this.src='../ValidateNumber.aspx?temp=' + (new Date())" />
       </td>
       
       </tr>
            <tr>
            <td colspan="2" id="pub-tongyi">
             <input name="" type="checkbox" value="" checked />
             <a href="#" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
              <input name="" type="image" src="http://img2.topfo.com/member/images/member-btn-tj.jpg"  style="margin-top:6px"/>
               </td>
            </tr>
</table>

    </div>
      </div>
</asp:Content>

