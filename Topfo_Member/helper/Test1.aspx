<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="helper_Test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <script language="javascript" type="text/javascript">

function GetObj(objName){
    if(document.getElementById)
    {
        return eval('document.getElementById("' + objName + '")');
    }else if(document.layers)
    {
       return eval("document.layers['" + objName +"']");
    }else
    {
       return eval('document.all.' + objName);
    }
}
function hit(idx){
document.getElementById("Hidden1").value = idx;
    for(var i=0;i<30;i++){
    if(GetObj("div"+i)) GetObj("div"+i).className = "";
    if(GetObj("panel"+i)) GetObj("panel"+i).style.display = "none";
    }
    GetObj("div"+idx).className = "btn_on";
    GetObj("panel"+idx).style.display = "block";
}
window.onload=function()
{
    var type=document.getElementById("hidType").value 
    if(type=="Add")
    {
        setTimeout("hit(1)",100);
    }
}

</script>
<input type="hidden" id="hidType" runat="server" />
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">搜索订阅</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
      <div class="jl-wxts">
         <h3><img src="http://img2.topfo.com/member/img/icon_tishi.gif" align="absMiddle" /> 如何设置搜索订阅</h3>
         <p>如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />
            第一时间抢占先机，万千财富滚滚来！ <br />
            如果你想拥有无限数量的订阅，请 <a href="/Register/VIPMemberRegister_In.aspx">申请拓富通会员</a><br />
            您是拓富通会员，享有无限数量的免费订阅权限 
           </p>
      </div>
       
        <h2 style="margin-bottom:0">
        <ul >
         <li  class="btn_on" runat="server"  id="div1" onclick="hit(1)" ><a href="#" >资本资源</a></li>
         <li  id="div0" runat="server" onclick="hit(0)"><a href="#" >政府资源</a></li>
        <li  id="div2" runat="server" onclick="hit(2)"><a href="#" >企业项目</a></li>
         </ul>
        </h2>
        
        <!--资本资源 -->
        <div  id="panel1" runat="server">
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
          <tr>
            <td class="publica-td-left" width="20%"><span class="hong">*</span>投资方式：</td>
            <td>
        <asp:CheckBoxList ID="chTzfsZb" runat="server" RepeatLayout="Flow"  RepeatDirection="Horizontal" />
        </td>
          </tr>
      <tr>
        <td class="publica-td-left" width="20%"><span class="hong">*</span><span id="lbCapital">单项目可投资金额：</span></td>
        <td><asp:RadioButtonList ID="chkCapital" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
        </td>
        </tr>
     <tr>
       <td class="publica-td-left" width="20%">
       投资行业：
       </td>
       <td>
        <table id="pnlIndustryB" cellspacing="0" cellpadding="0"  border="0">
            <tr>
                <td >
                    <asp:ListBox ID="lstIndustryBLeft" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td >
                    <input id="addIB" onclick="moveOver(document.getElementById('lstIndustryBLeft'),document.getElementById('lstIndustryBRight'));"
                        type="button" value=">>" name="addIB" />
                    <br />
                    <input id="cutIB" onclick="removeMe(document.getElementById('lstIndustryBRight'))"
                        type="button" value="<<" name="cutIB" />
                </td>
                <td>
                    <asp:ListBox ID="lstIndustryBRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td class="hong">
                    最多选5项</td>
            </tr>
        </table>
       </td>
          </tr>
            <tr>
              <td class="publica-td-left" width="20%">
              <span class="hong">*</span><span id="lbProvince">投资省市：</span></td>
              <td style="height: 125px"><table id="pnlProvince" cellspacing="0" cellpadding="0"  border="0">
                <tr>
                   
                    <td >
                        <asp:ListBox ID="lstProvinceLeft" runat="server" Width="133px" DataValueField="ProvinceID"
                            DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                    <td >
                        <input id="addIP" onclick="moveOver(document.getElementById('lstProvinceLeft'),document.getElementById('lstProvinceRight'))"
                            type="button" value=">>" name="addIP" />
                        <br />
                        <input id="cutIP" onclick="removeMe(document.getElementById('lstProvinceRight'))"
                            type="button" value="<<" name="cutIP" /></td>
                    <td >
                        
                            <asp:ListBox ID="lstProvinceRight" runat="server" Width="133px" DataValueField="ProvinceID"
                                DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                    <td class="hong" >
                        最多选5项</td>
                </tr>
            </table>
          </td>
            </tr>
</table>
</div>
<!--资本资源 END-->

 <!--政府招商 -->
        <div  id="panel0" runat="server">
      <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
       <tr>
       <td class="publica-td-left" width="20%">
       投资行业：
       </td>
       <td>
        <table  cellspacing="0" cellpadding="0"  border="0">
            <tr>
                <td >
                    <asp:ListBox ID="lisTzhy" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td>
                    <input id="Button5" onclick="moveOver(document.getElementById('lisTzhy'),document.getElementById('lisTzhyRight'));"
                        type="button" value=">>" name="addIB" />
                    <br />
                    <input id="Button6" onclick="removeMe(document.getElementById('lisTzhyRight'))"
                        type="button" value="<<" name="cutIB" />
                </td>
                <td>
                    <asp:ListBox ID="lisTzhyRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td class="hong" >
                    最多选5项</td>
            </tr>
        </table>
       </td>
          </tr>
            <tr>
              <td class="publica-td-left" width="20%">
              <span class="hong">*</span><span id="Span4">投资省市：</span></td>
              <td>
            <table  cellspacing="0" cellpadding="0"  border="0">
               <tr>
                <td>
                    <asp:ListBox ID="lisTzQy" runat="server" Width="133px" DataValueField="ProvinceID"
                        DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                <td>
                    <input id="Button7" onclick="moveOver(document.getElementById('lisTzQy'),document.getElementById('lisTzQyRight'))"
                        type="button" value=">>" name="addIP" />
                    <br />
                    <input id="Button8" onclick="removeMe(document.getElementById('lisTzQyRight'))"
                        type="button" value="<<" name="cutIP" /></td>
                <td>
                      <asp:ListBox ID="lisTzQyRight" runat="server" Width="133px" DataValueField="ProvinceID"
                            DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                <td class="hong">
                    最多选5项</td>
                </tr>
            </table>
          </td>
            </tr>
</table>
</div>
<!--政府招商 END-->

 <!--企业项目 -->
        <div  id="panel2" runat="server">
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
          <tr>
            <td class="publica-td-left" width="20%"><span class="hong">*</span>融资类型：</td>
            <td>
        <asp:CheckBoxList ID="ckRzlxQy" runat="server" RepeatColumns="10" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Text="股权融资" Value="0"></asp:ListItem>
            <asp:ListItem Text="债券融资" Value="1"></asp:ListItem>
        </asp:CheckBoxList>
        </td>
          </tr>
      <tr>
        <td class="publica-td-left" width="20%"><span class="hong">*</span><span id="Span1">融资金额：</span></td>
        <td><asp:RadioButtonList ID="ckJkjeQy" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList> 
        </td>
        </tr>
     <tr>
       <td class="publica-td-left" width="20%">
       投资行业：
       </td>
       <td>
        <table id="Table1" cellspacing="0" cellpadding="0"  border="0">
            <tr>
                <td >
                    <asp:ListBox ID="lisTzhyQy" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td >
                    <input id="Button1" onclick="moveOver(document.getElementById('lisTzhyQy'),document.getElementById('lisTzhyQyRight'));"
                        type="button" value=">>" name="addIB" />
                    <br />
                    <input id="Button2" onclick="removeMe(document.getElementById('lisTzhyQyRight'))"
                        type="button" value="<<" name="cutIB" />
                </td>
                <td>
                    <asp:ListBox ID="lisTzhyQyRight" runat="server" DataValueField="IndustryBID" DataTextField="IndustryBName"
                        SelectionMode="Multiple" Width="133px"></asp:ListBox></td>
                <td class="hong">
                    最多选5项</td>
            </tr>
        </table>
       </td>
          </tr>
            <tr>
              <td class="publica-td-left" width="20%">
              <span class="hong">*</span><span id="Span2">投资省市：</span></td>
              <td style="height: 125px"><table id="Table2" cellspacing="0" cellpadding="0"  border="0">
                <tr>
                  <td>
                        <asp:ListBox ID="lisTzqyQy" runat="server" Width="133px" DataValueField="ProvinceID"
                            DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></td>
                    <td>
                        <input id="Button3" onclick="moveOver(document.getElementById('lisTzqyQy'),document.getElementById('lisTzqyQyRight'))"
                            type="button" value=">>" name="addIP" />
                        <br />
                        <input id="Button4" onclick="removeMe(document.getElementById('lisTzqyQyRight'))"
                            type="button" value="<<" name="cutIP" /></td>
                    <td >
                        <font face="Arial, Helvetica, sans-serif">
                            <asp:ListBox ID="lisTzqyQyRight" runat="server" Width="133px" DataValueField="ProvinceID"
                                DataTextField="ProvinceName" SelectionMode="Multiple"></asp:ListBox></font></td>
                    <td class="hong">
                        最多选5项</td>
                </tr>
            </table>
          </td>
            </tr>
</table>
</div>
<!--企业项目 END-->

<!--共同部分 -->
  <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
     <tr>
        <td class="publica-td-left" width="20%">
           请输入关键字：       
        </td>
        <td>
        <asp:TextBox ID="txtKey" runat="server"  MaxLength="200" Height="21px" Width="303px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="publica-td-left" width="20%">
          发布时间：
        </td>
        <td>
        <asp:DropDownList ID="ddlValidateTerm" runat="server">
            <asp:ListItem Value="0" Selected="True">不限</asp:ListItem>
            <asp:ListItem Value="3">3天</asp:ListItem>
            <asp:ListItem Value="7">7天</asp:ListItem>
            <asp:ListItem Value="15">15天</asp:ListItem>
            <asp:ListItem Value="30">30天</asp:ListItem>
            <asp:ListItem Value="60">60天</asp:ListItem>
            <asp:ListItem Value="90">90天</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
    <td colspan="2">
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
    </td>
    </tr>
      <tr>
        <td colspan="2" id="pub-tongyi" >
         <%--<input name="" type="button" value="搜 索" class="btn-002"  /> --%>
         <asp:Button CssClass="btn-002" ID="butSelect" runat="server" Text="搜 索" OnClick="butSelect_Click">
                                            </asp:Button>
         <%--<input name="" type="button" value="订 阅" class="btn-002"  />--%>
         <asp:Button CssClass="btn-002" ID="btnAdd" runat="server" Text="订 阅" OnClick="btnAdd_Click">
                                            </asp:Button>
                                            
                                            <input type="button" class="btn-002" value="返回>>" onclick="window.location.href='MatchingInfo.aspx'" id="Button9" />
         </td>
        </tr>
   </table>
   <!--共同部分 END-->
    </div>
      </div>
          <script type="text/javascript">
function $id(obj)
{
    return document.getElementById("infoReceiveGridView_ctl02_"+obj);
}
function getid(obj)
{
    return document.getElementById(obj);
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
    </form>
</body>
</html>
