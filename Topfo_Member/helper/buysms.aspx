<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="���Ź�������-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="buysms.aspx.cs"
    Inherits="helper_buysms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function getpoint()
    {
        var re = /^[1-9]+[0-9]*]*$/   
        if (!re.test($id("txtcount").value))
        {
            $id("txtcount").value="";
            $id("txtcount").focus();
            return false;
         }
         
         if($id("txtcount").value.length>9)
         {
            $id("txtcount").value=$id("txtcount").value;
            return false;
         }
         else
         {
            helper_buysms.getDis($id("txtcount").value,backres);
         }
    }
    function backres(res)
    {  
        var array=new Array();
        array=res.value.split('|');
        
        if(array[2]=="False")//��VIP
        {
             $id("lblmoney").innerHTML=array[1]+"Ԫ";
             $id("lbltofomoney").innerHTML="<font color='#C0C0C0'>"+array[0]+"Ԫ</font>";
        }
        else
        {
             $id("lblmoney").innerHTML="<font color='#C0C0C0'>"+array[1]+"Ԫ</font>";
             $id("lbltofomoney").innerHTML=array[0]+"Ԫ";
        }
       
        
    }   
    function post()
    {
        if($id("txtcount").value=="")
        {
            alert("�������������!");
            return false;
        }
        if(confirm("����֪ͨ����"+$id("txtcount").value+"��!"))
        {
           var a=$id("txtcount").value;
           window.location.href="http://pay.topfo.com/order_item_sms.aspx?smscount="+a;
        }
    }
  
    function $id(obj)
    {
       
       return document.getElementById(obj);
    }
    </script>

    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                ֪ͨ����</div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="suggestbox  lightc">
            ������������ʹ��վ�ڶ��š������ʼ����ֻ����ŵȷ�ʽ���ո���֪ͨ��<br />
            ��<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">�ظ�ͨ��Ա</a>������500������ֻ����ŷ���
            <br />
            ����ͨ��Ա����ʹ���ֻ����ŷ�������<a href="buysms.aspx">�����������</a>��ÿ������0.1Ԫ��</div>
        <div class="blank20">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="Notice.aspx" style="text-decoration: none">֪ͨ����</a></li><li class="liwai">
                    ������� </li>
            </ul>
        </div>
        <div class="smsconbox cshibiank">
            <h1 class="dottedl">
                <img src="/images/icon_tishi.gif" align="absmiddle" />
                <span class="cheng">��ܰ��ʾ��</span>�����ڻ����Խ���<asp:Label ID="lblMobileCount" runat="server"
                    Text="0"></asp:Label>���ֻ�����</h1>
            <table width="465" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="46" align="right">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td width="186" align="right" style="height: 27px">
                        �����빺���ֻ���������:</td>
                    <td colspan="2" style="height: 27px">
                        <input name="textarea" type="text" value="" onkeyup="getpoint()" size="15" id="txtcount"
                            maxlength="9" />
                        ��(��������)</td>
                </tr>
                <tr>
                    <td align="right">
                        �������:</td>
                    <td class="chengcu">
                        <span id="lblmoney">0</span></td>
                    <td class="chengcu">
                        <a href="/Register/VIPMemberRegister_In.aspx">
                            <img src="../images/buttom_lijisj.gif" width="188" height="26" border="0" id="imgVip"
                                runat="server" /></a></td>
                </tr>
                <tr>
                    <td align="right">
                        �ظ�ͨ��Ա����:</td>
                    <td width="64" class="chengcu">
                        <span id="lbltofomoney">0</span></td>
                    <td width="215" align="left" class="cheng">
                        (�ظ�ͨ��Ա����8�۹����Ż�)</td>
                </tr>
                <tr>
                    <td height="49" colspan="3" align="center">
                        &nbsp;<input type="button" class="buttomal" id="Submit1" style="width: 92px" onclick="post()"
                            value="��������" /></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
