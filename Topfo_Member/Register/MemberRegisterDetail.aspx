<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberRegisterDetail.aspx.cs" 
    MasterPageFile="~/MasterPage.master" Inherits="Register_MemberRegisterDetail" %>

<%@ Register Src="Control/FileUploader.ascx" TagName="FileUploader" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!--���ʷ��� --><link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                �޸���ϵ��Ϣ
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox allxian lightc">
            ������ϵ��Ϣ�ǶԿں������ǳ���ע�ģ���д�����������ʵ����ϸ���������ʧȥ���������������Σ�<br />
            <a href="#"></a>
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">Ԥ�����Ļ�Ա����</asp:HyperLink></div>
        <div class="blank20">
        </div>
        <!--��ϵ��ʽ -->
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>�û�����</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbLoginName" runat="server" Text="uren812131125 "></asp:Label></span><span
                            class="hui"></span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <strong>��Ա���ͣ�</strong></td>
                <td >
                    <span class="chengcu">
                        <asp:Label ID="lbManageType" runat="server"></asp:Label></span> <span class="hui"></span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>��������</strong></td>
              <td ><asp:CheckBoxList ID="ChkLstRequirInfo" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                <asp:ListItem Value="1001">��������</asp:ListItem>
                <asp:ListItem Value="1004">��ҵ����</asp:ListItem>
                <asp:ListItem Value="1002">��Ŀ����</asp:ListItem>
                <asp:ListItem Value="1003">��ĿͶ��</asp:ListItem>
                <asp:ListItem Value="1005">��ҵ����</asp:ListItem>
                <asp:ListItem Value="1006">��Ʒ����</asp:ListItem>
              </asp:CheckBoxList></td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                   <strong>�� �ƣ�</strong></td>
                <td valign="bottom" >
                    <div class="namefill" >
                        <asp:Label ID="lbNickName" runat="server" ></asp:Label>   
                             <span class="hui">�ǳƲ����޸�</span>  
                         
        </div>
                           <div id="lbName"><br /></div>                  
                    <div class="namepic">
                        <uc1:FileUploader ID="FileUploader1" runat="server" Visible="true" IsCancel="0"  ImgHeight="220" ImgWidth="160" />
                      </div>
                           <div class="blank0"> </div> 
					    [�ϴ�ͼƬ�� (��С:220*160px;����:.jpg|.gif|.png) ]
                     </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <strong>��ʵ������</strong></td>
                <td >
                    <asp:TextBox ID="txtMemberName" runat="server" Width="176px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <strong>�� ��</strong></td>
                <td >
                    <asp:RadioButtonList ID="rblSex" runat="server" Height="8px" RepeatDirection="Horizontal"
                        Width="136px">
                        <asp:ListItem Selected="True" Value="False">��</asp:ListItem>
                        <asp:ListItem Value="True">Ů</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <strong>������λ</strong></td>
                <td valign="top" >
                    <asp:TextBox ID="txtOrganizationName" runat="server" Width="324px"></asp:TextBox>   
                    <asp:Label ID="Label2" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>����ְλ</strong></td>
                <td valign="top" >
                    <asp:TextBox ID="tbCareer" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7" style="height: 44px">
                    <strong>
                        <asp:Label ID="Label1" runat="server"></asp:Label></strong></td>
                <td valign="top" style="height: 44px" >
                    http://<asp:TextBox ID="txtWebSite" runat="server" size="18" Width="229px"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server"></asp:Label> <br />
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>�̶��绰��</strong></td>
                <td valign="top" >
                    <ul>
                        <li class="liwai" style="width: 66px;">����</li><li style="width: 70px;">��������</li><li>�绰����</li></ul>
                    <br />
                    <asp:TextBox ID="txtTelCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtTelZoneCode" runat="server" size="7"></asp:TextBox>
                    <asp:TextBox ID="txtTelNumber" runat="server" size="18"></asp:TextBox>
                    <span class="hui">���Ҫ���������룬��ʹ��&quot;,&quot;�ָ����ֻ�������&quot;��&quot;�ָ�</span>&nbsp;<br />
                        </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>�� ����</strong></td>
                <td style="width: 638px; height: 33px;">
                    <asp:TextBox ID="txtMobile" runat="server" Width="169px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" style="height: 52px">
                    <strong>�� �棺</strong></td>
                <td valign="top" style="width: 638px; height: 52px">
                    <ul>
                        <li class="liwai" style="width: 66px;">����</li><li style="width: 70px;">��������</li><li>�绰����</li></ul>
                    <br />
                    <asp:TextBox ID="txtFaxCountry" runat="server" size="4">+86</asp:TextBox>
                    <asp:TextBox ID="txtFaxZoneCode" runat="server" size="7"></asp:TextBox>
                    <asp:TextBox ID="txtFaxNumber" runat="server" size="18"></asp:TextBox>
                    <span class="hui">���Ҫ���������룬��ʹ��&quot;,&quot;�ָ����ֻ�������&quot;��&quot;�ָ�
                        </span></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>��ϵ��ַ��</strong></td>
                <td >
                    <asp:TextBox ID="txtAddress" runat="server" size="18" Width="269px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7" >
                    <strong>�� �ࣺ</strong></td>
                <td >
                    <asp:TextBox ID="txtPostCode" runat="server" size="18" Width="115px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>�������䣺</strong></td>
              <td >
                    <asp:TextBox ID="txtEmail" runat="server" size="18" Width="185px"></asp:TextBox>
                  &nbsp;
                    <br />
                  <span class="hui">����д����õĵ������䡣�������û�У��Ƽ���ʹ���й�����Ͷ������������䡣</span></td>
            </tr>
        </table>
        <div class="blank0">
        </div>
        <div>
            &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="�Ƿ�Ը����ձ�վ�ʼ�֪ͨ" /></div>
        <div class="mbbuttom">
            <img src="../images/Application/icon_yuan.gif" width="17" height="17" style="position:relative;top:3px;" />
            <asp:HyperLink ID="hlView" runat="server" Text="Ԥ���ҵĻ�Ա����" Target="_blank"></asp:HyperLink><br />
            <p>
                &nbsp;<asp:Button ID="btnOk" runat="server" CausesValidation="False" Height="22"
                    Style="padding-top: 1px" Text="ȷ  ��" Width="50" OnClick="btnOk_Click" /><label>
                    </label>
            </p>
        </div>
    </div>

    <script type="text/javascript">	
		function GetName(name)
		{ 
		    AjaxMethod.GetMemberByLN(name,showMessage);	
		}
		function showMessage(res)
		{	
		 var ln = document.getElementById("lbName");	
		    if(res=="��Ա����")
		    {
			    ln.innerHTML ="<font color='red'>�Բ��𣬴��ǳƼ���ʹ��</font>";	
		    }
		    else
		    {
		         ln.innerHTML ="<font color='red'>���ǳƿ�ʹ��</font>";
		    }	
		}
		
	function chkPost()
     {
        var objWebSite = document.getElementById("ctl00_ContentPlaceHolder1_txtWebSite").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("��ַ��д����ȷ!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtWebSite").focus();
                return false;
             }
		}
		var objZoneCode = document.getElementById("ctl00_ContentPlaceHolder1_txtTelZoneCode").value;
		var objNumber = document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").value;
		var objMobile = document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").value;
		if(objMobile=="")
		{
		    if(objZoneCode =="" ||  objNumber=="")
		    {
		        alert("�绰���벻��Ϊ��!");
		        document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").focus();
			    return false;
		     }
		     else
		     {
    	        var patn = /^[0-9-\/]+$/;
    	        if(!patn.test(objNumber)) 
    	        {
    	            alert("�绰������д����ȷ!");
			        document.getElementById("ctl00_ContentPlaceHolder1_txtTelNumber").focus();
			        return false;			    
    	        } 
    	     }	
    	}
		if(objMobile !="")
		{
		    if(!checkMobile(objMobile))
		    {
		    
		        alert("�ֻ���д����ȷ!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtMobile").focus();
			    return false;
			}
		}
		
		var objPostCode= document.getElementById("ctl00_ContentPlaceHolder1_txtPostCode").value;
		if(objPostCode !="")
		 {
		   	var filter =/^\d{6}$/;
		   	if (!filter.test(objPostCode))
             { 
                alert("�ʱ���д����ȷ!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtPostCode").focus();
                return false;
             }
		 }
		var objMail = document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").value;
		if(obj =="")
		{
		    alert("���䲻��Ϊ��!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
			return false;
		}
		else
		{
		  	var filter = '/^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/';
            if (!filter.test(objMail))
             { 
                alert("������д����ȷ!");
			    document.getElementById("ctl00_ContentPlaceHolder1_txtEmail").focus();
                return false;
             }
		 }		
	 }
		
	function checkMobile(strValue)
	{
	/*^13\d{5,9}$/ //130�C139������5λ�����9λ
/^153\d{4,8}$/ //��ͨ153������4λ�����8λ
/^159\d{4,8}$/ //�ƶ�159������4λ�����8λ */
        var mobile=strValue;
        var reg0 = /^13\d{5,9}$/;
        var reg1 = /^153\d{4,8}$/;
        var reg2 = /^159\d{4,8}$/;
        var reg3 = /^158\d{4,8}$/;
        var reg4 = /^157\d{4,8}$/;
        var reg5 = /^0\d{10,11}$/;
        var my = false;
        if (reg0.test(mobile))my=true;
        if (reg1.test(mobile))my=true;
        if (reg2.test(mobile))my=true;
        if (reg3.test(mobile))my=true;
        if (reg4.test(mobile))my=true;
        if (reg5.test(mobile))my=true;
              
        return my;	
	}	
    </script>
    
    

</asp:Content>
