<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="�����ֵ��-�ظ�����-�й�����Ͷ����" CodeFile="tofocard_buy.aspx.cs"
    Inherits="PayManage_tofocard_buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function chkInput()
    {
        if($id("txtwushi").value==""&&$id("txtbai").value==""&&$id("txttwobai").value==""&&$id("txtfivebai").value=="")
        {
            alert("����ѡ��һ�ſ�!");
            return false;
        }
      
        if($id("txtwushi").value!="")
        {
            if(isNaN($id("txtwushi").value))
            {
                alert("����д����!");
                $id("txtwushi").value="";
                $id("txtwushi").focus();
               return false;
            }
        }
        if($id("txtbai").value!="")
        {
            if(isNaN($id("txtbai").value))
            {
                alert("����д����!");
                $id("txtbai").value="";
                $id("txtbai").focus();
               return false;
            }
        }
         if($id("txttwobai").value!="")
        {
            if(isNaN($id("txttwobai").value))
            {
                alert("����д����!");
                $id("txttwobai").value="";
                $id("txttwobai").focus();
                return false;
            }
        }
        if($id("txtfivebai").value!="")
        {
            if(isNaN($id("txtfivebai").value))
            {
                alert("����д����!");
                $id("txtfivebai")="";
                $id("txtfivebai").focus();
                return false;
            }
        }
        if(parseInt($id("txtbai").value)>100000||parseInt($id("txtwushi").value)>100000||parseInt($id("txttwobai").value)>100000||parseInt($id("txtfivebai").value)>100000)
        {
            alert("��ֵ������ֵ���� Int32 ̫���̫С");
            return false;
        }
         if(parseInt($id("txtbai").value)<1||parseInt($id("txtwushi").value)<1||parseInt($id("txttwobai").value)<1||parseInt($id("txtfivebai").value)<1)
        {
            alert("��ֵ������ֵ���� Int32 ̫���̫С");
            return false;
        }
        if($id("txtrealname").value=="")
        {
            alert("����д����,");
            $id("txtrealname").focus();
           return false;
        }
        if($id("txtTel").value==""&&$id("txtMobile").value=="")
        {
           alert("Ϊ������ϵ,����д�绰���ֻ�����һ��!");
            $id("txtTel").focus();
            return false;
        }
        if($id("txtMobile").value!="")
        {
            if($id("txtMobile").value.length!=11)
            {
                alert("�ֻ���ʽ����!");
                $id("txtMobile").focus();
                return false;
            }
            if(isNaN($id("txtMobile").value))
            {
                 alert("�ֻ���ʽ����!");
                $id("txtMobile").focus();
                return false;
            }
        }
        if($id("txtAddress").value=="")
        {
          alert("����д��ַ,�Ա������ܰѿ�׼ȷ�ķ����������!");
            $id("txtAddress").focus();
            return false;
        }
        if($id("txtEmail").value=="")
        {
           alert("����д��������,");
            $id("txtEmail").focus();
           return false;
        }
    }
   function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                �����ظ���ֵ��</div>
            <div class="right">
                <a href="http://www.topfo.co/help/AccountCZ.shtml#14" target="_blank">�鿴�����ظ���ֵ���̳�</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox lightc allxian">
            <h1>
                С��ʾ��</h1>
            �ظ���ֵ�����Կ��ٶ�ָ���˻����г�ֵ�������Դ���������������Ϊ��<a href="http://www.topfo.com/help/AccountCZ.shtml" target="_blank">�˽����</a><br />
            ����׼���˶��ֹ�����������ѡ�񣬷��㡢��ݣ�<br />
            ��������κ����ʣ��벦�����ǵĿͷ��绰��<!--#include file="../common/custel.html"-->
        </div>
        <div class="blank20">
        </div>
        <!-- -->
        <div class="fillbox cshibiank">
            <h1 class="lightc">
                ����д���¶�����Ϣ���� <span class="hong">*</span> ��Ϊ�������</h1>
            <table width="85%" height="332" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="32" colspan="4">
                        <strong>��ѡ���ֵ����ֵ�������� </strong>
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td width="128" align="right" style="height: 28px">
                        <span class="chengcu font14">50</span>Ԫ��ֵ�ĳ�ֵ����</td>
                    <td width="159" style="height: 28px">
                        <label>
                        <input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                                id="txtwushi" runat="server" />
                            ��
                        </label>
                  </td>
                    <td width="137" align="right" style=" height: 28px">
                        <span class="chengcu font14">100</span>Ԫ��ֵ�ĳ�ֵ����</td>
                    <td align="left" style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txtbai" runat="server" />
                        ��
                  </td>
                </tr>
                <tr>
                    <td align="right" style="height: 28px">
                       <span class="chengcu font14"> 200</span>Ԫ��ֵ�ĳ�ֵ����
                    </td>
                    <td style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txttwobai" runat="server" />
                        ��
                    </td>
                    <td align="right" style=" height: 28px">
                       <span class="chengcu font14"> 500</span>Ԫ��ֵ�ĳ�ֵ����
                    </td>
                    <td style="height: 28px"><input name="textarea" type="text" value="" style="width: 67px; height: 18px"
                            id="txtfivebai" runat="server" />
                        ��
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                        </td>
                    <td>&nbsp;
                        </td>
                    <td style="width: 133px">&nbsp;
                        </td>
                    <td>&nbsp;
                        </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <strong>����д����������ϣ�</strong><br />
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 34px">
                        <span class="hong">*</span> ��ʵ������</td>
                    <td colspan="3" style="height: 34px">
                        <input name="textarea22" type="text" value="" style="width: 109px; height: 18px"
                            id="txtrealname" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" valign="bottom" style="padding-bottom: 10px;">
                        <span class="hong">*</span> �̶��绰��</td>
                    <td colspan="3">
                        <input name="textarea22" type="text" value="" style="width: 226px; height: 18px"
                            id="txtTel" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        �ֻ���
                    </td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 227px; height: 18px"
                            id="txtMobile" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        <span class="hong">*</span> ��ϸ��ַ��</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 228px; height: 18px"
                            id="txtAddress" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px">
                        �ʱࣺ</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 227px; height: 18px"
                            id="txtCode" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="hong">*</span> E-mail��</td>
                    <td colspan="3" style="height: 29px">
                        <input name="textarea222" type="text" value="" style="width: 226px; height: 18px"
                            id="txtEmail" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right">&nbsp;
                        </td>
                    <td height="50" colspan="2" align="center">
                        <asp:Button ID="btnSend" runat="server" Text="��  ��" OnClick="btnSend_Click"  class="buttomal"/>
                        &nbsp;<input type="reset" name="Submit2" value="�� �� " style="width: 71px" class="buttomal" />
                    </td>
                    <td>&nbsp;
                        </td>
                </tr>
            </table>
        </div>
       <div class="blank20">
        </div>
        <!-- -->
        <div class="helpbox">
            <div class="con">
                <h1 >
                    <img src="../images/icon_yb.gif" align="absmiddle" /><strong> ��Ҫ˵��</strong></h1>
                <ul>
                    <li>�ظ���ֵ�����ݻ�Ա��Ҫ���ڵ����������̴�����Ҳ����ֱ�Ӵ��й�����Ͷ�������򣬻����������ϵ���֧��ƽ̨ϵͳ�����������ɳ�ֵ��</li><li>�ظ���ֵ��������Ч��������������ʧ�������Ʊ��ܣ�������ʧ��ð�ã�û�п���ҵ�����Ϳ���ֵʹ�õĿ��������˻���ԭ�������̣������������׼��Ҳ���˻����й�����Ͷ������</li><li>
                        �ظ���ֵ���������룬��ֵʱ��ȷ���뿨�š�����󼴿ɳɹ���ֵ��</li><li>��Ա���򡢳�ֵ���������й�����Ͷ��������Ա����Э�顷���ƿ������ҵ�����</li></ul>
                <p>
                  <span class="hong">��Ա�������ߣ�<!--#include file="../common/custel.html"--></span> <a href="/ContactUs.shtml" target="_blank">���߿ͷ�</a></p>
            </div>
    </div>
	</div>
</asp:Content>
