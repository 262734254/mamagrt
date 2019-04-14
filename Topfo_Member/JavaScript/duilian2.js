var coupletcode;

coupletcode = "<DIV id=sidebar1 style='left: 0px; POSITION: absolute; TOP: 50px; VISIBILITY: hidden;' width=100>32</div><DIV id=sidebar12 style='right: 0px; POSITION: absolute; TOP: 50px; VISIBILITY: hidden' width=100>32</div>";

if (window.screen.width>=1024)
{
document.write(coupletcode);
}

function InsertCouplet()
{
if (window.screen.width>=1024){	
document.all.sidebar1.style.visibility = "visible";
document.all.sidebar12.style.visibility = "visible";
document.all.sidebar1.innerHTML = "<OBJECT classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0 WIDTH=100 HEIGHT=286 id=left2FF> <PARAM NAME=movie VALUE=/images/flash/duilian_20061113z.swf> <PARAM NAME=quality VALUE=high> <EMBED id=left2FFG src=/images/flash/duilian_20061113z.swf quality=high wmode=transparent  WIDTH=100 HEIGHT=286 NAME=zuo TYPE=application/x-shockwave-flash PLUGINSPAGE=http://www.macromedia.com/go/getflashplayer></EMBED></OBJECT>";
document.all.sidebar12.innerHTML = "<OBJECT classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0 WIDTH=100 HEIGHT=286 id=you2FF> <PARAM NAME=movie VALUE=/images/flash/duilian_20061113z.swf> <PARAM NAME=quality VALUE=high> <EMBED id=you2FFG src=/images/flash/duilian_20061113z.swf quality=high wmode=transparent  WIDTH=100 HEIGHT=286 NAME=you2 TYPE=application/x-shockwave-flash PLUGINSPAGE=http://www.macromedia.com/go/getflashplayer></EMBED></OBJECT>";

}
}

	InsertCouplet();

	/*function left2FFG_DoFSCommand(command,args){
		if ((command == "SohuCLFS")&&(args =="hidecouplet")){
			document.all.sidebar1.style.visibility = "hidden";
			document.all.sidebar12.style.visibility = "hidden";
		}
	}*/
	
	function left2FFG_DoFSCommand(command, args) {
		document.all.sidebar1.style.visibility = "hidden";
		document.all.sidebar12.style.visibility = "hidden";
	} 
	
	function you2FFG_DoFSCommand(command,args){
		left2FFG_DoFSCommand(command,args);
	}
	<!--
	if (document.all){
		document.write("<Script language=\"JavaScript\" For=\"you2FF\" Event=\"FSCommand(command,args)\">\n");
		document.write("	left2FFG_DoFSCommand(command,args);\n");
		document.write("</Script>\n");
		document.write("<Script language=\"JavaScript\" For=\"left2FF\" Event=\"FSCommand(command,args)\">\n");
		document.write("	left2FFG_DoFSCommand(command,args);\n");
		document.write("</Script>\n");
	}
	//-->
	var dl_init_pos = dl_last_pos = document.getElementById("sidebar1").style.posTop
	dulianMove();
	function dulianMove()
	{
		var target_pos = document.body.scrollTop + dl_init_pos 
		var step=(target_pos - dl_last_pos)/5|0 
		document.getElementById("sidebar1").style.posTop += step
		document.getElementById("sidebar12").style.posTop += step
		dl_last_pos += step 
		setTimeout(dulianMove, 50);
	}
	
