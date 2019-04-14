

function LoginAlert(strUrl){
	//window.pwShow("/cmLogin.do",300,240,1,null);
	// var strUrl = "/Capital/ShowContact.aspx?infoid=74092" ;
	window.pwShow(strUrl,469,430,1,null);
}

function RefreshAlert(strUrl)
{
	var mwidth=500;
	var mheight=478;	
	window.showModalDialog(strUrl,'','help:0;resizable:1;dialogWidth:'+mwidth+'px;dialogHeight:'+mheight+'px');


}



function loginRedirect(strUrl){
	location.href=strUrl;
}



