<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServiceAdd.aspx.cs" Inherits="ValueAdd_ServiceAdd" Title="��ֵ������" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/CSS/style.css" rel="stylesheet" type="text/css" />
    <div class="size">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="50" colspan="9">
                    <p align="center" class="STYLE1">
                        ��ֵ������
                    </p>
                </td>
            </tr>
            <tr>
                <td height="20" colspan="9" align="right" valign="middle">
                <a href="/ValueAdd/ServiceList.aspx">�鿴�ҵĶ���</a>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="9" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td width="1" rowspan="26" bgcolor="#cccccc">
                </td>
                <td width="115" height="40" bgcolor="#fffbe8">
                    &nbsp;</td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="153" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        <div align="center">
                            ������Ŀ</div>
                    </div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="515" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        ����˵��</div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td width="160" bgcolor="#fffbe8">
                    <div align="center" class="STYLE2">
                        <div align="center">
                            �۸�(�����/Ԫ)</div>
                    </div>
                </td>
                <td width="1" rowspan="26" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="27" />
                            ��Ҫ����</strong></div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        �����ƹ�</div>
                </td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_27" name="decrip_27" runat="server">
                    ��ͨ�����䡢վ�ڶ��š��ֻ����ŵȷ�ʽ����ȫ�������жԿ��������ҵ�û�����Ͷ���������󣬻��ȫ��300��������ҵ�û������ĳ�����ע��������֮�Ƹ�����ȫ��֮�̻���</td>
                <td width="1" bgcolor="#cccccc">
                </td>
                <td id="price_27" name="price_27" runat="server">
                    <p align="center">
                        1Ԫ/��/��(100Ԫ��)</p>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="28" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        �Կ���Դ�������</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_28" name="decrip_28" runat="server">
                    1.���̡���Ŀ��Ͷ����Դ�������<br />
                    2.�����Ƽ����Կڿͻ�<br />
                    3.ͨ��վ�ڶ���Ϣ��������ֻ�������Խ��֪ͨ<br />
                    4.��Դ�۸�����Ͷ������Դʵ�ʶ�������<br />
                    �˷��������Դ������������ʵ��</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_28" name="price_28" runat="server">
                    <div align="center">
                        ��ÿ����Դ�շ�</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="29" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        �Կ���Դר���Ƽ�</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_29" name="decrip_29" runat="server">
                    <ol>
                        <li>1.���̡�Ͷ����ר��ͬ����ϵ��Ϊ�������ơ�������ѡ��������������Ƽ�������Դ������ҵ������ר���������ݷöԿ���Դ������ </li>
                        <li>2.�����Ƽ����Կڿͻ��������רҵ������ </li>
                        <li>3.ͨ��վ�ڶ���Ϣ��������ֻ�������Խ��֪ͨ��רҵ�ٽ����̡�Ͷ�ʡ����ʣ��ɹ����б��ϣ� </li>
                    </ol>
                    ������Դ������Դ���ɡ�С������Ͷ���ʶԽӻᡱ������Ŀ��ͷ���Ȼ���������˿���ר��������Ǣ��</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_29" name="price_29" runat="server">
                    <div align="center">
                        2000Ԫ/��</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="30" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ������ҵ�ƻ���ժҪ</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_30" name="decrip_30" runat="server">
                    <p>
                       �����ҵ�ƻ���ժҪ1�ݡ�����ɹ�����Ŀ���ʷ��������ɹ�˾����ר�Ҹ���Ϥ��ָ��������������Ŀ�ƻ�������������Ŀ��ֵ����Ͷ��������������
                      </p>
                    �������������쵽����Ͷ�������רҵ�������񣬾������˿���ר��������Ǣ��</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_30" name="price_30" runat="server">
                    <div align="center">
                        8000Ԫ/��</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="31" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ������־�ƹ�</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_31" name="decrip_31" runat="server">
                    ����ȫ���е���Ӣ��˫�������־���ƾ�����ý���Ϊ���ṩ�߶ˡ�խ�桱���񡣻�ú����߶���ҵ�û�Ⱥ��ĳ�����ע�����������ͨ���ģ������Ƹ�ӿ���ţ�</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_31" name="price_31" runat="server">
                    <div align="center">
                        3500Ԫ/��</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="32" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        �쵼ר��</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_32" name="decrip_32" runat="server">
                    �쵼ר��һ�Σ�����վ�������Ŀ��������־��Ӣ��ר�ⱨ����չʾ�����ɣ�͹����ҵ��ֵ����ȫ�򶥼���ҵ�Ż�չʾƷ��������չ�г�Ӱ������</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_32" name="price_32" runat="server">
                    <div align="center">
                        ��ҵ10000Ԫ/��<br />
                        ����30000Ԫ/��
                    </div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="33" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ���չʾ</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_33" name="decrip_33" runat="server">
                    <ol>
                        <li>1.չʾ�ظ�ָ����͹����Ŀ��ֵ���������� </li>
                        <li>2.�����������ӹ�ע�� </li>
                        <li>3.�л�������ҳ��Ƶ�����ص��Ƽ� </li>
                        <li>4.��ʱˢ���Լ�������������չʾ����ǰ�� </li>
                    </ol>
                    ���Ϸ����ǰ������,�ӷ�����֮�������</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_33" name="price_33" runat="server">
                    <div align="center">
                        888Ԫ/��</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="2" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ����Ͷ����·��</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_2" name="decrip_2" runat="server">
                    ������ҳ������Ƶ����Ͷ��Ƶ��������Ƶ��·��չʾ���ø����˹�ע����
                    <br />
                    �������������쵽������������������վ����ҵ��վ���裬�������˿���ר��������Ǣ</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_2" name="price_2" runat="server">
                    <div align="center">
                        �۸�8��Ԫ/�꣨����������</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="34" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ר���Ƽ�</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_34" name="decrip_34" runat="server">
                    ����Ͷ���ʻ֧�֣�Э�����̻ᡢͶ���ʶԽӻᣬ��������ר�ⱨ��������ȫ����ҵ�û�Ӫ���ȵ㣬�����û�˲��۽����̻����ٻ�ۣ����̸���Ч�������б��ϣ�</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_34" name="price_34" runat="server">
                    <div align="center">
                        8000Ԫ/3��</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="1" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        ������</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_1" name="decrip_1" runat="server">
                    ��ҳ����Ƶ��Ϊ���ṩͼ��桢��Ƶ��桢������������ѡ���ƹ����Ч����ȫ��3000��������ҵ�û���ע����ǿ��Ĺ������̨��˲�侫ȷ��λ����Ǳ�ڿͻ����������㷺�Ŀͻ���ϵ��ר�˶���Ϊ���ṩ�ͻ��嵥����������������Ч���̣�Ͷ�ʣ����ʣ����ʲ�ҵ���ۻ���˲����죡</td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_1" name="price_1" runat="server">
                    <div align="center">
                        �ο�����շѱ�׼</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="7" bgcolor="#cccccc">
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center">
                        <strong>
                            <input name="CB_Type" type="checkbox" value="35" />
                            ��Ҫ����</strong></div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td>
                    <div align="center">
                        վ�ڻ���</div>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td style="padding-left: 10px; padding-right: 0px;" id="decrip_35" name="decrip_35" runat="server">
                    <p>
                        �����֮���������磬���Ը��ݿͻ��������֪Ǳ�ڶԿڵĿͻ�Ⱥ�壬�����ǿ��Ŀ���������������漼������ÿһ���������Դ���û���չ��������ǰ��
                    </p>
                </td>
                <td bgcolor="#cccccc">
                </td>
                <td id="price_35" name="price_35" runat="server">
                    <div align="center">
                       ����Դ����ʵ�ʼ۸��շ�</div>
                </td>
            </tr>
            <tr>
                <td height="1" colspan="9" bgcolor="#cccccc">
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>�û��� </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <%=loginNameStr%>
                    </strong>
                </td>
                <td>
                    <div align="right">
                        <strong>��ϵ������:</strong></div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Name" runat="server" Width="160px"></asp:TextBox></strong>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>ҵ�����������: </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Email" runat="server" Width="160px"></asp:TextBox>
                    </strong>
                </td>
                <td>
                    <div align="right">
                        <strong>�绰����: </strong>
                    </div>
                </td>
                <td>
                    <strong>
                        <asp:TextBox ID="textB_Tel" runat="server" Width="160px"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>����Ҫ��</strong>:</div>
                </td>
                <td colspan="3">
                    <strong>
                        <asp:TextBox ID="textB_Remark" runat="server" TextMode="MultiLine" Width="500px" Height="60px"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div align="center">
                        <strong>
                            <asp:Button ID="Btn_submit" runat="server" Text=" �� �� "
                                Width="72" Height="24" OnClick="Btn_submit_Click" OnClientClick="return CheckIt();" /></strong></div>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
    function GetCheckNum(checkobjectname)     
    {   
        var truei = 0;   
        checkobject = document.getElementsByName("CB_Type"); //eval("document.all."+checkobjectname);   
        var inum = checkobject.length;   
        if (isNaN(inum))   
        {   
            inum = 0;   
        }   
        for(i=0;i<inum;i++)   
        {   
            if (checkobject[i].checked)   
            {   
                truei = truei + 1;   
            }   
        }   
        return truei;   
    }   
    function CheckIt()   
    {   
        var flag=true; 
        if (GetCheckNum('checkbox')<=0)   
        {   
            //document.all.checkbox1.focus();   
            alert("������ѡ��1�����Ʒ���");   
            flag = false;   
        }   
        return flag;
    }   
    </script>
</asp:Content>
