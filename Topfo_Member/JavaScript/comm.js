//全选与反选
function chkAll() 
{ 
    var a = document.getElementsByTagName("input"); 
	for (var i=0; i<a.length; i++) 
	 if (a[i].type == "checkbox") 
		a[i].checked =!a[i].checked; 
}
function chkAll2() 
{ 
    var a = document.getElementsByTagName("input"); 
	for (var i=0; i<a.length; i++) 
	 if (a[i].type == "checkbox") 
		a[i].checked =true; 
}
/*
function chkValue()
{
    var a = document.documentElement.getElementsByTagName("input");
    var str="";
	for (var i=0; i<a.length-3; i++) 
	{
		if (a[i].type == "checkbox")
		{
			if(a[i].checked)
			{
				str+=a[i].value+",";
    		}
	    }
	}
	if(str!="")
	{
	    if(confirm('确定删除吗?'))
	        return str;
	}
	else
	{
	   alert("请选择所要删除的项");
	}
}*/