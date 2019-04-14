<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPublishMerchant1.aspx.cs" Inherits="Publish_TestPublishMerchant1" %>
<%@ Register Src="../Controls/MerchantInfoAddressInfo1.ascx" TagName="MerchantInfoAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:1000px;}
        .content p{line-height:30px;        }
        
    </style>  
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
<link href="../css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.trnone{
    display:none;
    }
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.infomsg{

    padding-left:20px;
    padding-right:20px;
    fong-size:12px;
    color:#777777;
    background:#83BDC0;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>

    <script type="text/javascript" language="javascript">

function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()"); 
}

    </script>

    <script type="text/javascript" language="javascript">
        function switchPublish()
        {
            var tag = document.getElementById("hdswitchpublish").value;
            var objs = document.getElementsByName("trswitchpublish");
            if(objs == null)
                return;
            var style = "";
            if(tag == 1){
                style = "trnone";  
                document.getElementById("hdswitchpublish").value = 0;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }

        
      
    </script>
    

</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hdswitchpublish" value="1" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布政府招商需求

            </div>
            
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle" />
                 <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a>            </div>
            <div class="clear">
            </div>
        </div>
        <asp:Panel ID="plTitle" runat='server'>
        <div class='stepsbox'>
            <ul>
                <li>第1步 登记招商机构 </li>
                <li class="liimg">
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='liwai'>第2步 填写招商项目信息</li>
                <li class='liimg'>
                    <img src='../images/publish/projectbg.gif' align='left' /></li>
                <li class='lishort'>第3步 发布成功</li>
            </ul>
            <div class='clear'>
            </div>
            <div class='blank0'>
            </div>
            <div class='suggestbox lightc'>
                "招商机构已经登记，接下来请您填写招商项目信息</div>
        </div>
        </asp:Panel>
        <div  id="switchtext">
            带 <span class="hong">*</span> 的为必填项</div>  <!--（您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）-->
			 <div class='dottedlline'>  </div>
			  <div class="blank6"> </div>
			 <!--这是后来招商信息的div-->
			 <div id="ProjectDiv" style="display:block;" >
			
        <div class="infozi">
            填写招商项目信息</div>
            <!--以下是修改的部分-->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
             <tr>
                <td align="right" bgcolor="#F7F7F7">
                  <span class="hong">* </span>  <strong>招商项目标题：</strong></td>
                <td>
                    <asp:TextBox ID="txtMerchantTopic"  onchange="checkMerchantTopic();" runat="server" Width="270px"></asp:TextBox>
                    <span id="spMerchantTopic"></span>
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7" style="height: 2px">
                    <span class="hong">* </span><strong>招商类别：</strong></td>
                <td width="618">
                    <asp:RadioButtonList ID="rblMerchantType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                   <%--<asp:TextBox  runat="server" ID="MerType" Width="0"></asp:TextBox>--%>
                   <input type="text" runat="server" id="MerType" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    <span id="spMerchantTypeInfo" runat="server"></span>
                    <span id="spMerchantType" ></span>
                </td>
            </tr>
           
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                <td width="618">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    <input type="text" runat="server" id="ZoneId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                <td width="630">
                <input type="text" runat="server" id="IndustryId" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF; height:2px;" />
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>合作方式：</strong></td>
                <td valign="top">
                    <asp:CheckBoxList ID="cblCooperationDemandType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:CheckBoxList>&nbsp; <span class="hui">(可多选)</span>
                    <input type="text" runat="server" id="cblDemandType" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spCooperationDemand">
                    </span>
                </td>
            </tr>
            <tr id="trswitchpublish1" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>总投资：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlCapitalCurrency" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal"  onchange="checkCapitalTotal();" runat="server"
                        Width="75px"></asp:TextBox>
                    万元 <span id="spCapitalTotal"></span>
                </td>
            </tr>
            <tr id="trswitchpublish2" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>引资金额：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlMerchantCurrency" runat="server">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlMerchantTotal" runat="server">
                    </asp:DropDownList></td>
            </tr>
              <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>项目有效期：</strong></td>
                <td width="630">
                <input id="Vaildite" type="hidden" name="Vaildite" />
                     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" Height="2px" >
                      </asp:RadioButtonList>
                      <input type="text" runat="server" id="rdlTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                     <span id="spValiditeTerm"></span>
                          
             </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>招商项目简介：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAbout"  onchange="checkZoneAboutB();" runat="server" cols="50"
                        rows="10" style="width: 558px; height:100px"></textarea><span id="spZoneAboutB"></span>
                           
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>招商项目摘要：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAboutBrief"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span ></span>
                            <br />
                            <span class="hui">请用简明扼要的语言描述招商项目要点，建议字数在200字以内 ！</span>
                </td>
            </tr>
            <!--以下是要添加的部分-->
              
              
             <tr><td colspan="2"><span class="f_red strong">※ 项目详细资料</span><span class="f_gray">（完善的资料可以得到投资方更多信任，请完善以下信息！）</span></td></tr>
            
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>项目现状及规划：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtProjectStatus"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea>
                        <input type="text" runat="server" id="ProjectSt" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                        <span ></span>
                </td>
            </tr>
             <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>项目优势及市场分析：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtMarket"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span ></span>
                </td>
            </tr>
            
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>经济效益分析：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtBenefit"  runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span ></span>
                </td>
            </tr>
           <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>地方经济指标描述：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtEconomicIndicators" runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span ></span>
                </td>
            </tr>
            
             <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong"></span> <strong>投资环境描述：</strong>
                    <br /></td>
                <td width="618" valign="top">
                    <textarea id="txtInvestmentEnvironment" runat="server" cols="50"
                        rows="10" style="width: 558px; height:70px"></textarea><span ></span>
                </td>
            </tr>
            <!--结束处-->
            <tr id="trswitchpublish" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>招商关键字：</strong></td>
                <td width="630" valign="top">
                    <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    <br />
                    <span id="spKeyMsg"></span><span class="hui">用户现在更多地通过搜索来寻找资源，定义相关的关键字能让您的需求更容易被潜在合作方找到。</span>
                </td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <strong>上传附件：</strong></td>
                <td width="618" valign="top" class="nonepad">
                    <uc3:FilesUploadControl ID="FilesUploadControl1" InfoType="Merchant"
                        runat="server" />
                </td>
            </tr>

        </table>
        <div class="blank0">
        </div>
         <!--重新添加一个按纽记录上一步的值以上是注释部分-->
         <!-- <div id="nextDiv" style="display:block; text-align:center;">
              <input id="ShowInfo" type="button" value="下一步：确认联系方式"  /></div>
         </div> -->
         <!--招商基本信息的div结束处-->
         
        <!--联系方式开始将之隐藏 -->
        <div id="ContactDiv" style="display:block;">
        <div class="infozi">
            <strong>联系方式确认</strong></div>
            <!--这里是添加联系方式-->
      <div>
      <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">

    
    <tr>
        <td width="124" align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>招商机构名称：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtCompanyName"  onchange="checkComName();" runat="server" Width="324px" />
            <span id="spCAComName" ></span>
            </td>
    </tr>
    <tr id="tr2" name="trswitchpublish">
        <td width="124" align="right" bgcolor="#F7F7F7">
            <strong>项目承办单位：</strong></td>
        <td width="622">
            <asp:TextBox ID="txtUndertaker" runat="server" Width="324px" /></td>
    </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系人：</strong></td>
        <td width="638">
          
            <asp:TextBox id="txtName"  onchange="CAcheckNavigate(2)" width="127px" runat="server" />
        </td>
    </tr>
      <tr>
     
       <td align="right" bgcolor="#F7F7F7">
        <span class="hong">*</span> <strong>职位：</strong>
       </td>
     
      <td><asp:TextBox ID="txtPosition"  onchange="checkPosi();" width="127px" runat="server" />
      <span id="spPosition"></span>
      </td>
      </tr>
    <tr>
        <td align="right" bgcolor="#F7F7F7">
            <span class="hong">*</span> <strong>联系电话：</strong></td>
        <td width="638" valign="top">
          
           
            固话<asp:TextBox ID="txtTelCountry" onchange="validatePhone();" runat="server" size='4'>+86</asp:TextBox>
            <asp:TextBox ID="txtTelZoneCode" onchange="validatePhone();" runat="server" size='7' />
            <asp:TextBox ID="txtTelNumber" onchange="validatePhone();" runat="server" size='18' />
            <span id="spTel" ></span>
            手机<asp:TextBox id="txtMobile"  width="127px" runat="server" /><span>（固定电话或手机至少填写一项）</span>       
        </td>
    </tr>
    <tr id="tr3" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>电子邮箱：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtEmail"  onchange="checkEmail();" runat="server" size='18' Width="269px" />
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span> 
        </td>
    </tr>
   
    
    <tr id="tr4" name="trswitchpublish">
        <td align="right" bgcolor="#F7F7F7">
            <strong>联系地址：</strong></td>
        <td width="638">
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
  
    
</table></div>
          <!--这里是添加验证码的地方-->
       <div style="width:758px;  border:1px solid #cccccc; border-top:0px;">
       <table>
       <tr>
       <td style="font-weight:bold; width:126px; background-color:#F7F7F7; text-align:right;">
      验证码：&nbsp;&nbsp;</td>
      <td>
      <asp:TextBox ID="ImageCode"  runat="server" Width="120px"></asp:TextBox> <img src="../ValidateNumber.aspx"  onclick="this.src='../ValidateNumber.aspx?temp=' + (new Date())" />
       </td>
       
       </tr></table>
       </div>
        
        <!--申请域名 建立我的展厅 -->
        <div class="blank0">
        </div>
        <div class="mbbuttom">
           <p>
            <asp:CheckBox ID="ckbCheck" onclick="JavaScript:CheckCheck();" Checked="true" runat="server" />
           <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">我已阅读并同意《拓富中国招商投资网服务》</a></p>
           <span id="spCheck"></span>
            <asp:ImageButton ID="IbtnSubmit" OnClientClick="return TopFo();" ImageUrl="../images/publish/buttom_tywftk.gif" runat="server"
                OnClick="IbtnSubmit_Click"  />
        </div>
        </div>
          
     </div>
     </div>
    
    <%--   <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div> --%>
    </form>
</body>
</html>
