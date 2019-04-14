<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Publishproject2.aspx.cs"
    Inherits="agent_Publish_Publishproject2" Title="融资需求-拓富指数评估" %>

<%@ Register Src="../Controls/TFZSEvaluateGQ.ascx" TagName="TFZSEvaluateGQ" TagPrefix="uc2" %>
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
<link href="../css/common.css" rel="stylesheet" type="text/css" />

<form id="Form1" runat="server">
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布融资需求
            </div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank" class="lanlink">
                    需求发布规则</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="stepsbox">
            <ul>
                <li style="width: 149px">第1步 填写项目信息 </li>
                <li class="liimg">
                    <img src="../images/publish/projectbg.gif" align="left" /></li>
                <li class="liwai" style="width: 171px">第2步 项目投资价值评估 </li>
                <li class="liimg">
                    <img src="../images/publish/projectbg.gif" align="left" /></li>
                <li class="lishort">第3步 发布成功</li>
            </ul>
            <div class="clear ">
            </div>
        </div>
        <div class="blank20">
        </div>
        <div class="suggestbox lightc allxian">
            <h1>
                您的项目基本资料已经成功发布！</h1>
            <p>
                接下来请进行“项目投资价值评估”，获得拓富指数！ &nbsp; <a href="http://www.topfo.com/help/TopfoZS.shtml#11"
                    target="_blank" class="lanlink">什么是拓富指数？</a></p>
        </div>
        <div class="blank6">
        </div>
        <div class="advantabox">
            <h1>
                参与项目投资价值评估的<i>3</i>大优势
            </h1>
            <div class="clear">
            </div>
            <ul>
                <li>
                    <img src="../images/publish/biao_02.gif" width="14" height="14" />
                    投资机构更多选择拓富指数高的项目</li>
                <li>
                    <img src="../images/publish/biao_02.gif" width="14" height="14" />
                    让您对项目的优缺点一目了然，帮助您改进项目质量</li>
                <li>
                    <img src="../images/publish/biao_02.gif" width="14" height="14" />
                    全球首创项目自助评估系统，完全免费</li>
            </ul>
            <p>
                <a href="http://www.topfo.com/help/TopfoZS.shtml" target="_blank" class="lanlink">详细了解一下</a>&nbsp;
                <asp:imagebutton imageurl="../images/publish/buttom_cypg.gif" runat="server" id="IbtnShow" />
            </p>
            <input id="hdIsShow" type="hidden" value="N" size="1" runat="server" />
            <div id="divPanel" style="display: none;">
                <p>
                    <uc2:TFZSEvaluateGQ ID="TFZSEvaluateGQ1" runat="server"></uc2:TFZSEvaluateGQ>
                </p>
            </div>
            <div class="dottedlline">
            </div>
            <div align="center">
                <asp:button id="btnSubmit" runat="server" text="保存评价并完成发布" width="146px" onclick="btnSubmit_Click"
                    class="buttomal" />
                &nbsp; &nbsp;&nbsp; &nbsp;<asp:button id="btnJump" runat="server" text="跳过此步骤" width="80px"
                    class="buttomal" onclick="btnJump_Click" />
            </div>
        </div>
    </div>
</form>

<script type="text/javascript" language="javascript">
    function show()
    {
        var id = "<%=this.hdIsShow.ClientID %>";
        var obj = document.getElementById(id);
        
        if(obj.value == 'N'){
            document.getElementById("divPanel").style.display = "block";
            obj.value = 'Y';
        }
        else
        {
            document.getElementById("divPanel").style.display = "none";
            obj.value = 'N';
        }
    }
    
    function checkMyTFZSform()
    {
        var id = "<%=this.hdIsShow.ClientID %>";
        var obj = document.getElementById(id);
        
        if(obj.value == 'N'){
            return false;
        }
        
        return CheckTFZSForm();
    }
</script>

