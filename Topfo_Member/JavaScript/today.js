
var focus_width=220
var focus_height=160
var text_height=0
var swf_height = focus_height+text_height

var pics='/images/swap/1.jpg|/images/swap/2.jpg|/images/swap/3.jpg|/images/swap/4.jpg|/images/swap/5.jpg'
var links='http://tz888.cn/News/200606/NTheOther200606292_41208.shtml|http://tz888.cn/News/200606/NC200606293_41196.shtml|http://tz888.cn/News/200606/NTheZH200606292_41190.shtml|http://tz888.cn/News/200606/ND200606281_41012.shtml|http://www.tz888.cn/mipage/zjzxm.shtml'
var texts='a|b|c|d|e'

document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="/images/pixviewer.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
document.write('<embed src="/images/pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#ffffff" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');		document.write('</object>');
