<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OtherPay.aspx.cs" Inherits="PayManage_OtherPay" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Literal ID="Literal1" runat="server" Text="<link href=../css/paymanage.css rel='stylesheet' type='text/css' />"></asp:Literal>
   
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                其它交易管理
            </div>
            <div class="right">
                <a href="#" class="chenglink">交易完全教程</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox">
            <h1>
                温馨提示：</h1>
            <p>
                我们为您开通了多种支付渠道，无论金额大小皆可轻松支付！
                <br />
                如果您的账户余额充足，使用账户余额支付是最快捷的支付方式。您现在的账户余额为 <strong>0</strong> 元。<a href="#" class="chenglink">点此立即充值</a></p>
        </div>
        <div class="blank20">
        </div>
        <!--我的购物车 -->
        <div class="mycartbox">
            <div class="title">
                <ul>
                    <li class="liwai">交易订单</li><li>已完成交易</li></ul>
                <div class="right">
                    每页显示：<a href="#">10</a> 条 <a href="#">20</a> 条 <a href="#">30</a> 条</div>
            </div>
            <div class="con">
                <h1>
                    资源查询：
                    <select name="jumpMenu" id="jumpMenu">
                        <option>最近三个月</option>
                    </select>
                    <label>
                    </label>
                    <input type="submit" name="button" id="button" value="查询" />
                </h1>
                <table width="100%" align="center" cellspacing="0" class="tabtitle">
                    <tr>
                        <td width="11%" height="25" align="center">
                            全选/反选</td>
                        <td width="6%">
                            类别</td>
                        <td width="28%" align="center">
                            资源标题</td>
                        <td width="9%" align="left">
                            价格(元)</td>
                        <td width="11%" align="left">
                            发布时间</td>
                        <td width="27%" align="left">
                            状态</td>
                        <td width="8%" align="left">
                            匹配</td>
                    </tr>
                </table>
                <table width="100%" align="center" cellspacing="0" class="taba">
                    <tr>
                        <td width="11%" height="25" align="center">
                            <label>
                                <input type="checkbox" name="checkbox" id="checkbox" />
                            </label>
                        </td>
                        <td width="6%" height="25">
                            资本
                        </td>
                        <td width="28%">
                            <a href="#">公司寻华东地区的基础建设工程</a></td>
                        <td width="9%">
                            400.00元</td>
                        <td width="11%" align="left">
                            20007-06-30</td>
                        <td width="26%" align="left">
                            <a href="#">已提交订单，未付款</a> | 立即付款</td>
                        <td width="9%" align="left">
                            <a href="#">相关资源</a><a href="#"></a></td>
                    </tr>
                </table>
                <table width="100%" align="center" cellspacing="0" class="tabb">
                    <tr>
                        <td width="11%" height="25" align="center">
                            <input type="checkbox" name="checkbox2" id="checkbox2" /></td>
                        <td width="6%" height="25">
                            资本
                        </td>
                        <td width="28%">
                            <a href="#">公司寻华东地区的基础建设工程</a></td>
                        <td width="9%">
                            400.00元</td>
                        <td width="11%" align="left">
                            20007-06-30</td>
                        <td width="26%" align="left">
                            已提交订单，未付款 | <a href="#">立即付款</a></td>
                        <td width="9%" align="left">
                            <a href="#">相关资源</a><a href="#"></a></td>
                    </tr>
                </table>
                <table width="100%" align="center" cellspacing="0" class="taba">
                    <tr>
                        <td width="11%" height="25" align="center">
                            <input type="checkbox" name="checkbox3" id="checkbox3" /></td>
                        <td width="6%" height="25">
                            资本
                        </td>
                        <td width="28%">
                            <a href="#">公司寻华东地区的基础建设工程</a></td>
                        <td width="9%">
                            400.00元</td>
                        <td width="11%" align="left">
                            20007-06-30</td>
                        <td width="26%" align="left">
                            已提交订单，未付款 | 立即付款<a href="#"></a></td>
                        <td width="9%" align="left">
                            <a href="#">相关资源</a><a href="#"></a></td>
                    </tr>
                </table>
                <p>
                    <a href="#">全选</a>/<a href="#">反选</a> 共3条 页次：1/1页 首页 上一页 下一页 尾页<span>转到 第
                        <input name="textarea" type="text" id="textarea" value="" size="5" style="width: 20px;
                            height: 15px;">
                        页</span>
                    <input type="submit" name="button2" id="button2" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" />
                </p>
            </div>
            <div class="buttom">
                <input type="button" value="删除订单" />
                <input type="button" value="清空" />
            </div>
        </div>
        <div class="blank20">
        </div>
        <!--帮助 -->
        <div class="helpbox">
            <div class="title">
                <img src="/Member/images/PayManage/biao_print.gif" />
                打印该页</div>
            <div class="con">
                <h1>
                    <img src="/Member/images/icon_yb.gif" align="absmiddle" />
                    帮助</h1>
                <p>
                    点击<a href="#" class="chenglink">订单明细</a>可以查看订单的详细情况；
                    <br />
                    <br />
                </p>
            </div>
            <div class="bottomzi">
                想分析项目的投资价值吗？拓富通会员可申请中国招商投资促进平台的专业服务。了解更多<a href="#" class="chenglink">专业服务</a> >>
                <a href="#" class="chenglink">申请拓富通</a></div>
        </div>
    </div>
</asp:Content>
