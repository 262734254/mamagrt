//document.write(new Array(100).join("<br>"))
var coupletcode = '<div id="oLayer2" style="LEFT:0px; VISIBILITY:visible; POSITION:absolute; TOP:415px"><a href="http://www.tz888.cn/surveypaper/surveypaper.aspx" target="_blank"></a></div>'
document.write(coupletcode);
document.all.oLayer2.innerHTML = "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='108' height='108'><param name='movie' value='/images/flash/20060630_xl_fz.swf'><param name='quality' value='high'><embed src='/images/flash/20060630_xl_fz.swf' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='108' height='108'></embed></object>";
if(window.screen.width < 800)
{
    oLayer2.style.left = window.screen.width * 0.80;
	//oLayer1.style.left = 5
	//oLayer1.style.top = oLayer2.style.top = 200
}
else
{
	if(window.screen.width == 800)
	{
		//oLayer1.style.left = 5
    	oLayer2.style.left = 670 //window.screen.width * 0.80;
		//oLayer1.style.top = oLayer2.style.top =300		
	}
	else
	{
		//oLayer1.style.left = 5
		oLayer2.style.left = 900
	}
}
var init_pos=last_pos=oLayer2.style.posTop 
setInterval(function scrollit(){ 
target_pos=document.body.scrollTop+init_pos 
step=(target_pos-last_pos)/5|0 
//oLayer1.style.posTop += step 
oLayer2.style.posTop += step
last_pos+=step 
},100) 
