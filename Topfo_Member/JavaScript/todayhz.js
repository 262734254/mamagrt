
var focus_width=457
var focus_height=282
var text_height=0
var swf_height = focus_height+text_height

var pics='/images/swap/hz01.jpg|/images/swap/hz02.jpg|/images/swap/hz03.jpg|/images/swap/hz04.jpg|/images/swap/hz05.jpg'
var links='http://www.zyexp.com/2007cyz|http://www.tz888.cn/images/中国连锁特许加盟代理博览会邀请函.doc|http://www.tz888.cn/images/2007国际投融资项目洽谈会.doc|http://www.tz888.cn/images/文交会邀请函.doc|http://www.zhixuanw.com'
var texts='a|b|c|d|e'

document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/images/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
document.write('<embed src="/images/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#ffffff" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');		document.write('</object>');

