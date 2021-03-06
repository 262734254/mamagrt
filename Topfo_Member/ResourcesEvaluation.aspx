﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourcesEvaluation.aspx.cs"
    Inherits="ResourcesEvaluation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>全部资源--资源超市--中国招商投资网</title>
    <link href="css/resource3.0.css" rel="stylesheet" type="text/css" />
    <%--<base target="_blank">--%>

    <script type="text/javascript">
        function checkRad()
        {
            var flag = false;
            for(var i=1;i<=5;i++)
            {
                var rdPoint = document.getElementById("rdPoint"+i);
                if(rdPoint.checked == true)
                {
                    flag = true;
                }
            }
            return flag;
        }
    </script>

</head>
<body>
    <form runat="server" id="form1">
        <table width="500" align="center" class="con21 f_14px">
            <tr>
                <td align="center" class="f_tit3" style="padding: 20px 0 5px 0;">
                    评价该资源</td>
            </tr>
            <tr>
                <td height="30" style="padding-left: 30px; line-height: 23px;">
                    <input type="radio" name="radiobutton" value="5" runat="server" id="rdPoint5" />
                    非常有价值(5A)<span class="f_yel">★★★★★</span><br />
                    <input type="radio" name="radiobutton" value="4" runat="server" id="rdPoint4" />
                    有价值(4A) <span class="f_yel">★★★★</span><br />
                    <input type="radio" name="radiobutton" value="3" runat="server" id="rdPoint3" />
                    价值一般(3A) <span class="f_yel">★★★</span><br />
                    <input type="radio" name="radiobutton" value="2" runat="server" id="rdPoint2" />
                    没有价值(2A) <span class="f_yel">★★</span><br />
                    <input type="radio" name="radiobutton" value="1" runat="server" id="rdPoint1" />
                    虚假信息(A) <span class="f_yel">★</span>
                </td>
            </tr>
            <tr>
                <td align="center" style="padding-bottom: 20px;">
                    <asp:Button ID="btSubmit" runat="server" Text="提交" CssClass="btn2"
                        OnClick="btSubmit_Click" OnClientClick="return checkRad()" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
