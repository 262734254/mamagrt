function fillDropdown(value,dropDown)
		{      
            dropDown.length = 0;
　　　　    var piArray = value.split(",");
　　　　    for(var i=0;i<piArray.length;i++)
　　　　    {
　　　　　　    var ary1 = piArray[i].toString().split("|");　　　　　　   
　　　　　　    try
　　　　　　    {
　　　　　　		dropDown.options.add(new Option(ary1[1].toString(),ary1[0].toString()));
　　　　　　    }
　　　　　　    catch(e)
　　　　　　    {}　　　　　　  
　　　　    }
　　　　    dropDown.selectedIndex = 0;
		}

function fillDropdownTech(value,dropDown)
		{  		
            dropDown.length = 0;
　　　　    var piArray = value.split(",");
　　　　    for(var i=0;i<1;i++)
　　　　    {
　　　　　　    var ary1 = piArray[18].toString().split("|");　　　　　　   
　　　　　　    try
　　　　　　    {
　　　　　　		dropDown.options.add(new Option(ary1[1].toString(),ary1[0].toString()));
　　　　　　    }
　　　　　　    catch(e)
　　　　　　    {}　　　　　　  
　　　　    }　　　　   
　　　　    dropDown.selectedIndex = 0;
		}
		
		function initZone()
		{
			AjaxMethod.GetCountryList("",initCountryCall);

		}
		
		//孃斌選男藻冱曝囃
		function initMerchantZone()
		{
			AjaxMethod.GetCountryList("CN",initCountryCall);

		}
		function initIndustry()
		{
			AjaxMethod.GetIndustryBList("",initIndustryCall);			
		}		
		
		function initCountryCall(response)
		{
			var countryEL = document.getElementById("CountryListCN");
			fillDropdown(response.value,countryEL);
			var countryCode = document.getElementById("hideCountyCode").value;
			if(countryCode == "")
			{
				countryCode = "CN";
			}
			countryEL.value = countryCode;			
			changeCountry();
		
			
		}
		function changeCountry()
		{
			var countryCode = document.getElementById("CountryListCN").value;
			document.getElementById("hideCountyCode").value = countryCode;
			if(countryCode == "CN")
			{
			document.getElementById("AreaSpan").style.display = "inline";
				//document.getElementById("provinceCN").style.display = "block";
				//document.getElementById("capitalCN").style.display = "block";
				//document.getElementById("cityCN").style.display = "block";
			}
			else
			{
			document.getElementById("AreaSpan").style.display = "none";
				//document.getElementById("provinceCN").style.display = "none";
				//document.getElementById("capitalCN").style.display = "none";
				//document.getElementById("cityCN").style.display = "none";
				document.getElementById("hideProvince").value = "";
				document.getElementById("hideCounty").value = "";
				document.getElementById("hideCapitalCity").value = "";
			}		
			AjaxMethod.GetProvinceList(countryCode,countryCall);
			
		}
		
		function countryCall(response)
		{
			var provinceEL = document.getElementById("provinceCN");
			fillDropdown(response.value,provinceEL);
			var provinceCode = document.getElementById("hideProvince").value;

			provinceEL.value = provinceCode;
			if(provinceEL.selectedIndex < 0)
			{
				provinceEL.selectedIndex = 0;
			}
			changeProvince();			
		}
		
		function changeProvince()
		{
			//alert("Change Province");
			var provinceCode = document.getElementById("provinceCN").value;
			document.getElementById("hideProvince").value = provinceCode;
			AjaxMethod.GetCityList(provinceCode,provinceCall);
		}
		
		function provinceCall(response)
		{
			var capitalEL = document.getElementById("capitalCN");
			fillDropdown(response.value,capitalEL);
			var capitalCityCode = document.getElementById("hideCapitalCity").value;

			capitalEL.value = capitalCityCode;
			if(capitalEL.selectedIndex < 0 )
			{
				capitalEL.selectedIndex = 0;
			}
			changeCapital();
		}
		function changeCapital()
		{
			var capitalCode = document.getElementById("capitalCN").value;
			document.getElementById("hideCapitalCity").value = capitalCode;
			AjaxMethod.GetCountyList(capitalCode,capitalCall);
		}
		
		function capitalCall(response)
		{
			var cityEL = document.getElementById("cityCN");
			fillDropdown(response.value,cityEL);
			var countyCode = document.getElementById("hideCounty").value;

			cityEL.value = countyCode;
			if(cityEL.selectedIndex < 0)
			{
				cityEL.selectedIndex = 0;
			}
			changeCounty();
		}
		function changeCounty()
		{
			var cityCode = document.getElementById("cityCN").value;
			document.getElementById("hideCounty").value = cityCode;
		}
		
		function initIndustryCall(response)
		{
		
			var BIndustryEL = document.getElementById("topCatFormKey");
			fillDropdownTech(response.value,BIndustryEL);
			var bCode = document.getElementById("hideIndustryB").value;
			BIndustryEL.value = bCode;
			if(BIndustryEL.selectedIndex < 0)
			{
				BIndustryEL.selectedIndex = 0;
			}
			changeBIndustry();
			
		}
		function changeBIndustry()
		{
			var bCode = document.getElementById("topCatFormKey").value;
			document.getElementById("hideIndustryB").value = bCode;
			AjaxMethod.GetIndustryMList(bCode,BIndustryCall);
		}
		
		function BIndustryCall(response)
		{
			var mIndustryEL = document.getElementById("secondCatFormKey");
			fillDropdown(response.value,mIndustryEL);
			var mIndustryCode = document.getElementById("hideIndustryM").value;
			mIndustryEL.value = mIndustryCode;
			if(mIndustryEL.selectedIndex < 0)
			{
				mIndustryEL.selectedIndex = 0;
			}
			changeMIndustry();
		}
		function changeMIndustry()
		{
			var mIndustryCode = document.getElementById("secondCatFormKey").value;
			document.getElementById("hideIndustryM").value = mIndustryCode;
		}	
