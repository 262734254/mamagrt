
var focus_width=372
var focus_height=192
var text_height=0
var swf_height = focus_height+text_height

var pics='/images/swap/lm01.jpg|/images/swap/lm02.jpg|/images/swap/lm03.jpg|/images/swap/lm04.jpg|/images/swap/lm05.jpg'
var links='http://www.gboforum.com/chs/gbo/service.php|http://www.zhixuanw.com|http://www.lyqiye.com/|http://www.crei.cn/|http://www.cinic.org.cn/'
var texts='a|b|c|d|e'

document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/images/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
document.write('<embed src="/images/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#ffffff" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');		document.write('</object>');
