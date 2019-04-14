<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="GovernmentRegister.aspx.cs"
    Inherits="Register_GovernmentRegister" %>    
<%@ Register Src="Control/ImageUploadControl.ascx" TagName="ImageUploadControl" TagPrefix="uc4" %>
<%@ Register Src="Control/OrgContactControl.ascx" TagName="OrgContactControl" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:800px;}
        .content p{line-height:30px;        }
        
    </style>  
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
  <script src="../js/jquery.js"type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function $id(obj)
    {
        document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
    }
    function chkPost()
    { 

  

       if(document.getElementById("ctl00_ContentPlaceHolder1_tbGovernmentName").value=="")
		{
			alert("���̻������Ʋ���Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbGovernmentName").focus();
			return false;
		}
		
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout").value;
		
		if( obj.length<50  || obj.length==0)
		{
		    alert("���̻���������д����ȷ��50��������!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout").focus();
			return false;
		}		
		
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").value;
		if(obj.length<0 ||obj =="")
		{
		    alert("��������Ϊ��!");
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
                       
                            �Ǽ��������̻���                    </div>
                    <div class="right">
                       </div>
                    <div class="clear">
                    </div>
              </div>
                <div class="suggestboxs lightc allxian">
                    <h3 class="cu cheng font14">
                        ��Ҫ��ʾ</h3>
                    <div>
                        �������������̻�����ȷ����ʵ��Ч�����ڷ��������Ϣ�������κ����Σ��ɷ��������ге���<br>
                        ��������ϸ���̻�����Ϣ��������Ŀ��������Ͷ�ʷ��Ͽ�!</div>
              </div>
				<div class="blank0"></div>
                <div > ��<span class="hong">*</span>��Ϊ������</div>
               <div class="infozi">
                    ���̻�����������</div>
                <div class="widthTable">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tabbiank">
                        <tr>
                            <td width="20%" align="right" class="ltitles">
                                <span class="hong">*</span> <strong>���̻������ƣ�</strong></td>
                            <td width="80%"><asp:TextBox ID="tbGovernmentName" runat="server" Width="306px"></asp:TextBox>  <asp:RequiredFieldValidator
                                        ID="reqEnterpriseName" runat="server" ControlToValidate="tbGovernmentName" ErrorMessage="���̻������Ʋ���Ϊ��"></asp:RequiredFieldValidator>
                        </tr>
                        <tr>
                            <td align="right" class="ltitles">
                                <span class="hong">* </span><strong>�������壺</strong></td>
                            <td>
                                <asp:DropDownList ID="ddlSubjectType" runat="server" Width="157px">
                                    <asp:ListItem Value="1001">���Ҿ��ÿ�����</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ltitles">
                                <span class="hong">* </span><strong>��������</strong></td>
                            <td>
                                <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="ltitles">
                                <span class="hong">* </span><span class="blue13_b"><strong>���̻������ܣ�</strong></span><br>
                          (50-2000��)</td>
                            <td>
                               
                                <div><asp:TextBox ID="tbGovAbout" runat="server" Height="200px" TextMode="MultiLine"
                                        onkeyup="ShowFontCount(this);" Width="441px"></asp:TextBox> 
                                    <br />
                                  <asp:RequiredFieldValidator ID="reqDescript" runat="server" ControlToValidate="tbGovAbout"
                                        ErrorMessage="���̻�������Ϊ��"></asp:RequiredFieldValidator><asp:Label ID="lbMessage" runat="server"
                                            ForeColor="Red"></asp:Label></div>
											 <div class="hui">
                                    �������Ľ������̻�����������ݣ�������ݹ��ڼ򵥣��п����޷�ͨ����ˡ�<br />

��ϵ��ʽ���绰�����桢�ֻ�����������ȣ�������һ����д���˴��ظ���д���޷�ͨ����ˡ� 

                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="ltitles"><strong>
                              ͼƬ�ϴ���</strong></td>
                            <td class="nonepad">
                                <div class="hui">
                                    <uc4:ImageUploadControl ID="ImageUploadControl1" runat="server" InfoType="GovernmentRegister" />
                                    &nbsp;</div>
                          </td>
                        </tr>
                        <tr id="fileDiv" runat="server">
                            <td align="right" class="ltitles"><strong>
                              �ļ��ϴ���</strong></td>
                            <td>
                           
                            </td>
                        </tr>
                  </table>
                </div>
				<div class="blank0"></div>
               <div class="infozi">
                    ��ϵ��ʽ��</div>
                <div class="widthTable">
                    <uc3:OrgContactControl ID="OrgContactControl1" runat="server"></uc3:OrgContactControl> 
                </div>
				<div class="blank0"></div>
              <div class="infozi"> �������������ҵ�չ��:</div>
                <div class="viewbox lightc cshibiank" >                    �ҵ�չ���������Ƴ���һ�����·��񣬷����û�ȫ��չʾ�Լ��Ĺ�˾/��������ú�������������Ρ�<a href="" class="lanlink">�˽����</a></div>
				<div class="blank0"></div>
                <div >
                    <b><span class="hong">*</span>�ҵ�������http://<asp:TextBox ID="tbExhibitionHall" runat="server" Width="93px"  ></asp:TextBox>
                  </b><b>.gov.topfo.com</b><span> ֻ�����������������̻������ܲ�������չʾ!
                  <asp:Label
                        ID="Label1" runat="server"></asp:Label>
                        <input id="Hidden1" type="hidden" runat="server" /></span></div>
                <div class="mbbuttom">
                   <p> <a href="">����Ķ��й�����Ͷ������������</a></p>
              <asp:ImageButton ID="buSend" runat="server" ImageUrl="../images/Company_Manage/arr_06.gif"
                        OnClick="buSend_Click" OnClientClick="return chkPost();" /></div>
            </div>
</div>
                 
 <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1800px; filter: 
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
	var Descript=document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout");	
    var msg=document.getElementById("ctl00_ContentPlaceHolder1_lbMessage");
    var len=theControl.value.length;
    if( Descript != null )
    {
         msg.innerHTML = "���̻�������������"+len;       
	}	
}	
function CheckDomain(domain,loginName)
{
	if(domain!="")
    {
     AjaxMethod.CheckDomain(domain,loginName,showMessage);
    }	
}
 function sendAjax(){
   var sname=$("#ctl00_ContentPlaceHolder1_tbExhibitionHall").attr("value");
   $.ajax({url:"Ajax.aspx",type:"post",data:"username="+sname,dataType:"text",success:function(req){
  
   if(req=="1")
   {
    alert("�����Ѿ�����");
 $("#ctl00_ContentPlaceHolder1_tbExhibitionHall").focus();

    return false ;
    }   
   }});
 }
function showMessage(res)
{
    var ln = document.getElementById("ctl00_ContentPlaceHolder1_Label1");			
     var hid=document.getElementById("ctl00_ContentPlaceHolder1_Hidden1");
     hid.value=res.value;
    ln.innerHTML ="<font color='red'>"+res.value+"</font>";

   			
}

</script>

</asp:Content>