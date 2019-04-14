<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceAdd.aspx.cs" Inherits="ValueAdd_ServiceAdd" Title="增值服务定制" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <div class="size">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="50" colspan="9">
                    <p align="center" class="STYLE1">
                        增值服务定制
                    </p>
                </td>
            </tr>
            <tr>
                <td height="20" colspan="9" align="right" valign="middle">
                <a href="/ValueAdd/ServiceList.aspx">查看我的定制</a>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="9" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td width="1" rowspan="26" bgcolor="#cccccc">
                </td>
                <td width="115" height="40" bgcolor="#fffbe8">
                    &nbsp;</td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="153" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        <div align="center">
                            服务项目</div>
                    </div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="515" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        服务说明</div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="160" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        <div align="center">
                            价格(人民币/元)</div>
                    </div>
                </td>
                <td width="1" rowspan="26" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="27" />
                            我要定制</strong></div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        定向推广</div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_27" name="decrip_27" runat="server">
                    可通过邮箱、站内短信、手机短信等方式面向全球所有有对口需求的行业用户定向投递您的需求，获得全球300万以上行业用户对您的持续关注，拓世界之财富，网全球之商机！</td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td id="price_27" name="price_27" runat="server">
                    <p align="center">
                        1元/条/个(100元起)</p>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="28" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        对口资源智能配对</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_28" name="decrip_28" runat="server">
                    1.招商、项目、投资资源智能配对<br />
                    2.优先推荐给对口客户<br />
                    3.通过站内短消息和邮箱和手机接收配对结果通知<br />
                    4.资源价格按招商投融资资源实际定价消费<br />
                    此服务可在资源超市自由消费实现</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_28" name="price_28" runat="server">
                    <div align="center">
                        按每条资源收费</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="29" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        对口资源专家推荐</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_29" name="decrip_29" runat="server">
                    <ol>
                        <li>1.招商、投融资专家同您联系并为您量身定制、精心优选，针对您的需求推荐优质资源，并由业界资深专家引领您拜访对口资源机构。 </li>
                        <li>2.优先推荐给对口客户进行深度专业运作。 </li>
                        <li>3.通过站内短消息和邮箱和手机接收配对结果通知，专业促进招商、投资、融资，成功更有保障！ </li>
                    </ol>
                    此项资源服务可以打包成“小型招商投融资对接会”、“项目猎头”等活动，具体事宜可与专家另行商洽。</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_29" name="price_29" runat="server">
                    <div align="center">
                        2000元/个</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="30" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        编制商业计划书摘要</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_30" name="decrip_30" runat="server">
                    <p>
                       获得商业计划书摘要1份。借鉴成功的项目融资方案，并由公司资深专家给与悉心指导，完善您的项目计划，提升您的项目价值，让投资商主动找您！
                      </p>
                    此项服务可以延伸到招商投融资深度专业运作服务，具体事宜可与专家另行商洽。</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_30" name="price_30" runat="server">
                    <div align="center">
                        8000元/份</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="31" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        电子杂志推广</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_31" name="decrip_31" runat="server">
                    面向全球发行的中英文双语电子杂志、财经立体媒体等为您提供高端“窄告”服务。获得海量高端行业用户群体的持续关注！传播至深，沟通至心，滚滚财富涌上门！</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_31" name="price_31" runat="server">
                    <div align="center">
                        3500元/期</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="32" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        领导专访</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_32" name="decrip_32" runat="server">
                    领导专访一次，在网站“人物”栏目及电子杂志中英文专题报道。展示精项风采，凸显企业价值！在全球顶级行业门户展示品牌形象，拓展市场影响力！</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_32" name="price_32" runat="server">
                    <div align="center">
                        企业10000元/次<br />
                        政府30000元/次
                    </div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="33" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        尊贵展示</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_33" name="decrip_33" runat="server">
                    <ol>
                        <li>1.展示拓富指数，凸显项目价值或区域优势 </li>
                        <li>2.优先排序，增加关注度 </li>
                        <li>3.有机会获得首页，频道等重点推荐 </li>
                        <li>4.即时刷新自己所发布的需求，展示更靠前。 </li>
                    </ol>
                    以上服务都是按年服务,从服务定制之日起计算</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_33" name="price_33" runat="server">
                    <div align="center">
                        888元/年</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="2" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        招商投融资路演</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_2" name="decrip_2" runat="server">
                    给予首页和招商频道、投资频道、融资频道路演展示，让更多人关注您！
                    <br />
                    此项服务可以延伸到金字塔型政府招商网站、商业网站建设，具体事宜可与专家另行商洽</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_2" name="price_2" runat="server">
                    <div align="center">
                        价格：8万元/年（不含制作费</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="34" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        专题推荐</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_34" name="decrip_34" runat="server">
                    招商投融资活动支持：协办招商会、投融资对接会，给予网上专题报道，面向全球行业用户营造热点，海量用户瞬间聚焦，商机快速汇聚，招商更高效，质量有保障！</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_34" name="price_34" runat="server">
                    <div align="center">
                        8000元/3月</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="1" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        广告服务</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_1" name="decrip_1" runat="server">
                    首页、各频道为您提供图广告、视频广告、互动广告等任您选择，推广更有效！让全球3000万以上行业用户关注您！强大的广告管理后台，瞬间精确定位所有潜在客户，并建立广泛的客户关系，专人定期为您提供客户清单！人脉即财脉，高效招商，投资，融资，优质产业积聚基地瞬间打造！</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_1" name="price_1" runat="server">
                    <div align="center">
                        参考广告收费标准</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="35" />
                            我要定制</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        站内互告</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_35" name="decrip_35" runat="server">
                    <p>
                        定向告之，反向联络，可以根据客户需求定向告知潜在对口的客户群体，针对性强，目标清晰，独创互告技术，让每一个浏览过资源的用户都展现在你面前。
                    </p>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_35" name="price_35" runat="server">
                    <div align="center">
                       按资源超市实际价格收费</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="9" bgcolor="#cccccc">
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>用户名 </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <%=loginNameStr%>
                    </strong>
                </td>
                <td>
                    <div align="right">
                        <strong>联系人姓名:</strong></div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Name" runat="server" Width="160px"></asp:TextBox></strong>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>业务跟进人邮箱: </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Email" runat="server" Width="160px"></asp:TextBox>
                    </strong>
                </td>
                <td>
                    <div align="right">
                        <strong>电话号码: </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Tel" runat="server" Width="160px"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>特殊要求</strong>:</div>
                </td>
                <td colspan="3">
                    <strong>
                        <asp:TextBox ID="textB_Remark" runat="server" TextMode="MultiLine" Width="500px" Height="60px"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div align="center">
                        <strong>
                            <asp:Button ID="Btn_submit" runat="server" Text=" 提 交 "
                                Width="72" Height="24" OnClick="Btn_submit_Click" OnClientClick="return CheckIt();" /></strong></div>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
    function GetCheckNum(checkobjectname)     
    {   
        var truei = 0;   
        checkobject = document.getElementsByName("CB_Type"); //eval("document.all."+checkobjectname);   
        var inum = checkobject.length;   
        if (isNaN(inum))   
        {   
            inum = 0;   
        }   
        for(i=0;i<inum;i++)   
        {   
            if (checkobject[i].checked)   
            {   
                truei = truei + 1;   
            }   
        }   
        return truei;   
    }   
    function CheckIt()   
    {   
        var flag=true; 
        if (GetCheckNum('checkbox')<=0)   
        {   
            //document.all.checkbox1.focus();   
            alert("请至少选择1个定制服务！");   
            flag = false;   
        }   
        return flag;
    }   
    </script>
</asp:Content>
