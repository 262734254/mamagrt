var coupletcode;

coupletcode = "<DIV id=sidebar style='LEFT: 0px; POSITION: absolute; TOP: 100px; VISIBILITY: hidden;' width=100>32</div><DIV id=sidebar2 style='right: 0px; POSITION: absolute; TOP: 100px; VISIBILITY: hidden' width=100>32</div>";

if (window.screen.width>=1024)
{
document.write(coupletcode);
}

function InsertCouplet()
{
if (window.screen.width>=1024){	
document.all.sidebar.style.visibility = "visible";
document.all.sidebar2.style.visibility = "visible";
document.all.sidebar.innerHTML = "<OBJECT classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0 WIDTH=100 HEIGHT=300 id=leftFF> <PARAM NAME=movie VALUE=/images/flash/yizhandl_z.swf> <PARAM NAME=quality VALUE=high> <EMBED id=leftFFG src=/images/flash/yizhandl_z.swf quality=high wmode=transparent  WIDTH=100 HEIGHT=300 NAME=zuo TYPE=application/x-shockwave-flash PLUGINSPAGE=http://www.macromedia.com/go/getflashplayer></EMBED></OBJECT>";
document.all.sidebar2.innerHTML = "<OBJECT classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0 WIDTH=100 HEIGHT=300 id=youFF> <PARAM NAME=movie VALUE=/images/flash/yizhandl_y.swf> <PARAM NAME=quality VALUE=high> <EMBED id=youFFG src=/images/flash/yizhandl_y.swf quality=high wmode=transparent  WIDTH=100 HEIGHT=300 NAME=you TYPE=application/x-shockwave-flash PLUGINSPAGE=http://www.macromedia.com/go/getflashplayer></EMBED></OBJECT>";

}
}

	InsertCouplet();

	/*function leftFFG_DoFSCommand(command,args){
		if ((command == "SohuCLFS")&&(args =="hidecouplet")){
			document.all.sidebar.style.visibility = "hidden";
			document.all.sidebar2.style.visibility = "hidden";
		}
	}*/
	
	function leftFFG_DoFSCommand(command, args) {
		document.all.sidebar.style.visibility = "hidden";
		document.all.sidebar2.style.visibility = "hidden";
	} 
	
	function youFFG_DoFSCommand(command,args){
		leftFFG_DoFSCommand(command,args);
	}
	<!--
	if (document.all){
		document.write("<Script language=\"JavaScript\" For=\"youFF\" Event=\"FSCommand(command,args)\">\n");
		document.write("	leftFFG_DoFSCommand(command,args);\n");
		document.write("</Script>\n");
		document.write("<Script language=\"JavaScript\" For=\"leftFF\" Event=\"FSCommand(command,args)\">\n");
		document.write("	leftFFG_DoFSCommand(command,args);\n");
		document.write("</Script>\n");
	}
	//-->
	var dl_init_pos = dl_last_pos = document.getElementById("sidebar").style.posTop
	dulianMove();
	function dulianMove()
	{
		var target_pos = document.body.scrollTop + dl_init_pos 
		var step=(target_pos - dl_last_pos)/5|0 
		document.getElementById("sidebar").style.posTop += step
		document.getElementById("sidebar2").style.posTop += step
		dl_last_pos += step 
		setTimeout(dulianMove, 50);
	}
	
