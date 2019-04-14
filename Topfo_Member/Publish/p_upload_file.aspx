<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_upload_file.aspx.cs" Inherits="Member_p_upload_file" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>资料上传</title>
    <link href="../css/upload.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
    
    function showEncrypt(obj,id)
    {
        if(obj.checked == true)
            document.getElementById(id).style.display = "";
        else
            document.getElementById(id).style.display = "none";
    }
    var parentIframe = "<%=this.ParentIframe %>";
	
	function resize()
	{
	    parent.document.all(parentIframe).style.height=document.body.scrollHeight; 
        parent.document.all(parentIframe).style.width=document.body.scrollWidth; 
    }
    
    window.onresize = resize;
    </script>

</head>
<body>
    <form id="form" onsubmit="return submitForm(this);" runat="server">
        <div id="fileUpload">
            <asp:Panel ID="plupload" runat="server">
                <table width="600" border="0" align="center" cellpadding="5" cellspacing="0" class="cshibiank">
                    <tr>
                        <td style="width: 500px;" align="left">
                            <div style="padding-left: 60px; padding-top: 10px;">
                                <input type="file" id="fileuploadothers" runat="server" style="width: 345px; height: 20px" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="padding-left: 60px;">
                                <input type="checkbox" id="cbxIsEncrypt" name="cbxIsEncrypt" onclick="showEncrypt(this,'IsEncrypt');" />
                                我要加密 <a href="#" class="lanlink">什么是加密？</a></div>
                        </td>
                    </tr>
                    <tr id="IsEncrypt" style="display: none;">
                        <td align="left">
                            <div class="content">
                                <div id="name">
                                    <div class="text" id="password_info_check">
                                        &nbsp;密码</div>
                                    <div class="redstar">
                                        *</div>
                                </div>
                                <div class="input">
                                    <input class="note" id="password" style="width: 180px" type="password" size="35"
                                        value="" /></div>
                                <div class="note" id="password_info">
                                </div>
                                <div class="HackBox">
                                </div>
                            </div>
                            <div class="content">
                                <div id="name">
                                    <div class="text" id="confirm_password_info_check">
                                        &nbsp;重复输入密码</div>
                                    <div class="redstar">
                                        *</div>
                                </div>
                                <div class="input">
                                    <input class="note" id="confirm_password" style="width: 180px" type="password" size="35"
                                        value="" /></div>
                                <div class="note" id="confirm_password_info">
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 22px">
                            <div style="padding-top: 10px; padding-bottom: 10px;">
                                <input id="btnSubmit" type="submit" value="上传" runat="server" width="70px" style="width: 107px"
                                    onserverclick="btnSubmit_ServerClick" /></div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pldisplay" runat="server">
                <table width="600"border="0" align="center" cellpadding="5" cellspacing="0" class="cshibiank">
                    <tr style="height:100px;">
                        <td style="width: 71px">
                            &nbsp;
                        </td>
                        <td style="width: 360px;" align="left" valign="middle">
                            <asp:Label ID="lblTitle" runat="server">商业计划书[图][密]</asp:Label></td>
                        <td>
                            <asp:LinkButton ID="lblDisplay" runat="server" OnClick="lblDisplay_Click">下载</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lblUpdate" runat="server" OnClick="lblUpdate_Click">修改</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lblDelete" runat="server" OnClick="lblDelete_Click">删除</asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
