<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_upload_vedio.aspx.cs" Inherits="Member_p_upload_vedio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>视频上传</title>
    <link href="../css/test.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divUploadVideo">
            <table width="95%" height="111" border="0" cellpadding="0" cellspacing="0" class="cshibiank">
                <tr>
                    <td height="10" colspan="3" align="right">
                    </td>
                </tr>
                <tr>
                    <td width="26%" align="right" style="height: 25px">
                        <p>
                            视频主题：</p>
                    </td>
                    <td colspan="2" style="height: 25px">
                        <label>
                            <input name="textarea4" type="text" id="textarea4" value="" style="width: 225px" />
                        </label>
                        不超过18个汉字
                    </td>
                </tr>
                <tr>
                    <td height="21">
                        &nbsp;</td>
                    <td colspan="2">
                        <input type="file" id="fileuploadVideo" runat="server" style="width: 294px; height: 20px" />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td height="19" colspan="3" align="center">
                        <p>
                            如果您的文件很大，可以将资料寄给我们来帮您上传（<a href="#" class="lanlink">邮寄地址</a>）。<span class="hong">此服务为拓富通会员专享。</span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px" colspan="3" align="center">
                        &nbsp;<asp:Button ID="btnUploadVideo" runat="server" Text="上传" Width="68px" /></td>
                </tr>
                <tr>
                    <td colspan="3" align="right" style="height: 10px">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
