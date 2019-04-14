
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ZoneMoreSelectControl.ascx.cs"
    Inherits="Tz888.Member.Controls.ZoneMoreSelectControl" %>
<div class="local">
    <div class="left" style="height: 68px; width: 279px;">
        <select id="CountryListCN" style="width: 136px" onchange="javascript:changeCountry();"
            name="CountryListCN">
            <option selected="selected">中国</option>
        </select>
        <div id="AreaSpan" style="width: 271px; padding-top: 5px; display: inline; height: 1px;
            line-height: normal;">
            <select id="provinceCN" style="width: 92px" onchange="javascript:changeProvince();"
                name="provinceCN">
                <option selected="selected">省份</option>
            </select>
            <select id="capitalCN" style="width: 92px; margin-top:4px;" onchange="javascript:changeCapital();"
                name="capitalCN">
                <option selected="selected">地级市</option>
            </select>
            <select id="cityCN" style="width: 141px; margin-top:4px;" onchange="javascript:changeCounty();" name="cityCN">
                <option selected="selected">县级地区</option>
            </select>
        </div>
        <br />
        <span class="hui">投资区域可多选，若不填，则默认为所有区域。</span></div>
    <div class="zhong" style="height: 28px">
        <input type="button" name="button" onclick="javascript:addZone();" id="button" value="添加&gt;&gt;" />
        <br />
        <input type="button" name="button2" onclick="javascript:delZone();" id="button2"
            value="<<删除" /></div>
    <div class="right" style="vertical-align: middle; height: 79px; text-align: center;
        width: 260px;">
        <select id="sltZone_Select" style="width: 220px;" size="4" runat="server">
        </select>
    </div>
</div>
<input id="hideCountryCode" type="hidden" name="hideCountryCode" runat="server" style="width: 1px" />
<input id="hideCounty" type="hidden" name="hideCounty" runat="server" style="width: 1px" />
<input id="hideProvince" type="hidden" name="hideProvince" runat="server" style="width: 1px" />
<input id="hideCapitalCity" type="hidden" name="hideCapitalCity" runat="server" style="width: 1px" />
<input id="hideSelectZone" type="hidden" name="hideSelectZone" runat="server" style="width: 1px;" />
<input id="hidListCount" type="hidden" runat="server" />
<script type="text/javascript" language="javascript">

var hideCountryCodeID = "<%=hideCountryCode.ClientID %>";
var hideCountyID = "<%=hideCounty.ClientID %>";
var hideProvinceID = "<%=hideProvince.ClientID %>";
var hideCapitalCityID = "<%=hideCapitalCity.ClientID %>";
var hideSelectZoneID = "<%=hideSelectZone.ClientID %>";
var sltZone_SelectID = "<%=sltZone_Select.ClientID %>";
var hidListCountID = "<%=hidListCount.ClientID %>";
var ZoneMaxCount = "<%=MaxCount %>";

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
}

function addZone()
{   
    var objListCount = document.getElementById(hidListCountID);
    var listCount = objListCount.value;
    if(ZoneMaxCount<=listCount){
        alert("最多只能添加5个区域！");
        return;
    }
    var objCountry = document.getElementById("CountryListCN");
    var objProvince = document.getElementById("provinceCN");
    var objCity = document.getElementById("capitalCN");
    var objCounty = document.getElementById("cityCN");
    
    var objSelect = document.getElementById(sltZone_SelectID);
    
    if(objCountry == null || objCountry.value == "")
        return;
    if(objCountry.value != "CN"){
        var text = objCountry.options[objCountry.selectedIndex].text;
        if(checkSelect(text)){
            var oOption=new Option(objCountry.options[objCountry.selectedIndex].text,objCountry.value);
            objSelect.options[objSelect.length]=oOption;
            SaveVelue(objCountry.value);
            listCount++;
            objListCount.value = listCount;
        }
        return;
    }
    else{
        var strText = "";
        var strValue = "";
        strText = objCountry.options[objCountry.selectedIndex].text + " ";
        strValue = objCountry.value;
        if(objProvince.value != ""){
            strText += objProvince.options[objProvince.selectedIndex].text + " ";
            strValue += "," + objProvince.value;
            if(objCity.value != ""){
                strText += objCity.options[objCity.selectedIndex].text + " ";
                strValue += "," + objCity.value;
                if(objCounty.value != ""){
                    strText += objCounty.options[objCounty.selectedIndex].text + " ";
                    strValue += "," + objCounty.value;
                }
            }
        }
        if(checkSelect(strText)){
            var oOption=new Option(strText,strValue);
            objSelect.options[objSelect.length]=oOption;
            SaveVelue(strValue);
            listCount++;
            objListCount.value = listCount;
        }
    }
    
}

function delZone()
{
    var objSelect = document.getElementById(sltZone_SelectID);
    if(objSelect.selectedIndex == -1)
        return;    
    var objListCount = document.getElementById(hidListCountID);
    var listCount = objListCount.value;
    var value = objSelect.value;
    objSelect.remove(objSelect.selectedIndex);
    DeleteValue(value);
    listCount--;
    objListCount.value = listCount;
}

function checkSelect(t)
{
    //alert(t);
    var objSelect = document.getElementById(sltZone_SelectID);
    if(objSelect.length == 0)
        return true;
    t = t.trim();
    for(var i = 0; i < objSelect.length; i++)
    {
        var tmp = objSelect.options[i].text.trim();
        if(tmp == t){
            return false;
        }
    }
    return true;
}

function SaveVelue(v){
    var objSelectZone = document.getElementById(hideSelectZoneID);
    var oldValue = objSelectZone.value;
    if(oldValue == ""){
        objSelectZone.value = v + "|";
        return;
    }
    var piArray = oldValue.split("|");  
    for(var i=0;i<piArray.length;i++)
    {
        
        var tmpValue = piArray[i].toString();
        if(tmpValue == v){
            return;
        }
    }
    objSelectZone.value = oldValue + v + "|"; 
}

function DeleteValue(v){
    var objSelectZone = document.getElementById(hideSelectZoneID);
    var oldValue = objSelectZone.value;
    v = v + "|";
    oldValue = oldValue.replace(v,"");
    objSelectZone.value = oldValue;
}
AjaxMethod.GetCountryList(initCountryCall);

</script>

