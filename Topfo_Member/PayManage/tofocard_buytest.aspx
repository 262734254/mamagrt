<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tofocard_buytest.aspx.cs" Inherits="PayManage_tofocard_buytest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
         <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


    <script language="javascript" type="text/javascript">
    function chkInput()
    {
        if($id("txtwushi").value==""&&$id("txtbai").value==""&&$id("txttwobai").value==""&&$id("txtfivebai").value=="")
        {
            alert("至少选择一张卡!");
            return false;
        }
      
        if($id("txtwushi").value!="")
        {
            if(isNaN($id("txtwushi").value))
            {
                alert("请填写整数!");
                $id("txtwushi").value="";
                $id("txtwushi").focus();
               return false;
            }
        }
        if($id("txtbai").value!="")
        {
            if(isNaN($id("txtbai").value))
            {
                alert("请填写整数!");
                $id("txtbai").value="";
                $id("txtbai").focus();
               return false;
            }
        }
         if($id("txttwobai").value!="")
        {
            if(isNaN($id("txttwobai").value))
            {
                alert("请填写整数!");
                $id("txttwobai").value="";
                $id("txttwobai").focus();
                return false;
            }
        }
        if($id("txtfivebai").value!="")
        {
            if(isNaN($id("txtfivebai").value))
            {
                alert("请填写整数!");
                $id("txtfivebai")="";
                $id("txtfivebai").focus();
                return false;
            }
        }
        if($id("txtrealname").value=="")
        {
            alert("请填写姓名,");
            $id("txtrealname").focus();
           return false;
        }
        if($id("txtTel").value==""&&$id("txtMobile").value=="")
        {
           alert("为方便联系,请填写电话或手机其中一个!");
            $id("txtTel").focus();
            return false;
        }
        if($id("txtMobile").value!="")
        {
            if($id("txtMobile").value.length!=11)
            {
                alert("手机格式错误!");
                $id("txtMobile").focus();
                return false;
            }
            if(isNaN($id("txtMobile").value))
            {
                 alert("手机格式错误!");
                $id("txtMobile").focus();
                return false;
            }
        }
        if($id("txtAddress").value=="")
        {
          alert("请填写地址,以便我们能把卡准确的发到你的手中!");
            $id("txtAddress").focus();
            return false;
        }
        if($id("txtEmail").value=="")
        {
           alert("请填写电子邮箱,");
            $id("txtEmail").focus();
           return false;
        }
    }
   function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                购买拓富充值卡</div>
            <div class="right">
                <a href="http://www.topfo.co/help/AccountCZ.shtml#14" target="_blank">查看购买拓富充值卡教程</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox lightc allxian">
            <h1>
                小提示：</h1>
            拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。<a href="http://www.topfo.com/help/AccountCZ.shtml" target="_blank">了解更多</a><br />
            我们准备了多种购买渠道供您选择，方便、快捷！<br />
            如果您有任何疑问，请拨打我们的客服电话：<!--#include file="../common/custel.html"-->
        </div>
        <div class="blank20">
        </div>
        <!-- -->
        <div class="fillbox cshibiank">
            <h1 class="lightc">
                请填写以下订购信息（带 <span class="hong">*</span> 的为必填项）：</h1>
            <table width="85%" height="332" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="32" colspan="4">
                        <strong>请选择充值卡面值和数量： </strong>
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="128" align="right" style="height: 28px">
                        <span class="chengcu font14">50</span>元面值的充值卡：</td>
                    <td width="159" style="height: 28px">
                        <label>
                        <input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                                id="txtwushi" runat="server" />
                            张
                        </label>
                  </td>
                    <td width="137" align="right" style=" height: 28px">
                        <span class="chengcu font14">100</span>元面值的充值卡：</td>
                    <td align="left" style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txtbai" runat="server" />
                        张
                  </td>
                </tr>
                <tr>
                    <td align="right" style="height: 28px">
                       <span class="chengcu font14"> 200</span>元面值的充值卡：
                    </td>
                    <td style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txttwobai" runat="server" />
                        张
                    </td>
                    <td align="right" style=" height: 28px">
                       <span class="chengcu font14"> 500</span>元面值的充值卡：
                    </td>
                    <td style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txtfivebai" runat="server" />
                        张
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                        </td>
                    <td>&nbsp;
                        </td>
                    <td style="width: 133px">&nbsp;
                        </td>
                    <td>&nbsp;
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <strong>请填写您的相关资料：</strong><br />
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 34px">
                        <span class="hong">*</span> 真实姓名：</td>
                    <td colspan="3" style="height: 34px">
                        <input name="textarea22" type="text" value="" style="width: 109px; height: 18px"
                            id="txtrealname" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" valign="bottom" style="padding-bottom: 10px;">
                        <span class="hong">*</span> 固定电话：</td>
                    <td colspan="3">
                        <input name="textarea22" type="text" value="" style="width: 226px; height: 18px"
                            id="txtTel" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        手机：
                    </td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 227px; height: 18px"
                            id="txtMobile" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        <span class="hong">*</span> 详细地址：</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 228px; height: 18px"
                            id="txtAddress" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        邮编：</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 227px; height: 18px"
                            id="txtCode" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="hong">*</span> E-mail：</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 226px; height: 18px"
                            id="txtEmail" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">&nbsp;
                        </td>
                    <td height="50" colspan="2" align="center">
                        <asp:Button ID="btnSend" runat="server" Text="提  交" OnClick="btnSend_Click"  class="buttomal"/>
                        &nbsp;<input type="reset" name="Submit2" value="清 空 " style="width: 71px" class="buttomal" />
                    </td>
                    <td>&nbsp;
                        </td>
                </tr>
            </table>
        </div>
       <div class="blank20">
        </div>
        <!-- -->
        <div class="helpbox">
            <div class="con">
                <h1 >
                    <img src="../images/icon_yb.gif" align="absmiddle" /><strong> 重要说明</strong></h1>
                <ul>
                    <li>拓富充值卡根据会员需要可在当地特许经销商处购买，也可以直接从中国招商投资网购买，还可以在网上电子支付平台系统自主购买、自由充值！</li><li>拓富充值卡长期有效，不记名、不挂失，请妥善保管，谨防丢失、冒用，没有开封挂掉保密涂层充值使用的卡，均可退还给原代理经销商，特殊情况经批准后也可退还给中国招商投资网；</li><li>
                        拓富充值卡配有密码，充值时正确输入卡号、密码后即可成功充值；</li><li>会员购买、充值必须遵守中国招商投资网《会员服务协议》、推卡及相关业务规则；</li></ul>
                <p>
                  <span class="hong">会员服务热线：<!--#include file="../common/custel.html"--></span></p>
            </div>
    </div>
	   <div class="blank20">
        </div>
	</div>
    </form>
</body>
</html>
