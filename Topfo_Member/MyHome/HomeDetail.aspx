<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeDetail.aspx.cs" Inherits="MyHome_Default" %>

<<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Tz888.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc2" %>
 
 <script type="text/jscript">
  function hidd(a,b){
   
      var  a=document.getElementById(a);
      var more_section=document.getElementById(b)
  
            if (a.style.display=="block"){
                a.style.display="none";
    more_section.innerText='�����ҳ��Ϣ';
    
            } else {
                a.style.display="block";
    more_section.innerText='������ҳ��Ϣ';
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
             
         var objWebSite = document.getElementById("txtURL").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("��ַ��д����ȷ!");
			    document.getElementById("txtURL").focus();
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
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�й�����Ͷ�����������</title>
<meta name="keywords" content="���̣�Ͷ��" />
<meta name="description" content="�й�����Ͷ�����������" />
<%--<base target="_blank"/>--%>
<link href="css/yellow.css" rel="stylesheet" type="text/css" />
</head>

<body>
 <form id="form1" runat="server">
<!--��괥��Ч��JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--�����¼JS-->
<script type="text/javascript" src="js/email.js"></script>

<!--Top����-->
<div class="logo">
	<div class="logo_r">
		<div class="inl">
			<ul>
				<%--<li class="n1"><a href="#">��������</a></li>
				<li class="n2"><a href="#">��¼</a></li>
				<li class="n3"><a href="#">�û�ע��</a></li>
				<li class="n4"><a href="#">��ҳ</a></li>--%>
			</ul>
			<div class="clear"></div>
		</div>
		<div class="clear"></div>
		<div class="log">
			<%--�û�����<input type="text" name="textfield2" class="inp_lo">
			���룺<input type="password" name="textfield2" class="inp_lo">
			<input type="submit" name="Submit2" value="" class="btn1">--%>
	    </div>
	</div>
	<div class="clear"></div>
</div>

<!--�˵������л�-->
<div class="menu2 f_14">
	<ul>
		<li id="nav_btn_2" onclick="SetBtn('nav',2);">��վ��ַ����</li>
	</ul>
</div>
<!--��վ��ַ����-->
<div class="con" id="nav_con_2" >
	<!--����˵��-->
	<div class="date f_date" style="padding:40px 0 5px 0;">
<%--		<div class="date_l"><span class="f_red strong">[������]</span>��ӭ�������ظ��������������ģ�</div>--%>
		<div class="clear"></div>
	</div>

	<table border="0" cellspacing="0" cellpadding="0" class="tab1 f_14 f_line" style="margin-top:10px;">
      <tr>
        <td colspan="8" align="center" class="strong"  bgcolor="#FFFFFF">�����Ϣ</td>
      </tr>
      <tr align="center" style="background:#FFF5DF;" class="strong">
        <td align="center" style="width: 167px; height: 30px;">��վ����</td>
        <td align="center" style="width: 133px; height: 30px;">��ַ</td>
        <td align="center" style="width: 137px; height: 30px;">���</td>
        <td  align="center"style="width: 137px; height: 30px;">����ʱ��</td>
        <td align="center" style="width: 169px; height: 30px;">����</td>
        <td  align="center"colspan="3" style="height: 30px">����</td>
      </tr>
      <asp:Repeater ID="Repeater1" runat="server" EnableViewState="True" EnableTheming="True" Visible="True">
        <ItemTemplate>
        <tr>
          <td align="center" ><%#GetTitle(Eval("LName").ToString(),10)%></td>
       
          <td align="center"><a href="http://<%#Eval("Linkwww")%> " target="_blank"><%#GetTitle(Eval("Linkwww").ToString(),50)%></a></td>
        <td align="center"><%#ShowUserName(Eval("nid").ToString())%></td>
          <td align="center"><%#Eval("CreateTimes","{0:yyyy-MM-dd}")%></td>
          <td align="center"><%# Eval("WSort") %>  </td>
           <td align="center">
           <asp:LinkButton ID="lbdelHome" CommandArgument='<%#Eval("LID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="ɾ��������¼" OnClientClick="return confirm('ȷ��ɾ�����ļ�?');">ɾ��</asp:LinkButton>
         <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("LID") %>' onclick="lkUpdate_Click" target="_blank">�޸�</asp:LinkButton>
           </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
        <cc2:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" >
    </cc2:AspNetPager>
    </tr>
    </table>
</div>

<!--Bottom����-->
<div class="con">
	<div class="link"><a href="#">��������</a> - <a href="#">��ϵ����</a> - <a href="#">���ǵķ���</a> - <a href="#">֧����ʽ</a> - <a href="#">������</a> - <a href="#">��������</a> - <a href="#">��վ��ͼ</a> - <a href="#">��ƸӢ��</a> - <a href="#">���Է���</a> - <a href="#">��������</a></div>
	<div class="copy">
		Copyright &copy; 1998-2010 <a href="http://www.topfo.com/">www.investguide.cn</a> All Rights Reserved<br>
		�ظ����磺�й�����Ͷ���� Ӣ��վ רҵ������ ������ ����Ͷ�ʡ�֧�ֺ��������Ϲ���ҵ����չ��֯�й�Ͷ�ʴٽ��� Ψһ��Ȩ������վ<br>
		��Ӫ���֤��ţ���B2-20040428  ICP��ţ���B2-19981001<br>
		�ͷ�����:0755-82210116
	</div>
</div>
</form>
</body>
</html>