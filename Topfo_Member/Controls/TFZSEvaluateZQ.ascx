<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TFZSEvaluateZQ.ascx.cs" Inherits="Controls_TFZSEvaluateZQ" %>

<script type="text/javascript" language="javascript">
 
function GetCheckBoxListCheckNum(checkobjectid)
{
    var selectedItemCount = 0;
    var liIndex = 0;
    var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    while (currentListItem != null)
    {
        if (currentListItem.checked) selectedItemCount++;
        liIndex++;
        currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    }
    return selectedItemCount;
}

function GetCheckNum(checkobjectname)
{
	var truei2 = 0;
	var checkobject = document.getElementsByName(checkobjectname);
//	var checkobject = eval("document.all." + checkobjectname + "");
	var inum = checkobject.length;
	if (isNaN(inum))
	{
		inum = 0;
	}
	for(i=0;i<inum;i++){
		if (checkobject[i].checked == 1){
			truei2 = truei2 + 1;
		}
	}
	return truei2;
}

function CheckBoxListCheckSelect(checkobjectid,obj)
{
    var selectid = obj.id;
    var selectedItemCount = 0;
    var liIndex = 0;
    var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    while (currentListItem != null)
    {
        liIndex++;
        currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    }
    var lastItemid = checkobjectid + '_' + (liIndex-1).toString();
    if(selectid == lastItemid){
        LastListItem = document.getElementById(lastItemid);
        if (LastListItem.checked){
            liIndex--;
            for(i = 0;i<liIndex;i++){
                currentListItem = document.getElementById(checkobjectid + '_' + i.toString());
                if (currentListItem != null){
                    if(currentListItem.checked){
                        currentListItem.checked = false;
                    }
                }
            }
        }
     }
     else{
        document.getElementById(lastItemid).checked = false;
     }
}
function CheckTFZSZQForm()
{
    	if(GetCheckBoxListCheckNum('<%=this.cblIsNewIndustry.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cblIsNewIndustry.ClientID %>').focus();
		alert("请选择是否属于高新技术产业！");
		return false;
	}
	
	if(GetCheckBoxListCheckNum('<%=this.cblProjectInstance.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cblProjectInstance.ClientID %>').focus();
		alert("请选择项目立项情况！");
		return false;
	}
	
	if(GetCheckBoxListCheckNum('<%=this.cbl1.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl1.ClientID %>').focus();
		alert("请选择项目是否符合产业政策！");
		return false;
	}
	
	var id1 = "<%=this.rbl2.ClientID %>";
    var name1 = id1.replace(/_/g,"$");
	if(GetCheckNum(name1)<=0)
	{
		document.getElementById(id1).focus();
		alert("请选择产品市场增长率！");
		return false;
	}
	
	var id2 = "<%=this.rbl3.ClientID %>";
    var name2 = id2.replace(/_/g,"$");
	if(GetCheckNum(name2)<=0)
	{
		document.getElementById(id2).focus();
		alert("请选择资产负债率！");
		return false;
	}
	
	var id3 = "<%=this.rbl4.ClientID %>";
    var name3 = id3.replace(/_/g,"$");
	if(GetCheckNum(name3)<=0)
	{
		document.getElementById(id3).focus();
		alert("请选择流动比率！");
		return false;
	}
	
	var id4 = "<%=this.rbl5.ClientID %>";
    var name4 = id4.replace(/_/g,"$");
	if(GetCheckNum(name4)<=0)
	{
		document.getElementById(id4).focus();
		alert("请选择速动比率！");
		return false;
	}
	
	var id5 = "<%=this.rbl6.ClientID %>";
    var name5 = id5.replace(/_/g,"$");
	if(GetCheckNum(name5)<=0)
	{
		document.getElementById(id5).focus();
		alert("请选投资收益率！");
		return false;
	}
	
	var id6 = "<%=this.rbl7.ClientID %>";
    var name6 = id6.replace(/_/g,"$");
	if(GetCheckNum(name6)<=0)
	{
		document.getElementById(id6).focus();
		alert("请选销售利润率！");
		return false;
	}
	
	var id7 = "<%=this.rbl8.ClientID %>";
    var name7 = id7.replace(/_/g,"$");
	if(GetCheckNum(name7)<=0)
	{
		document.getElementById(id7).focus();
		alert("请选企业发展阶段！");
		return false;
	}
	
	var id8 = "<%=this.rbl9.ClientID %>";
    var name8 = id8.replace(/_/g,"$");
	if(GetCheckNum(name8)<=0)
	{
		document.getElementById(id8).focus();
		alert("请选企业信用等级！");
		return false;
	}
	
	var id9 = "<%=this.rbl10.ClientID %>";
    var name9 = id9.replace(/_/g,"$");
	if(GetCheckNum(name9)<=0)
	{
		document.getElementById(id9).focus();
		alert("请选投资回报期！");
		return false;
	}
	
	var id10 = "<%=this.rbl11.ClientID %>";
    var name10 = id10.replace(/_/g,"$");
	if(GetCheckNum(name10)<=0)
	{
		document.getElementById(id10).focus();
		alert("请选自筹资金比重！");
		return false;
	}
	
	if(GetCheckBoxListCheckNum('<%=this.cbl12.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl12.ClientID %>').focus();
		alert("请选择还款来源！");
		return false;
	}

	if(GetCheckBoxListCheckNum('<%=this.cbl13.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl13.ClientID %>').focus();
		alert("请选择还款保障！");
		return false;
	}
	
	var id11 = "<%=this.rbl14.ClientID %>";
    var name11 = id11.replace(/_/g,"$");
	if(GetCheckNum(name11)<=0)
	{
		document.getElementById(id11).focus();
		alert("请选主营业务销售比重！");
		return false;
	}
	
	if(GetCheckBoxListCheckNum('<%=this.cbl15.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl15.ClientID %>').focus();
		alert("请选择产权变动可能性！");
		return false;
	}
}

</script>

<div class="assessbox cshibiank">
    <h1 class="lightc">
        投资机构对拓富指数非常重视，<span class="hong">请认真填写以下选项</span>。您也可以略过此步，但您可能因此错过改善项目质量、提升合作成功率的机会。</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 30%" align="right">
                        是否属于高新技术产业 ：</td>
                    <td>
                        <asp:CheckBoxList ID="cblIsNewIndustry" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        项目立项情况 ：</td>
                    <td style="height: 45px">
                        <asp:CheckBoxList ID="cblProjectInstance" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList><br />
                        <span class="hui">说明：项目若缺乏所需批文、执照和证件，则对项目评价有较大影响</span></td>
                </tr>
                <tr>
                    <td align="right">
                        项目是否符合产业政策 ：</td>
                    <td>
                        <asp:CheckBoxList ID="cbl1" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        产品市场增长率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl2" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        资产负债率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl3" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        流动比率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl4" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        速动比率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl5" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        投资收益率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl6" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        销售利润率 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl7" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        企业发展阶段 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl8" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        企业信用等级 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl9" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        投资回报期 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl10" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        自筹资金比重 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl11" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        还款来源 ：</td>
                    <td>
                        <asp:CheckBoxList ID="cbl12" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        还款保障 ：</td>
                    <td>
                        <asp:CheckBoxList ID="cbl13" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        主营业务销售比重 ：</td>
                    <td>
                        <asp:RadioButtonList ID="rbl14" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        产权变动可能性 ：</td>
                    <td>
                        <asp:CheckBoxList ID="cbl15" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
            </table>
            <div class="buttom" style="width: 100%; text-align: center;">
                <asp:Label id="lblInfo" runat="server"></asp:Label>
            </div>
            <div class="buttom" style="width: 100%; text-align: center;">
                <asp:Button ID="btnGetEvaluate" runat="server" Text="查看评价结果" OnClick="btnGetEvaluate_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<script language="javascript">
var id = "<%=this.lblInfo.ClientID %>";
function loading()
{
    var obj = document.getElementById(id);
    obj.innerHTML = "<table width=\"262\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">"+
                        "<tr><td width=\"262\" align=\"center\">"+
                            "<img src=\"http://www.topfo.com/Web13/images/down.gif\" />正在评价....</td></tr></table>";
}
</script>
