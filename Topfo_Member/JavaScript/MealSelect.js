
function initFeedBack()
		{
			AjaxMethod.GetMemberGrade(initBTypeCall);			
		}
		
function initBTypeCall(response)
		{
			var BTypeList = document.getElementById("listBig");
			fillDropdown(response.value,BTypeList);
			var bCode = document.getElementById("hideBig").value;
			BTypeList.value = bCode;
			if(bCode!="" && bCode!=null)
			{
				if(BTypeList.selectedIndex < 0)
				{
					BTypeList.selectedIndex = 0;
				}			
				changeBTypeList();	
			}		
		}
		
function changeBTypeList()
		{
			var bCode = document.getElementById("listBig").value;
			document.getElementById("hideBig").value = bCode;
			if(bCode!="" && bCode!=null)
			{
				AjaxMethod.GetMealName(bCode,BTypeListCall);
			}
			else
			{		

				document.getElementById("listSmall").options.length=0;
			}
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
						strbigtype = "请选择会员类别"
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
	if(!document.getElementById("listSmall").options.length<=0)
	{
		var STypeList = document.getElementById("listSmall");
		if(isFirst)
		{
			document.getElementById("lblType").innerText = "请选择VIP会员类型";
			isFirst=false;
			//InitListBox();
		}
		else
		{
			document.getElementById("hideSmall").value = STypeList.value;
		}
		
		for(var i=0;i<document.getElementById("listSmall").options.length;i++)
		{	
			if(document.getElementById("listSmall").options[0].selected==true)
			{
				document.getElementById("lblType").innerText = "请选择VIP会员类型";
				break;
			}
		var str1;
		var str2;
		if(document.getElementById("listSmall").options[i].selected==true)
		{
			str1=document.getElementById("listSmall").options[i].text;
			switch (str1.substr(2))
			{
				case "银牌融资会员":
					var str2 = "-4800元/年<a href='/Service/VIPproject.shtml#01' target='_blank'>（详细介绍）</a>";
				break;				
				case "金牌融资会员":
					str2 = "-9800元/年<a href='/Service/VIPproject.shtml#02' target='_blank'>（详细介绍）</a>";
					break;
				case "翡翠融资会员":
					str2 = "-16800元/年<a href='/Service/VIPproject.shtml#03' target='_blank'>（详细介绍）</a>";
					break;
				case "钻石融资会员":
					str2 = "-36800元/年<a href='/Service/VIPproject.shtml#04' target='_blank'>（详细介绍）</a>";
					break;
				
				case "银牌招商会员":
					str2 = "-4800元/年<a href='/Service/VIPmerchant.shtml#01' target='_blank'>（详细介绍）</a>";
					break;
				case "金牌招商会员":
					str2 = "-9800元/年<a href='/Service/VIPmerchant.shtml#02' target='_blank'>（详细介绍）</a>";
					break;
				case "翡翠招商会员":
					str2 = "-16800元/年<a href='/Service/VIPmerchant.shtml#03' target='_blank'>（详细介绍）</a>";
					break;
				case "钻石招商会员":
					str2 = "-36800元/年<a href='/Service/VIPmerchant.shtml#04' target='_blank'>（详细介绍）</a>";
					break;
					
				case "银牌投资会员":
					str2 = "-4800元/年<a href='/Service/VIPcapital.shtml#01' target='_blank'>（详细介绍）</a>";
					break;
				case "金牌投资会员":
					str2 = "-9800元/年<a href='/Service/VIPcapital.shtml#02' target='_blank'>（详细介绍）</a>";
					break;
				case "翡翠投资会员":
					str2 = "-16800元/年<a href='/Service/VIPcapital.shtml#03' target='_blank'>（详细介绍）</a>";
					break;
				case "钻石投资会员":
					str2 = "-36800元/年<a href='/Service/VIPcapital.shtml#04' target='_blank'>（详细介绍）</a>";
					break;
				default:
					break;
			}				
			document.getElementById("lblType").innerHTML = "您选择的VIP会员类型为： VIP"+str1.substr(2)+str2;
			break;			
		}
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
		
