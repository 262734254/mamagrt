<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Publish_Professional_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script language="javascript">
    function ac()
    {
    var i=0;
    alert('aaa');
    Publish_Professional_Default.DeleteMethod(i)
    }
    function Del()
    {
    if(confirm('确认要删除吗！'))
 {
 return true;
 }
 else{
 return false;
 }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="javascript:ac()" onclick='javascript:Del()'>a</a>
            <asp:Button ID="Button1" runat="server" Text="Button" /></div>
    </form>
</body>
</html>
