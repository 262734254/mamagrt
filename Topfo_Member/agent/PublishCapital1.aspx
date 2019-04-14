<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PublishCapital1.aspx.cs" Inherits="agent_PublishCapital1" %>
<%@ Register Src="../Controls/CapitalAddressInfo.ascx" TagName="CapitalAddressInfo"
    TagPrefix="uc5" %>
<%@ Register Src="../offer/Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl2.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>

    <link href="../offer/css/member.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .noteawoke{font-weight:normal;color:red;}
    </style>
    <form runat="server" id="aspnetForm">
    <script type="text/javascript" language="javascript">
    //检查复选择框
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

//检查是否选择
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

//检查长度
function checkByteLength(str,minlen,maxlen) {

	if (str == null) return false;
	var l = str.length;
	var blen = 0;
	for(i=0; i<l; i++) {
		if ((str.charCodeAt(i) & 0xff00) != 0) {
			blen ++;
		}
		blen ++;
	}
	if (blen > maxlen || blen < minlen) {
		return false;
	}
	return true;
}
    
    //以下是做判断检查
    
    //投资方简介
    function CheckGovIntro()
    {
    var txtGovIntroID = "<%=this.txtGovIntro.ClientID %>";
    var obj = document.getElementById(txtGovIntroID);
    if(!checkByteLength(obj.value,1,5000))
    {
        document.getElementById("spGovIntro").innerHTML = "请正确填写投资机构介绍";
        document.getElementById("spGovIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spGovIntro").innerHTML = "";
        document.getElementById("spGovIntro").className = "";
        return true;
    }
}

 //意向有效期限
function checkValiditeTerm()
{
    var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";
    var rdlValiditeTermIDName = rdlValiditeTermID.replace(/_/g,"$");
    if(GetCheckNum(rdlValiditeTermIDName) <= 0){
        document.getElementById("spValiditeTerm").innerHTML = "请选择有效期";
        document.getElementById("spValiditeTerm").className = "noteawoke";
        document.getElementById(rdlValiditeTermID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spValiditeTerm").innerHTML = "";
        document.getElementById("spValiditeTerm").className = "";
		return true;
	}
}
//是否参与项目方管理
function checkJoinManage()
{
    var rdlJoinManageID = "<%=this.rdlJoinManage.ClientID %>";
    var rdlJoinManageName = rdlJoinManageID.replace(/_/g,"$");
    if(GetCheckNum(rdlJoinManageName) <= 0){
        document.getElementById("spJoinManage").innerHTML = "请选择是否参与项目方管理";
        document.getElementById("spJoinManage").className = "noteawoke";
        document.getElementById(rdlJoinManageID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spJoinManage").innerHTML = "";
        document.getElementById("spJoinManage").className = "";
		return true;
	}
}
//投资方式
function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "请选择投资方式";
        document.getElementById("spCooperationDemand").className = "noteawoke";
        document.getElementById(chkLstCooperationDemandID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCooperationDemand").innerHTML = "";
        document.getElementById("spCooperationDemand").className = "";
		return true;
	}
}
//投资项目阶段
function checkStage()
{
    var rdlStageID = "<%=this.rblStage.ClientID %>";
    var rblStageIDName = rdlStageID.replace(/_/g,"$");
    if(GetCheckNum(rblStageIDName) <= 0){
        document.getElementById("spStage").innerHTML = "请选择项目阶段";
        document.getElementById("spStage").className = "noteawoke";
        document.getElementById(rdlStageID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spStage").innerHTML = "";
        document.getElementById("spStage").className = "";
		return true;
	}
}
  //单项目可投资金额
  function checkCurrency()
{
    var rblCurrencyID = "<%=this.rblCurreny.ClientID %>";
    var rblCurrencyIDName = rblCurrencyID.replace(/_/g,"$");
    if(GetCheckNum(rblCurrencyIDName) <= 0){
        document.getElementById("spCurrency").innerHTML = "请选择单个项目可投资资金";
        document.getElementById("spCurrency").className = "noteawoke";
        document.getElementById(rblCurrencyID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCurrency").innerHTML = "";
        document.getElementById("spCurrency").className = "";
		return true;
	}
}

 //资本类型改为投资方式
 
 function checkCapitalType()
{
    var rblCapitalTypeID = "<%=this.rblfinancingTarget.ClientID %>";
    //var rblCapitalTypeName = rblCapitalTypeID.replace(/_/g,"$");
    if(GetCheckBoxListCheckNum(rblCapitalTypeID) <= 0){
        document.getElementById("spCapitalType").innerHTML = "请选择资本类型";
        document.getElementById("spCapitalType").className = "noteawoke";
        document.getElementById(rblCapitalTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCapitalType").innerHTML = "";
        document.getElementById("spCapitalType").className = "";
		return true;
	}
	
}
//投资意想详细说明
function ChecktCapitalIntent(){
    var txtCapitalIntentID = "<%=this.txtCapitalIntent.ClientID %>";
    var obj = document.getElementById(txtCapitalIntentID);
    if(!checkByteLength(obj.value,1,1000))
    {
        document.getElementById("spCapitalIntent").innerHTML = "请正确您的投资意向说明";
        document.getElementById("spCapitalIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalIntent").innerHTML = "";
        document.getElementById("spCapitalIntent").className = "";
        return true;
    }
}
//投资需求名称
function CheckCapitalName(){
    var txtCapitalNameID = "<%=this.txtCapitalName.ClientID %>";
    var obj = document.getElementById(txtCapitalNameID);
    if(!checkByteLength(obj.value,1,60))
    {
        document.getElementById("spCapitalName").innerHTML = "请正确填写标题，30字以内";
        document.getElementById("spCapitalName").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalName").innerHTML = "";
        document.getElementById("spCapitalName").className = "";
        return true;
    }
}
//是否阅读服务协议
function CheckCheck()
{
    var ckbCheckID = "<%=this.ckbCheck.ClientID %>";
    var obj = document.getElementById(ckbCheckID);
    if(!obj.checked){
        document.getElementById("spCheck").innerHTML = "发布前请阅读并接受接受服务协议";
        document.getElementById("spCheck").className = "noteawoke";
        obj.focus();
		return false;
	}
	else
	{
	    document.getElementById("spCheck").innerHTML = "";
        document.getElementById("spCheck").className = "";
		return true;
	}
}
//关键字的判断
function checkKeyword()
{
    var key1ID = "<%=this.txtKeyword1.ClientID %>";
    var key2ID = "<%=this.txtKeyword2.ClientID %>";
    var key3ID = "<%=this.txtKeyword3.ClientID %>";
    
    var revalue = true;
    var filter=/^\s*[\u4e00-\u9fa5A-Za-z0-9_]{0,10}\s*$/;
    if(filter.test(document.getElementById(key1ID).value)&&filter.test(document.getElementById(key2ID).value)&&filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "";
        document.getElementById("spKeyMsg").className = "";
        return true;
    }
    if (!filter.test(document.getElementById(key1ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key1ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key2ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key2ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key3ID).focus();
        return false;
    }
}
//拟投资行业
function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()");
}

   //这是新添加的检验
     //机构注册资金
     function checkCurreny()
     {
        //rblRegisterdollar
        
        var rblRegisterdollarID = "<%=this.rblRegisterdollar.ClientID %>";
        var rblRegisterdollarIDName = rblRegisterdollarID.replace(/_/g,"$");
        if(GetCheckNum(rblRegisterdollarIDName) <= 0){
        document.getElementById("spdollar").innerHTML = "请选择机构注册资金";
        document.getElementById("spdollar").className = "noteawoke";
        document.getElementById(rblRegisterdollarID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("spdollar").innerHTML = "";
        document.getElementById("spdollar").className = "";
		return true;
	    }
     
    }
    
    //团队规模
    function checkTeam()
    {
        var rblTeamID = "<%=this.rblTeam.ClientID %>";
        var rblTeamIDName = rblTeamID.replace(/_/g,"$");
        if(GetCheckNum(rblTeamIDName) <= 0){
        document.getElementById("sprblTeam").innerHTML = "请选择团队规模";
        document.getElementById("sprblTeam").className = "noteawoke";
        document.getElementById(rblTeamID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblTeam").innerHTML = "";
        document.getElementById("sprblTeam").className = "";
		return true;
	    }
    
    
    }
   //机构年平均投资事件数
   function checkPinjun()
   {
       var rblPinJID = "<%=this.rblPinJ.ClientID %>";
        var rblPinJIDName = rblPinJID.replace(/_/g,"$");
        if(GetCheckNum(rblPinJIDName) <= 0){
        document.getElementById("sprblPinJ").innerHTML = "请选择投资事件数";
        document.getElementById("sprblPinJ").className = "noteawoke";
        document.getElementById(rblPinJID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblPinJ").innerHTML = "";
        document.getElementById("sprblPinJ").className = "";
		return true;
	    }
   
   }
   //成功事件数
   function checkSucess()
   {
   
 
       var rblSucessID = "<%=this.rblSucess.ClientID %>";
        var rblSucessIDName = rblSucessID.replace(/_/g,"$");
        if(GetCheckNum(rblSucessIDName) <= 0){
        document.getElementById("sprblSucess").innerHTML = "请选择成功事件数";
        document.getElementById("sprblSucess").className = "noteawoke";
        document.getElementById(rblSucessID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblSucess").innerHTML = "";
        document.getElementById("sprblSucess").className = "";
		return true;
	    }
   
   }
    
    //项目承办单位
    function checkSpors()
    {
       
     // var txtProrganizersID = "<%=this.txtProrganizers.ClientID %>";
       // var obj = document.getElementById(txtProrganizersID);
         //if(!checkByteLength(obj.value,1,60))
        //{
        //document.getElementById("sptxtProrganizers").innerHTML = "请正确填写承办单位，30字以内";
       // document.getElementById("sptxtProrganizers").className = "noteawoke";
       /// obj.focus();
       // return false;
       // }
       // else
       // {
       // document.getElementById("sptxtProrganizers").innerHTML = "";
      // document.getElementById("sptxtProrganizers").className = "";
        return true;
        //}
    }
     
     //投资需求摘要
     function checkZhaiYao()
     {
     
     var txtDemandID = "<%=this.txtDemand.ClientID %>";
    var obj = document.getElementById(txtDemandID);
    if(!checkByteLength(obj.value,1,1000))
    {
        document.getElementById("sptxtDemand").innerHTML = "请正确填写需求摘要";
        document.getElementById("sptxtDemand").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("sptxtDemand").innerHTML = "";
        document.getElementById("sptxtDemand").className = "";
        return true;
    }
     }
     
//以下是做整体的判断
function FormSubmit(){
    var revalue = true;
     //投资机构名称
    //if(!CheckGovName())
     //   {
      //  if(revalue) revalue = false;
      //  }
        //投资方简介
    if(!CheckGovIntro())
        {
        if(revalue) revalue = false;
        }
        //投资需求名称
    if(!CheckCapitalName())
        {
        if(revalue) revalue = false;
        }
       //资本类型
    if(!checkCapitalType())
        {
        if(revalue) revalue = false;
        }
        //单项目可投入金额
    if(!checkCurrency())
       {
        if(revalue) revalue = false;
       }
       //拟投资行业
    if(!checkIndustry())
        {
        if(revalue) revalue = false;
        }
        //投资项目阶段
    if(!checkStage())
        {
        if(revalue) revalue = false;
        }
        //是否参与项目方管理
     if(!checkJoinManage())
        {
        if(revalue) revalue = false;
        }
        //投资方式
    if(!checkCooperationDemand())
        {
        if(revalue) revalue = false;
        }
        //关键字的判断
    if(!checkKeyword())
        {
        if(revalue) revalue = false;
        }
     //意向有效期限   
    if(!checkValiditeTerm())
        {
        if(revalue) revalue = false;
        }
     //投资意向详细说明     
    if(!ChecktCapitalIntent())
        {
        if(revalue) revalue = false;
        }
      //服务协议
    if(!CheckCheck())
        {
        if(revalue) revalue = false;
        } 
     //机构注册资金
     if(!checkCurreny())
     {
       if(revalue) revalue=false;
     }
     //团队规模
     if(!checkTeam())
     {
       if(revalue) revalue=false;
     }
     //平均事件数
     if(!checkPinjun())
     {
       if(revalue) revalue=false;
     }
     
      //机构成功投资事件总数
      if(!checkSucess())
      {
        if(revalue) revalue=false;
      }
     
     //承办单位
     if(!checkSpors())
     {
       if(revalue) revalue=false;
     }
     //项目摘要
      if(!checkZhaiYao())
      {
       if(revalue) revalue=false;
      }
    return revalue;
}

document.getElementById("aspnetForm").onsubmit = FormSubmit;
    
    </script>
    


    
    <div>
  
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">资本资源发布</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
     <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资需求标题：</strong></td>
    <td style="width:699px"> <asp:TextBox ID="txtCapitalName" runat="server" onchange="JavaScrpit:CheckCapitalName()" Height="20px" Width="266px"></asp:TextBox>
                    <span id="spCapitalName" >请正确填写标题，30字以内</span>
      <span class="f_gray"></span></td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px" ><span class="f_red">*</span> <strong>资本类型：</strong></td>
    <td style="width:569px;">
	  
     <asp:CheckBoxList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        Height="2px">
                    </asp:CheckBoxList>
                    <span id="spCapitalType"></span>
                   
	  </td>
  </tr>
  
 <!-- <tr>
    <td class="tdbg" width="140"><span class="f_red">*</span> <strong>所属区域：</strong></td>
    <td style="width: 569px">
 <uc2:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
   </td>
  </tr>-->
  
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>拟投资行业：</strong></td>
    <td style="width: 569px">
       <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" /></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>拟投向区域：</strong></td>
    <td style="width: 569px"> 
    
    <uc1:ZoneSelect id="ZoneSelect1" runat="server"></uc1:ZoneSelect>
    
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>单项目可投资金额：</strong></td>
    <td style="width: 569px">
    
    <p>
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><br />
                        <span style="color:#999999;">金额的货币单位为人民币</span><span id="spCurrency"></span></p>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资项目阶段：</strong></td>
    <td style="width: 569px">
     <p>
                        <asp:RadioButtonList ID="rblStage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spStage"></span>
                    </p>
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"> <strong>机构注册资金：</strong></td>
    <td style="width: 569px">
     <asp:RadioButtonList ID="rblRegisterdollar" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
    <span id="spdollar"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"> <strong>机构团队规模：</strong></td>
    <td style="width: 569px">
    
     <asp:RadioButtonList ID="rblTeam" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="sprblTeam"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><strong>机构年平均投资事件数：</strong></td>
    <td style="width: 569px">
      <asp:RadioButtonList ID="rblPinJ" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="sprblPinJ"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><strong>机构成功投资事件总数：</strong></td>
    <td style="width: 569px">
     <asp:RadioButtonList ID="rblSucess" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="sprblSucess"></span>
    
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资方式：</strong></td>
    <td style="width: 569px">
    <p>
                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" /><span id="spCooperationDemand"></span>
                    </p>
    </td>
  </tr>
  <!-- <tr>
   <td valign="top" class="tdbg" width="140"><span class="f_red">*</span> <strong>项目承办单位：</strong></td>
   
    <td style="width: 569px">
    <asp:TextBox ID="txtProrganizers" runat="server"  Height="20px" Width="266px" onchange="javascript:checkSpors()"></asp:TextBox>
                    <span id="Span1"></span>
      </td>
  </tr>-->
  
  
  
  <tr>
    <td class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>是否参与项目方管理：</strong></td>
    <td style="width: 569px"><p>
                        <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spJoinManage"></span></p> 	</td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资需求摘要：</strong></td>
    <td style="width: 569px">
     <textarea cols="50" rows="10" id="txtDemand" runat="server" onchange="javaScript:checkZhaiYao()"  style="width: 540px;
                        height: 100px"></textarea>
                        
    <span id="sptxtDemand"></span>
    
      <br />
      <span class="f_gray">用最简洁扼要的语言介绍您的投资需求，建议字数控制在600字以内！</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资意向详细说明：</strong></td>
    <td style="width: 569px">
     <p>
                        <textarea id="txtCapitalIntent" runat="server" cols="50" rows="10" onchange="ChecktCapitalIntent();" style="width: 558px; height: 204px"></textarea>
                        <span id="spCapitalIntent"></span><br />
                        <span class="hui">1.填写投资的对象、以及对项目方的要求等；<br />
                            2.不少于20字，不能含有联系方式如电话、E-mail等，否则将无法通过审核。</span><a href="">查看范例</a></p>
    </td> 
  </tr>
    <tr>
                      <td valign="top" class="tdbg" style="width: 190px"><strong>关键字：</strong></td>
                <td width="699">
                    <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>
                    <span id="spKeyMsg"></span>
                    <p>  
                   <a href="http://www.topfo.com/help/demandmanage.shtml#19" style="color:blue;"> 如何定义关键字</a>
                        <span class="hui">填写与投资意向相关的关键字更容易被项目方搜索到，空格内不能使用标点符号。</span></p>
                </td>
            </tr>
  <tr>
    <td class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>意向有效期限：</strong></td>
    <td style="width: 569px">发布之日起
     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spValiditeTerm"></span>
    </td>
  </tr>
  
  <!--<tr>
     <td valign="top" class="tdbg" width="140"><span class="f_red">*</span> <strong>投资机构名称：</strong></td>
                <td style="width: 569px">
                    <asp:TextBox ID="txtGovName" runat="server" onchange="JavaScrpit:CheckGovName()" Height="20px" Width="277px"></asp:TextBox>
                    <span id="spGovName"></span>
                    </td>
            </tr>-->
            
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>投资机构简介：</strong></td>
    <td style="width: 569px">
    
    <textarea cols="50" rows="10" id="txtGovIntro" runat="server" onchange="JavaScrpit:CheckGovIntro()" style="width: 540px;
                        height: 100px"></textarea><span id="spGovIntro"></span>
   
    <br />
    <span class="f_gray">机构的历史发展介绍、投资方向及运作团队等.</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 190px"><span class="f_red">*</span> <strong>上传附件：</strong></td>
    <td style="width: 569px" class="nonepad">
	   <uc4:FilesUploadControl ID="FilesUploadControl1" InfoType="Capital"
                        runat="server"  />
    </td>
  </tr>
  <tr>
  <td style="width: 190px"></td>
  <td> <!--联系方式 -->
        <div class="infozi">
            联系方式</div>
        <uc5:CapitalAddressInfo ID="CapitalAddressInfo1" runat="server" /></td>
  </tr>
  
</table>
<table width="100%" cellspacing="0" style="text-align:center;">
  <tr>
    <td height="40"> 
                <asp:CheckBox ID="ckbCheck" onclick="JavaScript:CheckCheck();" Checked="true" runat="server" />
                <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" style="color:Blue;">我已阅读并同意拓富《中国招商投资网服务》</a>
                <span id="spCheck"></span></td>
  </tr>
  <tr>
    <td>
   
        <asp:Button ID="IbtnSubmit" runat="server" Text="填好了，确认一下联系方式" OnClick="IbtnSubmit_Click" />
      </td>
  </tr>
</table>
    </div>
   </form>