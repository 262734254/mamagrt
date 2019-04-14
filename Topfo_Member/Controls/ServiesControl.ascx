<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ServiesControl.ascx.cs" Inherits="Controls_ServiesControl" %>
<table cellspacing="0" cellpadding="0" width="430px" border="0">
    <tr>
        <td colspan="3" style="height: 22px">
            <select id="ServiceList" name="ServiceList" style="width: 140px;" onchange="javascript:changeServiceListB();">
                <option selected="selected">--选择服务大类别--</option>
            </select>
        </td>
    </tr>
    <tr>
        <td align="left">
            <select id="sltServiesM" size="6" runat="server" ondblclick="ServiesMoreControl1_SelectServies.add();"
                style="width: 140px">
                <option selected="selected">--选择服务小类别--</option>
            </select>
        </td>
        <td align="center">
            <input type="button" name="btnAddServies" onclick="<%=this.ClientID %>_SelectServies.add();"
                id="btnAddServies" value="添加&gt;&gt;" />
            <br /> <br />
            <input type="button" name="btnDelServies" onclick="<%=this.ClientID %>_SelectServies.del();"
                id="btnDelServies" value="<<删除" />
        </td>
        <td align="center">
            <select id="sltServiesName_Select" style="width: 131px;" ondblclick="ServiesMoreControl1_SelectServies.del();"
                size="6" runat="server">
            </select>
        </td>
    </tr>
    <tr>
        <td colspan="5">
            请认真选择贵单位能提供的服务类别，用户将根据服务类别查询到服务单位。
        </td>
    </tr>
</table>
<input id="hdselectBValue" type="hidden" runat="server" />
<input id="hdselectMValue" type="hidden" runat="server" />

<script type="text/javascript" language="javascript">
function changeServiceListB()
{
    var hideServiceBID = document.getElementById("<%=this.hdselectBValue.ClientID %>");
    var hideServiceMID = document.getElementById("<%=this.hdselectMValue.ClientID %>");
    var ServiceBID = document.getElementById("ServiceList").value;
	AjaxServies.GetServiesMList(ServiceBID,initServiceMCall);
}
function changeServiceListM()
{
    var hideServiceMID = document.getElementById("<%=this.hdselectMValue.ClientID %>");
    var ServiceMID = document.getElementById("<%=this.sltServiesM.ClientID %>").value;
    document.getElementById(hideServiceMID).value = ServiceMID;
}
function initServiceCall(response)
{
	var droplist = document.getElementById("ServiceList");
	fillDropdown(response.value,droplist);
	if(document.getElementById("<%=this.hdselectBValue.ClientID %>").value!="")
	{
	    droplist.value=document.getElementById("<%=this.hdselectBValue.ClientID %>").value;
	    changeServiceListB();
	}
}
function initServiceMCall(response)
{
    var droplist = document.getElementById("<%=this.sltServiesM.ClientID %>");
    fillDropdown(response.value,droplist);
    if(document.getElementById("<%=hdselectMValue.ClientID %>").value!="")
         droplist.value=document.getElementById("<%=hdselectMValue.ClientID %>").value;
}
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
function SelectServies(ServiesNameSelectID,HdselectValueBID,HdselectValueMID,prefix)
{

    this.ServiesNameSelectID = ServiesNameSelectID; //显示选中行业的容器ID
    this.HdselectValueBID = HdselectValueBID; //隐藏控件BID容器
    this.HdselectValueMID = HdselectValueMID; //隐藏控件MID容器
    this.Prefix = prefix; //生成DOM元素ID的前缀
}

SelectServies.prototype.addHide = function(t,v,l){
    var text = t + "," + v + "&";
    var objB = document.getElementById(this.HdselectValueBID);
    var objM = document.getElementById(this.HdselectValueMID);
    if(l=="0")
    {
         objB.value += text;
    }
    else
    {
         objM.value += text;
    }

}

SelectServies.prototype.removeHide = function(t,v){
    var text = t + "," + v + "&";
    var objB = document.getElementById(this.HdselectValueBID);
    var objM= document.getElementById(this.HdselectValueMID);
    var oldBValue = objB.value;
    var oldMValue = objM.value;
    var arr = text.split('|');
    if(arr.length==1)
    {
         objB.value = oldBValue.replace(text,"");
         objM.value = oldMValue.replace(text,"");
    }
    if(arr.length==2)
    {
        var arrT=t.split('-');
        var arrV=v.split('|');
        var t1=arrT[0]+","+arrV[0]+"&";
        var t2=t+","+arr[1];
        objB.value = oldBValue.replace(t1,"");
        objM.value = oldMValue.replace(t2,"");
    }
}
function SelectIsExitItem(objSelect,objItemText)
{
     var isExit = false;
     for(var i=0;i<objSelect.options.length;i++)
     {
         if(objSelect.options[i].text == objItemText)
         {
             isExit = true;
             break;
         }
     }     
     return isExit;
}

SelectServies.prototype.add = function()
{
    var objB = document.getElementById("ServiceList");
    var objM=document.getElementById("<%=sltServiesM.ClientID %>")
    var objSelect = document.getElementById("<%=sltServiesName_Select.ClientID %>");
    
    if(objB.selectedIndex == -1)
        return;
    if(objB.value == "")
        return;
   if(objB.value!=""&&objM.value=="")//只选择大类
   {
        var text = objB.options[objB.selectedIndex].text;//选择的文本

        var value = objB.options[objB.selectedIndex].value;
        var index = objB.selectedIndex;
        if(!SelectIsExitItem(objSelect,text))
        {
            var oOption = new Option(text,value);
            objSelect.options[objSelect.length] = oOption;
            this.addHide(text,value,0);
        }
    }
    if(objB.value!=""&&objM.value!="")//选择大类和小类

    {
        var textM = objM.options[objM.selectedIndex].text;//选择的文本
        var textB = objB.options[objB.selectedIndex].text;//大类的文本
        var valueM = objM.options[objM.selectedIndex].value;
        var valueB = objB.options[objB.selectedIndex].value;
        var index = objM.selectedIndex;
        var strText=textB+"-"+textM;
        if(!SelectIsExitItem(objSelect,strText))
        {
            var oOption = new Option(strText,valueB+"|"+valueM);
            objSelect.options[objSelect.length] = oOption;
            this.addHide(strText,valueM,1);
            this.addHide(objB.options[objB.selectedIndex].text,objB.options[objB.selectedIndex].value,0);
        }
   }
    
}

SelectServies.prototype.del = function()
{
    var objB = document.getElementById("ServiceList");
    var objSelect = document.getElementById(this.ServiesNameSelectID);
    if(objSelect.selectedIndex == -1)
        return;
    var index = objSelect.selectedIndex;
    var text = objSelect.options[index].text;
    var value = objSelect.options[index].value;
    objSelect.remove(index);
    var arr=value.split('|');
    if(arr.length=="1")
    {
        this.removeHide(text,value,0);
    }
   else
   {
       this.removeHide(text,arr[0]+"|"+arr[1],1);
   }
  
}
var <%=this.ClientID %>_SelectServies = new SelectServies("<%=this.sltServiesName_Select.ClientID %>","<%=this.hdselectBValue.ClientID %>","<%=this.hdselectMValue.ClientID %>","<%=this.ClientID %>");

AjaxServies.GetServiesList(initServiceCall);
</script>

