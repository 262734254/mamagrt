<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object s, EventArgs e)
    {
  
        
        
    }
    
    //图片上传
    protected void viewImg_Click(object sender, EventArgs e)
    {
        string Name = FileUpload1.FileName;
        string TimeName = DateTime.Now.ToString("yyyyMMddhhmmss");
        string fe = Name.Substring(Name.LastIndexOf(".") + 1).ToLower();
        //先将原图放到Images文件夹

        string Soft = Server.MapPath("../img/") + TimeName + "." + fe;
        if (fe == "jpg" || fe == "gif" || fe == "bmp")
        {
            FileUpload1.SaveAs(Soft);
            Hidden1.Value = "Img/" + TimeName + "." + fe;
        }
        else
        {
            Label1.Text = "<font color=\"red\">只能上传jpg,gif,bmp格式的图片</font>";
        }
    }

  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>上传页面</title>
    <script src="../js/jquery.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

function isClose()
{
     <% string id  = Request.QueryString["Id"]; %>
    <% Response.Write("var text=window.opener.document.getElementById('"+id+"');var t=window.opener.document.getElementById('img');"); %>
    if(document.getElementById("Hidden1").value!=''){
        text.value=document.getElementById("Hidden1").value;
t.src="../"+document.getElementById("Hidden1").value;

        close();
    }
}
</script>
</head>
<body onload="isClose();">
    <form id="form1" runat="server">
        <br />
        <input id="Hidden1" type="hidden" runat="server" value="" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="上传" OnClick="viewImg_Click"  />

        <asp:Label ID="Label1" ForeColor="red" runat="server" />
    

    </form>
</body>
</html>
