function AjaxBack(URL)
{
	var xmlhttp=false;
	try 
	{
		xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
	} 
	catch (e) 
	{
		try
		{
			xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
		} 
	catch (E) 
	{
		xmlhttp = false;
		}
	}
	if(!xmlhttp && typeof XMLHttpRequest!='undefined') 
	{
		xmlhttp = new XMLHttpRequest();
	}
	xmlhttp.open("get",URL,true); 
	xmlhttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	xmlhttp.onreadystatechange = function() 
	{
	    
		if(xmlhttp.readyState==1) 
		{
			document.getElementById("divshopcarlist").innerHTML="正在请求……";
		}
		if(xmlhttp.readyState==3) 
		{
			document.getElementById("divshopcarlist").innerHTML="正在加载……";
		}
		if(xmlhttp.readyState==4) 
		{
			document.getElementById("divshopcarlist").innerHTML=xmlhttp.responseText;
		}
	}
	xmlhttp.send(null);
}