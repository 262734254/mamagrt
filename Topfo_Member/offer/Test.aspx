<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="offer_Test" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl2.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
 <link href="../../css/publishCaptal.css" rel="stylesheet" type="text/css" />
 <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../css/common.css" rel="stylesheet" type="text/css" />
 <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <link href="css/member.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .noteawoke{font-weight:normal;color:red;}
    </style>
    <title>无标题页</title>
</head>
<body  runat="server">
<form id="form1" runat="server">
     <script type="text/javascript">
    

        
   
   function ValidErr()
   {
        document.getElementById("step1").style.display="none";
        document.getElementById("step2").style.display="block";
        alert('验证码错误,请重新输入！');
        document.getElementById("ctl00_ContentPlaceHolder1_ImageCode").focus();
        document.getElementById("ctl00_ContentPlaceHolder1_ImageCode").select();
   }

  function ChangeValidCode(id)
  {
     document.getElementById(id).src = "../../ValidateNumber.aspx?r="+Math.random();
  }
  
  
  function chkpost()
   {
            var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
                        
            //标题
            var ProjectName="txtCapitalName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
                        
            //资本类型
            if(!ChkCbl("<%=this.rblfinancingTarget.ClientID %>","资本类型"))
            {
                return false;
            }
            
            
           //行业
	   if(document.getElementById("SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {     
	   
	         alert("请选择所属行业...");
	         document.getElementById("SelectIndustryControl1_sltIndustryName_Select").focus();
	         return false;
	   }
              //地域
	   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelect1_sltZone_Select").options.length==0)
	   {     
	   
	         alert("请选择所属地域最多添加5个..");
	         document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelect1_sltZone_Select").focus();
	         return false;
	   }    
            
//            //地域
//            if(document.getElementById("CountryListCN").value=="CN")
//            {
//                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
//                { 
//                    alert("请选择省份...");
//                    document.getElementById("provinceCN").focus();
//                    return false;
//                }
//                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
//                {
//                    alert("请选择城市...");
//                    document.getElementById("capitalCN").focus();
//                    return false;
//                }
//            }
            //借款金额
            if(!ChkRbl("<%=this.rblCurreny.ClientID %>","借款金额"))
            {
                return false ;
            }
            //投资项目阶段
            if(!ChkRbl("<%=this.rblStage.ClientID %>","投资项目阶段"))
            {
                return false;
            }
            //机构注册资金
            if(!ChkRbl("<%=this.rblRegisterdollar.ClientID %>","机构注册资金"))
            {
                 return false ;
            }
            //机构团队规模
            
//             if(!ChkRbl("<%=this.rblTeam.ClientID %>","机构团队规模"))
//            {
//                 return false ;
//            }
            //机构年平均投资事件数
            
             if(!ChkRbl("<%=this.rblPinJ.ClientID %>","机构年平均投资事件数"))
            {
                 return false ;
            }
            //机构成功投资事件总数
            
             if(!ChkRbl("<%=this.rblSucess.ClientID %>","机构成功投资事件总数"))
            {
                 return false ;
            }
            //投资方式
             
            if(!ChkCbl("<%=this.chkLstCooperationDemand.ClientID %>","投资方式"))
            {
                 return false;
            }
            
            //是否参与项目方管理
             if(!ChkCbl("<%=this.rdlJoinManage.ClientID %>","是否参与项目方管理"))
            {
                 return false;
            }
           // 投资需求摘要
               var ProjectName0="txtDemand";
            if(trim(document.getElementById(ProjectName0).value)=="")
            {
                alert(" 投资需求摘要不能为空...");
                document.getElementById(ProjectName0).focus();
                return false;
            }
            //投资意向详细说明
            
                var ProjectName1="txtCapitalIntent";
            if(trim(document.getElementById(ProjectName1).value)=="")
            {
                alert("投资意向详细说明不能为空...");
                document.getElementById(ProjectName1).focus();
                return false;
            }
            
         //   意向有效期限
           if(!ChkCbl("<%=this.rdlValiditeTerm.ClientID %>","意向有效期限"))
            {
                return false ;
            }
            //投资机构简介 txtGovIntro
             
                var ProjectName3="txtGovIntro";
            if(trim(document.getElementById(ProjectName3).value)=="")
            {
                alert("投资机构简介不能为空...");
                document.getElementById(ProjectName3).focus();
                return false;
            }
            
            
          document.getElementById("imgLoding").style.display="";

    }
    

    
    

    
    
    //---------------------------公用，单选框的判断----------------------
    function ChkRbl(kjID,kjName)
    {
        var kjVal=kjID.replace(/_/g,"$");
        if(GetCheckNum(kjVal)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else 
        {
            return true;
        }
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
    //----------------------END-----------------------------------
   

    //-------------------公用 ，选择checkbox------------------------
    function ChkCbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else
        {
            return true;
        }
    }
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
    //-------------------------------END----------------------------------
    
    //判断多少个汉字,限制汉字
    function checkByteLength(str,minlen,maxlen) 
    {
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
    
    
    //////////////////////
//去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}


//替换掉字符串空格
function repl(obj)
{
    if(obj.value.length>0)
    {
        obj.value=trim(obj.value);
    }
}
//////////////////////////
    
    



  
    </script>
    <div>
<%--      <link href="css/member.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .noteawoke{font-weight:normal;color:red;}
    </style>--%>



    
    <div>
    <table width="100%" height="60" border="0" cellpadding="0"style="text-align:center; line-height:20px; margin:15px 0;" cellspacing="0" class="mem_tab1">
  <tr>
    <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
    <td width="125" style="background:url(images/member_bg1_on.gif) no-repeat;" class="f_red strong">第一步<br />
      填写项目信息</td>
    <td width="50"><img src="images/member_icon1.gif" /></td>
    <td width="125" style="background:url(images/member_bg1_off.gif) no-repeat;">第二步<br />
      确认联系方式</td>
    <td>&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">资本资源发布</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
     <td valign="top" class="tdbg" style="height: 30px; width: 151px;"><span class="f_red">*</span> <strong>投资需求标题：</strong></td>
    <td style="width:699px; height: 30px;"> <asp:TextBox ID="txtCapitalName" runat="server"  Height="20px" Width="266px"></asp:TextBox>
                    <span id="spCapitalName" >请正确填写标题，30字以内</span>
      <span class="f_gray"></span></td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px" ><span class="f_red">*</span> <strong>资本类型：</strong></td>
    <td style="width:569px;">
	  
     <asp:CheckBoxList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"  Height="2px">
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
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>拟投资行业：</strong></td>
    <td style="width: 569px">
       <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" /></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>拟投向区域：</strong></td>
    <td style="width: 569px"> 
    
    <uc1:ZoneSelect id="ZoneSelect1" runat="server"></uc1:ZoneSelect>
    
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>单项目可投资金额：</strong></td>
    <td >
    
    <p>
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><br />
                        <%--<span style="color:#999999;">金额的货币单位为人民币</span><span id="spCurrency"></span>--%></p>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>投资项目阶段：</strong></td>
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
    <td class="tdbg" style="width: 151px"> <strong>机构注册资金：</strong></td>
    <td style="width: 569px">
     <asp:RadioButtonList ID="rblRegisterdollar" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
    <span id="spdollar"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px; width: 151px;"> <strong>机构团队规模：</strong></td>
    <td style="width: 569px; height: 40px;">
        <asp:RadioButtonList ID="rblTeam" runat="server" Height="2px" RepeatDirection="Horizontal"
            RepeatLayout="Flow">
        </asp:RadioButtonList>&nbsp;<span id="sprblTeam"></span></td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><strong>机构年平均投资事件数：</strong></td>
    <td style="width: 569px">
      <asp:RadioButtonList ID="rblPinJ" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="sprblPinJ"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><strong>机构成功投资事件总数：</strong></td>
    <td style="width: 569px">
     <asp:RadioButtonList ID="rblSucess" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="sprblSucess"></span>
    
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>投资方式：</strong></td>
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
    <td class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>是否参与项目方管理：</strong></td>
    <td style="width: 569px"><p>
                        <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spJoinManage"></span></p> 	</td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>投资需求摘要：</strong></td>
    <td style="width: 569px">
     <textarea cols="50" rows="10" id="txtDemand" runat="server"  style="width: 540px;
                        height: 100px"></textarea>
                        
    <span id="sptxtDemand"></span>
    
      <br />
      <span class="f_gray">用最简洁扼要的语言介绍您的投资需求，建议字数控制在600字以内！</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>投资意向详细说明：</strong></td>
    <td style="width: 569px">
     <p>
                        <textarea id="txtCapitalIntent" runat="server" cols="50" rows="10" tyle="width: 558px; height: 204px"></textarea>
                        <span id="spCapitalIntent"></span><br />
                        <span class="hui">1.填写投资的对象、以及对项目方的要求等；<br />
                            2.不少于20字，不能含有联系方式如电话、E-mail等，否则将无法通过审核。</span><a href="">查看范例</a></p>
    </td> 
  </tr>
    <tr>
                      <td valign="top" class="tdbg" style="width: 151px"><strong>关键字：</strong></td>
                <td width="699">
                    <asp:TextBox ID="txtKeyword1"  runat="server" Width="72px" Height="20px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" runat="server" Width="72px" Height="20px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>
                    <span id="spKeyMsg"></span>
                    <p>  
                   <a href="http://www.topfo.com/help/demandmanage.shtml#19" style="color:blue;"> 如何定义关键字</a>
                        <span class="hui">填写与投资意向相关的关键字更容易被项目方搜索到，空格内不能使用标点符号。</span></p>
                </td>
            </tr>
  <tr>
    <td class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>意向有效期限：</strong></td>
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
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>投资机构简介：</strong></td>
    <td style="width: 569px">
    
    <textarea cols="50" rows="10" id="txtGovIntro" runat="server" onchange="JavaScrpit:CheckGovIntro()" style="width: 540px;
                        height: 100px"></textarea><span id="spGovIntro"></span>
   
    <br />
    <span class="f_gray">机构的历史发展介绍、投资方向及运作团队等.</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg" style="width: 151px"><span class="f_red">*</span> <strong>上传附件：</strong></td>
    <td style="width: 569px" class="nonepad">
	   <uc4:FilesUploadControl ID="FilesUploadControl1" InfoType="Capital"
                        runat="server"  />
    </td>
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
   
        <asp:Button ID="IbtnSubmit" runat="server" Text="填好了，确认一下联系方式" OnClientClick="return chkpost();" OnClick="IbtnSubmit_Click" />
      </td>
  </tr>
</table>
    </div>
    <div id="imgLoding" style="position:absolute;
            display:none;
            background-color: #A9A9A9; 
            top: -238px; 
            bottom:0px;
            left: -663px; 
            width: 1px; 
            height:1px; 
            filter:alpha(opacity=60);" runat="server">
            <div class="content" style="margin-left:500px; margin-top:600px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" /></div>
        </div>
<%--      <div id="imgLoding" style="position:absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            bottom:0px;
            left: 0px; 
            width: 1000px; 
            height:3500px; 
            filter:alpha(opacity=60);" runat="server">
            <div class="content" style="margin-left:500px; margin-top:600px;">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="images/loading42.gif" alt="Loading" /></div>
        </div>--%>
    </div>
    </form>
</body>
</html>
