<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMyHome.aspx.cs" Inherits="MyHome_UpdateMyHome" %>
 <script type="text/jscript">
 function hidd1(){
 if (document.getElementById("txtType").value = "") {
                alert('����������վ���ͣ�');
                document.getElementById("txtType").focus();
                return false;
            }
 }

        function yjhkk() {           
          var txtNumebr = document.getElementById("txtsorct").value;
		if(txtNumebr !="")
		{
		   var newPar=/^\d+$/ 
            if (!newPar.test(txtNumebr))
             { 
                alert("����ֵֻ��Ϊ����!");
			    document.getElementById("txtsorct").focus();
                return false;
             }
		}
             
         var objWebSite = document.getElementById("txtWan").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("��ַ��д����ȷ!");
			    document.getElementById("txtWan").focus();
                return false;
             }
		}
            if (document.getElementById("txtURL").value = "") {
                alert('������������ַ��');
                document.getElementById("txtURL").focus();
                return false;
            }
            if (document.getElementById("txtName").value == "") {
                alert('��������վ���ƣ�');
                document.getElementById("txtName").focus();
                return false;
            }
            
              if (document.getElementById("txtDOC").value == "") {
                alert('��������վ��ע��');
                document.getElementById("txtDOC").focus();
                return false;
            }
              if (document.getElementById("txtsorct").value == "") {
                alert('����������ֵ��');
                document.getElementById("txtsorct").focus();
                return false;
            }
              if (document.getElementById("txtNumber").value == "") {
                alert('��������վ�ʺţ�');
                document.getElementById("txtNumber").focus();
                return false;
            }
              if (document.getElementById("txtPass").value == "") {
                alert('��������վ���룡');
                document.getElementById("txtPass").focus();
                return false;
            }

        }
    </script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�й�����Ͷ�����������</title>
<meta name="keywords" content="���̣�Ͷ��" />
<meta name="description" content="�й�����Ͷ�����������" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
<%--<base target="_blank">--%>
</head>
 
<body>
<form id="form1" runat="server">
<!--��괥��Ч��JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--�����¼JS-->
<script type="text/javascript" src="js/email.js"></script>
 
<div style="width:760px; margin:20px auto; overflow:hidden;">
 
<!--�˵������л�-->
<div class="menu2">
	<ul>
		<li><a href="#" target="_parent">��Ŀ�������</a></li>
		<li class="on" style="width:111px;">��վ��ַ����</li>
	</ul>
</div>
 
<!--��ַ�������-->
<div class="con">
	<!--����˵��-->
	<div class="date f_date">
		<div class="date_l">���ڴ˱༭������ַ������*���ŵ�Ϊ�����</div>
		<div class="date_r"><a href="#" target="_parent">&gt;&gt;�����ҵĿ������</a>&nbsp;&nbsp;<a href="#">&gt;&gt;Ĭ�Ͽ������</a></div>
		<div class="clear"></div>
	</div>
	<table border="0" cellspacing="0" cellpadding="0" class="tab3 f_14">
      <tr>
        <td colspan="2" align="right" style="height:20px;"></td>
      </tr>
      <tr>
        <td width="15%" align="right" style="height: 30px"><span class="f_red">*</span> ��վ���ƣ�</td>
        <td width="85%" style="height: 30px">
            <asp:TextBox ID="txtName" runat="server" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right" style="height: 30px"><span class="f_red">*</span> ���ӵ�ַ��</td>
        <td style="height: 30px">
            <asp:TextBox ID="txtWan" runat="server" Width="516px" class="inp_set"></asp:TextBox></td>
      </tr>
	  <tr>
        <td align="right"><span class="f_red">*</span> ���</td>
        <td> <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList></td>
      </tr>
	  <tr>
        <td align="right">��վ��ע��</td>
        <td>
            <asp:TextBox ID="txtDOC" runat="server" Width="516px" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">����</td>
        <td>
            &nbsp;<asp:TextBox ID="txtsorct" runat="server" Width="49px" class="inp_set"></asp:TextBox><span style="font-size:12px; color:#999;">�����롰1-100��������,��ֵԽСλ��Խ��ǰ��</span></td>
      </tr>
      <tr>
        <td align="right">��վ�ʺţ�</td>
        <td>
            <asp:TextBox ID="txtNumber" runat="server" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">�ʺ����룺</td>
        <td>
            &nbsp;<asp:TextBox ID="txtPass" runat="server" class="inp_set"></asp:TextBox><span style="font-size:12px; color:#999;">���������ڸ���վ������,�������뽫�ǰ�ȫ�ģ�</span></td>
      </tr>
      <tr>
        <td align="right">״̬��</td>
        <td>
            <asp:RadioButton ID="rdostar" runat="server" class="inputs" GroupName="a" Text="����" />
            &nbsp;<asp:RadioButton ID="rdostop" runat="server" class="inputs" GroupName="a" Text="����" />
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td style="padding:5px 0 10px 0;">
            <asp:Button ID="btnUpdate" runat="server" OnClick="Button1_Click" class="btn4" Text="�޸�"  OnClientClick="return yjhkk();" /></td>
      </tr>
    </table>
</div>
 
</div>
 </form>
</body>
</html>
 
