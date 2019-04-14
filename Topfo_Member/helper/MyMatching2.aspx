<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyMatching2.aspx.cs" Inherits="helper_MyMatching2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                搜索订阅</div>
            <div class="right">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" alt="" />
                <a href="http://www.topfo.com/help/subscribe.shtml#12" target="_blank">如何设置搜索订阅</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <%--<div class="handtop">
            <ul>
                <li><a href="MatchingInfo.aspx">我的订阅</a></li><li class="liwai">添加订阅 </li>
            </ul>
        </div>--%>
        <%--<div class=" cshibiank">--%>
        <div class="handtop">
            <ul>
                <li id="li1" onclick="Valuechange(1)" style="cursor: pointer">资本资源</li>
                <li id="li0" onclick="Valuechange(0)" style="cursor: pointer">政府招商</li>
                <li id="li2" onclick="Valuechange(2)" style="cursor: pointer">企业项目</li>
                <li id="li5" onclick="Valuechange(5)" style="cursor: pointer">资 讯</li>
            </ul>
        </div>
        <div class=" cshibiank">
            <div class="blank6">
            </div>
            <div class="subtab">
                <table id="ff" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
                    <tr>
                        <td align="center" class="bxian">
                            <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnlMerchant1" >
                                <tr>
                                    <td width="16%" align="right" class="12g" >
                                        招商类别：</td>
                                    <td width="84%" align="left" >
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:CheckBoxList ID="chkMerchantType" runat="server" DataValueField="MerchantTypeID"
                                                DataTextField="MerchantTypeName" RepeatColumns="3" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </font>                                    </td>
                                </tr>
                            </table>                        </td>
                    </tr>
                    <tr  style="display:none">
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnlMerchant2" >
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        产业类型：</td>
                                    <td align="left" width="84%">
                                        <asp:CheckBoxList ID="chkIndustry" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                            RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                        </asp:CheckBoxList></td>
                                </tr>
                            </table>                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table id="pnlCapitalType" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        <asp:Label ID="lbtype" runat="server" Text="投资类别："></asp:Label>
                                    </td>
                                    <td width="84%" align="left">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:CheckBoxList ID="chkFinancingTarget" runat="server" DataValueField="financingID"
                                                DataTextField="FinancingName" RepeatColumns="4" Width="272px" RepeatLayout="Flow">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList></font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table id="pnlCapital" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right" class="12g" style="height: 40px">
                                        <asp:Label ID="lbCapital" runat="server">金额：</asp:Label></td>
                                    <td width="337" align="left">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:CheckBoxList ID="chkCapital" runat="server" DataValueField="CapitalID" DataTextField="CapitalName"
                                                RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList></font></td>
                                    <td width="239" align="left" style="height: 40px">
                                        <font face="Arial, Helvetica, sans-serif">币种：<asp:DropDownList ID="ddlCapitalCurrency"
                                            runat="server" Width="76px">
                                        </asp:DropDownList>
                                        </font>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center" class="bxian">
                            <table id="pnlIndustryB" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="106" align="right" class="12g">
                                        <asp:Label ID="lbIndustryB" runat="server">招商行业：</asp:Label></td>
                                    <td width="158" align="left">
                                        <asp:ListBox ID="lstIndustryBLeft" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                            SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                    <td align="center" width="74">
                                        <input id="addIB" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBLeft'),document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'));"
                                            type="button" value=">>" name="addIB" />
                                        <br />
                                        <input id="cutIB" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstIndustryBRight'))"
                                            type="button" value="<<" name="cutIB" />
                                    </td>
                                    <td width="148">
                                        <asp:ListBox ID="lstIndustryBRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                            SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                    <td class="hui" width="181">
                                        最多选5项</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table id="pnlProvince" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="106" align="right" class="12g">
                                        <asp:Label ID="lbProvince" runat="server">融资省市：</asp:Label></td>
                                    <td width="158" align="left">
                                        <asp:ListBox ID="lstProvinceLeft" runat="server" Width="133px" DataValueField="ProvinceID"
                                            DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                                    <td width="74" align="center">
                                        <input id="addIP" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceLeft'),document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'))"
                                            type="button" value=">>" name="addIP" />
                                        <br />
                                        <input id="cutIP" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'))"
                                            type="button" value="<<" name="cutIP"></td>
                                    <td width="148">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:ListBox ID="lstProvinceRight" runat="server" Width="133px" DataValueField="ProvinceID"
                                                DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></font></td>
                                    <td class="hui" width="181">
                                        最多选5项</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table id="pnlNewType" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        资讯类别：</td>
                                    <td width="84%" align="left">
                                        <asp:CheckBoxList ID="chkNewsType" runat="server" Width="520px" DataValueField="NewsTypeID"
                                            DataTextField="NewsTypeName" RepeatColumns="4">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem></asp:ListItem>
                                        </asp:CheckBoxList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnlCarveoutType">
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        创业类型：</td>
                                    <td width="84%" align="left">
                                        <asp:RadioButtonList ID="rblCarveoutType" runat="server" Width="214px" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow">
                                            <asp:ListItem Value="0" Selected="True">资金找项目</asp:ListItem>
                                            <asp:ListItem Value="1">项目找资金</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnCooperationDemandTyp">
                                <tr>
                                    <td width="16%" align="right" class="12g" style="height: 20px">
                                        合作方式：</td>
                                    <td width="84%" align="left" style="height: 20px">
                                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow">
                                        </asp:CheckBoxList>
                                        <asp:CheckBoxList ID="chkLstCooperationDemand2" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow">
                                        </asp:CheckBoxList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table id="pnlCarveoutInd" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="106" align="right" class="12g">
                                        创业行业：</td>
                                    <td width="158" align="left">
                                        <asp:ListBox ID="lstCarveoutInd" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutInd'),document.getElementById('lstCarveoutIndRight'));"
                                            runat="server" DataValueField="IndustryCarveOutID" DataTextField="IndustryCarveOutName"
                                            SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                    <td align="center" width="74">
                                        <input id="Button2" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutInd'),document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutIndRight'));"
                                            type="button" value=">>" name="addIM" />
                                        <br />
                                        <input id="Button3" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstCarveoutIndRight'))"
                                            type="button" value="<<" name="cutIM" /></td>
                                    <td width="148" align="left">
                                        <asp:ListBox ID="lstCarveoutIndRight" runat="server" DataValueField="IndustryMID"
                                            DataTextField="IndustryName" SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                    <td class="hui" width="181">
                                        最多选5项</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table id="pnlOpporType" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        商机类型：</td>
                                    <td width="84%" align="left">
                                        <asp:RadioButtonList ID="rblOpporType" runat="server" Width="426px" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="01" Selected="True">供应</asp:ListItem>
                                            <asp:ListItem Value="02">采购</asp:ListItem>
                                            <asp:ListItem Value="03">代理</asp:ListItem>
                                            <asp:ListItem Value="04">合作</asp:ListItem>
                                            <asp:ListItem Value="05">加盟</asp:ListItem>
                                            <asp:ListItem Value="06">二手</asp:ListItem>
                                            <asp:ListItem Value="07">其他</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table id="pnlOpporInd" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="106" align="right" class="12g">
                                        商机行业：</td>
                                    <td width="158" align="left">
                                        <asp:ListBox ID="lstOpporIndleft" runat="server" DataValueField="IndustryOpportunityID"
                                            DataTextField="IndustryOpportunityName" SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                    <td align="center" width="74">
                                        <input id="Button4" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndleft'),document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndRight'));"
                                            type="button" value=">>" name="addIM" />
                                        <br />
                                        <input id="Button5" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstOpporIndRight'))"
                                            type="button" value="<<" name="cutIM" /></td>
                                    <td width="148">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:ListBox ID="lstOpporIndRight" runat="server" DataValueField="IndustryOpportunityID"
                                                DataTextField="IndustryOpportunityName" SelectionMode="Multiple" Width="133px"></asp:ListBox></font></td>
                                    <td class="12g" width="181">
                                        <font face="Arial, Helvetica, sans-serif">最多选5项</font><font face="Arial, Helvetica, sans-serif">&nbsp;</font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table id="pnlExhibitonInd" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="106" align="right" class="12g">
                                        会展行业：</td>
                                    <td width="158" align="left">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:ListBox ID="lstExhibitonIndleft" runat="server" DataValueField="IndustryExhibitionID"
                                                DataTextField="IndustryExhibitionName" SelectionMode="Multiple" Width="133px"></asp:ListBox></font></td>
                                    <td align="center" width="74">
                                        <input id="Button6" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndleft'),document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndRight'));"
                                            type="button" value=">>" name="addIM">
                                        <br />
                                        <input id="Button7" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstExhibitonIndRight'))"
                                            type="button" value="<<" name="cutIM" /></td>
                                    <td width="148">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:ListBox ID="lstExhibitonIndRight" runat="server" DataValueField="IndustryExhibitonID"
                                                DataTextField="IndustryExhibitonName" SelectionMode="Multiple" Width="133px"></asp:ListBox></font></td>
                                    <td class="12g" width="181">
                                        <font face="Arial, Helvetica, sans-serif">最多选5项</font><font face="Arial, Helvetica, sans-serif">&nbsp;</font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#ffffff" class="bxian">
                            <table id="pnlExpertType" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right" class="12g">
                                        专家类型：</td>
                                    <td align="left" width="84%">
                                        <font face="Arial, Helvetica, sans-serif">
                                            <asp:RadioButtonList ID="rblExpertType" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="01" Selected="True">投融资</asp:ListItem>
                                                <asp:ListItem Value="02">法律 </asp:ListItem>
                                                <asp:ListItem Value="03">营销</asp:ListItem>
                                                <asp:ListItem Value="04">管理</asp:ListItem>
                                                <asp:ListItem Value="05">经济 </asp:ListItem>
                                                <asp:ListItem Value="06">招商</asp:ListItem>
                                                <asp:ListItem Value="07">财务</asp:ListItem>
                                                <asp:ListItem Value="08">创业</asp:ListItem>
                                            </asp:RadioButtonList></font></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="bxian" style="width: 17%; height: 22px;">
                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="16%" align="right">
                                        发布时间：</td>
                                    <td width="84%" align="left">
                                        <asp:DropDownList ID="ddlValidateTerm" runat="server">
                                            <asp:ListItem Value="0" Selected="True">不限</asp:ListItem>
                                            <asp:ListItem Value="3">3天</asp:ListItem>
                                            <asp:ListItem Value="7">7天</asp:ListItem>
                                            <asp:ListItem Value="15">15天</asp:ListItem>
                                            <asp:ListItem Value="30">30天</asp:ListItem>
                                            <asp:ListItem Value="60">60天</asp:ListItem>
                                            <asp:ListItem Value="90">90天</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="bxian">
                            <table id="Table5" cellspacing="0" cellpadding="0" width="96%" border="0">
                                <tr>
                                    <td width="16%" align="right">
                                        请输入关键字：</td>
                                    <td align="left" width="84%">
                                        <asp:TextBox ID="txtKey" runat="server" Width="344px" MaxLength="200"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="center">
                        <td align="center" style="height: 97px">
                            <input id="hideIndustryExhibition" type="hidden" name="hideIndustryExhibition" runat="server" />
                            <input id="hideIndustryExhibitiontxt" type="hidden" name="hideIndustryExhibitiontxt"
                                runat="server" />
                            <input id="hideIndustryCarveout" type="hidden" name="hideIndustryCarveout" runat="server" />
                            <input id="hideIndustryCarveouttxt" type="hidden" name="hideIndustryCarveouttxt"
                                runat="server" />
                            <input id="hideIndustryM" type="hidden" name="hideIndustryM" runat="server" />
                            <input id="hideProvince" type="hidden" name="hideProvince" runat="server" />
                            <input id="hideIndustryB" type="hidden" name="hideIndustryB" runat="server" />
                            <input id="hideIndustryOppor" type="hidden" name="hideIndustryOppor" runat="server" />
                            <input id="hideIndustryOpportxt" type="hidden" name="hideIndustryOpportxt" runat="server" />
                            <input id="hideProvincetxt" type="hidden" name="hideProvincetxt" runat="server" />
                            <input id="hideIndustryBtxt" type="hidden" name="hideIndustryBtxt" runat="server" />
                            <input id="hideIndustryMtxt" type="hidden" name="hideIndustryMtxt" runat="server" />
                            <input id="Hidden1" type="hidden" runat="server" value="0" /><br />
                            <asp:Button CssClass="buttomal" ID="butSelect" runat="server" Text="搜 索" OnClick="butSelect_Click">
                            </asp:Button>
                            &nbsp;
                            <asp:Button CssClass="buttomal" ID="btnAdd" runat="server" Text="订 阅" OnClick="btnAdd_Click">
                            </asp:Button></td>
                    </tr>
                </table>
                <div class="blank20">
                </div>
            </div>
        </div>
        <div class="pagebox" align="center">
            <div class="clear">
                &nbsp;</div>
        </div>
    </div>

    <script>
function $id(obj)
{
    return document.getElementById("infoReceiveGridView_ctl02_"+obj);
}
function getid(obj)
{
    return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
}
function moveOver(a,b) {
    var sltLocationID = a;
    var sltSubLocationID = b;
    if (sltSubLocationID.options.length >= 5) {
        alert("不能超过5个");
        return;
    }
    var max = sltLocationID.options.length;
    var isMulti;
    var HaveMulti = false;    
    for (var i=0;i<max;i++) {
		isMulti = false;
		if (sltSubLocationID.options.length >= 5) {
					alert("不能超过5个");
					break; 
		}
        if (sltLocationID.options[i].selected) {
            for (var j=0;j<sltSubLocationID.options.length;j++) {
                if (sltSubLocationID.options[j].text == sltLocationID.options[i].text) {                    
                    isMulti = true;
                    HaveMulti = true;    
                    continue;
                }
            }
            if (!isMulti)
            {
				sltSubLocationID.options.add(new Option(sltLocationID.options[i].text,sltLocationID.options[i].value));
				 
			}
        }
       
    }
}

function moveOver1(a,b) {
    var sltLocationID = a;
    var sltSubLocationID = b;
    if (sltSubLocationID.options.length >= 5) 
    {
        alert("不能超过5个");
        return;
    }
}

function removeMe(c) {
        var sltSubLocationID = c;
    var max = sltSubLocationID.options.length-1 ;
    for (var i=max;i>=0;i--) {
        if (sltSubLocationID.options[i].selected) {
            sltSubLocationID.options.remove(i);
        }
    }
}

function FillToTxtFeild(a, b,e, thediv) {
    var listFeild = a;
    var textFeild = b;
    var listtext = e;
    var opionText="";
    
    var itemValue = '';
    var max = listFeild.options.length ;
    for (var i= 0 ;i < max;i++) {

		if(listFeild.options[i].value != "")
		{
		itemValue += listFeild.options[i].value;
		opionText +=listFeild.options[i].text;
		/*if(i < max)
		{*/
			itemValue += thediv;
			opionText += thediv;
		//}
		}
    }
    while(itemValue.charAt(itemValue.length-1) == thediv)
    {
		itemValue = itemValue.substring(0,itemValue.length-1)
    }
     while(opionText.charAt(opionText.length-1) == thediv)
    {
		opionText = opionText.substring(0,opionText.length-1)
    }
    textFeild.value = itemValue;   
    e.value = opionText; 
  //  alert( e.value);
}
    
    </script>

    <script language="javascript">
		<!--
		function init()
		{		
			pnlMerchant1.style.display="none";
			//pnlMerchant2.style.display="none";
			pnlCapitalType.style.display="none";
			pnlCapital.style.display="none";
			pnlIndustryB.style.display="none";
			
			pnlProvince.style.display="none";
			pnlNewType.style.display="none";
			pnlCarveoutType.style.display="none";
			pnlCarveoutInd.style.display="none";
			pnlOpporType.style.display="none";		
			pnlOpporInd.style.display="none";	
			pnlExhibitonInd.style.display="none";	
			pnlExpertType.style.display="none";	
			pnCooperationDemandTyp.style.display="none";
			//获取类型	
             var str=window.location.href; 
             var es1=/CustomType=/; 
             var typeVaule;
             if(es1.exec(str))    typeVaule=RegExp.rightContext; 
             else typeVaule="1";
             Valuechange(typeVaule)
        }	
			
		function Valuechange(obj) 
		{ 
			document.getElementById("ctl00_ContentPlaceHolder1_Hidden1").value = obj;
			if (obj=="0") //招商
			{
				pnlMerchant1.style.display="block";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="none";
				pnlCapital.style.display="block";
				pnlIndustryB.style.display="block";
			
				pnlProvince.style.display="block";
				pnlNewType.style.display="none";
				pnlCarveoutType.style.display="none";
				pnlCarveoutInd.style.display="none";
				pnlOpporType.style.display="none";		
			    pnlOpporInd.style.display="none";	
			    pnlExhibitonInd.style.display="none";
			    pnlExpertType.style.display="none";	
			  	//document.all.lblConditionSet.innerText = "招商";	
			  	getid("chkLstCooperationDemand").style.display="none";	
			  	getid("chkLstCooperationDemand2").style.display="";	
			  	getid("lbCapital").innerText = "投资金额：";
				getid("lbProvince").innerText = "招商省市：";
				pnCooperationDemandTyp.style.display="block";
				document.getElementById("li0").className = "liwai";					
				document.getElementById("li1").className = "";
				document.getElementById("li2").className = "";
				document.getElementById("li3").className = "";
				document.getElementById("li4").className = "";
				document.getElementById("li5").className = "";
			}
			
			if (obj=="1") //投资
			{			
				pnlMerchant1.style.display="none";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="block";
				pnlCapital.style.display="block";
				pnlIndustryB.style.display="block";
		
				pnlProvince.style.display="block";
				pnlNewType.style.display="none";
				pnlCarveoutType.style.display="none";
				pnlCarveoutInd.style.display="none"
				pnlOpporType.style.display="none";		
			    pnlOpporInd.style.display="none";	
			    pnlExhibitonInd.style.display="none";
			    getid("chkLstCooperationDemand").style.display="";	
			  	getid("chkLstCooperationDemand2").style.display="none";	
				//document.all.lblConditionSet.innerText = "投资";
				getid("lbCapital").innerText = "投资金额：";
				getid("lbIndustryB").innerText = "投资行业：";
			//	document.all.lbIndustryM.innerText = "投资小行业";
				getid("lbProvince").innerText = "投资省市：";
				pnCooperationDemandTyp.style.display="block";
				getid("lbtype").innerText = "投资类别：";
				document.getElementById("li0").className = "liwain";					
				document.getElementById("li1").className = "liwai";
				document.getElementById("li2").className = "";
				document.getElementById("li3").className = "";
				document.getElementById("li4").className = "";
				document.getElementById("li5").className = "";
				
			}
					
			if (obj=="2") //融资
			{
		    	pnlMerchant1.style.display="none";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="block";
				pnlCapital.style.display="block";
				pnlIndustryB.style.display="block";
		
				pnlProvince.style.display="block";
				pnlNewType.style.display="none";
				pnlCarveoutType.style.display="none";
				pnlCarveoutInd.style.display="none"
				pnlOpporType.style.display="none";		
			    pnlOpporInd.style.display="none";	
			    pnlExhibitonInd.style.display="none";
				//document.all.lblConditionSet.innerText = "投资";
				getid("lbCapital").innerText = "资金需求：";
				getid("lbIndustryB").innerText = "融资行业：";
			//	document.all.lbIndustryM.innerText = "投资小行业";
				getid("lbProvince").innerText = "融资省市：";
				pnCooperationDemandTyp.style.display="block";	
				getid("lbtype").innerText = "融资类别：";
				 getid("chkLstCooperationDemand").style.display="";	
			  	getid("chkLstCooperationDemand2").style.display="none";	
			    document.getElementById("li0").className = "";					
				document.getElementById("li1").className = "liwain";
				document.getElementById("li2").className = "liwai";
				document.getElementById("li3").className = "";
				document.getElementById("li4").className = "";
				document.getElementById("li5").className = "";
								  
			}
			
			
			if (obj=="3") 

			{		
				pnlMerchant1.style.display="none";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="none";
				pnlCapital.style.display="block";
				pnlIndustryB.style.display="none";
		
				pnlProvince.style.display="block";
				pnlNewType.style.display="none";
				pnlCarveoutType.style.display="block";
				pnlCarveoutInd.style.display="block"
				pnlOpporType.style.display="none";		
			    pnlOpporInd.style.display="none";	
			    pnlExhibitonInd.style.display="none";
			    pnlExpertType.style.display="none";	
				//document.all.lblConditionSet.innerText = "创业";
				getid("lbCapital").innerText = "创业金额：";
				getid("lbIndustryB").innerText = "创业行业：";
			//	document.all.lbIndustryM.innerText = "创业小行业";
				getid("lbProvince").innerText = "创业省市：";
				 pnCooperationDemandTyp.style.display="none";
				 document.getElementById("li0").className = "";					
				document.getElementById("li1").className = "";
				document.getElementById("li2").className = "liwain";
				document.getElementById("li3").className = "liwai";
				document.getElementById("li4").className = "";
				document.getElementById("li5").className = "";
				
			}
			
			if (obj=="4") 
			{		
				pnlMerchant1.style.display="none";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="none";
				pnlCapital.style.display="none";
				pnlIndustryB.style.display="none";
			
				pnlProvince.style.display="block";
				pnlNewType.style.display="none";
				pnlCarveoutType.style.display="none";
				pnlCarveoutInd.style.display="none"
				pnlOpporType.style.display="block";		
			    pnlOpporInd.style.display="block";	
			    pnlExhibitonInd.style.display="none";
			    pnlExpertType.style.display="none";	
				//document.all.lblConditionSet.innerText = "商机";
				getid("lbCapital").innerText = "商机金额：";				
				getid("lbIndustryB").innerText = "商机行业：";
			//	document.all.lbIndustryM.innerText = "商机小行业";
				getid("lbProvince").innerText = "商机省市：";
				 pnCooperationDemandTyp.style.display="none";
				 document.getElementById("li0").className = "";					
				document.getElementById("li1").className = "";
				document.getElementById("li2").className = "";
				document.getElementById("li3").className = "liwain";
				document.getElementById("li4").className = "liwai";
				document.getElementById("li5").className = "";
				
			}
			
			if (obj=="5") 
			{		
				pnlMerchant1.style.display="none";
				pnlMerchant2.style.display="none";
				pnlCapitalType.style.display="none";
				pnlCapital.style.display="none";
				pnlIndustryB.style.display="none";
		
				pnlProvince.style.display="none";
				pnlNewType.style.display="block";
				pnlCarveoutType.style.display="none";
				pnlCarveoutInd.style.display="none"
				pnlOpporType.style.display="none";		
			    pnlOpporInd.style.display="none";	
			    pnlExhibitonInd.style.display="none";
			    pnlExpertType.style.display="none";	
				//document.all.lblConditionSet.innerText = "资讯";
				getid("lbCapital").innerText = "融资金额：";
				getid("lbIndustryB").innerText = "融资行业：";
			//	document.all.lbIndustryM.innerText = "融资小行业";
				getid("lbProvince").innerText = "融资省市：";
				 pnCooperationDemandTyp.style.display="none";
				  document.getElementById("li0").className = "";					
				document.getElementById("li1").className = "";
				document.getElementById("li2").className = "";
				document.getElementById("li3").className = "";
				document.getElementById("li4").className = "liwain";
				document.getElementById("li5").className = "liwai";
			}
		}
		//-->
		init();
    </script>

</asp:Content>
