<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectAdd.aspx.cs" Inherits="Subject_SubjectAdd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../css/publish.css"  rel="stylesheet" type="text/css" />
 <link href="../offer/css/member.css" rel="stylesheet" type="text/css" />
    <script src="../offer/js/yanz.js"></script>
  <script language="javascript" type="text/javascript">
  function $id(id)
  {
     return document.getElementById("ctl00_ContentPlaceHolder1_"+id+"");
  }
      function Verify()
      {
          if($id("txtTitle").value=="")
          {
             alert("专题标题不能为空");
             $id("txtTitle").focus();
             return false;
          }
          if($id("txtLinkName").value=="")
          {
              alert("联系人不能为空");
              $id("txtLinkName").focus();
              return false;
          }
          if($id("txtMobile").value=="")
          {
              alert("电话号码不能为空");
              $id("txtMobile").focus();
              return false;
          }
            var inputCode = document.getElementById("validCode").value;   
           if(inputCode.length <=0)   
           {   
               alert("请输入验证码！"); 
                document.getElementById("validCode").focus();
       	             return false;  
           }   
           else if(inputCode.toUpperCase() != code )   
           {   
              alert("验证码输入错误！");   
              createCode();//刷新验证码   
               document.getElementById("validCode").focus();
       	             return false;
           }   
         $id("imgLoding").style.display="block";
 
      } 
       
</script>
  <div class="member-right">
    <div class="publication">
          <h1><span class="fl"><span class="f_14px strong f_cen">发布专题信息需求</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>
        <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
      <tr>
        <td class="publica-td-left" width="20%">
        <span class="hong">*</span>专题标题：</td>
        <td>
        <input type="text" id="txtTitle" runat="server" style="width: 353px; height: 24px" />
        </td>
      </tr>
      <tr>
        <td class="publica-td-left" width="20%">
        <span class="hong"></span>专题说明：</td>
        <td >
          <textarea runat="server" id="txtRemark" style="width: 353px; height: 122px"></textarea>
    </td>
      </tr>
     
    <tr>
        <td class="publica-td-left" width="20%">
            <span class="hong">*</span>联系人：</td>
        <td >
           <input runat="server" id="txtLinkName" type="text" style="width: 145px; height: 24px" />
        </td>
    </tr>
    <tr >
        <td class="publica-td-left" width="20%">
            <span class="hong">*</span>电话号码：</td>
        <td >
           <input runat="server" type="text" id="txtMobile" style="width: 145px; height: 24px" />
        </td>
    </tr>
    <tr>
       <td class="publica-td-left" width="20%">
      <span class="hong">*</span>验证码：</td>
      <td>
      <input  type="text"   id="validCode" /> 
                   <input type="text" onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />
       </td>
       </tr>
            <tr>
            <td colspan="2" id="pub-tongyi">
             <input name="" type="checkbox" value="" checked />
             <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
              <asp:ImageButton ID="IbtnSubmit" OnClientClick="return Verify();" ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" runat="server" OnClick="IbtnSubmit_Click"
              />
               </td>
            </tr>
</table>

    </div>
      </div>
      <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:2500px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="http://member.topfo.com/images/loading42.gif" alt="Loading" />
                </div>
   </div> 
      <script language="javascript">  createCode();</script>
</asp:Content>

