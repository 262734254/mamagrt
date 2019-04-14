<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ZoneSelectControl2.ascx.cs"
    Inherits="Tz888.Member.Controls.ZoneSelectControl" %>
<select id="CountryListCN2" style="width: 120px" onchange="javascript:changeCountry2();"
    name="CountryListCN2">
    <option selected="selected">中国</option>
</select>
<div id="AreaSpan2" style="width: 397px; padding-top: 5px; display: inline;">
    <select id="provinceCN2" style="width: 80px" onblur="changeCheckZoneStatus2();" onchange="javascript:changeProvince2();"
        name="provinceCN2">
        <option selected="selected" value="0">省份</option>
    </select>
    <select id="capitalCN2" style="width: 150px" onchange="javascript:changeCapital2();"
        name="capitalCN2">
        <option selected="selected" value="0">地级市</option>
    </select>
    <select id="cityCN2" style="width: 150px" onchange="javascript:changeCounty2();" name="cityCN2">
        <option selected="selected" value="0">县级地区</option>
    </select>
</div>
<span id='spZoneSelect2'></span>
<input id="hideCountryCode2" type="hidden" name="hideCountryCode2" runat="server" />
<input id="hideCounty2" type="hidden" name="hideCounty2" runat="server" />
<input id="hideProvince2" type="hidden" name="hideProvince2" runat="server" />
<input id="hideCapitalCity2" type="hidden" name="hideCapitalCity2" runat="server" />

<script type="text/javascript" language="javascript">

var hideCountryCode2ID = "<%=hideCountryCode2.ClientID %>";
var hideCounty2ID = "<%=hideCounty2.ClientID %>";
var hideProvince2ID = "<%=hideProvince2.ClientID %>";
var hideCapitalCity2ID = "<%=hideCapitalCity2.ClientID %>";
var initCheckZone2 = false;

function fillDropdown2(value,dropDown)
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

function initCountryCall2(response)
{
	var countryEL = document.getElementById("CountryListCN2");
	fillDropdown2(response.value,countryEL);
	var countryCode = document.getElementById(hideCountryCode2ID).value;
	if(countryCode == "")
	{
		countryCode = "CN";
	}
	document.getElementById("CountryListCN2").value = countryCode;		
	changeCountry2();
	checkZoneSelect2(false);
}

function  changeCountry2()
{
	var countryCode = document.getElementById("CountryListCN2").value;
	document.getElementById(hideCountryCode2ID).value = countryCode;
	if(countryCode == "CN")
	{
	    document.getElementById("AreaSpan2").style.display = "inline";
	   
	}
	else
	{
	    document.getElementById("AreaSpan2").style.display = "none";
		document.getElementById(hideProvince2ID).value = "";
		document.getElementById(hideCounty2ID).value = "";
		document.getElementById(hideCapitalCity2ID).value = "";
	} 
	AjaxMethod.GetProvinceList(countryCode,countryCall2);
	checkZoneSelect2(false);
}

function countryCall2(response)
{
	var provinceEL = document.getElementById("provinceCN2");
	fillDropdown2(response.value,provinceEL);
	var provinceCode = document.getElementById(hideProvince2ID).value;
    
	provinceEL.value = provinceCode;
	if(provinceEL.selectedIndex < 0)
	{
		provinceEL.selectedIndex = 0;
	}
	changeProvince2();
}

function changeProvince2()
{
	var provinceCode = document.getElementById("provinceCN2").value;
	document.getElementById(hideProvince2ID).value = provinceCode;
	AjaxMethod.GetCityList(provinceCode,provinceCall2);
	checkZoneSelect2(false);
}

function provinceCall2(response)
{
	var capitalEL = document.getElementById("capitalCN2");
	fillDropdown2(response.value,capitalEL);
	var capitalCityCode = document.getElementById(hideCapitalCity2ID).value;

	capitalEL.value = capitalCityCode;
	if(capitalEL.selectedIndex < 0 )
	{
		capitalEL.selectedIndex = 0;
	}
	changeCapital2();
}
function changeCapital2()
{
	var capitalCode = document.getElementById("capitalCN2").value;
	document.getElementById(hideCapitalCity2ID).value = capitalCode;
	AjaxMethod.GetCountyList(capitalCode,capitalCall2);
	checkZoneSelect2(false);
}

function capitalCall2(response)
{
	var cityEL = document.getElementById("cityCN2");
	fillDropdown2(response.value,cityEL);
	var countyCode = document.getElementById(hideCounty2ID).value;
    
	cityEL.value = countyCode;
	if(cityEL.selectedIndex < 0)
	{
		cityEL.selectedIndex = 0;
	}
	changeCounty2();
}
function changeCounty2()
{
	var cityCode = document.getElementById("cityCN2").value;
	document.getElementById(hideCounty2ID).value = cityCode;
	checkZoneSelect2(false);
}
function changeCheckZoneStatus2()
{
    initCheckZone2 = true;
}

function checkZoneSelect2(type)
{
    if(!initCheckZone2&&!type)
        return false;
    var countryCode = document.getElementById(hideCountryCode2ID).value.trim();
    
    if(countryCode != "CN")
    {
        document.getElementById("spZoneSelect2").innerHTML = "";
        document.getElementById("spZoneSelect2").className = "";
        return true;
    }
    var capitalEL = document.getElementById(hideCapitalCity2ID);
    
    if(capitalEL.value == "")
    {
        document.getElementById("spZoneSelect2").innerHTML = "";
        document.getElementById("spZoneSelect2").innerHTML = "&nbsp;&nbsp;&nbsp;所属区域选择必须到城市！";
        document.getElementById("spZoneSelect2").className = "noteawoke";
        document.getElementById("CountryListCN2").focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneSelect2").innerHTML = "";
        document.getElementById("spZoneSelect2").className = "";
        return true;
    }
}


AjaxMethod.GetCountryList(initCountryCall2);

</script>