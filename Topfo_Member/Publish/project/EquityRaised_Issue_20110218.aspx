<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EquityRaised_Issue_20110218.aspx.cs" Inherits="Publish_project_EquityRaised_Issue" Title="Untitled Page" %>

<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    
    
<script language="javascript" type="text/javascript">
   
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
            var obj=document.getElementById(c+"txtCapitalTotal");
            if(trim(trim(obj.value))=="")
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
            
            
            
            //���ʽ�� rbtnCapital
            if(!ChkRbl("<%=this.rbtnCapital.ClientID %>","���ʽ��"))
            {
                return ;
            }
            
            //���ʶ�ռ�ɷݱ���
            kj="ctl00_ContentPlaceHolder1_txtSellStockShare";
            zt="���ʶ�ռ�ɷݱ���";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //���ʶ���cblTnObj
            if(!ChkCbl("<%=this.cblTnObj.ClientID %>","���ʶ���"))
            {
                return;
            }
            
            //�˳���ʽ chkReturn
            if(!ChkCbl("<%=this.chkReturn.ClientID %>","�˳���ʽ"))
            {
                return ;
            }
            
            //��ҵ��չ�׶�rblQyfzjd
            if(!ChkRbl("<%=this.rblQyfzjd.ClientID %>","��ҵ��չ�׶�"))
            {
                return;
            }
            
            // Ҫ���ʽ�λ��� rblYqzjdwqk
            if(!ChkRbl("<%=this.rblYqzjdwqk.ClientID %>","Ҫ���ʽ�λ���"))
            {
                return ;
            }
            
            //�г�ռ����(�ݶ�) tbSczylfy
            kj="ctl00_ContentPlaceHolder1_tbSczylfy";
            zt="�г�ռ����(�ݶ�)"
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //��ҵ�г������� tbYysczzl
            kj="ctl00_ContentPlaceHolder1_tbYysczzl";
            zt="��ҵ�г�������";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //�ʲ���ծ�� tbZcfzl
            kj="ctl00_ContentPlaceHolder1_tbZcfzl";
            zt="�ʲ���ծ��";
            if(!ChkData(kj,zt))
            {
                return ;
            }
            
            //�ݲ���
//            //��ĿͶ�ʻر����� rblXmtzfbzq
//            if(!ChkRbl("<%=this.rblXmtzfbzq.ClientID %>","��ĿͶ�ʻر�����"))
//            {
//                return ;
//            }
            
            //��Ŀ��Ч���� rblXmyxqxx
            if(!ChkRbl("<%=this.rblXmyxqxx.ClientID %>","��Ŀ��Ч����"))
            {
                return ;
            }
            
            //��ĿժҪ
            var ProIntro="ctl00_ContentPlaceHolder1_txtProIntro";
            obj=document.getElementById(ProIntro);
            if(!checkByteLength(obj.value,50,1200))
            {
                alert("��д��ĿժҪ.����600�����ڣ�������50�֣�");
                document.getElementById(ProIntro).focus();
                document.getElementById(ProIntro).select();
                return ;
            }
            
            //��Ŀ��ϸ����
            kj="ctl00_ContentPlaceHolder1_txtXmqxms";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,50,1000))
            {
                alert("��Ŀ��ϸ�������ó���1000������(������50��),���飡");
                obj.focus();
                obj.select();
                return ;
            }
            
            
            
            //��Ʒ����
            var displ="�������������30��1000�����ڣ���";
            kj="ctl00_ContentPlaceHolder1_txtProjectAbout";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,30,2000))
            {
                alert("��Ʒ�������ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //�г�ǰ��
            kj="ctl00_ContentPlaceHolder1_txtMarketAbout";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,30,2000))
            {
                alert("�г�ǰ�����ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //��������
            kj="ctl00_ContentPlaceHolder1_txtCompetitioAbout";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,30,2000))
            {
                alert("�����������ó���1000�����֣����飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //��ҵģʽ
            kj="ctl00_ContentPlaceHolder1_txtBussinessModeAbout";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,30,2000))
            {
                alert("��ҵģʽ���ó���1000������,���飡"+displ);
                obj.focus();
                obj.select();
                return ;
            }
            
            //�����Ŷ�
            kj="ctl00_ContentPlaceHolder1_txtManageTeamAbout";
            obj=document.getElementById(kj);
            if(!checkByteLength(obj.value,30,2000))
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
  
   </script>
   
   
   

<div id="step1" style="display:block;">
<table width="100%"  border="0" cellpadding="0" cellspacing="0" style=" height:60px; text-align:center; line-height:20px; margin:15px 0;" class="f_14">
  <tr>
    <td width="130" class="strong">������Դֻ��<span class="f_red">2</span>����</td>
    <td width="125" style="background:url(../../img/member_bg1_on.gif) no-repeat;" class="f_red strong">��һ��<br />
      ��д��Ŀ��Ϣ</td>
    <td width="50"><img src="../../img/member_icon1.gif"  alt=""  /></td>
    <td width="125" style="background:url(../../img/member_bg1_off.gif) no-repeat;">�ڶ���<br />
      ȷ����ϵ��ʽ</td>
    <td>&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding:5px 10px; height: 30px;" class="f_14 strong">
      <asp:RadioButton ID="RadioButton1" GroupName="group1" Text="��Ȩ����" Checked="true" runat="server" AutoPostBack="True" />
      <asp:RadioButton ID="RadioButton2" GroupName="group1" Text="ծȨ����" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
      </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="padding:5px 10px;" class="f_14"><span class="f_red strong">��Ŀ��ϸ����</span><span class="f_gray">�����»�����Ϣ��Ϊ�����</span></td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td width="145" class="tdbg"><span class="f_red">*</span> <strong>��Ŀ���⣺</strong></td>
    <td><input id="txtProjectName" style="width: 286px" size="15" runat="server" maxlength="30"  onblur="repl(this);"/>
      <span class="f_gray">������ÿ�����30��������</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>������ҵ��</strong></td>
    <td>
      <span class="f_gray">
          <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
          </span></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��������</strong></td>
    <td>
        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
    </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��Ŀ���������</strong></td>
    <td>
    <asp:CheckBoxList ID="cblXmlxqk" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList><br />
    <span class="f_gray">˵������Ŀ��ȱ���������ġ�ִ�պ�֤���������Ŀ�����нϴ�Ӱ�졣</span></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��ĿͶ���ܶ</strong></td>
    <td>
        <input id="txtCapitalTotal" type="text"  runat="server" maxlength="15"  width="75px"  onblur="repl(this);" onkeyup="value=value.replace(/[^\d]/g,'') "  />
                            �������<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="��ĿͶ���ܶ��Ϊ�գ�" ControlToValidate="txtCapitalTotal" Display="Dynamic" Enabled="False"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCapitalTotal"
            Display="Dynamic" ErrorMessage="����������,������λС����" ValidationExpression="^[1-9]+(.[0-9]{1,2})?" Enabled="False"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>���ʽ�</strong></td>
    <td>
	<asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rbtnCapital"
            Display="Dynamic" ErrorMessage="��ѡ�����ʽ�"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>���ʶ�ռ�ɷݱ���</strong><strong>��</strong></td>
    <td>
        <input id="txtSellStockShare" type="text" runat="server"  width="75px"  onblur="repl(this);" />
                            %<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
        ControlToValidate="txtSellStockShare" Display="Dynamic" ErrorMessage="���ʶ�ռ�ɷݱ��ز���Ϊ�գ�"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSellStockShare"
            Display="Dynamic" ErrorMessage="���ʶ�ռ�ɷݱ��صķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>���ʶ���</strong></td>
    <td>
        <asp:CheckBoxList ID="cblTnObj" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
        </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>�˳���ʽ��</strong></td>
    <td><asp:CheckBoxList ID="chkReturn" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList>
        </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��ҵ��չ�׶Σ�</strong></td>
    <td>
        <asp:RadioButtonList ID="rblQyfzjd" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rblQyfzjd"
            Display="Dynamic" ErrorMessage="��ѡ����ҵ��չ�׶Σ�"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>Ҫ���ʽ�λ�����</strong></td>
    <td><asp:RadioButtonList ID="rblYqzjdwqk" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rblYqzjdwqk"
            Display="Dynamic" ErrorMessage="��ѡ��Ҫ���ʽ�λ�����"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>�г�ռ����(�ݶ�)��</strong></td>
    <td>
        <input id="tbSczylfy" type="text"    maxlength="5" runat="server" onblur="repl(this);"/>
	%<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbSczylfy"
            Display="Dynamic" ErrorMessage="�г�ռ���ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbSczylfy"
            Display="Dynamic" ErrorMessage="�г�ռ���ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��ҵ�г������ʣ�</strong></td>
    <td>
        <input id="tbYysczzl" type="text" runat="server" maxlength="5"  onblur="repl(this);"/>
	%<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbYysczzl"
            Display="Dynamic" ErrorMessage="��ҵ�г������ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbYysczzl"
            Display="Dynamic" ErrorMessage="��ҵ�г������ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>�ʲ���ծ�ʣ�</strong></td>
    <td style="line-height:18px;">
        <input id="tbZcfzl" type="text"  runat="server" maxlength="5"  onblur="repl(this);"/>
	%<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbZcfzl"
            Display="Dynamic" ErrorMessage="�ʲ���ծ�ʲ���Ϊ�գ�"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbZcfzl"
            Display="Dynamic" ErrorMessage="�ʲ���ծ�ʵķ�Χ0��100�������룡" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"> <strong>��ĿͶ�ʻر����ڣ�</strong></td>
    <td>
        <asp:RadioButtonList ID="rblXmtzfbzq" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="rblXmtzfbzq"
            Display="Dynamic" ErrorMessage="��ѡ����ĿͶ�ʻر����ڣ�" Enabled="False"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��Ŀ��Ч���ޣ�</strong></td>
    <td>����֮����
        <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="rblXmyxqxx"
            Display="Dynamic" ErrorMessage="��ѡ����Ŀ��Ч���ޣ�"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��ĿժҪ��</strong></td>
    <td><textarea id="txtProIntro" runat="server" cols="50" style="width: 558px; height: 153px" onblur="repl(this);" ></textarea><span
                                id="spProIntro"></span>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtProIntro"
            Display="Dynamic" ErrorMessage="��ĿժҪ����Ϊ�գ�"></asp:RequiredFieldValidator><br />
      <span class="f_gray">Ϊ����Ͷ�ʷ��Ĺ�ע�������Ŀ�ص����ݽ��м򵥡�����������������600�����ڣ�������50�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��Ŀ��ϸ������</strong></td>
    <td><textarea id="txtXmqxms" runat="server" cols="50" style="width: 558px; height: 149px" onblur="repl(this);"></textarea>
        <br />
    <span class="f_gray">��Ŀ����Խ��ϸԽ������Ͷ�ʷ��˽�����Ŀ�ľ���������뾡���꾡���ƣ�����1000�����ڣ�������50�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>��Ŀ�ؼ��֣�</strong></td>
    <td>
    <input id="Xmgjz1" type="text" size="12" runat="server" maxlength="10" />
    <input id="Xmgjz2" type="text" size="12" runat="server" maxlength="10" />
    <input id="Xmgjz3" type="text" size="12" runat="server" maxlength="10" />
    <span class="f_red"><a href="#">��ζ���ؼ��֣�</a></span><br />
    <span class="f_gray">������صĹؼ�������������������ױ�Ǳ�ں������ҵ�</span></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding:25px 0 5px 0;">
  <tr>
    <td class="f_14"><span class="f_red strong">�� ��Ŀ��ϸ����</span><span class="f_gray">�����Ƶ����Ͽ��Եõ�Ͷ�ʷ��������Σ�������������Ϣ����</span></td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td width="145" class="tdbg"><strong>��λ��Ӫҵ���룺</strong></td>
    <td><input id="tbDwlyysy" type="text" size="15" runat="server" onkeyup="value=value.replace(/[^\d]/g,'') " />
    ��Ԫ(�����)</td>
  </tr>
  <tr>
    <td class="tdbg"><strong>��λ�꾻����</strong></td>
    <td><input id="tbDwljly" type="text" size="15" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
    ��Ԫ(�����)</td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><strong>��λ���ʲ���</strong></td>
    <td style="height: 40px"><input id="tbDwzzc" type="text" size="15" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
    ��Ԫ(�����)</td>
  </tr>
  <tr>
    <td class="tdbg"><strong>��λ�ܸ�ծ��</strong></td>
    <td><input id="tbDwzfz" type="text" size="15" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " />
    ��Ԫ(�����)</td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��Ʒ������</strong></td>
    <td><textarea id="txtProjectAbout" style="width:80%" rows="5" cols="50" runat="server" onblur="repl(this);"></textarea>
      <br />
      <span class="f_gray">����Ҫ�ṩ��Щ��Ʒ����������Щ�ͻ����з�����ζ��ۡ�����1000�����ڣ�������30�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>�г�ǰ����</strong></td>
    <td><textarea id="txtMarketAbout" cols="50"  rows="5" style="width:80%" runat="server" onblur="repl(this);"></textarea>
    <br />
    <span class="f_gray">��ǰ�г����ƻ�����Ŀ��������Ⱥ�������г���������г���չǱ����󡣽���1000�����ڣ�������30�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>����������</strong></td>
    <td><textarea id="txtCompetitioAbout" cols="50" name="textarea2" rows="5" style="width:80%" runat="server" onblur="repl(this);"></textarea>
    <br />
    <span class="f_gray">����״����������ռ����г��ݶSWOT���������ơ����ơ����ᡢ��в��������1000�����ڣ�������30�֣���</span> </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��ҵģʽ��</strong></td>
    <td><textarea id="txtBussinessModeAbout" cols="50" name="textarea2" rows="5" style="width:80%" runat="server" onblur="repl(this);"></textarea>
    <br />
    <span class="f_gray">�����г�����Ʒ�����ۡ�����������Դ�Լ�ӯ���ȷ�����ʲô��ʽʵ�֣����ĺ��ľ�������ʲô�� ��α�֤���ľ�����������1000�����ڣ�������30�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>�����Ŷӣ�</strong></td>
    <td><textarea id="txtManageTeamAbout" cols="50"  rows="5" style="width:80%" runat="server" onblur="repl(this);"></textarea>
    <br />
    <span class="f_gray">�ŶӼܹ����߹���Ա�Ĵ�ҵ�����ȡ�����1000�����ڣ�������30�֣���</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>��Ŀ���ϸ�����</strong></td>
    <td>
        <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
    </td>
       <span class="f_gray">
        �������ϴ���Ŀ������ļ�����Ӫҵִ�ա���Ŀ���ġ�֤��ȣ�</span>
  </tr>
</table>
<table width="100%" cellspacing="0" style="text-align:center;">
  <tr>
    <td style="height: 40px">
    <input type="checkbox" id="chkReadMe"  checked="checked" />
    �����Ķ�<span class="f_red"><a href="#">���ظ����й�����Ͷ��������Э�顷</a></span></td>
  </tr>
  <tr>
    <td>
        <input id="btnNext"  type="button" value="��һ����ȷ����ϵ��ʽ" onclick="chkpost();" />
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
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server" maxlength="30"  onblur="repl(this);" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtCompanyName"
                        runat="server" ErrorMessage="��Ŀ��λ���Ʋ���Ϊ�գ�"  Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��ϵ�ˣ�</strong></td>
                <td>
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server" maxlength="16"  onblur="repl(this);"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLinkMan"
                        runat="server" ErrorMessage="��ϵ�˲���Ϊ�գ�"  Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>ְλ��</strong></td>
                <td>
                    <input id="txtCareer" class="show" type="text" style="width: 210px" runat="server" maxlength="12"   onblur="repl(this);" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>��ϵ�绰��</strong></td>
                <td>
                    �̻�
                    <input id="telArea1" type="text" size="3" value="+86" runat="server" />
                    <input id="txtTelStateCode" maxlength="4" type="text" size="5" runat="server" />
                    <input id="txtTel" type="text" maxlength="8" size="15" runat="server"  />
                    <input id="telFg" type="text" maxlength="5" size="5" runat="server" />
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
                        ErrorMessage="�ֻ������ʽ����" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"  Display="Dynamic"></asp:RegularExpressionValidator>
                    <span class="f_gray">���̶��绰���ֻ�������дһ�</span></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>�������䣺</strong></td>
                <td>
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server" maxlength="40"   onblur="repl(this);" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="E-mail��ʽ����" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="�������䲻��Ϊ�գ�" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>��Ŀ��λ��ϸ��ַ��</strong></td>
                <td>
                    <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" maxlength="50"  onblur="repl(this);"  /></td>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="��֤�벻��Ϊ�գ�" ControlToValidate="ImageCode"  Display="Dynamic"></asp:RequiredFieldValidator></label></td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="height: 60px; text-align: center;">
            <tr>
                <td>
                    <input id="Button1" type="button" value="��һ��(�޸���Ŀ��Ϣ)" onclick="disp(2);" />
                    <asp:Button ID="btnIssueOK" runat="server" Text="ȷ�Ϸ���"  OnClientClick="DispLayer();" OnClick="btnIssueOK_Click" />
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

