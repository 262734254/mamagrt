
function initFeedBack()
		{
			AjaxMethod.GetBigTypeList(initBTypeCall);			
		}
		
function initBTypeCall(response)
		{
			var BTypeList = document.getElementById("listBig");
			fillDropdown(response.value,BTypeList);
			var bCode = document.getElementById("hideBig").value;
			BTypeList.value = bCode;
			if(BTypeList.selectedIndex < 0)
			{
				BTypeList.selectedIndex = 0;
			}
			changeBTypeList();			
		}
		
function changeBTypeList()
		{
			var bCode = document.getElementById("listBig").value;
			document.getElementById("hideBig").value = bCode;
			AjaxMethod.GetSmallTypeList(bCode,BTypeListCall);
		}
var strbigtype;
function BTypeListCall(response)
		{
			var STypeList = document.getElementById("listSmall");
			fillDropdown(response.value,STypeList);
			var SCode = document.getElementById("hideBig").value;
			for(var k=1;k<document.getElementById("listBig").options.length;k++)
			{
				if(document.getElementById("listBig").options[0].selected==true)
				{
						strbigtype = "萩艇僉夲寄窃"
						break;
				}
				if(document.getElementById("listBig").options[k].selected==true)
				{
					strbigtype = document.getElementById("listBig").options[k].text;
					break;
				}
			}
			STypeList.value = SCode;
			if(STypeList.selectedIndex < 0)
			{
				STypeList.selectedIndex = 0;
			}
			changeMTypeList();
		}
		
function changeMTypeList()
{
	var STypeList = document.getElementById("listSmall");
	if(isFirst)
	{
		document.getElementById("lblType").innerText = "萩艇僉夲弌窃";
		isFirst=false;
		InitListBox();
	}
	else
	{
		document.getElementById("hideSmall").value = STypeList.value;
	}
	
	for(var i=0;i<document.getElementById("listSmall").options.length;i++)
	{	   
		if(document.getElementById("listSmall").options[0].selected==true)
	   {
			document.getElementById("lblType").innerText = "萩艇僉夲弌窃";
			break;
	   }
	   if(document.getElementById("listSmall").options[i].selected==true)
	   {
	      document.getElementById("lblType").innerText = "艇僉夲議窃艶葎��  "+strbigtype+document.getElementById("listSmall").options[i].text;
	      break;
	   }
	}	
}

function fillDropdown(value,listbox)
		{      
            listbox.length = 0;
            if(value != null)
            {
　　　　		var piArray = value.split(",");
　　　　		for(var i=0;i<piArray.length;i++)
　　　　		{
　　　　　　		var ary1 = piArray[i].toString().split("|");
　　　　　　		try
　　　　　　		{
　　　　　　			listbox.options.add(new Option(ary1[1].toString(),ary1[0].toString()));
　　　　　　		}
　　　　　　		catch(e)
　　　　　　		{}　　　　　　  
　　　　		}
　　　　    }
　　　　    else
　　　　    {}
　　　　    listbox.selectedIndex = 0;　　　　    
		}
		
