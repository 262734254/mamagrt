<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TFZSEvaluateGQ.ascx.cs"
    Inherits="Controls_TFZSEvaluateGQ" %>

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
                    if(currentListItem.checked)
                        currentListItem.checked = false;
                }
            }
        }
     }
     else
        document.getElementById(lastItemid).checked = false;
}

function CheckTFZSGQForm()
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

    var id1 = "<%=this.rbl16.ClientID %>";
    var name1 = id1.replace(/_/g,"$");
	if(GetCheckNum(name1)<=0)
	{
		document.getElementById(id1).focus();
		alert("请选择您领导团队组建时间！");
		return false;
	}
    
	if(GetCheckBoxListCheckNum('<%=this.cbl17.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl17.ClientID %>').focus();
		alert("请选择您的领导团队人员构成！");
		return false;
	}

    var id2 = "<%=this.rbl18.ClientID %>";
    var name2 = id2.replace(/_/g,"$");
	if(GetCheckNum(name1)<=0)
	{
		document.getElementById(id2).focus();
		alert("请选择领导团队操作项目数！");
		return false;
	}
    var id3 = "<%=this.rbl19.ClientID %>";
    var name3 = id3.replace(/_/g,"$");
	if(GetCheckNum(name3)<=0)
	{
		document.getElementById(id3).focus();
		alert("请选择对领导团队的激励机制！ ");
		return false;
	}

    var id4 = "<%=this.rbl20.ClientID %>";
    var name4 = id4.replace(/_/g,"$");
	if(GetCheckNum(name4)<=0)
	{
		document.getElementById(id4).focus();
		alert("请选择行业市场增长率！");
		return false;
	}
    
    var id5 = "<%=this.rbl21.ClientID %>";
    var name5 = id5.replace(/_/g,"$");
	if(GetCheckNum(name5)<=0)
	{
		document.getElementById(id5).focus();
		alert("请选择产品更新周期！ ");
		return false;
	}

	if(GetCheckBoxListCheckNum('<%=this.cbl22.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl22.ClientID %>').focus();
		alert("您的产品（服务）是否拥有知识产权、技术标准？ ");
		return false;
	}

    var id6 = "<%=this.rbl23.ClientID %>";
    var name6 = id6.replace(/_/g,"$");
	if(GetCheckNum(name6)<=0)
	{
		document.getElementById(id6).focus();
		alert("请选择研发经费占销售额比重！ ");
		return false;
	}

	if(GetCheckBoxListCheckNum('<%=this.cbl24.ClientID %>') <= 0)
	{
		document.getElementById('<%=this.cbl24.ClientID %>').focus();
		alert("请选择营销方式！");
		return false;
	}
    
    var id7 = "<%=this.rbl25.ClientID %>";
    var name7 = id7.replace(/_/g,"$");
	if(GetCheckNum(name7)<=0)
	{
		document.getElementById(id7).focus();
		alert("请选择资产负债率！");
		return false;
	}
	
	var id8 = "<%=this.rbl26.ClientID %>";
    var name8 = id8.replace(/_/g,"$");
	if(GetCheckNum(name8)<=0)
	{
		document.getElementById(id8).focus();
		alert("请选择项目内部收益率IRR！");
		return false;
	}
	var id9 = "<%=this.rbl27.ClientID %>";
    var name9 = id9.replace(/_/g,"$");
	if(GetCheckNum(name9)<=0)
	{
		document.getElementById(id9).focus();
		alert("请选择投资净现值NPV！");
		return false;
	}
	var id10 = "<%=this.rbl28.ClientID %>";
    var name10 = id10.replace(/_/g,"$");
	if(GetCheckNum(name10)<=0)
	{
		document.getElementById(id10).focus();
		alert("请选择NPV/项目总融资额 ！");
		return false;
	}
	
	var id11 = "<%=this.rbl29.ClientID %>";
    var name11 = id11.replace(/_/g,"$");
	if(GetCheckNum(name11)<=0)
	{
		document.getElementById(id11).focus();
		alert("请选择企业发展阶段！");
		return false;
	}
	
	var id12 = "<%=this.rbl30.ClientID %>";
    var name12 = id12.replace(/_/g,"$");
	if(GetCheckNum(name12)<=0)
	{
		document.getElementById(id12).focus();
		alert("请选择要求资金到位情况！");
		return false;
	}
	var id13 = "<%=this.rbl31.ClientID %>";
    var name13 = id13.replace(/_/g,"$");
	if(GetCheckNum(name13)<=0)
	{
		document.getElementById(id13).focus();
		alert("请选择融资额占股份比重！");
		return false;
	}
	
	var id14 = "<%=this.rbl32.ClientID %>";
    var name14 = id14.replace(/_/g,"$");
	if(GetCheckNum(name14)<=0)
	{
		document.getElementById(id14).focus();
		alert("请选择最大股东股份比重！");
		return false;
	}
	
	var id15 = "<%=this.rbl33.ClientID %>";
    var name15 = id15.replace(/_/g,"$");
	if(GetCheckNum(name15)<=0)
	{
		document.getElementById(id15).focus();
		alert("请选择投资者控制权！");
		return false;
	}
	
	if(GetCheckBoxListCheckNum('<%=this.cbl34.ClientID %>')<=0)
	{
		document.getElementById('<%=this.cbl34.ClientID %>').focus();
		alert("请选择退出方式！");
		return false;
	}
}
</script>


<style type="text/css">
<!--
A.blue:link,A.blue:visited,A.blue:active{COLOR: #08099F;
 text-decoration: underline;}/* 兰色链接样式2 */
A.blue:hover {COLOR: #F87120;text-decoration: underline;}
.hong{	color:#FF0000;}/*红色1 */
-->
</style>
<div class="assessbox cshibiank" >
    <h1 class="lightc">
  <span class="hong">请认真填写下面的问题，填写完之后点击“查看评价结果”按钮，即可得到对应的拓富指数及相关的评价。</span>  <a href="http://www.topfo.com/help/TopfoZS.shtml#12" target="_blank" class="blue">为什么要参与项目投资价值评估？</a></h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 40%" align="right">
                        是否属于高新技术产业 ：</td>
                    <td align="left">
                        <asp:CheckBoxList ID="cblIsNewIndustry" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        项目立项情况 ：</td>
                    <td style="height: 45px" align="left">
                        <asp:CheckBoxList ID="cblProjectInstance" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList><br />
                        <span class="hui">说明：项目若缺乏所需批文、执照和证件，则对项目评价有较大影响</span></td>
                </tr>
                <tr>
                    <td align="right">
                        领导团队组建时间 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl16" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        领导团队人员构成 ：</td>
                    <td align="left">
                        <asp:CheckBoxList ID="cbl17" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        领导团队操作项目数 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl18" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        对领导团队的激励机制 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl19" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        行业市场增长率 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl20" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        产品更新周期 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl21" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        产品（服务）是否拥有知识产权、技术标准 ：</td>
                    <td align="left">
                        <asp:CheckBoxList ID="cbl22" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        研发经费占销售额比重 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl23" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        营销方式 ：
                    </td>
                    <td align="left">
                        <asp:CheckBoxList ID="cbl24" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td align="right">
                        资产负债率 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl25" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        项目内部收益率IRR ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl26" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        投资净现值NPV ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl27" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        NPV/项目总融资额 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl28" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        企业发展阶段 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl29" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        要求资金到位情况 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl30" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        融资额占股份比重 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl31" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        最大股东股份比重 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl32" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        投资者控制权 ：</td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbl33" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right">
                        退出方式 ：</td>
                    <td align="left">
                        <asp:CheckBoxList ID="cbl34" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
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