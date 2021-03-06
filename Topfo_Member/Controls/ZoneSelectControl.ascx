﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ZoneSelectControl.ascx.cs"
    Inherits="Tz888.Member.Controls.ZoneSelectControl" %>
<select id="CountryListCN" style="width: 120px" onchange="javascript:changeCountry();"
    name="CountryListCN">
    <option selected="selected">中国</option>
</select>
<div id="AreaSpan" style="width: 397px; padding-top: 5px; display: inline;">
    <select id="provinceCN" style="width: 80px" onblur="changeCheckZoneStatus();" onchange="javascript:changeProvince();"
        name="provinceCN">
        <option selected="selected">省份</option>
    </select>
    <select id="capitalCN" style="width: 150px" onchange="javascript:changeCapital();"
        name="capitalCN">
        <option selected="selected">地级市</option>
    </select>
    <select id="cityCN" style="width: 150px" onchange="javascript:changeCounty();" name="cityCN">
        <option selected="selected">县级地区</option>
    </select>
</div>
<span id='spZoneSelect'></span>
<input id="hideCountryCode" type="hidden" name="hideCountryCode" runat="server" />
<input id="hideCounty" type="hidden" name="hideCounty" runat="server" />
<input id="hideProvince" type="hidden" name="hideProvince" runat="server" />
<input id="hideCapitalCity" type="hidden" name="hideCapitalCity" runat="server" />

<script type="text/javascript" language="javascript">

var hideCountryCodeID = "<%=hideCountryCode.ClientID %>";
var hideCountyID = "<%=hideCounty.ClientID %>";
var hideProvinceID = "<%=hideProvince.ClientID %>";
var hideCapitalCityID = "<%=hideCapitalCity.ClientID %>";
var initCheckZone = false;

function fillDropdown(value,dropDown)
{      
    if(value == null)
        return ;
    dropDown.length = 0;
    var piArray = value.split(",");
    for(var i=0;i<piArray.length;i++)
    {
        var ary1 = piArray[i].toString().split("|");
        try
        {
            dropDown.options.add(new Option(ary1[1].toString(),ary1[0].toString()));
        }
        catch(e){}
    } 
    dropDown.selectedIndex = 0;
}

function initCountryCall(response)
{
	var countryEL = document.getElementById("CountryListCN");
	fillDropdown(response.value,countryEL);
	var countryCode = document.getElementById(hideCountryCodeID).value;
	if(countryCode == "")
	{
		countryCode = "CN";


	}
	document.getElementById("CountryListCN").value = countryCode;		
	changeCountry();
	checkZoneSelect(false);


}

function changeCountry()
{
	var countryCode = document.getElementById("CountryListCN").value;
	document.getElementById(hideCountryCodeID).value = countryCode;
	if(countryCode == "CN")
	{
	    document.getElementById("AreaSpan").style.display = "inline";
	   
	}
	else
	{
	    document.getElementById("AreaSpan").style.display = "none";
		document.getElementById(hideProvinceID).value = "";
		document.getElementById(hideCountyID).value = "";
		document.getElementById(hideCapitalCityID).value = "";
	} 
	AjaxMethod.GetProvinceList(countryCode,countryCall);
	checkZoneSelect(false);
}

function countryCall(response)
{
	var provinceEL = document.getElementById("provinceCN");
	fillDropdown(response.value,provinceEL);
	var provinceCode = document.getElementById(hideProvinceID).value;
    
	provinceEL.value = provinceCode;
	if(provinceEL.selectedIndex < 0)
	{
		provinceEL.selectedIndex = 0;
	}
	changeProvince();
}

function changeProvince()
{
	var provinceCode = document.getElementById("provinceCN").value;
	document.getElementById(hideProvinceID).value = provinceCode;
	AjaxMethod.GetCityList(provinceCode,provinceCall);
	checkZoneSelect(false);
}

function provinceCall(response)
{
	var capitalEL = document.getElementById("capitalCN");
	fillDropdown(response.value,capitalEL);
	var capitalCityCode = document.getElementById(hideCapitalCityID).value;

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
	document.getElementById(hideCapitalCityID).value = capitalCode;
	AjaxMethod.GetCountyList(capitalCode,capitalCall);
	checkZoneSelect(false);
}

function capitalCall(response)
{
	var cityEL = document.getElementById("cityCN");
	fillDropdown(response.value,cityEL);
	var countyCode = document.getElementById(hideCountyID).value;
    
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
	document.getElementById(hideCountyID).value = cityCode;
	checkZoneSelect(false);
}
function changeCheckZoneStatus()
{
    initCheckZone = true;
}

function checkZoneSelect(type)
{
    if(!initCheckZone&&!type)
        return false;
    var countryCode = document.getElementById(hideCountryCodeID).value.trim();
    
    if(countryCode != "CN")
    {
        document.getElementById("spZoneSelect").innerHTML = "";
        document.getElementById("spZoneSelect").className = "";
        return true;
    }
    var capitalEL = document.getElementById(hideCapitalCityID);
    
    if(capitalEL.value == "")
    {
        document.getElementById("spZoneSelect").innerHTML = "";
        document.getElementById("spZoneSelect").innerHTML = "&nbsp;&nbsp;&nbsp;所属区域选择必须到城市！";
        document.getElementById("spZoneSelect").className = "noteawoke";
        document.getElementById("CountryListCN").focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneSelect").innerHTML = "";
        document.getElementById("spZoneSelect").className = "";
        return true;
    }
}


AjaxMethod.GetCountryList(initCountryCall);

</script>