<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EquityRaised_Update2.aspx.cs" Inherits="Publish_project_EquityRaised_Update2"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function chkpost() {
            alert("中国招商投资");
            var c = "ctl00_ContentPlaceHolder1_";
            var kj = "";
            var zt = "";
            var obj = "";

            //标题
            var ProjectName = "ctl00_ContentPlaceHolder1_txtProjectName";
            if (document.getElementById(ProjectName).value == "") {
                alert("项目标题不能为空...");
                document.getElementById(ProjectName).focus();
                return;
            }
        }
    </script>

    <div id="step1" style="display: block;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span>
                </td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="145" class="tdbg">
                    <span class="f_red">*</span> <strong>项目标题：</strong>
                </td>
                <td>
                    <input id="txtProjectName" style="width: 286px" size="15" runat="server" />
                    <span class="f_gray">标题最好控制在25个字以内</span>
                </td>
            </tr>
        </table>
        <asp:Button ID="btOK" runat="server" OnClick="btOK_Click" />
    </div>
</asp:Content>
