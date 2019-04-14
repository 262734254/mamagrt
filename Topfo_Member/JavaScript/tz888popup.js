function checkTz888popup()
{   
	
   return true;	
}

function do_it()
{
	if ( checkTz888popup() )
	{
	//document.body.insertBefore(this.Tz888_chk_show,document.getElementsByTagName('div')[0]);
	var anim = function()
		{
			n += 5;
				if(n >= 45){
				document.getElementById('tz888_chk_show').style.marginTop = "0";
				window.clearInterval(t1);
				}else{
				document.getElementById('tz888_chk_show').style.marginTop = "-"+(45 - n)+"px";
				}
			},n=0;
			var t1 = window.setInterval(anim,80);
		}
		//setCookieTz888popup() ;
}

function close_chk_show()
{

	var anim = function()
	{
		n += 5;
		//alert(n);
		if(n >= 45){
		document.getElementById('tz888_chk_show').style.marginTop = "-45px";
		//document.getElementById('Tz888_chk_show').style.display = "none";
		window.clearInterval(t1);
		}else{
		document.getElementById('tz888_chk_show').style.marginTop = "-"+ n +"px";
		}
	},n=0;

		var t1 = window.setInterval(anim,80);
}



