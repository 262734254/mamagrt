<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EnterpriseRegister.aspx.cs" Inherits="Enterprise_Register" %>

<%@ Register Src="Control/ImageUploadControl.ascx" TagName="ImageUploadControl" TagPrefix="uc1" %>
<%@ Register Src="Control/OrgContactControl.ascx" TagName="OrgContactControl" TagPrefix="uc5" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:1200px;}
        .content p{line-height:30px;        }
        
    </style>  
<link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript" src="/Controls/DatePicker/WdatePicker.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
    {
        document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
    }
    function chkPost()
    { 
      
       if(document.getElementById("ctl00_ContentPlaceHolder1_tbEnterpriseName").value=="")
		{
			alert("���̻������Ʋ���Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbEnterpriseName").focus();
			return false;
		}
		
		if(document.getElementById("ctl00_ContentPlaceHolder1_tbRegisterDate").value=="")
		{
			alert("ע��ʱ�䲻��Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbRegisterDate").focus();
			return false;
		}
			var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbRegCapital").value;
		if(obj =="")
		{
		alert("ssssssssssssssssssssss!");
		    alert("ע���ʱ�����Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbRegCapital").focus();
			return false;
		}

		if(document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").value=="")
		{
			alert("��˾���ܲ���Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").focus();
			return false;
		}
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").value;
		if( obj.length<50 || obj.length>2000)
		{
		    alert("�밴Ҫ�����빫˾�������ݳ���(50-2000)!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout").focus();
			return false;
		}
		if(document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").value=="")
		{
			alert("�ҵ���������Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").focus();
			return false;
		}
		document.getElementById("imgLoding").style.display = "block";
    }
   
    </script>
<div class="mainconbox">
        <div class="contant_l">
            <div class="titled">
                <div class="left">
                    <h3 class="f14_b2">
                        �Ǽǹ�˾��Ϣ</h3>
              </div>
                <div class="right">
                    <span>
                        <img src="../images/Company_Manage/biao_01.gif" align="absmiddle" /> </span><span><a href="http://www.topfo.com/help/companyregister.shtml" target="_blank" class="lanlink">��˾�Ǽ�ָ��</a></span></div>
                <div class="clear">
                </div>
          </div>
            <div class="lightc pad_1 allxian">
                <h3 class="cu cheng font14">
                    ��Ҫ��ʾ</h3>
                <div>
                    ���������Ĺ�˾��ȷ����ʵ��Ч�����ڷ��������Ϣ�������κ����Σ��ɷ��������ге���<br />
                    ���Ǽ���ʵ����ϸ�Ĺ�˾��Ϣ���������û��Ͽɡ�</div>
            </div>
            <div >
			 <div class="blank0">        </div>
                �� <span class="hong">* </span>��Ϊ������</div>
				  <div class='dottedlline'>  </div>
        <div class="blank6">        </div>
            <h3 class="infozi">
                ��˾��������</h3>
            <div class="widthTable">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tabbiank">
                    <tr>
                        <td width="125" align="right" class="ltitles" >
                          <span class="hong">*</span> <strong>��˾���ƣ�</strong></td>
                        <td>
                            <div>
                                <asp:TextBox ID="tbEnterpriseName" runat="server" Width="315px">                                </asp:TextBox>&nbsp;
                                <span class="hui"> ��������������д�ڹ��̾�ע��Ĺ�˾ȫ��<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    runat="server" ControlToValidate="tbEnterpriseName" ErrorMessage="��˾���Ʋ���Ϊ��"></asp:RequiredFieldValidator></span></div>                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" >
                          <span class="hong">*</span><strong> ��ҵ���ʣ�</strong></td>
                        <td>
                            <asp:DropDownList ID="ddManageType" runat="server" Width="107px">
                                <asp:ListItem Value="1001">˽Ӫ������ҵ</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" style="height: 24px" >
                          <span class="hong">* </span><strong>ע��ʱ�䣺</strong></td>
                        <td style="height: 24px">
                            <asp:TextBox ID="tbRegisterDate" runat="server" Width="162px" onfocus="new WdatePicker(this,null,false,'whyGreen')"></asp:TextBox><a href="" class="blueline_2"></a>
                            <asp:HyperLink ID="hlStartCal" runat="server" Visible="False">�鿴����</asp:HyperLink>&nbsp;
                            <asp:RequiredFieldValidator ID="reqRegisterDate" runat="server" ControlToValidate="tbRegisterDate"
                                ErrorMessage="ע��ʱ�䲻��Ϊ��">                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" >
                          <span class="hong"> *</span><strong> ע���ַ��</strong></td>
                        <td>
                            <uc4:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" style="height: 24px" >
                          <span class="hong">*</span> <strong>ע���ʱ���</strong></td>
                        <td style="height: 24px" ><asp:DropDownList ID="ddlCapitalCurrency" runat="server" Width="76px">
                                <asp:ListItem Selected="True" Value="�����">�����</asp:ListItem>
                                <asp:ListItem Value="�۱�">�۱�</asp:ListItem>
                                <asp:ListItem Value="��Ԫ">��Ԫ</asp:ListItem>
                            </asp:DropDownList><asp:TextBox ID="tbRegCapital" runat="server" Width="89px"></asp:TextBox>
                            ��
                            <asp:RequiredFieldValidator ID="reqCurrency" runat="server" ControlToValidate="tbRegCapital"
                                ErrorMessage="ע���ʱ�����Ϊ��">                            </asp:RequiredFieldValidator></td>
                    </tr>
                    <tr id="behide">
                        <td align="right" valign="top" class="ltitles" >
                          <span class="hong">* </span><strong>��Ӫ��ҵ��</strong></td>
                        <td width="610">
                            <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server"></uc3:SelectIndustryControl>
                      </td>
                    </tr>
                    <tr>
                        <td align="right" class="ltitles" ><strong>
                          ��Ӫ��Ʒ�����</strong></td>
                        <td>
                            <div>
                                <asp:TextBox ID="tbMainProduct1" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct2" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct3" runat="server" Width="58px">                                </asp:TextBox>
                                <asp:TextBox ID="tbMainProduct4" runat="server" Width="58px">                                </asp:TextBox></div>  
                                                       <div class="hui">
                                ÿ������1�ֲ�Ʒ���������,����10��������,�磺���ز�</div>                       </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="ltitles" >
                          <span class="hong">*</span> <strong>��˾���ܣ�</strong><br />
                          ��50��2000�֣�<br />

                      (������ʾ��</td>
                        <td >
                            <div>
                                <asp:TextBox ID="tbComAbout" runat="server" Height="300px" TextMode="MultiLine"
                                    onkeyup="ShowFontCount(this);" Width="500px"></asp:TextBox>
                                &nbsp;
                                <br />
                                <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbComAbout"
                                    ErrorMessage="��˾���ܲ���Ϊ��" ></asp:RequiredFieldValidator>
                          </div>  <div class="hui">
                                �������Ľ��ܹ�˾��չ��ʷ���ʲ�״������Ӫҵ��Ʒ�Ʒ�������ƣ�������ݺܼ򵥣������޷�ͨ�����<br />
                                ��ϵ��ʽ���绰�����桢�ֻ�����������ȣ�������һ����д���˴��ظ���д���޷�ͨ�����                            </div>                       </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" class="ltitles" ><strong>
                          ͼƬ�ϴ���</strong></td>
                        <td class="nonepad" style="width: 585px; height: 18px;">
                            <div class="hui">
                                <uc1:ImageUploadControl ID="ImageUploadControl1" runat="server" InfoType="EnterpriseRegister" />
                                &nbsp;</div>                        </td>
                    </tr>
              </table>
            </div>
			<div class="blank6"></div>
            <h3 class="infozi">
                ��ϵ��ʽ��</h3>
            <div class="widthTable">
           <uc5:OrgContactControl ID="OrgContactControl1" runat="server" width="100%" />
            </div>
			<div class="blank6"></div>
            <h3 class="infozi">
                �������������ҵ�չ��:</h3>
            <div class="viewbox lightc cshibiank">
            �ҵ�չ���������Ƴ���һ�����·��񣬷����û�ȫ��չʾ�Լ��Ĺ�˾/��������ú������������Ρ� <a href="http://www.topfo.com/help/setup.shtml" target="_blank">�˽����</a></div>
			<div class="blank0">
        </div>
            <div >
                <span class="hong">*</span> <b>�ҵ�������<asp:TextBox ID="tbExhibitionHall" runat="server" Width="58px"></asp:TextBox>
                </b><b>.co.topfo.com
                </b><span>ֻ����������������˾���ܲ�������չʾ!
                    <input id="Hidden1" type="hidden" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                  </span><div id="MessageDiv">
                    </div>
            </div>
            <div class="mbbuttom">
             <p>   <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" >����Ķ��й�����Ͷ������������</a>
             <p>
          <asp:ImageButton ID="buSend" runat="server" ImageUrl="../images/Company_Manage/arr_06.gif"
                    OnClick="buSend_Click" OnClientClick="return chkPost(); "   /></div>
        </div>
		
    </div>
 <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    ���������ύ,���Ժ�...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>
    <script type="text/javascript">  
function ShowFontCount(theControl)
{
	var Descript=document.getElementById("ctl00_ContentPlaceHolder1_tbComAbout");	
    var msg=document.getElementById("ctl00_ContentPlaceHolder1_lbMessage");
    var len=theControl.value.length;
    if( Descript != null )
    {
         msg.innerHTML = "��˾����������"+len;       
	}
}	
function CheckDomain(domain,loginName)
{	
    if(domain!="")
    {
        AjaxMethod.CheckDomain(domain,loginName,showMessage);	
    }
}

function showMessage(res)
{
    var ln = document.getElementById("ctl00_ContentPlaceHolder1_Label1");			
    var hid=document.getElementById("ctl00_ContentPlaceHolder1_Hidden1");//ctl00_ContentPlaceHolder1_Hidden1
    hid.value=res.value;
    ln.innerHTML ="<font color='red'>"+res.value+"</font>";
    
   			
}
    </script>

</asp:Content>
