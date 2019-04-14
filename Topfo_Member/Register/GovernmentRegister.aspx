<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="GovernmentRegister.aspx.cs"
    Inherits="Register_GovernmentRegister" %>    
<%@ Register Src="Control/ImageUploadControl.ascx" TagName="ImageUploadControl" TagPrefix="uc4" %>
<%@ Register Src="Control/OrgContactControl.ascx" TagName="OrgContactControl" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:800px;}
        .content p{line-height:30px;        }
        
    </style>  
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
  <script src="../js/jquery.js"type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function $id(obj)
    {
        document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
    }
    function chkPost()
    { 

  

       if(document.getElementById("ctl00_ContentPlaceHolder1_tbGovernmentName").value=="")
		{
			alert("招商机构名称不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbGovernmentName").focus();
			return false;
		}
		
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout").value;
		
		if( obj.length<50  || obj.length==0)
		{
		    alert("招商机构介绍填写不正确，50字数以上!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout").focus();
			return false;
		}		
		
		var obj = document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").value;
		if(obj.length<0 ||obj =="")
		{
		    alert("域名不能为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_tbExhibitionHall").focus();
			return false;
		}
		
		document.getElementById("imgLoding").style.display = "block";
    }
    </script>
<div class="mainconbox">
            <div class="contant_l">
                <div class="titled">
                    <div class="left">
                       
                            登记政府招商机构                    </div>
                    <div class="right">
                       </div>
                    <div class="clear">
                    </div>
              </div>
                <div class="suggestboxs lightc allxian">
                    <h3 class="cu cheng font14">
                        重要提示</h3>
                    <div>
                        ·您发布的招商机构请确保真实有效，由于发布虚假信息产生的任何责任，由发布者自行承担！<br>
                        ·含有详细招商机构信息的招商项目将被更多投资方认可!</div>
              </div>
				<div class="blank0"></div>
                <div > 带<span class="hong">*</span>的为必填项</div>
               <div class="infozi">
                    招商机构基本资料</div>
                <div class="widthTable">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="tabbiank">
                        <tr>
                            <td width="20%" align="right" class="ltitles">
                                <span class="hong">*</span> <strong>招商机构名称：</strong></td>
                            <td width="80%"><asp:TextBox ID="tbGovernmentName" runat="server" Width="306px"></asp:TextBox>  <asp:RequiredFieldValidator
                                        ID="reqEnterpriseName" runat="server" ControlToValidate="tbGovernmentName" ErrorMessage="招商机构名称不能为空"></asp:RequiredFieldValidator>
                        </tr>
                        <tr>
                            <td align="right" class="ltitles">
                                <span class="hong">* </span><strong>机构主体：</strong></td>
                            <td>
                                <asp:DropDownList ID="ddlSubjectType" runat="server" Width="157px">
                                    <asp:ListItem Value="1001">国家经济开发区</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ltitles">
                                <span class="hong">* </span><strong>所属区域：</strong></td>
                            <td>
                                <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="ltitles">
                                <span class="hong">* </span><span class="blue13_b"><strong>招商机构介绍：</strong></span><br>
                          (50-2000字)</td>
                            <td>
                               
                                <div><asp:TextBox ID="tbGovAbout" runat="server" Height="200px" TextMode="MultiLine"
                                        onkeyup="ShowFontCount(this);" Width="441px"></asp:TextBox> 
                                    <br />
                                  <asp:RequiredFieldValidator ID="reqDescript" runat="server" ControlToValidate="tbGovAbout"
                                        ErrorMessage="招商机构不能为空"></asp:RequiredFieldValidator><asp:Label ID="lbMessage" runat="server"
                                            ForeColor="Red"></asp:Label></div>
											 <div class="hui">
                                    请用中文介绍招商机构的相关内容，如果内容过于简单，有可能无法通过审核。<br />

联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核。 

                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="ltitles"><strong>
                              图片上传：</strong></td>
                            <td class="nonepad">
                                <div class="hui">
                                    <uc4:ImageUploadControl ID="ImageUploadControl1" runat="server" InfoType="GovernmentRegister" />
                                    &nbsp;</div>
                          </td>
                        </tr>
                        <tr id="fileDiv" runat="server">
                            <td align="right" class="ltitles"><strong>
                              文件上传：</strong></td>
                            <td>
                           
                            </td>
                        </tr>
                  </table>
                </div>
				<div class="blank0"></div>
               <div class="infozi">
                    联系方式：</div>
                <div class="widthTable">
                    <uc3:OrgContactControl ID="OrgContactControl1" runat="server"></uc3:OrgContactControl> 
                </div>
				<div class="blank0"></div>
              <div class="infozi"> 申请域名建立我的展厅:</div>
                <div class="viewbox lightc cshibiank" >                    我的展厅是我们推出的一项最新服务，方便用户全面展示自己的公司/机构，获得合作方便更多信任。<a href="" class="lanlink">了解更多</a></div>
				<div class="blank0"></div>
                <div >
                    <b><span class="hong">*</span>我的域名：http://<asp:TextBox ID="tbExhibitionHall" runat="server" Width="93px"  ></asp:TextBox>
                  </b><b>.gov.topfo.com</b><span> 只有申请了域名，招商机构介绍才能上网展示!
                  <asp:Label
                        ID="Label1" runat="server"></asp:Label>
                        <input id="Hidden1" type="hidden" runat="server" /></span></div>
                <div class="mbbuttom">
                   <p> <a href="">点此阅读中国招商投资网服务条款</a></p>
              <asp:ImageButton ID="buSend" runat="server" ImageUrl="../images/Company_Manage/arr_06.gif"
                        OnClick="buSend_Click" OnClientClick="return chkPost();" /></div>
            </div>
</div>
                 
 <div id="imgLoding" Style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1800px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>
<script type="text/javascript">



function ShowFontCount(theControl)
{
	var Descript=document.getElementById("ctl00_ContentPlaceHolder1_tbGovAbout");	
    var msg=document.getElementById("ctl00_ContentPlaceHolder1_lbMessage");
    var len=theControl.value.length;
    if( Descript != null )
    {
         msg.innerHTML = "招商机构介绍字数："+len;       
	}	
}	
function CheckDomain(domain,loginName)
{
	if(domain!="")
    {
     AjaxMethod.CheckDomain(domain,loginName,showMessage);
    }	
}
 function sendAjax(){
   var sname=$("#ctl00_ContentPlaceHolder1_tbExhibitionHall").attr("value");
   $.ajax({url:"Ajax.aspx",type:"post",data:"username="+sname,dataType:"text",success:function(req){
  
   if(req=="1")
   {
    alert("域名已经存在");
 $("#ctl00_ContentPlaceHolder1_tbExhibitionHall").focus();

    return false ;
    }   
   }});
 }
function showMessage(res)
{
    var ln = document.getElementById("ctl00_ContentPlaceHolder1_Label1");			
     var hid=document.getElementById("ctl00_ContentPlaceHolder1_Hidden1");
     hid.value=res.value;
    ln.innerHTML ="<font color='red'>"+res.value+"</font>";

   			
}

</script>

</asp:Content>