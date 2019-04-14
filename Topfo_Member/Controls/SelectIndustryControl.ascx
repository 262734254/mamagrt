<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectIndustryControl.ascx.cs"
    Inherits="Tz888.Member.Controls.SelectIndustryControl" %>
<style type="text/css">
<!--
.sictabnew {
}
.sictabnew td{ border:0; padding:0}
-->
</style>
<table width="400" border="0" cellpadding="0" cellspacing="0" class="sictabnew">
    <tbody>
        <tr>
            <td width="40%">
                <label>
                    <span class="left">
                        <select id="sltIndustryName_all" style="width: 151px;" runat="server" size="4">
                        </select>
                    </span>
                </label>
            </td>
            <td valign="middle" width="20%">
                <span>
                    <input type="button" name="btnAddIndustry" onclick="<%=this.ClientID %>_SelectIndustry.add();"
                        id="btnAddIndustry" value="添加&gt;&gt;" />
                    <br />
                    <br />
                    <input type="button" name="btnDelIndustry" onclick="<%=this.ClientID %>_SelectIndustry.del();"
                        id="btnDelIndustry" value="<<删除" />
                </span>
            </td>
            <td width="40%">
                <span class="right">
                    <select id="sltIndustryName_Select" style="width: 151px;" size="4" runat="server">
                    </select>
                </span>
            </td>
        </tr>
    </tbody>
</table>
<div id="divHide" runat="server">
</div>
<input id="hdselectCount" type="hidden" value="0" runat="server" />
<input id="hdselectValue" type="hidden" runat="server" />
<span class="hui">最多可添加
    <%=this.MaxCount %>
    种行业。如选择有误，选择对应行业，点击 “删除”按钮即可。</span> <span id="spSelectIndustry"></span>

<script type="text/javascript" language="javascript">
function SelectIndustry(maxCount,selectCount,industryNameAllID,industryNameSelectID,hdselectValueID,prefix,selectCountID)
{
    this.MaxCount = maxCount; //最大行业数
    this.SelectCount = selectCount; //已选择行业数
    this.IndustryNameAllID = industryNameAllID; //显示所有行业的容器ID
    this.IndustryNameSelectID = industryNameSelectID; //显示选中行业的容器ID
    this.HdselectValueID = hdselectValueID; //隐藏控件容器
    this.Prefix = prefix; //生成DOM元素ID的前缀
    this.SelectCountID = selectCountID; //已选中行业数目容器
}

SelectIndustry.prototype.addHide = function(t,v){
    var text = t + "," + v + "|";
    var obj = document.getElementById(this.HdselectValueID);
    obj.value += text;
    //alert(obj.value);
}

SelectIndustry.prototype.removeHide = function(t,v){
    var text = t + "," + v + "|";
    var obj = document.getElementById(this.HdselectValueID);
    var oldValue = obj.value;
    obj.value = oldValue.replace(text,"");
    //alert(obj.value);
}
	
SelectIndustry.prototype.add = function()
{
    var objAll = document.getElementById(this.IndustryNameAllID);
    var objSelect = document.getElementById(this.IndustryNameSelectID);
    if(objAll.selectedIndex == -1)
        return;
    if(objSelect.length > this.MaxCount - 1){
        alert("最多只能同时选择" + this.MaxCount + "个行业!");
        return;
    }
    var text = objAll.options[objAll.selectedIndex].text;
    var value = objAll.options[objAll.selectedIndex].value;
    var index = objAll.selectedIndex;
    var oOption = new Option(text,value);
    objSelect.options[objSelect.length] = oOption;
    this.addHide(text,value);
    objAll.remove(index);
    this.SelectCount++;
    document.getElementById(this.SelectCountID).value = this.SelectCount;
    this.check();
}

SelectIndustry.prototype.del = function()
{
    var objAll = document.getElementById(this.IndustryNameAllID);
    var objSelect = document.getElementById(this.IndustryNameSelectID);
    if(objSelect.selectedIndex == -1)
        return;
    var index = objSelect.selectedIndex;
    var text = objSelect.options[index].text;
    var value = objSelect.options[index].value;
    var oOption=new Option(objSelect.options[index].text ,objSelect.options[index].value); 
    objAll.options[objAll.length]=oOption; 
    objSelect.remove(index); 
    this.removeHide(text,value);
    this.SelectCount--;
    document.getElementById(this.SelectCountID).value = this.SelectCount;
    this.check();
}

SelectIndustry.prototype.check = function()
{
    if(this.SelectCount<=0)
    {
        document.getElementById("spSelectIndustry").innerHTML = "&nbsp;&nbsp;&nbsp;请选至少选择一个行业！";
        document.getElementById("spSelectIndustry").className = "noteawoke";
        document.getElementById("btnAddIndustry").focus();
		return false;
	}
	else
	{
	    document.getElementById("spSelectIndustry").innerHTML = "";
        document.getElementById("spSelectIndustry").className = "";
		return true;
	}
}

var <%=this.ClientID %>_SelectIndustry = new SelectIndustry(<%=this.MaxCount %>,<%=this.SelectCount %>,"<%=this.sltIndustryName_all.ClientID %>","<%=this.sltIndustryName_Select.ClientID %>","<%=this.hdselectValue.ClientID %>","<%=this.ClientID %>","<%=this.hdselectCount.ClientID %>");
</script>

