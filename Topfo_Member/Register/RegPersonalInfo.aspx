<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegPersonalInfo.aspx.cs"
    Inherits="Register_RegPersonalInfo" %>

<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc3" %>
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>填写基本信息－－个人会员</title>
    <link href="../css/regstep.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <uc1:Header ID="Header1" runat="server" />
    <div class="mainnav">
        <ul>
            <li>1．选择会员类型</li>
            <li class="up">2．填写基本信息</li>
            <li>3．注册成功 </li>
        </ul>
    </div>
    &nbsp;&nbsp;
    <form id="frm" method="post" runat="server" onsubmit="return CheckAll()">
        <div class="content">
            <div class="content_top">
                <div class="clew">
                    <h4>
                        您选择的是个人会员！<span><a href="register.aspx">重新选择会员类型</a></span></h4>
                    <h6>
                        请填写真实、详细的注册信息，这样容易使您获得别人的信任，结交潜在的合作伙伴。</h6>
                </div>
            </div>
            <div class="step1_note">
                注：<span>*</span>为必填内容</div>
            <table width="0" border="0" class="inputtable">
                <tr>
                    <th>
                        <span>*</span>会员登录名：</th>
                    <td>
                        <input name="usrname" id="usrname" type="text" runat="server" /></td>
                    <td>
                        <div class="commonly" id="nameinfo">
                            会员登陆名由4-20个英文字母、数字、下划线组成，不区分大小写。登录名不能修改，请谨慎填写。</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>密码：</th>
                    <td>
                        <input name="pwd" id="pwd" type="password" /></td>
                    <td>
                        <div class="commonly" id="pwdinfo">
                            密码由6-20个英文字母或数字组成，建议采用易记、难猜的英文数字组合。<a href="http://www.topfo.com/help/register.shtml#15"
                                target="_blank">&gt;&gt;如何设置安全的密码</a></div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>重复输入密码：</th>
                    <td>
                        <input name="repwd" id="repwd" type="password" /></td>
                    <td>
                        <div class="commonly" id="repwdinfo">
                            请再输入一遍您上面填写的密码</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>昵称：</th>
                    <td>
                        <input name="nikename" id="nikename" type="text" /></td>
                    <td>
                        <div class="commonly" id="nikeinfo">
                            昵称不超过14个字符，一个汉字算2个字符。请尽量使用您的单位名作为您的昵称，如中国招商投资网、贤泽投资等。</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>电子邮箱：</th>
                    <td>
                        <input name="email" id="email" type="text" /></td>
                    <td>
                        <div class="commonly" id="emailinfo">
                            <b><span>重要！</span></b>请填写真实并且最常用的邮箱，这是客户联系您的重要方式。同时，还便于您接收“密码找回”的回复邮件或定向推广、资源定制等业务邮件。如果您还没有邮箱，
                            <a href="http://mail.tz888.cn/coremail/login8.php" target="_blank">点此免费获取</a></div>
                    </td>
                </tr>
            </table>
            <div style="padding-left: 100px; float: left; padding-top: 8px">
                当此帐号修改密码或找回密码时，会要求您回答密码保护问题，这将确保是您本人在进行操作，使您的帐号更安全。</div>
            <div style="clear: both">
            </div>
            <table width="0" border="0" class="inputtable">
                <tr>
                    <th>
                        <span>*</span>密码保护问题：</th>
                    <td style="width: 245px">
                        <select name="question" id="question">
                            <option value=" ">请选择密码保护问题</option>
                            <option value="您的出生地是？">您的出生地是？</option>
                            <option value="您就读的小学是？">您就读的小学是？</option>
                            <option value="您就读的中学是？">您就读的中学是？</option>
                            <option value="您父亲的名字是？">您父亲的名字是？</option>
                            <option value="您母亲的名字是？">您母亲的名字是？</option>
                            <option value="您配偶的名字是？">您配偶的名字是？</option>
                            <option value="您配偶的生日是？">您配偶的生日是？</option>
                            <option value="您最喜欢的历史人物是？">您最喜欢的历史人物是？</option>
                            <option value="您最喜欢的一本书是？">您最喜欢的一本书是？</option>
                            <option value="您最喜欢的运动是？">您最喜欢的运动是？</option>
                            <option value="您最喜欢的电影是？">您最喜欢的电影是？</option>
                            <option value="您的职业是？">您的职业是？</option>
                            <option value="您手机的后四位号码是？">您手机的后四位号码是？</option>
                        </select>
                    </td>
                    <td>
                        <div id="questioninfo" class="commonly">
                            请选择密码保护问题</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>问题的答案：</th>
                    <td style="width: 245px">
                        <input type="text" id="answer" name="answer" /></td>
                    <td>
                        <div id="answerinfo" class="commonly">
                            请输入密码保护问题的答案</div>
                    </td>
                </tr>
            </table>
            <div style="padding-left: 120px; float: left; padding-top: 8px">
                <span style="color: red"><b>*</b></span>固定电话和手机请您至少填写一项</div>
            <div style="clear: both">
            </div>
            <table width="0" border="0" class="inputtable">
                <tr>
                    <th>
                        固定电话：</th>
                    <td style="width: 250px">
                        <menu class="menulw">
                            国家</menu>
                        <menu>
                            城市区号</menu>
                        <menu class="menulw3">
                            电话号码</menu>
                        <br />
                        <input name="country" id="country" type="text" value="86" size="4" class="country" />
                        <input name="zone" id="zone" type="text" size="7" class="area">
                        <input name="phone" id="phone" type="text" size="18" class="phone" />
                    </td>
                    <td>
                        <div class="commonly" id="phoneinfo">
                            如果要输入多个电话号码,请使用“/”分隔，分机号码用“-”分隔。</div>
                        <span id="zoneinfo"></span>
                    </td>
                </tr>
                <tr>
                    <th>
                        手机：</th>
                    <td style="width: 250px">
                        <input name="mobile" id="mobile" type="text" /></td>
                    <td>
                        <div class="commonly" id="mobileinfo">
                            建议您填写，以便潜在的合作方能及时与您取得联系。中国招商投资网承诺不绑定任何收费服务！</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span>所在地：</th>
                    <td colspan="2">
                        <uc3:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="0" border="0" class="inputtable">
                <tr style="height: 30px; padding: 0">
                    <th>
                        <span>*</span>您的意向：</th>
                    <td>
                        <p class="redfont">
                            可多选<span style="font-size: 12px; font-weight: normal" id="intentinfo"></span></p>
                    </td>
                </tr>
                <tr>
                    <th>
                        &nbsp;</th>
                    <td>
                        <table width="0" border="0" cellpadding="0" cellspacing="0" class="yixiangtable">
                            <tr onclick="IntentOnSelect(this)">
                                <th>
                                    <input type="checkbox" id="intent" name="intent" value="1003" />
                                    项目融资</th>
                                <td>
                                    供融资额度在100万元人民币以上的企业或个人选择</td>
                            </tr>
                            <tr onclick="IntentOnSelect(this)">
                                <th>
                                    <input type="checkbox" name="intent" value="1004" />
                                    项目投资</th>
                                <td>
                                    供投资额度求在100万元人民币以上的企业或个人选择</td>
                            </tr>
                            <tr onclick="IntentOnSelect(this)">
                                <th>
                                    <input type="checkbox" name="intent" value="1005" />
                                    创业合作</th>
                                <td>
                                    供投、融资额度在100万元人民币以内的创业型企业或个人选择</td>
                            </tr>
                            <tr onclick="IntentOnSelect(this)">
                                <th>
                                    <input type="checkbox" name="intent" value="1007" />
                                    产品招商</th>
                                <td>
                                    供招募或想做经销商、代理商、加盟商等的企业或个人选择</td>
                            </tr>
                            <tr onclick="IntentOnSelect(this)">
                                <th>
                                    <input type="checkbox" name="intent" value="1006" />
                                    产品供求
                                </th>
                                <td>
                                    供有产品供应、求购意向的企业或个人选择择</td>
                            </tr>
                            <tfoot>
                            </tfoot>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="0" border="0" class="inputtable noborder">
                <tr>
                    <th>
                        邀请人：</th>
                    <td>
                        <input name="invite" id="invite" type="text" /></td>
                    <td>
                        <div class="commonly" id="inviteinfo">
                            填写邀请您注册的朋友昵称，如果没有则可不填</div>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>*</span> 验证码：</th>
                    <td>
                        验证码不区分大小写<br />
                        <input name="vercode" id="vercode" type="text" /></td>
                    <td>
                        <div class="validInfo">
                            <img src="../ValidateNumber.aspx" width="73" height="25" align="middle" id="validimg" />
                            <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">换一张图片</a><span
                                style="padding-right: 1px" id="vercodeinfo"></span></div>
                    </td>
                </tr>
            </table>
            <div class="content_bottom">
            </div>
        </div>
        <div class="tijiao">
            <p>
                <input name="checkbox" checked id="protocal" type="checkbox" value="checkbox" />
                我已阅读并同意<a href="http://www.topfo.com/Register/AgreeMent.shtml" target="_blank">《中国招商投资网服务协议》</a><span
                    id="protocalinfo"></span></p>
            <p>
                <input name="checkbox" type="checkbox" value="checkbox" checked="checked" />
                我愿意接收来自中国招商投资网的通知和消息（包括《中国招商投资网·电子杂志》等）</p>
            <asp:ImageButton ID="ImageButton1" ImageUrl="../images/reg_step/btn_tijiao.gif" runat="server"
                OnClick="ImageButton1_Click" />
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>

<script src="../js/commonReg.js" language="javascript" type="text/javascript"></script>

<script src="../js/Ajax.js" language="javascript" type="text/javascript"></script>

