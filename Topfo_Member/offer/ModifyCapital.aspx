<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModifyCapital.aspx.cs" Inherits="offer_ModifyCapital" Title="Untitled Page" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
       
        .llll{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:800px;}
       </style>
     <script type="text/javascript">
     
  function chkpost()
   {  
          var c="ctl00_ContentPlaceHolder1_";
            var kj="";
            var zt="";
            var obj="";
                        
            //标题
            var ProjectName="ctl00_ContentPlaceHolder1_txtCapitalName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return false;
            }
        //行业
	   if(document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {     
	   
	         alert("请选择所属行业...");
	         document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").focus();
	         return false;
	   }
        //地域
	   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneMoreSelectControl1_sltZone_Select").options.length==0)
	   {     
	   
	         alert("请选择所属地域最多添加5个..");
	         document.getElementById("ctl00_ContentPlaceHolder1_ZoneMoreSelectControl1_sltZone_Select").focus();
	         return false;
	   }    
	         //借款金额
            if(!ChkRbl("<%=this.rblCurreny.ClientID %>","单项目可投资金额"))
            {
             document.getElementById("touzje").focus();  
                return false ;
            }
               
         //   意向有效期限
           if(!ChkCbl("<%=this.rdlValiditeTerm.ClientID %>","意向有效期限"))
            {
              document.getElementById("ValiditeTerm").focus();  
                return false ;
            }
   
            //投资意向详细说明
                var ProjectName1="ctl00_ContentPlaceHolder1_txtCapitalIntent";
            if(trim(document.getElementById(ProjectName1).value)=="")
            {
                alert("投资意向详细说明不能为空...");
                document.getElementById(ProjectName1).focus();
                return false;
            }
            
       
       if(document.getElementById("ctl00_ContentPlaceHolder1_txtGovName").value=="")
	    {
	       alert("机构名称不能为空..");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtGovName").focus();
	       return false;
	    }
         if(document.getElementById("ctl00_ContentPlaceHolder1_txtLinkMan").value=="")
	    {
	       alert("联系人不能为空..");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtLinkMan").focus();
	       return false;
	    }
	      var telzone=document.getElementById(c+"txtTelZoneCode") ;
	   var telNumber=document.getElementById(c+"txtTelNumber");
	   var telMobile=document.getElementById(c+"txtMobile");
	    if(telNumber.value.length=="" && telMobile.value.length=="")
        {
            alert("手机和固定电话请至少填写一项");
             document.getElementById(c+"txtMobile").focus();
            return false;
        }
        if(document.getElementById(c+"txtMobile").value.length!="")
        {
           var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(trim(document.getElementById(c+"txtMobile").value)))
            {
                alert("请正确填写手机号码");
                document.getElementById(c+"txtMobile").focus();
                return false;
            }
        }
        
                var objWebSite = document.getElementById(c+"txtWebSite").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(trim(objWebSite)))
             { 
                alert("网址填写不正确!");
			    document.getElementById(c+"txtWebSite").focus();
                return false;
             }
		}
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value=="")
        {
           alert("请输入电子邮箱");
           document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value)))
            {
       	         alert("电子邮箱格式不正确，请重新输入");
       	         document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
       	         return false;
       	     }
        }
      
//     document.getElementById("aspnetForm").onsubmit = FormSubmit;

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
    <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布投资需求资源</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>投资需求标题：</td>
        <td><asp:TextBox ID="txtCapitalName" runat="server"  Height="20px" Width="266px"></asp:TextBox>
                    <span id="spCapitalName" >请正确填写标题，30字以内</span></td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>拟投资行业：</td>
        <td style="height: 22px">
        <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
    </td>
      </tr>
      <tr>
        <td class="publica-td-left" ><span class="hong">*</span>拟投向区域：</td>
        <td>
        <uc1:ZoneSelect id="ZoneMoreSelectControl1" runat="server"></uc1:ZoneSelect>   
    </td>
      </tr>
      <tr>
          <td class="publica-td-left" ><span class="hong">*</span>项目可投资金额：</td>
                <td>
                    <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList><input name="ZoneId" type="text" id="touzje" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                 </td>
          </tr>
            <tr>
              <td class="publica-td-left">
              <span class="hong">*</span>投资方式：</td>
                <td>
                <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" />
                            <input name="ZoneId" type="text" id="spCooperationDemand" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                      </td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 意向有效期限：</td>
                <td>
                    <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
     </asp:RadioButtonList>
    <input name="ZoneId" type="text" id="ValiditeTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                    </td>
            </tr>
               <tr>
                <td class="publica-td-left">
                    投资回报率:
                </td>
                <td>
                    <asp:TextBox ID="txtHBao" runat="server" Width="56px" onkeyup="value=value.replace(/[^\d]/g,'') " ></asp:TextBox>%</td>
            </tr>
            <tr>
             <td class="publica-td-left" >
                    <span class="hong">*</span> 投资意向详细说明：</td>
                <td>
                    <textarea id="txtCapitalIntent" runat="server" cols="50" rows="10" style="width: 558px; height: 204px"></textarea>
                        <span id="spCapitalIntent"></span><br />
                    </td>
            </tr>
          <tr>
          <td class="publica-td-left" valign="top" >
            上传图片：</td>
                <td class="nonepad" valign="top" width="618">
                <uc4:FilesUploadControl ID="FilesUploadControl1" InfoType="Capital"
                        runat="server"  />
                    </td>
            </tr>
            <tr>
            <td colspan="2">
            <span class="f_14px strong f_cen">联系人详细信息</span>
            </td>
            </tr>
            
       <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span> 投资机构名称：</td>
        <td >
            <asp:TextBox ID="txtGovName" onchange="checkGovName()" Width="246px" runat="server" />
                    <span id="SpGovName"></span>
            </td>
       </tr>

      <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系人：</td>
        <td >
      <asp:TextBox ID="txtLinkMan" onchange="checkLinkMan()" Width="246px" runat="server" />
                    <span id="splinkMan"></span>
        </td>
      </tr>

    <tr>
        <td class="publica-td-left" >
            <span class="hong">*</span>联系电话：</td>
        <td >
            <asp:TextBox ID="txtTelCountry" runat="server" size='4'  >+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size='8'  onkeyup="value=value.replace(/[^\d]/g,'') "  />
                    <asp:TextBox ID="txtTelNumber" runat="server" size='8'   onkeyup="value=value.replace(/[^\d]/g,'') "  />                    
                    <span class="f_gray">（如：+86-0755-89805588）</span>
                    <span id="spMobile"></span>
                    <span id="spMobile2"></span> 
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            手机：</td>
        <td >
            <asp:TextBox ID="txtMobile" Width="127px" runat="server"  onchange="CheckMobile()"/>
                 <span class="f_gray">（固定电话或手机至少填写一项）</span>
                <span id="spMobile1"></span>
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
           <span class="hong">*</span>  电子邮箱：</td>
        <td >
            <asp:TextBox ID="txtEmail" runat="server" size='18' Width="269px" onchange="CheckEmail()"/>
            <span id="spEmail" class="hui">请填写您最常用的电子邮箱</span>
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            投资机构地址：</td>
        <td >
            <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
    </tr>
    <tr >
        <td class="publica-td-left" >
            网站：</td>
        <td >
             <asp:TextBox ID="txtWebSite" runat="server" size='18' Width="269px" /><span class="f_gray">例如：http://www.topfo.com</span>&nbsp;</td>
    </tr>
            <tr>
            <td colspan="2" id="pub-tongyi">

             <asp:ImageButton ID="btnUpdate"  OnClientClick="return chkpost();" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server"
                OnClick="btnUpdate_Click"  />
               </td>
            </tr>
</table>

    </div>
      </div>
      <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2000px; filter: 
   alpha(opacity=60);">

               <div class="llll">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../../img/img-loading.gif" alt="Loading" />
                </div>
        </div>
       <script language="javascript"> createCode();</script>
</asp:Content>

