<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyMatching.aspx.cs" Inherits="helper_MyMatching" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />--%>
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
        <div class="suggestbox lightc allxian">
            <div id="pt" runat="server">
                如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />
                第一时间抢占先机，万千财富滚滚来！
                <br />
                如果你想拥有无限数量的订阅，请 <a href="/Register/VIPMemberRegister_In.aspx">申请拓富通会员</a>
            </div>
            <div id="tft" runat="server">
                您是拓富通会员，享有无限数量的免费订阅权限
            </div>
        </div>
        <!-- -->
        <%--<div class="handtop">
            <ul>
                <li><a href="MatchingInfo.aspx">我的订阅</a></li><li class="liwai">添加订阅 </li>
            </ul>
        </div>--%>
        <div id="divMain" class=" cshibiank">
            <div class="clear">
            </div>
            <div class="handtop">
                <asp:HiddenField ID="hidLiID" runat="server" />
                <ul>
                    <li id="li1" onclick="Valuechange(1)" runat="server" style="cursor: pointer" class="liwai">
                        资本资源</li><li id="li0" onclick="Valuechange(0)" runat="server" style="cursor: pointer"
                            class="liwai">政府招商</li>
                    <li id="li2" onclick="Valuechange(2)" runat="server" style="cursor: pointer" class="liwai">
                        企业项目</li>
                    <li id="li3" onclick="Valuechange(3)" runat="server" style="cursor: pointer" class="liwai">
                        资 讯</li>
                </ul>
            </div>
            <div class="blank6">
            </div>
            <div class="subtab" id="div1">
            </div>
            <!--资本资源 -->
            <div class="subtab">
                <asp:Panel ID="panel1" runat="server">
                    <table id="ff" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
                        <tr>
                            <td align="center" class="bxian">
                                <table id="pnlCapitalType" cellspacing="0" cellpadding="0" width="96%" border="0">
                                    <tr>
                                        <td width="16%" align="right" class="12g">
                                            <asp:Label ID="lbtype" runat="server" Text="资本类型："></asp:Label>
                                        </td>
                                        <td width="84%" align="left">
                                            <font face="Arial, Helvetica, sans-serif">
                                                <asp:CheckBoxList ID="chkSETfinancingTarget" runat="server" DataValueField="financingID"
                                                    DataTextField="financingName" RepeatColumns="20" Width="272px" RepeatLayout="Flow">
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
                                <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnlMerchant">
                                    <tr>
                                        <td width="16%" align="right" class="12g">
                                            投资方式：</td>
                                        <td align="left" width="84%">
                                            <asp:CheckBoxList ID="chTzfsZb" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Text="资金借贷" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="股权投资" Value="2"></asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#ffffff" class="bxian">
                                <table id="pnlCapital" cellspacing="0" cellpadding="0" width="96%" border="0">
                                    <tr>
                                        <td width="16%" align="right" class="12g" style="height: 40px">
                                            <asp:Label ID="lbCapital" runat="server">单项目可投资金额：</asp:Label></td>
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
                                            <%--<font face="Arial, Helvetica, sans-serif">币种：<asp:DropDownList ID="ddlCapitalCurrency"
                                            runat="server" Width="76px">
                                        </asp:DropDownList>
                                        </font>--%>
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
                                            <asp:Label ID="lbIndustryB" runat="server">投资行业：</asp:Label></td>
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
                                            <asp:Label ID="lbProvince" runat="server">投资省市：</asp:Label></td>
                                        <td width="158" align="left">
                                            <asp:ListBox ID="lstProvinceLeft" runat="server" Width="133px" DataValueField="ProvinceID"
                                                DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                                        <td width="74" align="center">
                                            <input id="addIP" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceLeft'),document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'))"
                                                type="button" value=">>" name="addIP" />
                                            <br />
                                            <input id="cutIP" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lstProvinceRight'))"
                                                type="button" value="<<" name="cutIP" /></td>
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
                            <td align="center" class="bxian">
                                <table id="Table1" cellspacing="0" cellpadding="0" width="96%" border="0">
                                    <tr>
                                        <td width="16%" align="right" class="12g">
                                            投资项目阶段：</td>
                                        <td width="84%" align="left">
                                            <asp:RadioButtonList ID="rblTzxmjd" runat="server" RepeatDirection="Horizontal" RepeatColumns="10"
                                                RepeatLayout="Flow">
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <!--资本资源 END -->
                <div class="blank20">
                </div>
                <!-- 政府招商-->
                <asp:Panel ID="panel2" runat="server">
                    <div class="subtab">
                        <table id="Table2" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
                            <tr>
                                <td align="center" class="bxian">
                                    <table width="96%" border="0" cellpadding="0" cellspacing="0" id="pnlMerchant1">
                                        <tr>
                                            <td width="16%" align="right" class="12g">
                                                招商类别：</td>
                                            <td width="84%" align="left">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:CheckBoxList ID="chkMerchantType" runat="server" DataValueField="MerchantTypeID"
                                                        DataTextField="MerchantTypeName" RepeatColumns="10" RepeatDirection="Horizontal"
                                                        RepeatLayout="Flow">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="center">
                                <td align="center" class="bxian">
                                    <table id="Table3" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="106" align="right" class="12g">
                                                <asp:Label ID="Label1" runat="server">投资行业：</asp:Label></td>
                                            <td width="158" align="left">
                                                <asp:ListBox ID="lisTzhy" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                                    SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                            <td align="center" width="74">
                                                <input id="Button1" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyRight'));"
                                                    type="button" value=">>" name="addIB" />
                                                <br />
                                                <input id="Button2" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyRight'))"
                                                    type="button" value="<<" name="cutIB" />
                                            </td>
                                            <td width="148">
                                                <asp:ListBox ID="lisTzhyRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                                    SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                            <td class="hui" width="181">
                                                最多选5项</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="bxian">
                                    <table id="Table4" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="106" align="right" class="12g">
                                                <asp:Label ID="Label2" runat="server">投资区域：</asp:Label></td>
                                            <td width="158" align="left">
                                                <asp:ListBox ID="lisTzQy" runat="server" Width="133px" DataValueField="ProvinceID"
                                                    DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                                            <td width="74" align="center">
                                                <input id="Button3" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzQyRight'))"
                                                    type="button" value=">>" name="addIP" />
                                                <br />
                                                <input id="Button4" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzQyRight'))"
                                                    type="button" value="<<" name="cutIP" /></td>
                                            <td width="148">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:ListBox ID="lisTzQyRight" runat="server" Width="133px" DataValueField="ProvinceID"
                                                        DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></font></td>
                                            <td class="hui" width="181">
                                                最多选5项</td>
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
                                    <table id="Table6" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="16%" align="right" class="12g" style="height: 40px">
                                                <asp:Label ID="Label3" runat="server">引资金额：</asp:Label></td>
                                            <td width="337" align="left">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:CheckBoxList ID="cboYzje" runat="server" DataValueField="CapitalID" DataTextField="CapitalName"
                                                        RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:CheckBoxList></font></td>
                                            <td width="239" align="left" style="height: 40px">
                                                <%--<font face="Arial, Helvetica, sans-serif">币种：<asp:DropDownList ID="ddlCapitalCurrency"
                                            runat="server" Width="76px">
                                        </asp:DropDownList>
                                        </font>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <!-- 政府招商 END-->
                <!-- 企业项目-->
                <asp:Panel ID="panel3" runat="server">
                    <div class="subtab">
                        <table id="Table8" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
                            <tr>
                                <td align="center" class="bxian">
                                    <table width="96%" border="0" cellpadding="0" cellspacing="0" id="Table9">
                                        <tr>
                                            <td width="16%" align="right" class="12g">
                                                融资类型：</td>
                                            <td width="84%" align="left">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:CheckBoxList ID="ckRzlxQy" runat="server" RepeatColumns="10" RepeatDirection="Horizontal"
                                                        RepeatLayout="Flow">
                                                        <asp:ListItem Text="股权融资" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="债券融资" Value="1"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="center">
                                <td align="center" class="bxian">
                                    <table id="Table10" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="106" align="right" class="12g">
                                                <asp:Label ID="Label4" runat="server">投资行业：</asp:Label></td>
                                            <td width="158" align="left">
                                                <asp:ListBox ID="lisTzhyQy" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                                    SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                            <td align="center" width="74">
                                                <input id="Button5" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQyRight'));"
                                                    type="button" value=">>" name="addIB" />
                                                <br />
                                                <input id="Button6" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzhyQyRight'))"
                                                    type="button" value="<<" name="cutIB" />
                                            </td>
                                            <td width="148">
                                                <asp:ListBox ID="lisTzhyQyRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                                                    SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                                            <td class="hui" width="181">
                                                最多选5项</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="bxian">
                                    <table id="Table11" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="106" align="right" class="12g">
                                                <asp:Label ID="Label5" runat="server">投资区域：</asp:Label></td>
                                            <td width="158" align="left">
                                                <asp:ListBox ID="lisTzqyQy" runat="server" Width="133px" DataValueField="ProvinceID"
                                                    DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                                            <td width="74" align="center">
                                                <input id="Button7" onclick="moveOver(document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQy'),document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQyRight'))"
                                                    type="button" value=">>" name="addIP" />
                                                <br />
                                                <input id="Button8" onclick="removeMe(document.getElementById('ctl00_ContentPlaceHolder1_lisTzqyQyRight'))"
                                                    type="button" value="<<" name="cutIP" /></td>
                                            <td width="148">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:ListBox ID="lisTzqyQyRight" runat="server" Width="133px" DataValueField="ProvinceID"
                                                        DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></font></td>
                                            <td class="hui" width="181">
                                                最多选5项</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#ffffff" class="bxian">
                                    <table id="Table13" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="16%" align="right" class="12g" style="height: 40px">
                                                <asp:Label ID="Label6" runat="server">借款金额：</asp:Label></td>
                                            <td width="337" align="left">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:CheckBoxList ID="ckJkjeQy" runat="server" DataValueField="CapitalID" DataTextField="CapitalName"
                                                        RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:CheckBoxList></font></td>
                                            <td width="239" align="left" style="height: 40px">
                                                <%--<font face="Arial, Helvetica, sans-serif">币种：<asp:DropDownList ID="ddlCapitalCurrency"
                                            runat="server" Width="76px">
                                        </asp:DropDownList>
                                        </font>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="bxian">
                                    <table id="Table12" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="16%" align="right" class="12g">
                                                <asp:Label ID="Label7" runat="server" Text="融资对象："></asp:Label>
                                            </td>
                                            <td width="84%" align="left">
                                                <font face="Arial, Helvetica, sans-serif">
                                                    <asp:CheckBoxList ID="ckRzdxQy" runat="server" DataValueField="financingID" DataTextField="financingName"
                                                        RepeatColumns="20" Width="272px" RepeatLayout="Flow">
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
                                <td align="center" class="bxian">
                                    <table id="Table14" cellspacing="0" cellpadding="0" width="96%" border="0">
                                        <tr>
                                            <td width="16%" align="right" class="12g">
                                                企业发展阶段：</td>
                                            <td width="84%" align="left">
                                                <asp:RadioButtonList ID="rdQyfzjd" runat="server" RepeatDirection="Horizontal"
                                                    RepeatColumns="10" RepeatLayout="Flow">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <!--企业项目 END-->
                <!--资讯类别-->
                <asp:Panel ID="panel4" runat="server">
                    <div class="subtab">
                        <table id="Table15" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
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
                        </table>
                    </div>
                </asp:Panel>
                <!--资讯类别 END-->
                <div class="subtab">
                    <table id="Table7" cellspacing="0" cellpadding="0" width="96%" align="center" border="0">
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
                            <td align="right" class="bxian" style="width: 17%; height: 22px;">
                                <table width="96%" border="0" cellpadding="0" cellspacing="0">
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
                                            <input id="Hidden1" type="hidden" runat="server" value="0" />
                                            
                                            <!--2010-06-23修改-->
                                            <!--资源项目-->
                                            <input id="hidZyCalling" type="hidden" name="hideIndustryExhibition" runat="server" />
                                            <input id="hidZyCallingTxt" type="hidden" name="hideIndustryExhibition" runat="server" />
                                            <input id="hidZyCity" type="hidden" name="hideIndustryExhibition" runat="server" />
                                            <input id="hidZyCityTxt" type="hidden" name="hideIndustryExhibition" runat="server" />
                                            <!--政府招商-->    
                                            <input id="hidZfCalling" type="hidden" name="hideIndustryCarveout" runat="server" />
                                            <input id="hidZfCallingTxt" type="hidden" name="hideIndustryCarveouttxt"
                                                runat="server" />
                                            <input id="hidZfCity" type="hidden" name="hideIndustryM" runat="server" />
                                            <input id="hidZfCityTxt" type="hidden" name="hideProvince" runat="server" />
                                            <!--企业项目-->
                                            <input id="hidQyCalling" type="hidden" name="hideIndustryCarveout" runat="server" />
                                            <input id="hidQyCallingTxt" type="hidden" name="hideIndustryCarveouttxt"
                                                runat="server" />
                                            <input id="hidQyCity" type="hidden" name="hideIndustryM" runat="server" />
                                            <input id="hidQyCityTxt" type="hidden" name="hideProvince" runat="server" />
                                            
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button CssClass="buttomal" ID="butSelect" runat="server" Text="搜 索" OnClick="butSelect_Click">
                                            </asp:Button>
                                            &nbsp;
                                            <asp:Button CssClass="buttomal" ID="btnAdd" runat="server" Text="订 阅" OnClick="btnAdd_Click">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="pagebox" align="center">
            <div class="clear">
                &nbsp;</div>
        </div>
    </div>

    <script type="text/javascript">
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

    <script type="text/javascript">
		<!--
		function init()
		{		
            document.getElementById("ctl00_ContentPlaceHolder1_li0").className = "";					
				document.getElementById("ctl00_ContentPlaceHolder1_li1").className = "liwai";
				document.getElementById("ctl00_ContentPlaceHolder1_li2").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li3").className = "";
			    ctl00_ContentPlaceHolder1_panel1.style.display = "block";
				ctl00_ContentPlaceHolder1_panel2.style.display = "none";
				ctl00_ContentPlaceHolder1_panel3.style.display = "none";
				ctl00_ContentPlaceHolder1_panel4.style.display = "none";
			//getid("ctl00_ContentPlaceHolder1_divMain").style.display ="none";
			
			//获取类型	
             var str=window.location.href; 
             var es1=/CustomType=/; 
             var typeVaule;
             if(es1.exec(str))    typeVaule=RegExp.rightContext; 
             else typeVaule="1";
             
             //getid("ctl00_ContentPlaceHolder1_hidLiID").value = typeVaule;
             //debugger;
             Valuechange(typeVaule)
        }	
			
		function Valuechange(obj) 
		{ 
			document.getElementById("ctl00_ContentPlaceHolder1_Hidden1").value = obj;
			//alert(document.getElementById("ctl00_ContentPlaceHolder1_Hidden1").value);
			if (obj=="0") //政府招商
			{
			    
				document.getElementById("ctl00_ContentPlaceHolder1_li0").className = "liwai";					
				document.getElementById("ctl00_ContentPlaceHolder1_li1").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li2").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li3").className = "";
				
				ctl00_ContentPlaceHolder1_panel1.style.display = "none";
				ctl00_ContentPlaceHolder1_panel2.style.display = "block";
				ctl00_ContentPlaceHolder1_panel3.style.display = "none";
				ctl00_ContentPlaceHolder1_panel4.style.display = "none";
				
				
			}
			
			if (obj=="1") //资本资源
			{						
			    document.getElementById("ctl00_ContentPlaceHolder1_li0").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li1").className = "liwai";
				document.getElementById("ctl00_ContentPlaceHolder1_li2").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li3").className = "";
				ctl00_ContentPlaceHolder1_panel1.style.display = "block";
				ctl00_ContentPlaceHolder1_panel2.style.display = "none";
				ctl00_ContentPlaceHolder1_panel3.style.display = "none";
				ctl00_ContentPlaceHolder1_panel4.style.display = "none";
				
			}
					
			if (obj=="2") //企业项目
			{
			    document.getElementById("ctl00_ContentPlaceHolder1_li0").className = "";					
				document.getElementById("ctl00_ContentPlaceHolder1_li1").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li2").className = "liwai";
				document.getElementById("ctl00_ContentPlaceHolder1_li3").className = "";
				
				ctl00_ContentPlaceHolder1_panel1.style.display = "none";
				ctl00_ContentPlaceHolder1_panel2.style.display = "none";
				ctl00_ContentPlaceHolder1_panel3.style.display = "block";
				ctl00_ContentPlaceHolder1_panel4.style.display = "none";
				
								  
			}
			if (obj=="3") //资讯
			{		
                document.getElementById("ctl00_ContentPlaceHolder1_li0").className = "";					
				document.getElementById("ctl00_ContentPlaceHolder1_li1").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li2").className = "";
				document.getElementById("ctl00_ContentPlaceHolder1_li3").className = "liwai";
				
				ctl00_ContentPlaceHolder1_panel1.style.display = "none";
				ctl00_ContentPlaceHolder1_panel2.style.display = "none";
				ctl00_ContentPlaceHolder1_panel3.style.display = "none";
				ctl00_ContentPlaceHolder1_panel4.style.display = "block";
				
			}
		}
		//-->
		
		init();
    </script>

</asp:Content>
