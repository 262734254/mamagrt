<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="֪ͨ����-�ظ�����-�й�����Ͷ����" CodeFile="PromotionServer.aspx.cs"
    Inherits="helper_PromotionServer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<link href="/css/promotion.css" rel="stylesheet" type="text/css" />

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
            helper_PromotionServer.getDis($id("txtcount").value,backres);
         }
    }
    function backres(res)
    {  
        var array=new Array();
        array=res.value.split('|');
         if(array[2]=="False")//��VIP
        {
           
             $id("lblmoney").innerHTML=array[0]+"Ԫ";
             $id("lbltofomoney").innerHTML="<font color='#C0C0C0'>"+array[1]+"Ԫ</font>";
        }
        else
        {
             $id("lblmoney").innerHTML="<font color='#C0C0C0'>"+array[0]+"Ԫ</font>";
             $id("lbltofomoney").innerHTML=array[1]+"Ԫ";
        }
        
    }   
    function post()
    {
        if($id("txtcount").value=="")
        {
            alert("�������������!");
            return false;
        }
        if(confirm("�����ƹ����"+$id("txtcount").value+"��!"))
        {
           var a=$id("txtcount").value;
           window.location.href="http://pay.topfo.com/order_item_promotion.aspx?smscount="+a;
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
                �����ƹ�</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" alt="" width="14" height="15" align="absmiddle" />
               <a href="http://www.topfo.com/help/directionalextend.shtml#12"  target="_blank">ʹ��˵��</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">�ƹ��ҵ�����</a></li><li><a href="/helper/getPromotion.aspx">���յ����Ƽ���Դ</a></li><li><a href="/helper/ReceivedSet.aspx">��������</a> </li>
                <li class="liwai">������</li></ul>
        </div>
        <div class="buybox cshibiank">
            <h1 class="dottedl lightc">
                <img src="/images/icon_tishi.gif" align="absmiddle" alt=""/> <span class="cheng"> ��ܰ��ʾ��</span>�����ڻ����Է���<asp:Literal ID="lblPromotionCount" runat="server" Text="0"></asp:Literal>�������ƹ㣬ÿ�������ƹ�����ʼ���վ�ڶ��ź��ֻ�����������ʽ�����͡�</h1>
            <div class="blank20">
            </div>
            <table width="449" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="191" align="right">
                        �����ƹ�����:</td>
                    <td colspan="2">
                       <input name="textarea" runat="server" type="text"  onkeyup="getpoint()"
                            size="15" id="txtcount" maxlength="9" />
                        ��(��������)</td>
                </tr>
                <tr>
                    <td align="right">
                        �������:</td>
                    <td colspan="2" class="chengcu">
                        <span id="lblmoney">0</span></td>
                </tr>
                <tr>
                    <td align="right">
                        �ظ�ͨ��Ա����:</td>
                    <td width="59" class="chengcu">
                        <span id="lbltofomoney">0</span></td>
                    <td width="199">
                        <a href="/Register/VIPMemberRegister_In.aspx">
                            <img src="../images/buttom_lijisj2.gif" alt="" width="188" height="26" border="0" /></a></td>
                </tr>
                <tr>
                    <td height="49" colspan="3" align="center">
                        <input name="Submit" onclick="post()" type="button" class="buttomal" value="��������" />
                    </td>
                </tr>
            </table>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>