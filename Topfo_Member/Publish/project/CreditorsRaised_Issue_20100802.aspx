<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreditorsRaised_Issue.aspx.cs" Inherits="Publish_project_CreditorsRaised_Issue"
    Title="Untitled Page" %>

<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>

<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
 <link href="../../css/publishCaptal.css" rel="stylesheet" type="text/css" />
 <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../css/common.css" rel="stylesheet" type="text/css" />
 <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../img/member.css" rel="stylesheet" type="text/css" />
 
 
 <script type="text/javascript">
    
    //��ʾ��
   function DispLayer()
   {
        document.getElementById("imgLoding").style.display="";
   }
   
   function ValidErr()
   {
        document.getElementById("step1").style.display="none";
        document.getElementById("step2").style.display="block";
        alert('��֤�����,���������룡');
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
                        
            //����
            var ProjectName="ctl00_ContentPlaceHolder1_txtProjectName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("��Ŀ���ⲻ��Ϊ��...");
                document.getElementById(ProjectName).focus();
                return false;
            }
            
            //��ҵ
            if(document.getElementById(c+"SelectIndustryControl1_hdselectValue").value=="")
            {
                alert("��ѡ����ҵ...");
                document.getElementById(c+"SelectIndustryControl1_sltIndustryName_all").focus();
                return false;
            }
            
            //����
            if(document.getElementById("CountryListCN").value=="CN")
            {
                if(document.getElementById(c+"ZoneSelectControl1_hideProvince").value=="")
                { 
                    alert("��ѡ��ʡ��...");
                    document.getElementById("provinceCN").focus();
                    return false;
                }
                if(document.getElementById(c+"ZoneSelectControl1_hideCapitalCity").value=="")
                {
                    alert("��ѡ�����...");
                    document.getElementById("capitalCN").focus();
                    return false;
                }
            }
            
            //��Ŀ������� cblXmlxqk
            if(!ChkCbl("<%=this.cblXmlxqk.ClientID %>","��Ŀ�������"))
            {
                return ;
            }
                                   
            //��ĿͶ���ܶ� txtCapitalTotal
            //kj="<%=this.txtCapitalTotal.ClientID %>"; 
            var obj=document.getElementById(c+"txtCapitalTotal");
            if(trim(obj.value)=="")
            {
                alert("��ĿͶ���ܶ��Ϊ�գ����飡");
                obj.focus();
                obj.select();
                return ;
            }
            else
            {
                if(isNaN(trim(obj.value)))
                {
                    alert("��ĿͶ���ܶ��ֵֻ��Ϊ���֣�����!��");
                    obj.focus();
                    obj.select();
                    return ;
                }
            }
            
            //�����rblJqjy
            if(!ChkRbl("<%=this.rblJqjy.ClientID %>","�����"))
            {
                return ;
            }
            
            //���ʶ���cblTnObj
            if(!ChkCbl("<%=this.cblTnObj.ClientID %>","���ʶ���"))
            {
                return;
            }
            
            //��ҵ��չ�׶�rblQyfzjd
            if(!ChkRbl("<%=this.rblQyfzjd.ClientID %>","��ҵ��չ�׶�"))
            {
                return;
            }
            
            // Ҫ���ʽ�λ���rblYqzjdwqk
            if(!ChkRbl("<%=this.rblYqzjdwqk.ClientID %>","Ҫ���ʽ�λ���"))
            {
                return ;
            }
            
            
            //���ʼƻ�����������txtWarrant
            var Warrant="ctl00_ContentPlaceHolder1_txtWarrant";
            if(trim(document.getElementById(Warrant).value).length<50)
            {
                alert("���ʼƻ��������������ܲ�����50��...");
                document.getElementById(Warrant).focus();
                return  ;
            }
               
            //��Ʒ�г����� tbCpsczzl
            kj="ctl00_ContentPlaceHolder1_tbCpsczzl";
            zt="��Ʒ�г�����";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //��Ʒ�г�����tbCpscyl
            kj="ctl00_ContentPlaceHolder1_tbCpscyl";
            zt="��Ʒ�г�����";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //�ʲ���ծ��tbZcfzl
            kj="ctl00_ContentPlaceHolder1_tbZcfzl";
            zt="�ʲ���ծ��";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //�ݲ���
            //��������tbLdbl
            //kj="ctl00_ContentPlaceHolder1_tbLdbl";
            //zt="��������";
            //if(!ChkData(kj,zt))
            //{
            //    return ;
            //}
            //���Ǳ�ѡ�ֶ�
            kj="<%=this.tbLdbl.ClientID %>";
            var obj=document.getElementById(kj);
            if(!obj.value=="")
            {
                 if(isNaN(obj.value))
                 {
                    alert("�������ʵ�ֵֻ��Ϊ���֣����飡");
                    obj.focus();
                    obj.select();
                    return ;
                 }
                 else
                 {
                    if(obj.value>100 || obj.value<0)
                    {
                        alert("�������ʵ�ֵӦ����0��100֮�䣬���飡");
                        obj.focus();
                        obj.select();
                        return ;
                    }  
                 }
            }
            
            //Ͷ��������tbTzsyl
            kj="ctl00_ContentPlaceHolder1_tbTzsyl";
            zt="Ͷ��������";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //����������tbXslyl
            kj="ctl00_ContentPlaceHolder1_tbXslyl";
            zt="����������";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //�ݲ���
//            //Ͷ�ʻر���rblXmtzfbzq
//            if(!ChkRbl("<%=this.rblXmtzfbzq.ClientID %>","Ͷ�ʻر���"))
//            {
//                return ;
//            }
            
            //��Ŀ��Ч����rblXmyxqxx
            if(!ChkRbl("<%=this.rblXmyxqxx.ClientID %>","��Ŀ��Ч����"))
            {
                return ;
            }
            
            
            //��ĿժҪ
            var ProIntro="ctl00_ContentPlaceHolder1_tbXmzy";
            obj=document.getElementById(ProIntro);
            if(!checkByteLength(trim(obj.value),50,1200))
            {
                alert("��д��ĿժҪ.����600�����ڣ�������50�֣�");
                document.getElementById(ProIntro).focus();
                document.getElementById(ProIntro).select();
                return ;
            }
            
            //��Ŀ��ϸ����
            kj="ctl00_ContentPlaceHolder1_tbXmqxms";
            obj=document.getElementById(kj);            
            if(!checkByteLength(trim(obj.value),50,2000))
            {
                alert("��Ŀ��ϸ���������������50��1000�����ڣ�,���飡");
                obj.focus();
                obj.select();
                return ;
            }

       //---------------------------------
       
        //��Ʒ����
            kj="ctl00_ContentPlaceHolder1_tbCpks";
            var displ="�������������30��1000�����ڣ���";
            obj=document.getElementById(kj);
            if(!checkByteLength(trim(obj.value),30,2000))
            {
                alert("��Ʒ�������ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //�г�ǰ��
            kj="ctl00_ContentPlaceHolder1_tbScqj";
            obj=document.getElementById(kj);
            if(!checkByteLength(trim(obj.value),30,2000))
            {
                alert("�г�ǰ�����ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //��������
            kj="ctl00_ContentPlaceHolder1_tbJjfs";
            obj=document.getElementById(kj);
            if(!checkByteLength(trim(obj.value),30,2000))
            {
                alert("�����������ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //��ҵģʽ
            kj="ctl00_ContentPlaceHolder1_tbSyms";
            obj=document.getElementById(kj);
            if(!checkByteLength(trim(obj.value),30,1200))
            {
                alert("��ҵģʽ���ó���1000������,���飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //�����Ŷ�
            kj="ctl00_ContentPlaceHolder1_tbGltd";
            obj=document.getElementById(kj);
            if(!checkByteLength(trim(obj.value),30,1200))
            {
                alert("�����ŶӲ��ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
        
            
            //�����Ķ�����Ϊ��
            if(!document.getElementById("chkReadMe").checked)
            {
                alert("��ѡ�������Ķ����ظ����й�����Ͷ��������Э�顷����");
                document.getElementById("chkReadMe").focus();
                return false;
            }
            
            //�ڶ���
            window.document.getElementById("step1").style.display="none";
            window.document.getElementById("step2").style.display="block";
            
            kj="ctl00_ContentPlaceHolder1_txtCompanyName";
            document.getElementById(kj).focus();
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
    
    
    //����0��100֮�����ֵ
    function ChkData(kjName,ztName)
    {
        var val=document.getElementById(kjName).value;
        if(val!="")
        {
            if(!isNaN(val))
            {
                if(val>100 || val<0)
                    {
                        alert("�������ֵӦ����0��100֮�䣬���飡");
                        document.getElementById(kjName).focus();
                        document.getElementById(kjName).select();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
            }
            else
            {
                alert(ztName+"ֻ��Ϊ��ֵ��������ķ�ΧӦ����0��100֮�䣡");
                document.getElementById(kjName).focus();
                document.getElementById(kjName).select();
                return false;
            }
        }
        else
        {
            alert(ztName+"���ܿգ�������ķ�ΧӦ����0��100֮�䣬���飡");
            document.getElementById(kjName).focus();
            document.getElementById(kjName).select();
            return false;
        }
    }
    
    
    //---------------------------���ã���ѡ����ж�----------------------
    function ChkRbl(kjID,kjName)
    {
        var kjVal=kjID.replace(/_/g,"$");
        if(GetCheckNum(kjVal)<=0)
        {
            alert("��ѡ��"+kjName);
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
   

    //-------------------���� ��ѡ��checkbox------------------------
    function ChkCbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("��ѡ��"+kjName);
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
    
    //�ж϶��ٸ�����,���ƺ���
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
//ȥ���ַ������߿ո�ĺ���
//������mystr������ַ���
//���أ��ַ���mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//ȥ��ǰ��ո�
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//ȥ������ո�
if (mystr==" "){
mystr="";
}
return mystr;
}


//�滻���ַ����ո�
function repl(obj)
{
    if(obj.value.length>0)
    {
        obj.value=trim(obj.value);
    }
}
//////////////////////////
    
    
//    //��֤���
//    function ChkJy(kj,kjName)
//    {
//        var kjVal=document.getElementById(kj).value;
//        if(kjVal!="")
//        {
//            if(isNaN(kjVal))
//            {
//                alert(kjName+"��ֵ���벻��ȷ�����飡");
//                document.getElementById(CapitalTotal).focus();
//                return false;
//            }
//            else 
//            {
//                return true;
//            }            
//        }
//        else 
//        {
//            return false;
//        }
//    }


////-------------------��֤������-------------------------------------
//function txtshow(obj)
//    {
//        if(obj=="Tel")
//        {
//            var t="<%=this.txtTelStateCode.ClientID %>";
//            var c="<%=this.txtTel.ClientID %>";
//            document.getElementById(t).className="";
//            document.getElementById(c).disabled="";
//        }
//        document.getElementById("ctl00_ContentPlaceHolder1_txt"+obj).className="";
//        document.getElementById('ctl00_ContentPlaceHolder1_txt'+obj).disabled="";
//        document.getElementById('lnk'+obj).innerHTML="";
//    }
//    

//    
// function chkContact()
//  {
//    var CompanyName="<%=this.txtCompanyName.ClientID %>";
//   if(document.getElementById(CompanyName).value=="")
//   {
//    alert("��Ŀ��λ���Ʋ���Ϊ��...");
//    txtshow("CompanyName");
//    document.getElementById(CompanyName).focus();
//    return false;
//  }
// 
//  var LinkMan="<%=this.txtLinkMan.ClientID %>";
//  if(document.getElementById(LinkMan).value=="")
//  {
//    alert("��ϵ�˲���Ϊ��...");
//    txtshow("LinkMan");
//    document.getElementById(LinkMan).focus();
//    return false;
//  }
// 
//  var Tel="<%=this.txtTel.ClientID %>";
//  var Mobile="<%=this.txtMobile.ClientID %>";
//  var TelStateCode="<%=this.txtTelStateCode.ClientID %>";
//  if(document.getElementById(Tel).value==""&&document.getElementById(Mobile).value=="")
//  {
//         alert("�绰������ֻ���������дһ��...");
//         txtshow("Tel");
//         document.getElementById(Tel).focus();
//         return false;
//  }
//  if(document.getElementById(Tel).value!="")
//  {
//      if(isNaN(document.getElementById(Tel).value))
//      {
//             alert("�绰�����ʽ����");
//             txtshow("Tel");
//             document.getElementById(Tel).focus();
//             return false;
//      }
//      if(document.getElementById(TelStateCode).value=="")
//      {
//        alert("���Ų���Ϊ��...");
//        txtshow("Tel");
//        document.getElementById(TelStateCode).focus();
//        return false;
//      }
//      else
//      {
//           var filter = /^[0-9]+$/;
//           if(!filter.test(document.getElementById(TelStateCode).value))
//           {
//             alert("���Ŵ���...");
//             document.getElementById(TelStateCode).focus();
//             return false;
//           }
//      }
//  } 
//  if(document.getElementById(Mobile).value!="")
//  {
//        if(isNaN(document.getElementById(Mobile).value)||document.getElementById(Mobile).value.length!=11)
//        {
//             alert("�ֻ�λ������ȷ...")
//             txtshow("Mobile");
//             document.getElementById(Mobile).focus();
//              return false;
//         }
//  }
//   var Email="<%=this.txtEmail.ClientID %>";
//  if(document.getElementById(Email).value=="")
//  {
//         alert("�����ʼ�����Ϊ��...");
//         txtshow("Email");
//    	  document.getElementById(Email).focus();
//	      return false;
//  }
//  else
//  {
//                var obj = document.getElementById(Email);
//    	        var str = obj.value;
//    	        var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
//    	        if(!filter.test(str))
//    	        {
//    	            alert("�����ʼ���ʽ����...");
//    	            txtshow("Email");
//    	            document.getElementById(Email).focus();
//	                return false;
//    	        }

//   }
//      var WebSite="<%=this.txtWebSite.ClientID %>";
//      if(document.getElementById(WebSite).value!="")
//      { 
//          var obj = document.getElementById(WebSite);
//    	  var str = obj.value; 
//    	  if(!IsURL(str))
//    	  {
//    	         alert("��ַ��ʽ����...");
//    	         document.getElementById(WebSite).focus();
//	             return false;
//    	  }
//      }
//  
// }
// function IsURL(str_url){ 
//  var strRegex = "^((https|http|ftp|rtsp|mms)?://)"  
//        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp��user@  
//        + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP��ʽ��URL- 199.194.52.184  
//        + "|" // ����IP��DOMAIN�������� 
//        + "([0-9a-z_!~*'()-]+\.)*" // ����- www.  
//        + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // ��������  
//        + "[a-z]{2,6})" // first level domain- .com or .museum  
//        + "(:[0-9]{1,4})?" // �˿�- :80  
//        + "((/?)|" // a slash isn't required if there is no file name  
//        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";  
//        var re=new RegExp(strRegex);  
//        if (re.test(str_url)){ 
//            return (true);  
//        }else{  
//            return (false);  
//        } 
//    }
//    //----------------------------END---------------------------------
  
    </script>

    <div id="step1" style="display: block;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 60px;
            text-align: center; line-height: 20px; margin: 15px 0;" class="f_14">
            <tr>
                <td width="130" class="strong">
                    ������Դֻ��<span class="f_red">2</span>����</td>
                <td width="125" style="background: url(../../img/member_bg1_on.gif) no-repeat;" class="f_red strong">
                    ��һ��<br />
                    ��д��Ŀ��Ϣ</td>
                <td width="50">
                    <img src="../../img/member_icon1.gif" alt="" /></td>
                <td width="125" style="background: url(../../img/member_bg1_off.gif) no-repeat;">
                    �ڶ���<br />
                    ȷ����ϵ��ʽ</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14 strong">
                    <asp:RadioButton ID="RadioButton1" GroupName="group1" Text="��Ȩ����" runat="server"
                        OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                    <asp:RadioButton ID="RadioButton2" GroupName="group1" Text="ծȨ����" Checked="true"
                        runat="server" /></td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">��Ŀ��ϸ����</span><span class="f_gray">�����»�����Ϣ��Ϊ�����</span></td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��Ŀ���⣺</strong></td>
                <td>
                    <input id="txtProjectName" style="width: 286px" runat="server"  onblur="repl(this);" maxlength="30" />
                    <span class="f_gray">������ÿ�����30��������</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>������ҵ��</strong></td>
                <td>
                    <span class="f_gray">
                        <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    </span>
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��������</strong></td>
                <td>
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span><strong>��Ŀ���������</strong></td>
                <td>
                    <asp:CheckBoxList ID="cblXmlxqk" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList><br />
                    <span class="f_gray">˵������Ŀ��ȱ���������ġ�ִ�պ�֤���������Ŀ�����нϴ�Ӱ��</span></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��ĿͶ���ܶ</strong></td>
                <td>
                    
                    <input id="txtCapitalTotal" type="text" onblur="repl(this);" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
                    �������<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCapitalTotal"
                        Display="Dynamic" ErrorMessage="��ĿͶ���ܶ��Ϊ�գ�" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                        ControlToValidate="txtCapitalTotal" ErrorMessage="����������,����2λС����" ValidationExpression="^[1-9]+(.[0-9]{1,2})?" Enabled="False"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>����</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblJqjy" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblJqjy"
                        Display="Dynamic" ErrorMessage="��ѡ�����" Enabled="False"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px; height: 40px;">
                    <span class="f_red">*</span> <strong>���ʶ���</strong></td>
                <td style="height: 40px">
                    <asp:CheckBoxList ID="cblTnObj" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��ҵ��չ�׶Σ�</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblQyfzjd" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rblQyfzjd"
                        Display="Dynamic" ErrorMessage="��ѡ����ҵ��չ�׶Σ�"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>Ҫ���ʽ�λ�����</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblYqzjdwqk" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rblYqzjdwqk"
                        Display="Dynamic" ErrorMessage="��ѡ��Ҫ���ʽ�λ�����"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>���ʼƻ�������������</strong></td>
                <td>
                    <textarea id="txtWarrant" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtWarrant"
                        Display="Dynamic" ErrorMessage="���ʼƻ���������������Ϊ�գ�"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��Ʒ�г������ʣ�</strong></td>
                <td>
                    <input id="tbCpsczzl" type="text" size="5" runat="server"   onblur="repl(this);" />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbCpsczzl"
                        Display="Dynamic" ErrorMessage="��Ʒ�г������ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbCpsczzl"
                        Display="Dynamic" ErrorMessage="��Ʒ�г������ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��Ʒ�г�������</strong></td>
                <td>
                    <input id="tbCpscyl" type="text" size="5" runat="server"   onblur="repl(this);" />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbCpscyl"
                        Display="Dynamic" ErrorMessage="��Ʒ�г���������Ϊ�գ�"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbCpscyl"
                        Display="Dynamic" ErrorMessage="��Ʒ�г������ķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>�ʲ���ծ�ʣ�</strong></td>
                <td style="line-height: 18px;">
                    <input id="tbZcfzl" type="text" size="5" runat="server"   onblur="repl(this);" />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbZcfzl"
                        Display="Dynamic" ErrorMessage="�ʲ���ծ�ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbZcfzl"
                        Display="Dynamic" ErrorMessage="�ʲ���ծ�ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator><br />
                    <span class="f_gray">�ʲ���ծ��=����ծ�ܶ�/�ʲ��ܶ*100�����ʲ���ծ�ʷ�ӳ�����ʲ����ж�������ͨ����ծ�����ʵģ�Ҳ���Ժ�����ҵ������ʱ����ծȨ������ĳ̶ȡ�</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <strong>�������ʣ�</strong></td>
                <td>
                    <input id="tbLdbl" type="text" size="5" runat="server"   onblur="repl(this);"  />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbLdbl"
                        Display="Dynamic" ErrorMessage="�������ʲ���Ϊ�գ�" Enabled="False"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbLdbl"
                        Display="Dynamic" ErrorMessage="�������ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator><br />
                    <span class="f_gray">&nbsp;�������ʣ������ʲ���������ծX100��������������ҵ�����ʲ��ڶ���ծ������ǰ�����Ա�Ϊ�ֽ����ڳ�����ծ��������</span></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>Ͷ�������ʣ�</strong></td>
                <td>
                    <input id="tbTzsyl" type="text" size="5" runat="server"   onblur="repl(this);" />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbTzsyl"
                        Display="Dynamic" ErrorMessage="Ͷ�������ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="tbTzsyl"
                        Display="Dynamic" ErrorMessage="Ͷ�������ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span><strong>���������ʣ�</strong></td>
                <td>
                    <input id="tbXslyl" type="text" size="5" runat="server"   onblur="repl(this);" />
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbXslyl"
                        Display="Dynamic" ErrorMessage="���������ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="tbXslyl"
                        Display="Dynamic" ErrorMessage="���������ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <strong>Ͷ�ʻر��ڣ�</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblXmtzfbzq" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rblXmtzfbzq"
                        Display="Dynamic" ErrorMessage="��ѡ��Ͷ�ʻر��ڣ�"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��Ŀ��Ч���ޣ�</strong></td>
                <td>
                    ����֮����
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rblXmyxqxx"
                        Display="Dynamic" ErrorMessage="��ѡ����Ŀ��Ч���ޣ�"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span> <strong>��ĿժҪ��</strong></td>
                <td>
                    <textarea id="tbXmzy" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tbXmzy"
                        Display="Dynamic" ErrorMessage="��ĿժҪ����Ϊ�գ�"></asp:RequiredFieldValidator><br />
                    <span class="f_gray">Ϊ����Ͷ�ʷ��Ĺ�ע�������Ŀ�ص����ݽ��м򵥶�Ҫ�������������������50��600�����ڣ�</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <span class="f_red">*</span><strong>��Ŀ��ϸ������</strong></td>
                <td>
                    <textarea id="tbXmqxms" rows="7" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">��Ŀ����Խ��ϸԽ������Ͷ�ʷ��˽�����Ŀ�ľ���������뾡���꾡���ƣ������������50��1000�����ڣ�</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" style="width: 145px">
                    <strong>��Ŀ�ؼ��֣�</strong></td>
                <td>
                    <input id="tbXmgjz1" type="text" size="12" runat="server"   onblur="repl(this);" maxlength="10" />
                    <input id="tbXmgjz2" type="text" size="12" runat="server"   onblur="repl(this);" maxlength="10" />
                    <input id="tbXmgjz3" type="text" size="12" runat="server"   onblur="repl(this);" maxlength="10" />
                    <span class="f_red"><a href="#">��ζ���ؼ��֣�</a></span><br />
                    <span class="f_gray">������صĹؼ�������������������ױ�Ǳ�ں������ҵ�</span></td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding: 25px 0 5px 0;">
            <tr>
                <td class="f_14">
                    <span class="f_red strong">�� ��Ŀ��ϸ����</span><span class="f_gray">�����Ƶ����Ͽ��Եõ�Ͷ�ʷ��������Σ�������������Ϣ����</span></td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="145" class="tdbg">
                    <strong>��λ��Ӫҵ���룺</strong></td>
                <td>
                    <input id="tbJkdwlyysy" type="text" size="15" runat="server"   onkeyup="value=value.replace(/[^\d]/g,'') "   onblur="repl(this);" />
                    ��Ԫ(�����)</td>
            </tr>
            <tr>
                <td width="145" class="tdbg">
                    <strong>��λ�꾻����</strong></td>
                <td>
                    <input id="tbJkdwljly" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') "    onblur="repl(this);" />
                    ��Ԫ(�����)</td>
            </tr>
            <tr>
                <td width="145" class="tdbg">
                    <strong>��λ���ʲ���</strong></td>
                <td>
                    <input id="tbJkdwzzc" type="text" size="15" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') "   onblur="repl(this);" />
                    ��Ԫ(�����)</td>
            </tr>
            <tr>
                <td width="145" class="tdbg">
                    <strong>��λ�ܸ�ծ��</strong></td>
                <td>
                    <input id="tbJkdwzfz" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') "    onblur="repl(this);" />
                    ��Ԫ(�����)</td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <span class="f_red">*</span><strong>��Ʒ������</strong></td>
                <td>
                    <textarea id="tbCpks" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">����Ҫ�ṩ��Щ��Ʒ����������Щ�ͻ����з�����ζ��ۡ�����1000�����ڣ�������30�֣���</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <span class="f_red">*</span><strong>�г�ǰ����</strong></td>
                <td>
                    <textarea id="tbScqj" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">��ǰ�г����ƻ�����Ŀ��������Ⱥ�������г���������г���չǱ����󡣽���1000�����ڣ�������30�֣���</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <span class="f_red">*</span><strong>����������</strong></td>
                <td>
                    <textarea id="tbJjfs" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">����״����������ռ����г��ݶSWOT���������ơ����ơ����ᡢ��в��������1000�����ڣ�������30�֣���</span>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <span class="f_red">*</span><strong>��ҵģʽ��</strong></td>
                <td>
                    <textarea id="tbSyms" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">�����г�����Ʒ�����ۡ�����������Դ�Լ�ӯ���ȷ�����ʲô��ʽʵ�֣����ĺ��ľ�������ʲô�� ��α�֤���ľ�����������1000�����ڣ�������30�֣���</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <span class="f_red">*</span><strong>�����Ŷӣ�</strong></td>
                <td>
                    <textarea id="tbGltd" rows="5" style="width: 80%;" runat="server"  onblur="repl(this);" ></textarea>
                    <br />
                    <span class="f_gray">�ŶӼܹ����߹���Ա�Ĵ�ҵ�����ȡ�����1000�����ڣ�������30�֣���</span></td>
            </tr>
            <tr>
                <td valign="top" class="tdbg" width="145px">
                    <strong>��Ŀ���ϸ�����</strong></td>
                <td>
                    <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
                    <span class="f_gray">�������ϴ���Ŀ������ļ�����Ӫҵִ�ա���Ŀ���ġ�֤��ȣ�</span></td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="text-align: center;">
            <tr>
                <td height="40">
                    <input type="checkbox" id="chkReadMe" checked="checked" />
                    �����Ķ�<span class="f_red"><a href="#">���ظ����й�����Ͷ��������Э�顷</a> </span>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <input id="Button2" type="button" value="��һ����ȷ����ϵ��ʽ" onclick="chkpost();" />
                </td>
            </tr>
        </table>
    </div>
    <!--########### �ڶ�����ȷ�����緽ʽ #########-->
    <div id="step2" style="display: none;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 60px;
            text-align: center; line-height: 20px; margin: 15px 0;" class="f_14">
            <tr>
                <td width="130" class="strong">
                    ������Դֻ��<span class="f_red">2</span>����</td>
                <td width="125" style="background: url(../../img/member_bg1_off.gif) no-repeat;">
                    ��һ��<br />
                    ��д��Ŀ��Ϣ</td>
                <td width="50">
                    <img src="../../img/member_icon1.gif" alt="" /></td>
                <td width="125" style="background: url(../../img/member_bg1_on.gif) no-repeat;" class="f_red strong">
                    �ڶ���<br />
                    ȷ����ϵ��ʽ</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="f_14 f_red strong" style="padding: 5px 10px;">
                    ��ϵ��ʽȷ��</td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="130" class="tdbg">
                    <span class="f_red">*</span> <strong>��Ŀ��λ���ƣ�</strong></td>
                <td>
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server"   onblur="repl(this);" maxlength="30" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCompanyName"
                        runat="server" ErrorMessage="��Ŀ��λ���Ʋ���Ϊ�գ�"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��ϵ�ˣ�</strong></td>
                <td>
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server"   onblur="repl(this);" maxlength="16" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLinkMan"
                        runat="server" ErrorMessage="��ϵ�˲���Ϊ�գ�"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>ְλ��</strong></td>
                <td>
                    <input id="txtCareer" class="show" type="text" style="width: 210px" runat="server"   onblur="repl(this);" maxlength="12" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��ϵ�绰��</strong></td>
                <td>
                    �̻�
                    <input id="telArea1" type="text" maxlength="3" size="3" value="+86" runat="server" />
                    <input id="txtTelStateCode" type="text" maxlength="4" size="5" runat="server" />
                    <input id="txtTel" type="text" size="15" maxlength="8" runat="server"  />
                    <input id="telFg" type="text" size="5"  maxlength="5" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelStateCode"
                        ErrorMessage="����������" ValidationExpression='[0-9]{3,4}' Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                        ErrorMessage="�绰��������" ValidationExpression='[0-9]{7,8}' Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="telFg"
                        ErrorMessage="�ֻ���������" ValidationExpression='[0-9]{1,5}' Display="Dynamic"></asp:RegularExpressionValidator>
                    <br />
                    �ֻ�
                    <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtMobile"
                        ErrorMessage="�ֻ������ʽ����" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                    <span class="f_gray">���̶��绰���ֻ�������дһ�</span></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>�������䣺</strong></td>
                <td>
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server"   onblur="repl(this);" maxlength="40" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="E-mail��ʽ����" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="�������䲻��Ϊ�գ�" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>��Ŀ��λ��ϸ��ַ��</strong></td>
                <td>
                    <input id="txtAddress" type="text" value="" style="width: 210px" runat="server"  onblur="repl(this);" maxlength="50"  /></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>��λ��ַ��</strong></td>
                <td>
                    <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" maxlength="40"   onblur="repl(this);" /><span class="f_gray">���磺http://www.topfo.com</span>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtWebSite"
                        ErrorMessage="��ַ��ʽ�磺http://www.topfo,com������!" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��֤�룺</strong>
                </td>
                <td>
                    <label>
                        <asp:TextBox ID="ImageCode" runat="server" Width="120px"></asp:TextBox>
                        <img id="validimg" src="../../ValidateNumber.aspx" onclick="this.src='../../ValidateNumber.aspx?temp=' + (new Date())"
                            alt="" />
                        <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">��һ��ͼƬ</a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="��֤�벻��Ϊ�գ�" ControlToValidate="ImageCode"></asp:RequiredFieldValidator></label></td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="height: 60px; text-align: center;">
            <tr>
                <td>
                    <input id="Button1" type="button" value="��һ��(�޸���Ŀ��Ϣ)" onclick="disp(2);" />
                    <asp:Button ID="btnIssueOK" runat="server" Text="ȷ�Ϸ���"   OnClientClick="DispLayer();" OnClick="btnIssueOK_Click" />
                </td>
            </tr>
        </table>
    </div>
    <!--###########  �ڶ�������  #########-->
    
    
     <div id="imgLoding" Style="position: absolute;
            display:none;
            background-color: #A9A9A9; 
            top: 0px; 
            bottom:0px;
            left: 0px; 
            width: 100%; 
            height: 100%; 
            filter: alpha(opacity=60);">
            <div class="content">
                <p>
                    ���������ύ,���Ժ�...</p>
                <img src="../../img/img-loading.gif" alt="Loading..." /></div>
        </div>
        
</asp:Content>
