<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_upload_file.aspx.cs"
    Inherits="Member_p_upload_file" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ļ��ϴ�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/publish.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
	//document.domain = "tz888.cn";
	function check()
	{
	    var is = 0;
	    if(document.getElementById("txtImgDesc").value.length > 15 || document.getElementById("txtImgDesc").value.length <= 0)
	    {
	        document.getElementById("msg1").className = "megerror";
	        is = 1;
	    }
	    else
	    {
	        document.getElementById("msg1").className = "";
	    }
	    if(document.getElementById("fileUpload").value == "")
	    {
	        var str = "<span>û��ѡ���ļ���</span>";
	        document.getElementById("msg2").innerHTML = str;
	        document.getElementById("msg2").className = "megerror";
	        is = 1;
	    }
	    else
	    {
	        document.getElementById("msg2").innerHTML = "<span>���ϴ����ļ���ʽ��jpg|gif|bmp|doc|ppt|pdf����С������5000k��</span>";
	        document.getElementById("msg2").className = "";
	    }    
	    if(is==1)
	        return false;
	}
	
	function showErrMsg(msg)
	{
	    var str = "<span>" + msg + "</span>";
	    document.getElementById("msg2").innerHTML = str;
	    document.getElementById("msg2").className = "megerror";
	}
	
	var parentIframe = "<%=this.ParentIframe %>";
	
	function resize()
	{
	    //alert("1");
	    parent.document.all(parentIframe).style.height=document.body.scrollHeight; 
        parent.document.all(parentIframe).style.width=document.body.scrollWidth; 
    }
    
    window.onresize = resize;
    </script>

</head>
<body>
    <form id="form1" runat="server" onsubmit="return check();">
        <div>
            <table class="cshibiank" cellspacing="0" cellpadding="5" width="560" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td align="right" width="104">
                            <p>
                                �ļ�������</p>
                        </td>
                        <td width="434">
                            <input type="text" id="txtImgDesc" style="width: 272px" runat="server">
                            <div id="msg1" style="display: inline;">
                                <span>����Ϊ���Ҳ�����15������</span></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <input type="file" ID="fileUpload" runat="server" style="width: 341px; height: 20px"/></td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <div id="msg2" style="display: inline;">
                                <span>���ϴ��ļ���ʽ����Ϊ��.gif|.jpg|.bmp|.doc|.ppt|.pdf����С������500k��</span></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            <label>
                                <asp:Button ID="btnUpload" runat="server" Text="�ϴ�" Width="58px" OnClick="btnUpload_Click" OnClientClick="return check();" />
                                &nbsp;&nbsp; &nbsp;<input type="reset" value="�� ��" style="width: 60px">
                            </label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
