<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="�ҵĹ���ȯ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="ticket_exchange.aspx.cs"
    Inherits="PayManage_ticket_exchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />


    <script language="javascript">
function chkpost()
{
    if ($id("txtExCount").value=="")
    { 
        $id("txtExCount").value="";
        divmsg.innerHTML="<font color='red' size=2>��������";
        $id("txtExCount").focus();
       
        return false;
    }
}
function changejifen(v)
{

    var re = /^[1-9]+[0-9]*]*$/   
    if (!re.test($id("txtExCount").value))
    { 
        $id("txtExCount").value="";
        divmsg.innerHTML="<font color='red' size=2>��������";
        $id("txtExCount").focus();
        return false;
    }
   if(parseInt(v)>parseInt($id("lblOwnerCount").innerText))
   {
        divmsg.innerHTML="<font color='red' size=2>���ֲ���";
         $id("txtExCount").value="";
        $id("txtExCount").focus();
        return false;
   }
   else
   {
      divmsg.innerHTML="";
   }
   if(v!="")
   {
      var b=$id("hidB");
      document.getElementById("ExCount").innerText=v/b.value;
   }
 
}

function $id(obj)
{
    return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
}
    </script>

    <!--�ҵĹ��ﳵ -->
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �ҵĹ���ȯ
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox allxian">
            <h1>
                ��ܰ��ʾ��</h1>
            <p>
                ��ÿ<asp:Literal ID="lbVRate" runat="server"></asp:Literal>���ֿ��Զһ�1.00Ԫ����ȯ��ÿ��ÿ����߿ɶһ�<asp:Literal
                    ID="lbExLimit" runat="server"></asp:Literal>Ԫ
                <br />
                ������ȯ��Чʹ����Ϊ�һ�֮����<asp:Literal ID="lbVTerms" runat="server"></asp:Literal>�����ڣ�����<font
                    class="cheng"><asp:Literal ID="lbVTerms2" runat="server"></asp:Literal>������δ���ѵĹ���ȯ���Զ�����
                </font>&nbsp;<a href="ticket_exchange_record.aspx" class="lanlink">�鿴�ҵĹ���ȯ��Ч��</a>
                <br />
                ������ȯֻ�ܹ���ָ������Դ
                <br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--����ȯ�һ� -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li class="liwai">����ȯ�һ�</li><li><a href="ticket_exchange_record.aspx" style="text-decoration: none">
                        �һ���¼</a></li><li><a href="http://pay.topfo.com/cost/Project.aspx" target="_blank"
                            style="text-decoration: none">����ȯ��Դר��</a> </li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="left">
                    <div class="top">
                        <ul>
                            <li>����ʣ����֣�<asp:Label ID="lblOwnerCount" runat="server">0</asp:Label>
                                ��</li><li>�ɶһ�����ȯ��<asp:Literal ID="lblExCount" runat="server">0</asp:Literal>
                                    Ԫ<br />
                                </li>
                            <li>����ȯʣ���<span class="chengcu"><asp:Literal ID="lblLeft" runat="server" Text="0"></asp:Literal></span>Ԫ</li><div
                                class="clear">
                            </div>
                        </ul>
                        <div class="blank20">
                        </div>
                        <div>
                            <a href="http://www.topfo.com/web13/help/tradeticket.shtml#13" target="_blank" class="lanlink">
                                ��λ�ø������</a> <a href="ticket_exchange_record.aspx" class="lanlink">�鿴�ҵĶһ���¼</a>
                            <a href="ticket_exchange_record.aspx" class="lanlink" style="display: none">�鿴�ҵĹ���ȯ���Ѽ�¼</a></div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="blank0">
                    </div>
                    <table width="348" height="152" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="165" height="38" align="right">
                                ��Ҫ�һ���</td>
                            <td width="191">
                                <label>
                                    <input name="textarea" type="text" id="txtExCount" onkeyup="changejifen(this.value)"
                                        value="" size="7" runat="server" />
                                </label>
                                ���� <span id="divmsg"></span>
                            </td>
                        </tr>
                        <tr>
                            <td height="38" align="right">
                                �ɶһ�����ȯ��</td>
                            <td>
                                <span id="ExCount">0.00</span> Ԫ</td>
                        </tr>
                        <tr>
                            <td height="1" colspan="2" bgcolor="#CCCCCC">
                            </td>
                        </tr>
                        <tr>
                            <td height="70" colspan="2" align="center">
                                <label>
                                    &nbsp;
                                    <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="�һ�" Width="53px"
                                        CssClass="buttomal" />
                                    &nbsp;
                                    <input type="reset" name="button2" id="button2" value="����" style="width: 46px" class="buttomal" />
                                    <input id="hidB" runat="server" style="width: 44px" type="hidden" /></label></td>
                        </tr>
                    </table>
                </div>
                <div class="right" style="display: none">
                    <h2>
                        ��ѡ����ȯ��Դ
                    </h2>
                    <table width="326" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <strong>��Դ���� </strong>
                            </td>
                            <td>
                                <strong>�۸�(Ԫ)</strong></td>
                        </tr>
                        <tr>
                            <td>
                                ��Ͷ�ʹ�˾Ͷ����Դ�����ز�����Ŀ</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ѱ���������Ļ���������Ŀ
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ͷ�ʹ�˾Ͷ����Դ�����ز�����Ŀ</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ѱ���������Ļ���������Ŀ
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ͷ�ʹ�˾Ͷ����Դ�����ز�����Ŀ</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ѱ���������Ļ���������Ŀ
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ͷ�ʹ�˾Ͷ����Դ�����ز�����Ŀ</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ѱ���������Ļ���������Ŀ
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ͷ�ʹ�˾Ͷ����Դ�����ز�����Ŀ</td>
                            <td>
                                500.00</td>
                        </tr>
                        <tr>
                            <td>
                                ��Ѱ���������Ļ���������Ŀ
                            </td>
                            <td>
                                400.00</td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <!--���� -->
    </div>
</asp:Content>
