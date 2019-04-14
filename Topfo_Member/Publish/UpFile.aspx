<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpFile.aspx.cs" Inherits="Publish_UpFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="/css/common.css" rel="stylesheet" type="text/css">
    <link href="/css/stake.css" rel="stylesheet" type="text/css">

    <script language="javascript">
    function chkpost()
    {
        if(document.getElementById("txtFileName").value=="")
        {
            alert("附件标题不能为空..");return false;
        }
        if(document.getElementById("txtFileName").value.lenght>30)
        {
            alert("附件标题长度要在15个字以内..");return false;
        }
        var f=document.getElementById("FileUpload1");
        if(f.value=="")
        {
            alert("请选择要上传的文件"); return false;
        }
        var c= parent.document.getElementById("txtCount");
        if(parseInt(c)>2)
        {
            alert("已经传满三个文件.");
            parent.init();parent.Lock_CheckForm();
            return;
        }
    } 
    </script>

</head>
<body style="border-left: 0; margin-left: 0">
    <form id="form1" runat="server">
        <div class="annex" style="margin-left: 0px;">
            <div class="anntitle">
                <span>上传附件</span></div>
            <div class="tacontent">
                <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="18%" align="right" style="height: 24px">
                            附件名称：

                        </td>
                        <td style="height: 24px">
                            <input name="textfield" type="text" id="txtFileName" runat="server" style="width: 235px"><span
                                style="color: #999999">限15个字</span></td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 24px">
                            选择附件：

                        </td>
                        <td style="height: 24px">
   
                            <input ID="FileUpload1" runat="server" Width="306px" type="file" style="width: 311px" /><br />
                            注意：可上传的文件格式有jpg|bmp|gif|doc|ppt|pdf</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;<asp:Button ID="btnUp" runat="server" Text="上  传" OnClick="btnUp_Click" Width="95px" />&nbsp;
                            <input type="submit" onclick="parent.Lock_CheckForm()" name="Submit4" value="关闭该页面"></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
