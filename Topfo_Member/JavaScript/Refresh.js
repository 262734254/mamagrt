function RefreshType(strtype)
		{
			var name = document.getElementById("hidname").value;
			AjaxMethod.GetRefreshTypeList(name,strtype,initRefreshCall);				
		}
function initRefreshCall(response)
		{
			fillDropdown(response.value);
		}

function fillDropdown(value)
		{	
　　　　    var piArray = value.split(",");
　　　　    
　　　　    for(var i=1;i<piArray.length;i++)
　　　　    {
　　　　　　    var ary1 = piArray[i].toString().split("|"); 
　　　　　　   // var chkSelect = document.getElementById("chkSelect");
　　　　		var lblTitle = document.getElementById("lblTitle");　　　　　    
　　　　　　    try
　　　　　　    {　　　　		　　　　　　    
　　　　　　		//chkSelect.value = ary1[0].toString()
　　　　　			lblTitle.innerText = ary1[1].toString();　　　　　			
　　　　　　    }
　　　　　　    catch(e)
　　　　　　    {}　　　  
　　　　    }
		}
		
/*		
		function fillDropdownAA(value)
		{	alert("aaaaaaaaaaaaaa");
　　　　    var piArray = value.split(",");
　　　　    var str="<table>":　　　　   
　　　　    for(var i=1;i<piArray.length;i++)
　　　　    { str +="<tr><td>畠僉</td><td>佚連炎籾</td></tr>";
　　　　　　    var ary1 = piArray[i].toString().split("|"); 
　　　　　　   // var chkSelect = document.getElementById("chkSelect");
　　　　		var lblTitle = document.getElementById("lblTitle");　　    
　　　　　　    try
　　　　　　    {　　　　　　　    
　　　　　　    str +="<tr><td>";
				str +=ary1[0].toString().innerText;
				str +="</td><td>";　
				str +=ary1[1].toString().innerText;
				str +="</td></tr>";
　　　　　　    }
　　　　　　    catch(e)
　　　　　　    {}　　　  
　　　　    }str +="</table>";lblTitle.innerText = str;
		}*/