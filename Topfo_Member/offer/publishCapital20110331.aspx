<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="publishCapital20110331.aspx.cs" Inherits="offer_publishCapital" Title="Untitled Page" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ZoneSelectControl2.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:1000px auto 0;text-align:center;padding-top:1000px;}
        .content p{line-height:30px;        }
        </style>
 <style type="text/css">.noteawoke{font-weight:normal;color:red;}</style>
 <link href="../../css/publish.css" rel="stylesheet" type="text/css" />
 <link href="../../css/publishCaptal.css" rel="stylesheet" type="text/css" />
 <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
 <link href="css/member.css"rel="stylesheet" type="text/css" />
 <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
 <link href="../../img/member.css" rel="stylesheet" type="text/css" />
 <script src="js/yanz.js"></script>
     <script type="text/javascript">
     
    function ValidErr()
   {
        var c="ctl00_ContentPlaceHolder1_";
        alert('��֤�����,���������룡');
        document.getElementById(c+"ImageCode").focus();
        document.getElementById(c+"ImageCode").select();
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
            var ProjectName="ctl00_ContentPlaceHolder1_txtCapitalName";
            if(trim(document.getElementById(ProjectName).value)=="")
            {
                alert("��Ŀ���ⲻ��Ϊ��...");
                document.getElementById(ProjectName).focus();
                return false;
            }
        //��ҵ
	   if(document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").options.length==0)
	   {     
	   
	         alert("��ѡ��������ҵ...");
	         document.getElementById("ctl00_ContentPlaceHolder1_SelectIndustryControl1_sltIndustryName_Select").focus();
	         return false;
	   }
        //����
	   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelect1_sltZone_Select").options.length==0)
	   {     
	   
	         alert("��ѡ����������������5��..");
	         document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelect1_sltZone_Select").focus();
	         return false;
	   }    
	         //�����
            if(!ChkRbl("<%=this.rblCurreny.ClientID %>","����Ŀ��Ͷ�ʽ��"))
            {
             document.getElementById("touzje").focus();  
                return false ;
            }
               
         //   ������Ч����
           if(!ChkCbl("<%=this.rdlValiditeTerm.ClientID %>","������Ч����"))
            {
              document.getElementById("ValiditeTerm").focus();  
                return false ;
            }
   
            //Ͷ��������ϸ˵��
            
                var ProjectName1="ctl00_ContentPlaceHolder1_txtCapitalIntent";
            if(trim(document.getElementById(ProjectName1).value)=="")
            {
                alert("Ͷ��������ϸ˵������Ϊ��...");
                document.getElementById(ProjectName1).focus();
                return false;
            }
              //Ͷ�ʷ�ʽ
             
            if(!ChkCbl("<%=this.chkLstCooperationDemand.ClientID %>","Ͷ�ʷ�ʽ"))
            {
              document.getElementById("spCooperationDemand").focus();  
                 return false;
            }
       
       if(document.getElementById("ctl00_ContentPlaceHolder1_txtGovName").value=="")
	    {
	       alert("�������Ʋ���Ϊ��..");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtGovName").focus();
	       return false;
	    }
         if(document.getElementById("ctl00_ContentPlaceHolder1_txtLinkMan").value=="")
	    {
	       alert("��ϵ�˲���Ϊ��..");
	       document.getElementById("ctl00_ContentPlaceHolder1_txtLinkMan").focus();
	       return false;
	    }
	    
	    
	    var telzone=document.getElementById(c+"txtTelZoneCode") ;
	   var telNumber=document.getElementById(c+"txtTelNumber");
	   var telMobile=document.getElementById(c+"txtMobile");
	    if(telNumber.value.length=="" && telMobile.value.length=="")
        {
            alert("�ֻ��͹̶��绰��������дһ��");
             document.getElementById(c+"txtMobile").focus();
            return false;
        }
        if(document.getElementById(c+"txtMobile").value.length!="")
        {
           var filtMobile = /^(13|15|18)[0-9]{9}$/;
            if(!filtMobile.test(trim(document.getElementById(c+"txtMobile").value)))
            {
                alert("����ȷ��д�ֻ�����");
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
                alert("��ַ��д����ȷ!");
			    document.getElementById(c+"txtWebSite").focus();
                return false;
             }
		}
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value=="")
        {
           alert("�������������");
           document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
           return false;
        } else  
        {
            var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
            if(!filtEmial.test(trim(document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value)))
            {
       	         alert("���������ʽ����ȷ������������");
       	         document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
       	         return false;
       	     }
        }
//           if(document.getElementById(c+"ImageCode").value=="")
//        {
//             alert("��������֤��");
//             document.getElementById(c+"ImageCode").focus();
//             return false;
//        }
          var inputCode = document.getElementById("validCode").value;   
       if(inputCode.length <=0)   
       {   
           alert("��������֤�룡"); 
            document.getElementById("validCode").focus();
       	         return false;  
       }   
       else if(inputCode.toUpperCase() != code )   
       {   
          alert("��֤���������");   
          createCode();//ˢ����֤��   
           document.getElementById("validCode").focus();
       	         return false;
       }   
      
      
            
//            document.getElementById("aspnetForm").onsubmit = FormSubmit;

               document.getElementById("imgLoding").style.display="";



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
    </script> 
    <div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">Ͷ��������Դ����</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>Ͷ��������⣺</strong></td>
    <td style="width:699px"> <asp:TextBox ID="txtCapitalName" runat="server" onchange="JavaScrpit:CheckCapitalName()" Height="20px" Width="266px"></asp:TextBox>
                    <span id="spCapitalName" >����ȷ��д���⣬30������</span>
      <span class="f_gray"></span></td>
  </tr>
  
 <!-- <tr>
    <td class="tdbg" width="140"><span class="f_red">*</span> <strong>��������</strong></td>
    <td style="width: 569px">
 <uc2:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
   </td>
  </tr>-->
  
  <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>��Ͷ����ҵ��</strong></td>
    <td>
       <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" /></td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>��Ͷ������</strong></td>
    <td> 
    <uc1:ZoneSelect id="ZoneSelect1" runat="server"></uc1:ZoneSelect>   
    </td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>��Ŀ��Ͷ�ʽ�</strong></td>
    <td>   
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        </asp:RadioButtonList><input name="ZoneId" type="text" id="touzje" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>Ͷ�ʷ�ʽ��</strong></td>
    <td>
                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" />
                            <input name="ZoneId" type="text" id="spCooperationDemand" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
                  
    </td>
  </tr>
   <tr>
    <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>������Ч���ޣ�</strong></td>
    <td>
     <asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
     </asp:RadioButtonList>
    <input name="ZoneId" type="text" id="ValiditeTerm" style="width:0; border-color:#FFFFFF;border:1px solid #FFFFFF" />
    </td>
  </tr>
  <!-- <tr>
   <td valign="top" class="tdbg" width="140"><span class="f_red">*</span> <strong>��Ŀ�а쵥λ��</strong></td>
   
    <td style="width: 569px">
    <asp:TextBox ID="txtProrganizers" runat="server"  Height="20px" Width="266px" onchange="javascript:checkSpors()"></asp:TextBox>
                    <span id="Span1"></span>
      </td>
  </tr>-->
  <tr>
  <td class="tdbg" style="width: 678px"><span class="f_red">*</span> <strong>Ͷ��������ϸ˵����</strong></td>
    <td >

                        <textarea id="txtCapitalIntent" runat="server" cols="50" rows="10" style="width: 558px; height: 204px"></textarea>
                        <span id="spCapitalIntent"></span><br />
                     
    </td> 
  </tr>
 
  

  <tr>
  <td class="tdbg" style="width: 678px"> <strong>�ϴ�ͼƬ��</strong></td>
    <td style="width: 569px" class="nonepad">
	   <uc4:FilesUploadControl ID="FilesUploadControl1" InfoType="Capital"
                        runat="server"  />
    </td>
  </tr>
    <tr>
       <td align="right" bgcolor="#f7f7f7" style="width: 678px">
        <span class="f_14 f_red strong">��ϵ��ʽȷ��</span> </td>
    </tr>
           <tr>
                <td align="right" bgcolor="#f7f7f7" style="width: 678px">
                    <span class="hong">*</span> <strong>Ͷ�ʻ������ƣ�</strong></td>
                <td width="638">
                            <asp:TextBox ID="txtGovName" onchange="checkGovName()" Width="246px" runat="server" />
                    <span id="SpGovName"></span>
                </td>
            </tr>
          
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="width: 678px">
                    <span class="hong">*</span> <strong>��ϵ�ˣ�</strong></td>
                <td width="638">
                            <asp:TextBox ID="txtLinkMan" onchange="checkLinkMan()" Width="246px" runat="server" />
                    <span id="splinkMan"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="width: 678px" >
                     <strong>�̶��绰��</strong></td>
                <td  valign="top">
                    <menu class="menulw">
                    <asp:TextBox ID="txtTelCountry" runat="server" size='4'  >+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size='8'  onkeyup="value=value.replace(/[^\d]/g,'') "  />
                    <asp:TextBox ID="txtTelNumber" runat="server" size='8'   onkeyup="value=value.replace(/[^\d]/g,'') "  />                    
                    <span class="f_gray">���磺+86-0755-89805588��</span>
                    <span id="spMobile"></span>
                    <span id="spMobile2"></span>                 
                </menu>
                    
                     
                </td>
                </tr>
                <tr>
               <td align="right" bgcolor="#f7f7f7" style="width:678px">
                    <span class="hong">*</span> <strong>�ֻ���</strong></td>
                
                <td width="638">
                 <asp:TextBox ID="txtMobile" Width="127px" runat="server"  onchange="CheckMobile()"/>
                 <span class="f_gray">���̶��绰���ֻ�������дһ�</span>
                <span id="spMobile1"></span>
                </td>
                
            </tr>
            
            <tr id="trswitchpublish" name="trswitchpublish">
                <td align="right" bgcolor="#f7f7f7" style="width: 678px; height: 26px;">
                     <span class="hong">*</span><strong>�������䣺</strong></td>
                <td width="638" style="height: 26px">
                    <asp:TextBox ID="txtEmail" runat="server" size='18'
                        Width="269px" onchange="CheckEmail()"/>
                    <span id="spEmail" class="hui">����д����õĵ�������</span>
                </td>
            </tr>
            <tr id="tr3" name="trswitchpublish3">
                <td align="right" bgcolor="#f7f7f7" style="width: 678px; height: 40px;">
                    <strong>Ͷ�ʻ�����ַ��</strong></td>
                <td width="638" style="height: 40px">
                    <asp:TextBox ID="txtAddress" runat="server" size='18' Width="269px" /></td>
            </tr>
             <tr>
        <td align="right">
                    <strong>��վ��</strong></td>
                <td>
                    <asp:TextBox ID="txtWebSite" runat="server" size='18' Width="269px" /><span class="f_gray">���磺http://www.topfo.com</span>&nbsp;
                    </td>
        
    </tr>
      <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��֤�룺</strong>
                </td>
                <td>
                <input  type="text"   id="validCode" /> 
                   <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />
                    <%--<label>
              
                       <asp:TextBox ID="ImageCode"   runat="server" Width="120px"></asp:TextBox>
                        <img id="validimg" src="../../ValidateNumber.aspx" onclick="this.src='../../ValidateNumber.aspx?temp=' + (new Date())"
                            alt="" />
                        <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">��һ��ͼƬ</a>
                        </label>--%></td>
            </tr>
        
</table>
<table width="100%" cellspacing="0" style="text-align:center;">
  <tr>
    <td height="40"> 
                <asp:CheckBox ID="ckbCheck"  Checked="true" runat="server" />
                <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" style="color:Blue;">�����Ķ���ͬ���ظ����й�����Ͷ��������</a>
                <span id="spCheck"></span></td>
  </tr>
  <tr>
    <td style="height: 32px">
   
        <asp:Button ID="IbtnSubmit" runat="server" Text="ȷ��"  OnClientClick="return chkpost();" OnClick="IbtnSubmit_Click" />
      </td>
  </tr>
</table>
    </div>
   <div id="imgLoding" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2000px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    ���������ύ,���Ժ�...</p>
                <img src="../../img/img-loading.gif" alt="Loading" />
                </div>
        </div>
           <script language="javascript">  createCode();</script>
</asp:Content>
