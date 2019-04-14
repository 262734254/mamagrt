<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUploadControl2.ascx.cs"
    Inherits="Register_Control_ImageUploadControl2" %>
&nbsp;<table class="cshibiank" cellspacing="0" cellpadding="5" width="560" align="center"
    border="0">
    <tbody>
        <tr>
            <td align="center" colspan="2">
                <asp:DataList ID="Repeater1" runat="server" RepeatColumns="3" RepeatDirection="Vertical" >
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("ResourceTitle")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img alt="<%#Eval("ResourceTitle")%>" src="<%#ImageDomain%><%#Eval("ResourceAddr")%>">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="button" name="Submit2" value="删除"  onclick="Delete('<%#Eval("ResourceID") %>')" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <input id="Button1" type="button" value="添加上传" onclick="addImage();" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <table class="cshibiank" cellspacing="0" cellpadding="5" width="560" align="center"
                    border="0" style="display: none" id="fileUpload">
                    <tbody>
                        <tr>
                            <td align="right" width="104">
                                <p>
                                    标题：</p>
                            </td>
                            <td width="434">
                                <input type="text" id="Text1" style="width: 272px" runat="server">
                                <div id="Div1" style="display: inline;">
                                    <span>不超过15个汉字</span></div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                选择文件：
                            </td>
                            <td>
                                <input type="file" id="File1" runat="server" style="width: 341px; height: 20px" /></td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                                <label>
                                    <asp:Button ID="Button3" runat="server" Text="上传" Width="58px" />
                                    </label></td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>

<script>
function Delete(str)
{
	if(confirm("确定删除所有推荐资源吗?"))
	{ 
	   Register_Control_ImageUploadControl2.Delete(str,backres);
    }
}
 function backres(res)
	{
	    if(res.value=="1")
	    {
	        window.location.reload();
	    }
	}
	function addImage()
	{
	    if(fileUpload.style.display=="none")
	    {
	       fileUpload.style.display="";
	       // Button1.style.display="none";
	    }
	}
</script>

