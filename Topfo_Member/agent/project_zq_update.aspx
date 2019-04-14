<%@ Page Language="C#" AutoEventWireup="true" CodeFile="project_zq_update.aspx.cs"
    Inherits="agent_project_zq_update2" %>

<%@ Register Src="../Controls/UpFileControl.ascx" TagName="UpFileControl" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

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
            var ProjectName="ctl00_ContentPlaceHolder1_txtProjectName";
            if(document.getElementById(ProjectName).value=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            
            //行业
            if(document.getElementById(c+"SelectIndustryControl1_hdselectValue").value=="")
            {
                alert("请选择行业...");
                document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
                return false;
            }
            
            //地域
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
                { 
                    alert("请选择省份...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("请选择城市...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            
            //项目立项情况 cblXmlxqk
            if(!ChkCbl("<%=this.cblXmlxqk.ClientID %>","项目立项情况"))
            {
                return ;
            }
                        
            //项目投资总额 txtCapitalTotal
            kj="<%=this.txtCapitalTotal.ClientID %>"; 
            if(document.getElementById(kj).value=="")
            {
                alert("项目投资总额不能为空，请检查！");
                document.getElementById(kj).focus();
                return ;
            }
            
            //借款金额rblJqjy
            if(!ChkRbl("<%=this.rblJqjy.ClientID %>","借款金额"))
            {
                return ;
            }
            
            //融资对象cblTnObj
            if(!ChkCbl("<%=this.cblTnObj.ClientID %>","融资对象"))
            {
                return;
            }
            
            //企业发展阶段rblQyfzjd
            if(!ChkRbl("<%=this.rblQyfzjd.ClientID %>","企业发展阶段"))
            {
                return;
            }
            
            // 要求资金到位情况rblYqzjdwqk
            if(!ChkRbl("<%=this.rblYqzjdwqk.ClientID %>","要求资金到位情况"))
            {
                return ;
            }
            
            
            //融资计划及还款能力txtWarrant
            var Warrant="ctl00_ContentPlaceHolder1_txtWarrant";
            if(document.getElementById(Warrant).value.length<50)
            {
                alert("融资计划及还款能力介绍不少于50字...");
                document.getElementById(Warrant).focus();
                return  ;
            }
               
            //产品市场增长 tbCpsczzl
            kj="ctl00_ContentPlaceHolder1_tbCpsczzl";
            zt="产品市场增长";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //产品市场容量tbCpscyl
            kj="ctl00_ContentPlaceHolder1_tbCpscyl";
            zt="产品市场容量";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //资产负债率tbZcfzl
            kj="ctl00_ContentPlaceHolder1_tbZcfzl";
            zt="资产负债率";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //暂不用
//            //流动比率tbLdbl
//            kj="ctl00_ContentPlaceHolder1_tbLdbl";
//            zt="流动比率";
//            if(!ChkData(kj,zt))
//            {
//                return ;
//            }
            
            //投资收益率tbTzsyl
            kj="ctl00_ContentPlaceHolder1_tbTzsyl";
            zt="投资收益率";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //销售利润率tbXslyl
            kj="ctl00_ContentPlaceHolder1_tbXslyl";
            zt="销售利润率";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //暂不用
//            //投资回报期rblXmtzfbzq
//            if(!ChkRbl("<%=this.rblXmtzfbzq.ClientID %>","投资回报期"))
//            {
//                return ;
//            }
            
            //项目有效期限rblXmyxqxx
            if(!ChkRbl("<%=this.rblXmyxqxx.ClientID %>","项目有效期限"))
            {
                return ;
            }
            
            
            //项目摘要
            var ProIntro="ctl00_ContentPlaceHolder1_tbXmzy";
            obj=document.getElementById(ProIntro);
            if(document.getElementById(ProIntro).value.length<50)
            {
                alert("填写项目摘要.建议200字以内（不少于50字）");
                document.getElementById(ProIntro).focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,400))
            {
                alert("填写项目摘要.建议200字以内（不少于50字）");
                document.getElementById(ProIntro).focus();
                return ;
            }
            
            //项目详细描述
            kj="ctl00_ContentPlaceHolder1_tbXmqxms";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("项目详细描述不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("项目详细描述不得超过400个汉字,请检查！");
                obj.focus();
                return ;
            }

       //---------------------------------
       
        //产品概述
            kj="ctl00_ContentPlaceHolder1_tbCpks";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("产品概述不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("产品概述不得超过600个汉字，请检查！");
                obj.focus();
                return ;
            }
            
            //市场前景
            kj="ctl00_ContentPlaceHolder1_tbScqj";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("市场前景不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("市场前景不得超过600个汉字，请检查！");
                obj.focus();
                return ;
            }
            
            //竞争分析
            kj="ctl00_ContentPlaceHolder1_tbJjfs";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("竞争分析不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("竞争分析不得超过600个汉字，请检查！");
                obj.focus();
                return ;
            }
            
            //商业模式
            kj="ctl00_ContentPlaceHolder1_tbSyms";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("商业模式不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("商业模式不得超过600个汉字,请检查！");
                obj.focus();
                return ;
            }
            
            //管理团队
            kj="ctl00_ContentPlaceHolder1_tbGltd";
            obj=document.getElementById(kj);
            if(obj.value=="")
            {
                alert("管理团不能为空，请检查！");
                obj.focus();
                return ;
            }
            if(!checkByteLength(obj.value,1,1200))
            {
                alert("管理团队不得超过600个汉字，请检查！");
                obj.focus();
                return ;
            }
        
            
            //我已阅读不能为空
            if(!document.getElementById("chkReadMe").checked)
            {
                alert("请选择‘我已阅读《拓富·中国招商投资网服务协议》’。");
                document.getElementById("chkReadMe").focus();
                return false;
            }
            
            //第二步
            window.document.getElementById("step1").style.display="none";
            window.document.getElementById("step2").style.display="block";
    }
    
    function disp(iType)
    {
        if(iType=="1")
        {
            window.document.getElementById("step1").style.display="none";
            window.document.getElementById("step2").style.display="block";
        }
        if(iType=="2")
        {
            window.document.getElementById("step1").style.display="block";
            window.document.getElementById("step2").style.display="none";
        }
    }
    
    
    //输入0到100之间的数值
    function ChkData(kjName,ztName)
    {
        var val=document.getElementById(kjName).value;
        if(val!="")
        {
            if(!isNaN(val))
            {
                if(val>100 || val<0)
                    {
                        alert("输入的数值应该在0到100之间，请检查！");
                        document.getElementById(kjName).focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
            else
            {
                alert(ztName+"只能为数值，且输入的范围应该在0到100之间！");
                document.getElementById(kjName).focus();
                return false;
            }
        }
        else
        {
            alert(ztName+"不能空，且输入的范围应该在0到100之间，请检查！");
            document.getElementById(kjName).focus();
            return false;
        }
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
    
    
    //验证金额
    function ChkJy(kj,kjName)
    {
        var kjVal=document.getElementById(kj).value;
        if(kjVal!="")
        {
            if(isNaN(kjVal))
            {
                alert(kjName+"的值输入不正确，请检查！");
                document.getElementById(CapitalTotal).focus();
                return false;
            }
            else 
            {
                return true;
            }            
        }
        else 
        {
            return false;
        }
    }


//-------------------验证联络人-------------------------------------
function txtshow(obj)
    {
        if(obj=="Tel")
        {
            var t="<%=this.txtTelStateCode.ClientID %>";
            var c="<%=this.txtTel.ClientID %>";
            document.getElementById(t).className="";
            document.getElementById(c).disabled="";
        }
        document.getElementById("ctl00_ContentPlaceHolder1_txt"+obj).className="";
        document.getElementById('ctl00_ContentPlaceHolder1_txt'+obj).disabled="";
        document.getElementById('lnk'+obj).innerHTML="";
    }
    

    
 function chkContact()
  {
    var CompanyName="<%=this.txtCompanyName.ClientID %>";
   if(document.getElementById(CompanyName).value=="")
   {
    alert("项目单位名称不能为空...");
    txtshow("CompanyName");
    document.getElementById(CompanyName).focus();
    return false;
  }
 
  var LinkMan="<%=this.txtLinkMan.ClientID %>";
  if(document.getElementById(LinkMan).value=="")
  {
    alert("联系人不能为空...");
    txtshow("LinkMan");
    document.getElementById(LinkMan).focus();
    return false;
  }
 
  var Tel="<%=this.txtTel.ClientID %>";
  var Mobile="<%=this.txtMobile.ClientID %>";
  var TelStateCode="<%=this.txtTelStateCode.ClientID %>";
  if(document.getElementById(Tel).value==""&&document.getElementById(Mobile).value=="")
  {
         alert("电话号码或手机须至少填写一个...");
         txtshow("Tel");
         document.getElementById(Tel).focus();
         return false;
  }
  if(document.getElementById(Tel).value!="")
  {
      if(isNaN(document.getElementById(Tel).value))
      {
             alert("电话号码格式错误");
             txtshow("Tel");
             document.getElementById(Tel).focus();
             return false;
      }
      if(document.getElementById(TelStateCode).value=="")
      {
        alert("区号不能为空...");
        txtshow("Tel");
        document.getElementById(TelStateCode).focus();
        return false;
      }
      else
      {
           var filter = /^[0-9]+$/;
           if(!filter.test(document.getElementById(TelStateCode).value))
           {
             alert("区号错误...");
             document.getElementById(TelStateCode).focus();
             return false;
           }
      }
  } 
  if(document.getElementById(Mobile).value!="")
  {
        if(isNaN(document.getElementById(Mobile).value)||document.getElementById(Mobile).value.length!=11)
        {
             alert("手机位数不正确...")
             txtshow("Mobile");
             document.getElementById(Mobile).focus();
              return false;
         }
  }
   var Email="<%=this.txtEmail.ClientID %>";
  if(document.getElementById(Email).value=="")
  {
         alert("电子邮件不能为空...");
         txtshow("Email");
    	  document.getElementById(Email).focus();
	      return false;
  }
  else
  {
                var obj = document.getElementById(Email);
    	        var str = obj.value;
    	        var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    	        if(!filter.test(str))
    	        {
    	            alert("电子邮件格式错误...");
    	            txtshow("Email");
    	            document.getElementById(Email).focus();
	                return false;
    	        }

   }
      var WebSite="<%=this.txtWebSite.ClientID %>";
      if(document.getElementById(WebSite).value!="")
      { 
          var obj = document.getElementById(WebSite);
    	  var str = obj.value; 
    	  if(!IsURL(str))
    	  {
    	         alert("网址格式错误...");
    	         document.getElementById(WebSite).focus();
	             return false;
    	  }
      }
  
 }
 function IsURL(str_url){ 
  var strRegex = "^((https|http|ftp|rtsp|mms)?://)"  
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@  
        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184  
        + "|" // 允许IP和DOMAIN（域名） 
        + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.  
        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名  
        + "[a-z]{2,6})" // first level domain- .com or .museum  
        + "(:[0-9]{1,4})?" // 端口- :80  
        + "((/?)|" // a slash isn't required if there is no file name  
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";  
        var re=new RegExp(strRegex);  
        if (re.test(str_url)){ 
            return (true);  
        }else{  
            return (false);  
        } 
    }
    //----------------------------END---------------------------------
  
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="step1" style="display: block;">
            <%--<table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 60px;
            text-align: center; line-height: 20px; margin: 15px 0;" class="f_14">
            <tr>
                <td width="130" class="strong">
                    发布资源只需<span class="f_red">2</span>步：</td>
                <td width="125" style="background: url(../../img/member_bg1_on.gif) no-repeat;" class="f_red strong">
                    第一步<br />
                    填写项目信息</td>
                <td width="50">
                    <img src="../../img/member_icon1.gif" alt="" /></td>
                <td width="125" style="background: url(../../img/member_bg1_off.gif) no-repeat;">
                    第二步<br />
                    确认联系方式</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14 strong">
                    <asp:RadioButton ID="RadioButton1" GroupName="group1" Text="股权融资" runat="server"
                        OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="RadioButton2" GroupName="group1" Text="债权融资" Checked="true"
                        runat="server" /></td>
            </tr>
        </table>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="padding: 5px 10px;" class="f_14">
                        <span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span></td>
                </tr>
            </table>
            <table cellspacing="0" class="mem_tab1">
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>项目标题：</strong></td>
                    <td>
                        <input id="txtProjectName" style="width: 286px" runat="server" />
                        <span class="f_gray">标题最好控制在25个字以内</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>所属行业：</strong></td>
                    <td>
                        <span class="f_gray">
                            <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>所属区域：</strong></td>
                    <td>
                        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span><strong>项目立项情况：</strong></td>
                    <td>
                        <asp:CheckBoxList ID="cblXmlxqk" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:CheckBoxList>
                        <br />
                        <span class="f_gray">说明：项目若缺乏所需批文、执照和证件，则对项目评价有较大影响</span></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>项目投资总额：</strong></td>
                    <td>
                        <asp:TextBox ID="txtCapitalTotal" runat="server" Width="75px">
                        </asp:TextBox>
                        万人民币<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCapitalTotal"
                            Display="Dynamic" ErrorMessage="项目投资总额不能为空！">
                        </asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                            ControlToValidate="txtCapitalTotal" ErrorMessage="请输入数字,保留2位小数！" ValidationExpression="^[1-9]+(.[0-9]{1,2})?"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>借款金额：</strong></td>
                    <td>
                        <asp:RadioButtonList ID="rblJqjy" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblJqjy"
                            Display="Dynamic" ErrorMessage="请选择借款金额！" Enabled="False"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px; height: 40px;">
                        <span class="f_red">*</span> <strong>融资对象：</strong></td>
                    <td style="height: 40px">
                        <asp:CheckBoxList ID="cblTnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>企业发展阶段：</strong></td>
                    <td>
                        <asp:RadioButtonList ID="rblQyfzjd" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rblQyfzjd"
                            Display="Dynamic" ErrorMessage="请选择企业发展阶段！"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>要求资金到位情况：</strong></td>
                    <td>
                        <asp:RadioButtonList ID="rblYqzjdwqk" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rblYqzjdwqk"
                            Display="Dynamic" ErrorMessage="请选择要求资金到位情况！"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>融资计划及还款能力：</strong></td>
                    <td>
                        <textarea id="txtWarrant" rows="5" style="width: 80%;" runat="server"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtWarrant"
                            Display="Dynamic" ErrorMessage="融资计划及还款能力不能为空！"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>产品市场增长率：</strong></td>
                    <td>
                        <input id="tbCpsczzl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbCpsczzl"
                            Display="Dynamic" ErrorMessage="产品市场增长率不能为空！"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbCpsczzl"
                            Display="Dynamic" ErrorMessage="产品市场增长率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>产品市场容量：</strong></td>
                    <td>
                        <input id="tbCpscyl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbCpscyl"
                            Display="Dynamic" ErrorMessage="产品市场容量不能为空！"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbCpscyl"
                            Display="Dynamic" ErrorMessage="产品市场容量的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>资产负债率：</strong></td>
                    <td style="line-height: 18px;">
                        <input id="tbZcfzl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbZcfzl"
                            Display="Dynamic" ErrorMessage="资产负债率不能为空！"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbZcfzl"
                            Display="Dynamic" ErrorMessage="资产负债率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator><br />
                        <span class="f_gray">资产负债率=（负债总额/资产总额）*100％，资产负债率反映在总资产中有多大比例是通过借债来筹资的，也可以衡量企业在清算时保护债权人利益的程度。</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <strong>流动比率：</strong></td>
                    <td>
                        <input id="tbLdbl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbLdbl"
                            Display="Dynamic" ErrorMessage="流动比率不能为空！" Enabled="False"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbLdbl"
                            Display="Dynamic" ErrorMessage="流动比率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator><br />
                        <span class="f_gray">&nbsp;流动比率＝流动资产／流动负债X100％，用来衡量企业流动资产在短期债务到期以前，可以变为现金用于偿还负债的能力。</span></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>投资收益率：</strong></td>
                    <td>
                        <input id="tbTzsyl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbTzsyl"
                            Display="Dynamic" ErrorMessage="投资收益率不能为空！"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="tbTzsyl"
                            Display="Dynamic" ErrorMessage="投资收益率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span><strong>销售利润率：</strong></td>
                    <td>
                        <input id="tbXslyl" type="text" size="5" runat="server" />
                        %<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbXslyl"
                            Display="Dynamic" ErrorMessage="销售利润率不能为空！"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="tbXslyl"
                            Display="Dynamic" ErrorMessage="销售利润率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <strong>投资回报期：</strong></td>
                    <td>
                        <asp:RadioButtonList ID="rblXmtzfbzq" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rblXmtzfbzq"
                            Display="Dynamic" ErrorMessage="请选择投资回报期！"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>项目有效期限：</strong></td>
                    <td>
                        发布之日起
                        <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rblXmyxqxx"
                            Display="Dynamic" ErrorMessage="请选择项目有效期限！"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span> <strong>项目摘要：</strong></td>
                    <td>
                        <textarea id="tbXmzy" rows="5" style="width: 80%;" runat="server"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tbXmzy"
                            Display="Dynamic" ErrorMessage="项目摘要不能为空！"></asp:RequiredFieldValidator><br />
                        <span class="f_gray">为吸引投资方的关注，请对项目重点内容进行简单扼要的描述，字数请控制在200字以内！</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <span class="f_red">*</span><strong>项目详细描述：</strong></td>
                    <td>
                        <textarea id="tbXmqxms" rows="7" style="width: 80%;" runat="server"></textarea>
                        <br />
                        <span class="f_gray">项目内容越详细越有利于投资方了解您项目的具体情况，请尽量详尽完善！</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg" style="width: 142px">
                        <strong>项目关键字：</strong></td>
                    <td>
                        <input id="tbXmgjz1" type="text" size="12" runat="server" />
                        <input id="tbXmgjz2" type="text" size="12" runat="server" />
                        <input id="tbXmgjz3" type="text" size="12" runat="server" />
                        <span class="f_red"><a href="#">如何定义关键字？</a></span><br />
                        <span class="f_gray">定义相关的关键字能让您的需求更容易被潜在合作方找到</span></td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding: 25px 0 5px 0;">
                <tr>
                    <td class="f_14">
                        <span class="f_red strong">※ 项目详细资料</span><span class="f_gray">（完善的资料可以得到投资方更多信任，请完善以下信息！）</span></td>
                </tr>
            </table>
            <table cellspacing="0" class="mem_tab1">
                <tr>
                    <td width="145" class="tdbg">
                        <strong>借款单位年营业收入：</strong></td>
                    <td>
                        <input id="tbJkdwlyysy" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " />
                        万元(人民币)</td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>借款单位年净利润：</strong></td>
                    <td>
                        <input id="tbJkdwljly" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " />
                        万元(人民币)</td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>借款单位总资产：</strong></td>
                    <td>
                        <input id="tbJkdwzzc" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " />
                        万元(人民币)</td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>借款单位总负债：</strong></td>
                    <td>
                        <input id="tbJkdwzfz" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " />
                        万元(人民币)</td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <span class="f_red">*</span><strong>产品概述：</strong></td>
                    <td>
                        <textarea id="tbCpks" rows="5" style="width: 80%;" runat="server"></textarea>
                        <br />
                        <span class="f_gray">您主要提供哪些产品与服务，针对哪些客户进行服务，如何定价。</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <span class="f_red">*</span><strong>市场前景：</strong></td>
                    <td>
                        <textarea id="tbScqj" rows="5" style="width: 80%;" runat="server" cols="0"></textarea>
                        <br />
                        <span class="f_gray">当前市场法制环境、目标消费人群分析、市场总量多大，市场发展潜力多大。</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <span class="f_red">*</span><strong>竞争分析：</strong></td>
                    <td>
                        <textarea id="tbJjfs" rows="5" style="width: 80%;" runat="server" cols="0"></textarea>
                        <br />
                        <span class="f_gray">竞争状况、你所能占领的市场份额、SWOT分析（优势、劣势、机会、威胁）。</span>
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <span class="f_red">*</span><strong>商业模式：</strong></td>
                    <td>
                        <textarea id="tbSyms" rows="5" style="width: 80%;" runat="server" cols="0"></textarea>
                        <br />
                        <span class="f_gray">您在市场、产品、销售、管理、收入来源以及盈利等方面以什么形式实现，您的核心竞争力是什么？ 如何保证核心竞争力？</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <span class="f_red">*</span><strong>管理团队：</strong></td>
                    <td>
                        <textarea id="tbGltd" rows="5" style="width: 80%;" runat="server" cols="0"></textarea>
                        <br />
                        <span class="f_gray">团队架构、高管人员的从业经历等。</span></td>
                </tr>
                <tr>
                    <td valign="top" class="tdbg">
                        <strong>项目资料附件：</strong></td>
                    <td bgcolor="#FFFFFF">
                        <div class="fujian">
                            <%--<uc3:UpFileControl ID="UpFileControl1" runat="server" />--%>
                            <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
                            &nbsp;</div>
                    </td>
                </tr>
            </table>
        </div>
        <!--########### 第二步，确认联络方式 #########-->
        <!--<div id="step2" style="display: none;">-->
        <div id="step2">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="f_14 f_red strong" style="padding: 5px 10px;">
                        联系方式确认</td>
                </tr>
            </table>
            <table cellspacing="0" class="mem_tab1">
                <tr>
                    <td width="130" class="tdbg">
                        <span class="f_red">*</span> <strong>项目单位名称：</strong></td>
                    <td>
                        <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCompanyName"
                            runat="server" ErrorMessage="项目单位名称不能为空！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <span class="f_red">*</span> <strong>联系人：</strong></td>
                    <td>
                        <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLinkMan"
                            runat="server" ErrorMessage="联系人不能为空！"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>职位：</strong></td>
                    <td>
                        <input id="txtCareer" class="show" type="text" style="width: 210px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <span class="f_red">*</span> <strong>联系电话：</strong></td>
                    <td>
                        固话
                        <input id="telArea1" type="text" size="3" value="+86" runat="server" />
                        <input id="txtTelStateCode" type="text" size="5" runat="server" />
                        <input id="txtTel" type="text" size="15" runat="server" />
                        <input id="telFg" type="text" size="5" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelStateCode"
                            ErrorMessage="区号输有误！" ValidationExpression='[0-9]{3,4}' Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                            ErrorMessage="电话号码有误！" ValidationExpression='[0-9]{7,8}' Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="telFg"
                            ErrorMessage="分机号码有误！" ValidationExpression='[0-9]{1,5}' Display="Dynamic"></asp:RegularExpressionValidator>
                        <br />
                        手机
                        <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                            runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtMobile"
                            ErrorMessage="手机号码格式有误" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                        <span class="f_gray">（固定电话或手机至少填写一项）</span></td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <span class="f_red">*</span> <strong>电子邮箱：</strong></td>
                    <td>
                        <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="E-mail格式有误！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="电子邮箱不能为空！"
                            ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>项目单位详细地址：</strong></td>
                    <td>
                        <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" /></td>
                </tr>
                <tr>
                    <td class="tdbg">
                        <strong>单位网址：</strong></td>
                    <td>
                        <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="单位网址格式不能，请检查!"
                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ControlToValidate="txtWebSite"></asp:RegularExpressionValidator></td>
                </tr>
            </table>
            <table width="100%" cellspacing="0" style="text-align: center;">
                <tr>
                    <td height="40">
                        <input type="checkbox" id="chkReadMe" checked="checked" />
                        我已阅读<span class="f_red"><a href="#">《拓富·中国招商投资网服务协议》</a> </span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 26px">
                        <!-- <input id="Button2" type="button" value="下一步：确认联系方式" onclick="chkpost();" />-->
                    </td>
                </tr>
            </table>
            <table width="100%" cellspacing="0" style="height: 60px; text-align: center;">
                <tr>
                    <td>
                        <asp:Button ID="btnOK" runat="server" Text="确认修改" OnClick="BtnOk_Click" />
                        <%--<asp:ImageButton ID="btnOK" runat="server" ImageUrl="/images/button3.jpg" OnClick="BtnOk_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <!--###########  第二步结束  #########-->
    </form>
</body>
</html>
