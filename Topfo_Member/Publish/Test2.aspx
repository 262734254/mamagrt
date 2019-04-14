<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Publish_Test2" %>
<%@ Register Src="../Controls/MerchantInfoAddressInfo1.ascx" TagName="MerchantInfoAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hdswitchpublish" value="1" />
    <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布政府招商需求</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>项目标题：</td>
        <td><asp:TextBox ID="txtMerchantTopic"   runat="server" Width="270px"></asp:TextBox>
            <span id="spMerchantTopic"></span></td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属区域：</td>
        <td style="height: 22px">
         <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
    </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>所属行业：</td>
        <td>
        <input type="text" runat="server" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF; height:2px;" />
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
            </td>
      </tr>
      <tr>
          <td class="publica-td-left" >
          <span class="hong">*</span>总投资：</td>
                <td>
                    <asp:DropDownList ID="ddlCapitalCurrency" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal"   runat="server"
                        Width="75px" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    万元 <span id="spCapitalTotal"></span>   </td>
          </tr>
            <tr>
                <td class="publica-td-left">
                   <span class="hong">*</span> 招商回报率：</td>
                <td >
                    <asp:TextBox ID="txtHuiBao1" runat="server" Width="71px"></asp:TextBox>%</td>
            </tr>
            <tr>
              <td class="publica-td-left">
              <span class="hong">*</span>项目有效期：</td>
                <td><input id="Vaildite" type="hidden" name="Vaildite" visible="false" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                      </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 招商项目简介：</td>
                <td width="618">
                    <textarea id="txtZoneAbout"   runat="server" cols="50"
                        rows="10" style="width: 558px; height:100px"></textarea><span id="spZoneAboutB"></span>
                           </td>
            </tr>
          <tr>
          <td class="publica-td-left" valign="top" >
            上传图片：</td>
                <td class="nonepad" valign="top" width="618">
                <uc3:FilesUploadControl ID="FilesUploadControl1" InfoType="Merchant"
                        runat="server" />
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
            <asp:TextBox ID="txtCompanyName"   runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
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
            <span class="hong">*</span>联系电话：</td>
        <td >
              <asp:TextBox ID="txtTelCountry" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode"  runat="server" size='7' onkeyup="value=value.replace(/[^\d]/g,'') " />
            <asp:TextBox ID="txtTelNumber" runat="server" size='18' onkeyup="value=value.replace(/[^\d]/g,'') " />
            <span id="Span2" class="hui">（如：+86-0755-89805588）</span>  
            <span id="spTel" ></span>  
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            手机：</td>
        <td >
            <asp:TextBox id="txtMobile"  width="127px" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " /><span id="Span1" class="hui">（固定电话或手机至少填写一项）</span>  
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            电子邮箱：</td>
        <td >
            <asp:TextBox ID="txtEmail"  runat="server" size='18' Width="269px" />
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
      <input  type="text"   id="validCode" /> 
                   <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />
       </td>
       
       </tr>
            <tr>
            <td colspan="2" id="pub-tongyi">
             <input name="" type="checkbox" value="" checked />
             <a href="#" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
             <%-- <input name="" type="image" src="http://img2.topfo.com/member/images/member-btn-tj.jpg"  style="margin-top:6px"/>--%>
             <asp:ImageButton ID="IbtnSubmit"   ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="IbtnSubmit_Click"  />
               </td>
            </tr>
</table>

    </div>
      </div>
   <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: -3px; left: 0px; width: 100%;
   height:1500px; filter: 
   alpha(opacity=60);">

               <div class="llll">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
        </div>
 
    </form>
</body>
</html>
