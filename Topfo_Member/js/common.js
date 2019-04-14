//全选
function chkAll() 
{ 
    var a = document.getElementsByTagName("input"); 
	for (var i=0; i<a.length; i++) 
	 if (a[i].type == "checkbox") 
		a[i].checked =true;
}
//反选
function RechkAll() 
{ 
    var a = document.getElementsByTagName("input"); 
	for (var i=0; i<a.length; i++) 
	 if (a[i].type == "checkbox") 
		a[i].checked =!a[i].checked; 
}
//选择框Value
function chkValue()
{
    var a = document.documentElement.getElementsByTagName("input");
    var str="";
	for (var i=0; i<a.length; i++) 
	{
		if (a[i].type == "checkbox")
		{
			if(a[i].checked)
			{
				str+=a[i].value+",";
    		}
	    }
	}
    return str;
}

function backres(res)
{

    if(res.value)
        window.location.reload();
    else
        alert('删除失败!请重试..');
}
function $id(obj)
{
    return document.getElementById(obj);
}
function isNumber(obj)
{
    var re = /^[1-9]+[0-9]*]*$/   
    if (!re.test(obj))
        return false;
    else
        return true;
}