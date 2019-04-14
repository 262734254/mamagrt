<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recommend.aspx.cs" Inherits="Recommend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全部资源--资源超市--中国招商投资网</title>
    <link href="css/resource3.0.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function fCopyToClicp()
        {
             var a = document.getElementById("txtURl");
             window.clipboardData.setData('text',a.value);
             alert("已复制到剪贴板了，你可以粘贴到QQ/MSN上发送给您的好友");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#f9f9f9"
            class="con21 f_14px" style="text-align: center;">
            <tr>
                <td class="f_tit3" style="padding: 20px 0 5px 0;">
                    推荐资源给好友</td>
            </tr>
            <tr>
                <td height="30">
                    资源链接地址：
                    <asp:TextBox ID="txtURl" Style="width: 300px; height: 19px;" runat="server" /></td>
            </tr>
            <tr>
                <td align="center" style="padding-bottom: 20px;">
                    <input type="submit" name="Submit" value=" 复制 " class="btn2" onclick="fCopyToClicp()" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
