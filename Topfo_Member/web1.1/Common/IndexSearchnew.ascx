<form id="form_Search" name="form_Search" action="" method="post" target="_blank">
	<div class="search">
		<div class="menu">
			<div class="st_c">
				<div name='searchmenu' id="searchmenu" class="miaobianh_t" onclick="ChangeSearchMenu(0);">全部</div>
				<div name='searchmenu' id="searchmenu" class="bottom" onclick="ChangeSearchMenu(1);">投资</div>
				<div name='searchmenu' id="searchmenu" class="bottom" onclick="ChangeSearchMenu(2);">融资</div>
				<div name='searchmenu' id="searchmenu" class="bottom" onclick="ChangeSearchMenu(3);">招商</div>
				<div name='searchmenu' id="searchmenu" class="bottom" onclick="ChangeSearchMenu(4);">资讯</div>
			</div>
		</div>
		<div class="input">
			<div class="kuang">
				<input type="text" id='txtKeyWord' onblur='javascript:blurEdit(this);' style="COLOR: #999999;HEIGHT:18px;"
					onfocus='javascript:focusEdit(this);' size='75' value='输入关键字进行搜索' name='txtKeyWord'
					helptext="输入关键字进行搜索"> <input id='hideKey' type='hidden' value='0' name='hideKey'>
				<a href="JavaScript:doSubmit();"><img src="../img/search_ailiu.gif" width="80" height="26" align="absMiddle" /></a>
				<a href="http://www.tz888.cn/Member/Info/PublishCapital.aspx" target="_blank"><img src="../img/pulishpic.gif" width="108" height="26" align="absMiddle"></a>
				<div class="greyzi">热门关键字： 
				<a href="#">坯布</a> 
				<a href="#">工艺品</a> 
				<a href="#">暖气片</a>
				<a href="#">压克力</a> 
				<a href="#">螺旋藻</a> 
				<a href="#">钣金</a> 
				<a href="#">尼龙管</a> 
				<a href="#">压克力</a> 
				<a href="#">螺旋藻</a> 
				<a href="#">钣金</a> 
				&nbsp; <a href="#" style="TEXT-DECORATION: none">更多&gt;&gt; </a>
				</div>
			</div>
		</div>
		<script type="text/javascript" language="javascript">initPostUrl()</script>
	</div>
</form>
