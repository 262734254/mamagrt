<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="http://img2.topfo.com/member/js/email.js"></script>

<script language="javascript" type="text/javascript">
function menu(n)
{
     $("#help_"+n+"").toggle();
}

</script>

    <div class="member-right-left">
      <div class="per-infor">
        <ul>
          <li><span class="m-g-r"><img src="http://img2.topfo.com/member/images/member_33.jpg" width="16" height="14" /> 用户级别：<span class="f_cen" id="SpanGradeID" runat="server"></span></span> <img src="http://img2.topfo.com/member/images/member_35.jpg" width="13" height="14" /><span class="m-g-r f_cen" id="SpanTypeID" runat="server"></span>  </li>
          <li><span class="m-g-r"><img src="http://img2.topfo.com/member/images/member_40.jpg" width="13" height="14" /> 积分：<span class="f_cen" id="SpanJiFen" runat="server"></span></span><span class="m-g-r"> <img src="http://img2.topfo.com/member/images/member_42.jpg" width="13" height="14" /> 我的主页</span><span>我的主页关注度：<span class="f_cen">一般</span></span></li>
          <li> <img src="http://img2.topfo.com/member/images/member_46.jpg" width="18" height="14" /> 系统提示：<span class="f_lan"><span class="f_cen strong" runat="server" id="spanInnerInfo"></span>封未读短信  <a class="f_cen" href="http://member.topfo.com/InnerInfo/inbox2.aspx">查看</a> <%--<span class="f_cen strong">5</span>个好友邀请--%></span></li>
        </ul>
        <p runat="server" id="forInfo"> </p>
      </div>
      <%--<span class="f_cen strong">7</span>条未审需求<span class="f_cen strong">5</span>条已过期需求 <span class="f_cen strong">6</span>条已过期需求 有<span class="f_cen strong">6</span>人关注过你的项目 --%>
      <div class="pips">
        <h1><img src="http://img2.topfo.com/member/images/member_50.jpg" /></h1>
        <ul>
          <li> <img src="http://img2.topfo.com/member/images/member_61.jpg" width="66" height="64" />
            <p><a href="/helper/InfoCollection.aspx">我的收藏</a></p>
          </li>
 
          <li> <img src="http://img2.topfo.com/member/images/member_59.jpg" width="67" height="64" />
            <p><a href="Company/CompanyMiddle.aspx">我的名片</a></p>
          </li>
        
        
        
        
        
               <li> <img src="http://img2.topfo.com/member/images/member_57.jpg" />
            <p><a href="Company/zftopfoAdd.aspx" >专业服务拓富通</a></p>
          </li>
        
          <li> <img src="http://img2.topfo.com/member/images/member_75.jpg" width="64" height="65" />
            <p><%--<a href="/helper/InfoCollection.aspx">我的收藏</a>--%><a href="Company/tztopfoAdd.aspx">投资拓富通</a></p>
          </li>
          <li> <img src="http://img2.topfo.com/member/images/member_54.jpg" width="67" height="63" />
            <p><a href="Company/rztopfoAdd.aspx">融资拓富通</a></p>
          </li>
          <li> <img src="http://img2.topfo.com/member/images/member_80.jpg" width="66" height="64" />
            <p><a href="Company/CompanyShow.aspx">招商拓富通</a></p>
          </li>
         <li> <img src="http://img2.topfo.com/member/images/member_81.jpg" width="66" height="64" />
            <p><a href="Company/zylmAdd.aspx">资源联盟</a></p>
          </li>
          <li> <img src="http://img2.topfo.com/member/images/member_77.jpg" width="70" height="67" />
            <p><a href="Register/MemberRigisterDetailGov.aspx">完善资料</a></p>
          </li>
        </ul>
      </div>
<%--      <div class="my-xm" >
        <h1>
          <ul>
            <li class="btn_on"  id="wd_btn_1" onmousemove="SetBtn('wd',1);">我的项目</li>
            <li id="wd_btn_2" onmousemove="SetBtn('wd',2);">我的订阅信息</li>
            <li id="wd_btn_3" onmousemove="SetBtn('wd',3);">最新项目</li>
          </ul>
        </h1>
          <div class="my-xm-1" id="wd_con_1" >
           <%=ZSNews()%>
        </div>
        <div class="my-xm-1" id="wd_con_2" style="display:none" >
        </div>
        <div class="my-xm-1" id="wd_con_3" >
       <%=NewLeate()%>
        </div>
      </div>--%>
      <div class="member-huiy">
       <h1><img src="http://img2.topfo.com/member/images/mb-hy_03.jpg" width="539" height="35" /></h1>
       <div class="member-huiy1">
        <h2>我是普通会员</h2>
         <div class="member-huiy1-1">
        <ul>
        <li>
        <img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">项目发布</a>        </li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">机构发布</a></li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">人才发布</a></li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">资源发布</a></li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">资源匹配</a></li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">资源搜索</a></li>
        <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">收藏</a></li>
        </ul>
        </div>
       
        <div class="member-huiy1-2">
        <p> <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="http://img2.topfo.com/member/images/mb-hy_07.jpg" OnClick="ImageButton1_Click" /></p>
         <h3>享受以下服务</h3>
         <ul>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_11.jpg" align="absmiddle" /> <a href="Company/CompanyShow.aspx">招商拓富通</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_13.jpg" align="absmiddle" /> <a href="http://zt.topfo.com/index.html">专题推广</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_15.jpg" align="absmiddle" /> <a href="#">项目首页展示</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_17.jpg" align="absmiddle" /> <a href="#">邮件推广</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_22.jpg" align="absmiddle" /> <a href="http://video.topfo.com/index.html">视频路演</a></li>
         <li><img src="http://img2.topfo.com/member/images/mb-hy_24.jpg" align="absmiddle" /> <a href="#">软文推广</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_26.jpg" align="absmiddle" /> <a href="#">短信推广</a></li>
          <li><img src="http://img2.topfo.com/member/images/mb-hy_27.jpg" align="absmiddle" /> <a href="#">订阅项目</a></li>
         </ul>
        </div>
       </div>
       
       <div class="member-huiy2">
        <h2>我不是会员</h2>
         <div class="member-huiy2-1">
        <img src="http://img2.topfo.com/member/images/mb-hy_33.jpg"  class="fl"/>
        <div>
         <ul>
          <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">拓富通会员是什么</a></li>
          <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">拓富通会员有什么用</a></li>
          <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">成为会员有什么用</a></li>
          <li><img src="http://img2.topfo.com/member/images/member_08.jpg" /> <a href="#">成为会员</a></li>
         </ul>
        </div>
        </div>
       </div>
       
        <div class="member-huiy3">
         <h2>VIP会员</h2>
         <img src="http://img2.topfo.com/member/images/mb-hy_36.jpg" class="fl" />
          <div class="member-huiy3-1">
         <p>企业融资担保短期融资服务财产保全担保项目投资全担保项目投建设工程担保房地产金融政府融资担保<a href="#" class="f_cen">[详细]</a></p>
         <p><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="http://img2.topfo.com/member/images/mb-hy_38.jpg" OnClick="ImageButton1_Click" /></p>
         </div>
        </div>
      </div>
      
    </div>
    <div class="member-right-right">
      <div class="member-right-right-1">
        <h1>会员信息</h1>
        <div class="member-right-right-1-1" id="NewsId" runat="server">
        </div>
      </div>
      <div class="member-right-right-1" >
        <h1 style="padding:0">
          <ul>
            <li  class="btn_on"  id="xa_btn_1" onmousemove="SetBtn('xa',1);">合作加盟</li>
            <li  id="xa_btn_2" onmousemove="SetBtn('xa',2);">客服中心</li>
            <li style=" border:0" id="xa_btn_3" onmousemove="SetBtn('xa',3);">帮助中心</li>
          </ul>
        </h1>
        <div class="member-right-right-1-2" id="xa_con_1">
          <dl>
            <dt>网络合作</dt><dd>· 电话：18925252763 </dd><dd>· 联系人：黄先生</dd><dd>· 邮箱： hyh@topfo.com </dd></dl>
          <dl>
            <dt>分站加盟</dt><dd>· 电话：0755-89805588 </dd><dd>· 联系人：周小姐 </dd><dd>· 邮箱： zhp@topfo.com</dd></dl>
        </div>
        <div class="member-right-right-1-2" id="xa_con_2" style="display:none">
          <dl>
            <dt>广告投放</dt><dd>· 电话：0755-86146728 </dd><dd>· 联系人：周小姐 </dd><dd>· 邮箱： zhp@topfo.com </dd></dl>
          <dl>
            <dt>客户服务部</dt><dd>· 咨询热线：0755-86146728 </dd><dd>· 传真：0755-86146768 </dd><dd>· 客服邮箱：club@topfo.com </dd></dl>
        </div>
        <%--<div class="member-right-right-1-2" id="xa_con_3" style=" display:none">
          <dl>
            <dt onclick="menu(1);">注册登录</dt><div id="help_1" style="display:none" >
            <dd><a href="http://www.topfo.com/help/register.shtml" target="_blank">·注册/验证</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/login.shtml">·登录</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/infomodify.shtml">·个人资料修改</a></dd></div>
            <dt onclick="menu(2);">发布与管理</dt><div id="help_2" style="display:none">
            <dd><a target="_blank" href="http://www.topfo.com/help/demandrelease.shtml">·需求发布</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/demandmanage.shtml">·需求管理</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/companyregister.shtml">·公司登记/管理</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/organizationreister.shtml">·机构登记/管理</a></dd></div>
            <dt onclick="menu(3);">拓富助手</dt><div id="help_3" style="display:none">
            <dd><a target="_blank" href="http://www.topfo.com/help/message.shtml">·短消息</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/leaveword.shtml">·留言</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/friendmanage.shtml">·好友管理</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/subscribe.shtml">·订阅</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/favorite.shtml">·收藏夹</a></dd></div>
            <dt onclick="menu(4);">帐户充值</dt><div id="help_4" style="display:none">
            <dd><a target="_blank" href="http://www.topfo.com/help/AccountInfo.shtml">·帐号信息</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/AccountCZ.shtml">·充值</a></dd></div>
            <dt onclick="menu(5);">专业服务</dt><div id="help_5" style="display:none">
            <dd><a target="_blank" href="http://www.topfo.com/help/ProfessionalMerchant.shtml">·政府招商</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/ProfessionalProject.shtml">·企业投融资</a></dd></div>
            <dt onclick="menu(6);">其它问题</dt><div id="help_6" style="display:none">
            <dd><a target="_blank" href="http://www.topfo.com/help/otherone.shtml">·什么是认证资源</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/othertwo.shtml">·什么是无效资源</a></dd><dd><a target="_blank" href="http://www.topfo.com/help/otherthree.shtml">·购买了无效资源如何处理</a></dd></div>
            </dl>
        </div>--%>
        <div class="member-right-right-1-2" id="xa_con_3" style=" display:none">
        <dl>
            <dd>· <a href="http://www.topfo.com/help/releasedemand.shtml" target="_blank">如何发布需求？</a></dd><dd>· <a href="http://www.topfo.com/help/releasecriterion.shtml" target="_blank">需求发布规范？</a></dd><dd>· <a href="http://www.topfo.com/help/setupexhibit.shtml" target="_blank">为什么要创建我的展厅？</a></dd><dd>· <a href="http://www.topfo.com/help/searchres.shtml" target="_blank">如何寻找资源？</a></dd><dd>· <a href="http://www.topfo.com/help/buyres.shtml" target="_blank">如何购买收费资源？</a></dd></dl>
        </div>
      </div>
      <div class="member-right-right-1" >
        <h1 style="padding:0">
          <ul>
            <li class="btn_on"  id="kj_btn_1" onmousemove="SetBtn('kj',1);">常用网址</li>
            <li  id="kj_btn_2" onmousemove="SetBtn('kj',2);">实用工具</li>
            <li style=" border:0" id="kj_btn_3" onmousemove="SetBtn('kj',3);">邮 箱</li>
          </ul>
        </h1>
        <div class="member-right-right-1-kj1" id="kj_con_1" >
          <ul>
            <li><a href="http://www.topfo.com/" target="_blank">拓富网</a></li>
            <li><a href="http://www.people.com.cn/" target="_blank">人民网</a></li>
            <li><a href="http://news.sina.com.cn/" target="_blank">新浪新闻</a></li>
            <li><a href="http://www.secon.cn/templets/video/zhibo.htm" target="_blank">股市在线</a></li>
            <li><a href="http://www.ifeng.com/" target="_blank">凤凰网</a></li>
            <li><a href="http://news.sohu.com/" target="_blank">搜狐新闻</a></li>
            <li><a href="http://www.forbeschina.com/" target="_blank">福布斯网</a></li>
            <li><a href="http://hsb.hsw.cn/2010-11/24/node_833.htm" target="_blank">华商报</a></li>
            <li><a href="http://www.gov.cn/jrzg/" target="_blank">中国政府网</a></li>
            <li><a href="http://www.cnstock.com/" target="_blank">中国证券网</a></li>
            <li><a href="http://news.qq.com/" target="_blank">腾讯新闻</a></li>
            <li><a href="http://www.newone.com.cn/">招商证券</a></li>
            <li><a href="http://www.topfo.com/" target="_blank">招商投资网</a></li>
            <li><a href="http://www.yicai.com/" target="_blank">第一财经</a></li>
            <li><a href="http://www.cfi.net.cn/" target="_blank">中财网</a></li>
            <li><a href="http://www.baidu.com/" target="_blank">百度</a></li>
          </ul>
        </div>
        <div class="member-right-right-1-kj1" id="kj_con_2" style="display:none">
          <ul>
            <li><a href="http://dl_dir.qq.com/qqfile/qq/QQ2010/QQ2010Beta.exe" target="_blank">QQ2010</a></li>
            <li><a href="http://download.get.live.cn/files/441e36c0-fc83-4cb3-be33-621c9b1be881/Install_WLMessenger.exe" target="_blank">MSN</a></li>
            <li><a href="http://www.360.cn/down/soft_down2-3.html" target="_blank">360卫士</a></li>
            <li><a href="http://dl.baofeng.com/storm3/Storm2012595.exe" target="_blank">暴风影音</a></li>
            <li><a href="http://down.sandai.net/Thunder5.9.16.1306.exe" target="_blank">迅雷</a></li>
            <li><a href="http://images.nciku.cn/tools/imeshell/nshell/0.9.1.3/1/nShellInstaller_0_9_1_3.exe" target="_blank">及时译</a></li>
            <li><a href="http://ttplayer.qianqian.com/download/ttpsetup.exe" target="_blank">千千静听</a></li>
            <li><a href="http://download.verycd.com/easyMule-Setup.exe" target="_blank">电驴</a></li>
            <li><a href="http://www.jpwb.net/download/jpwb.exe" target="_blank">极品五笔</a></li>
            <li><a href="http://ime.sogou.com/dl/sogou_pinyin_431d.exe" target="_blank">搜狗拼音</a></li>
            <li><a href="http://dl.sd.keniu.com/setup.exe" target="_blank">可牛杀毒</a></li>
            <li><a href="http://download.pplive.com/pplivesetup_black_0024.exe" target="_blank">PPLive</a></li>
          </ul>
        </div>
         <%--name="mailForm" onsubmit='return log_submit();'--%>
   <%--<form name="mailForm" onsubmit='return log_submit();'>--%>
			<input type="hidden" name="u" value=""> 
			<input type="hidden" name="user" value=""> 
			<input type="hidden" name="LoginName" value=""> 
			<input type="hidden" name="username" value=""> 
			<input type="hidden" name="UserName" value=""> 
			<input type="hidden" name="login_name" value=""> 
			<input type="hidden" name="login" value=""> 
			<input type="hidden" name="psw" value=""> 
			<input type="hidden" name="language" value=""> 
			<input type="hidden" name="pass" value=""> 
			<input type="hidden" name="passwd" value=""> 
			<input type="hidden" name="password" value=""> 
			<input type="hidden" name="Password" value=""> 
			<input type="hidden" name="login_password" value=""> 
			<input type="hidden" name="url" value=""> 
			<input type="hidden" name="BackURL" value=""> 

        <div class="member-right-right-1-email" id="kj_con_3" style=" display:none">
          <ul>
            <li> 帐号：<input name="mail_name" onfocus="this.select" type="text" />
              <select name="mailSelect" class="mrr-1e-1">
				<option selected>选择您的邮箱</option> 
				<option value="http://mail.sina.com.cn/cgi-bin/login.cgi">@sina.com</option> 
				<option value="http://reg.163.com/in.jsp?url=http://fm163.163.com/coremail/fcg/ntesdoor2?username=wd.dm.mailForm.name.value">@163.com</option> 
				<option value="http://login.mail.sohu.com/chkpwd.php">@sohu.com</option> 
				<option value="http://login.chinaren.com/zhs/servlet/Login;url;http:/mail.chinaren.com">@ChinaRen.com</option> 
				<option value="http://bjweb.163.net/cgi/163/login_pro.cgi">@163.net</option> 
				<option value="http://bjweb.mail.tom.com/cgi/163/login_pro.cgi">@Tom.com</option> 
				<option value="http://webmail.21cn.com/NULL/NULL/NULL/NULL/NULL/SignIn.gen">@21cn.com</option> 
				<option value="https://edit.bjs.yahoo.com/config/login">@yahoo.com.cn</option> 
				<option value="http://entry.126.com/cgi/login">@126.com</option> 
				<option value="http://g2wm.263.net/xmweb">@263.net</option> 
				<option value="http://freemail.eyou.com/cgi-bin/login">@eyou.com</option> 
				<option value="http://vip.sina.com/cgi-bin/login.cgi">@vip.sina.com</option> 
				<option value="http://vip.163.com/payment/VipLogon.jsp">@vip.163.com</option> 
				<option value="http://paymail.china.com/extend/gb/NULL/NULL/NULL/SignIn.gen">@China.com</option> 
				<option value="http://mw1.elong.com/cgi-bin/weblogon.cgi">@elong.com</option> 
				<option value="http://login.etang.com/servlet/login;BackURL;http:/mail.etang.com/cgi/door">@etang.com</option> 
				<option value="http://www.citiz.net/login.jsp">@citiz.net</option> 
				<option value="http://202.106.186.230/extend/newgb1/NULL/NULL/NULL/SignIn.gen">@email.com.cn</option> 
              </select>
            </li>
            <li class="mrr-1e-2">密码：<input name="mail_password" onfocus="this.select" type="password"/>
            </li>
            <li class="mrr-1e-3"><input name="" type="button" value="登 录" class="btn-002" onclick="return log_submit();"  style="width:65px" /> <a href="http://www.topfo.com/links/default.html">申请邮箱</a></li>
          </ul>
        </div>
      <%--</form>--%>
      
<%--       <form>
        <div class="member-right-right-1-email" id="Div1" style=" display:none">
          <ul>
            <li> 帐号：<input name="" type="text" />
              <select name="" class="mrr-1e-1">
                <option>163.com</option>
              </select>
            </li>
            <li class="mrr-1e-2">密码：<input name="" type="password"/>
            </li>
            <li class="mrr-1e-3"><a href="#" class="f_cen" style="text-decoration: underline">登录</a> <a href="#">申请邮箱</a></li>
          </ul>
        </div>
        </form>--%>
      </div>
      <div class="member-right-right-1">
        <h1>拓富推广</h1>
        <div class="member-right-right-1-1 tuiguang" runat="server" id="DivNaID">
         
        </div>
      </div>
    </div>
<%--    <div class="liucheng">
      <h1>
        <ul>
          <li class="btn_on"  id="lc_btn_1" onmousemove="SetBtn('lc',1);">招商流程</li>
          <li id="lc_btn_2" onmousemove="SetBtn('lc',2);">投资流程</li>
          <li id="lc_btn_3" onmousemove="SetBtn('lc',3);">融资流程</li>
          <li id="lc_btn_4" onmousemove="SetBtn('lc',4);">专 服</li>
          <li id="lc_btn_5" onmousemove="SetBtn('lc',5);">贷款流程</li>
        </ul>
      </h1>
      <div class="liucheng-1" id="lc_con_1">
        <ul>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
        </ul>
      </div>
      <div class="liucheng-1" id="lc_con_2" style="display:none">
        <ul>
          <li><a href="#">s注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
        </ul>
      </div>
      <div class="liucheng-1" id="lc_con_3" style="display:none">
        <ul>
          <ul>
            <li><a href="#">u注册/登陆</a></li>
            <li><a href="#">注册/登陆</a></li>
            <li><a href="#">注册/登陆</a></li>
            <li><a href="#">注册/登陆</a></li>
            <li><a href="#">注册/登陆</a></li>
          </ul>
        </ul>
      </div>
      <div class="liucheng-1" id="lc_con_4" style="display:none">
        <ul>
          <li><a href="#">r注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
        </ul>
      </div>
      <div class="liucheng-1" id="lc_con_5" style="display:none">
        <ul>
          <li><a href="#">h注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
          <li><a href="#">注册/登陆</a></li>
        </ul>
      </div>
    </div>--%>

</asp:Content>

