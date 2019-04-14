var focus_width=190
var focus_height=155
var text_height=0
var swf_height = focus_height+text_height

var pics='/web1.1/img/swap/01.jpg|/web1.1/img/swap/02.jpg|/web1.1/img/swap/03.jpg|/web1.1/img/swap/04.jpg|/web1.1/img/swap/05.jpg'
var links='http://www.tz888.cn/News/200703/NZZIntl20070307_92256.shtml|http://www.tz888.cn/News/200703/NTheZH20070307_92236.shtml|http://www.tz888.cn/News/200703/NFDC20070307_92281.shtml|http://www.tz888.cn/zhuanti/news/index.htm|http://www.tz888.cn/mipage/zjzxm.shtml'
var texts='a|b|c|d|e'

document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/images/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
document.write('<embed src="/images/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#ffffff" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');		document.write('</object>');
