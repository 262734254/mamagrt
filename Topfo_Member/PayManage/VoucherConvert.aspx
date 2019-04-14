<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="VoucherConvert.aspx.cs" Inherits="PayManage_VoucherConvert" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Literal ID="Literal1" runat="server" Text="<link href=../css/paymanage.css rel='stylesheet' type='text/css' />"></asp:Literal>
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                我的购物券
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox">
            <h1>
                温馨提示：</h1>
            <p>
                ·每100积分可以兑换1.00元购物券，每人每天最高可兑换100元
                <br />
                ·购物券有效使用期为兑换之日起3个月内，超过<font class="cheng">三个月仍未消费的购物券将自动作废 </font>
                <br />
                <a href="#" class="lanlink">查看我的购物券有效期</a>
                <br />
                ·购物券只能购买指定的资源
                <br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--购物券兑换 -->
        <div class="mycartbox">
            <div class="title">
                <ul>
                    <li class="liwai">购物券兑换</li>
                    <li>兑换记录</li><li class="linone"><a href="#">购物券资源专区</a> </li>
                </ul>
            </div>
            <div class="con">
                <div class="left">
                    <div class="top">
                        <ul>
                            <li>您的剩余积分：<span class="chengcu">56800</span> 分</li><li>可兑换金额： <span class="chengcu">
                                568.00</span> 元<br />
                            </li>
                            <li>购物券剩余金额：<span class="chengcu">0.00</span> 元</li>
                            <div class="clear">
                            </div>
                        </ul>
                        <div class="blank20">
                        </div>
                        <div>
                            <a href="#" class="lanlink">如何获得更多积分</a> <a href="#" class="lanlink">查看我的兑换记录</a>
                            <a href="#" class="lanlink">查看我的购物券消费记录</a></div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="blank0">
                    </div>
                    <table width="348" height="152" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="165" height="38" align="right">
                                我要兑换：</td>
                            <td width="191">
                                <label>
                                    <input name="textarea" type="text" id="textarea" value="" size="7" />
                                </label>
                                积分</td>
                        </tr>
                        <tr>
                            <td height="38" align="right">
                                可兑换购物券金额：</td>
                            <td>
                                <input name="textarea2" type="text" id="textarea2" value="" size="7" />
                                元</td>
                        </tr>
                        <tr>
                            <td height="1" colspan="2" bgcolor="#CCCCCC">
                            </td>
                        </tr>
                        <tr>
                            <td height="70" colspan="2" align="center">
                                <label>
                                    <input type="submit" name="button" id="button" value="提交" />
                                    <input type="reset" name="button2" id="button2" value="重置" />
                                </label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="right">
                    <h2>
                        精选购物券资源
                    </h2>
                    <table width="326" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="lansen">
                                资源标题
                            </td>
                            <td class="lansen">
                                价格(元)</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td class="lansen">
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td class="lansen">
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td class="lansen">
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td class="lansen">
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td class="lansen">
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td class="lansen">
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td class="lansen">
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td class="lansen">
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·投资公司投资能源、房地产类项目</td>
                            <td class="lansen">
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ·寻东北地区的火力发电项目
                            </td>
                            <td class="lansen">
                                400.00</td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <!--帮助 -->
    </div>
</asp:Content>
