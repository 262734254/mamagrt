<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NarrowAdd.aspx.cs" Inherits="Company_NarrowAdd" Title="Untitled Page" %>

<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
 <%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
 function    CheckIndex()
    {        
     var tb = document.getElementById("ctl00_ContentPlaceHolder1_cblMangeType");
    for(var i=0;i < tb.rows.length;i++)         
    {
       for(var j =0; j < tb.rows[i].cells.length; j++)
        {
           var chk = tb.rows[i].cells[j].firstChild;
          if(chk!= null && chk != event.srcElement)                 
           {                       
               chk.checked = false;                 
            }         
         } 
     }    
     } 
     function SelectAll()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
		    if(elem[i].checked!=true)			
			    elem[i].click();
		}
    }
}

function ReSelect()
{
    if(!document.getElementById("cbxSelect"))
        return;
    var obj = document.getElementById("cbxSelect");
    elem=obj.form.elements;
    for(i=0;i<elem.length;i++)
    {          
		if(elem[i].type=="checkbox" && elem[i].id=="cbxSelect")
		{
			    elem[i].click();
		}
    }
}
  
function Dopost()
{
  if(jg("txtTitle").value=="")
  {
     alert("标题不能为空！");
     jg("txtTitle").focus();
     return false;
  }
   var index="<%=this.cblMangeType.ClientID %>";
   if(GetChenckBox(index)==0)
   {
      alert("会员类型不能为空");
      return false;
   }
   if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
	{
      alert("请选择所属区域");
     
      return false;
	}
	document.getElementById("imgLoding").style.display="block";
}
function DoGet()
{
    var a = document.documentElement.getElementsByTagName("input");
	var str="";
	for (var i=0; i<a.length; i++) 
	{
		if (a[i].type == "checkbox")
		{
			if(a[i].checked)
			{
				str+=a[i].value+",";
			}
		}
	}
	if(str=="on,")
	{
	   alert("请选择您要窄告的用户");
	   return false;
	}
		
}
  
  
function jg(id)
{
   return document.getElementById("ctl00_ContentPlaceHolder1_"+id);
}
function GetChenckBox(chenckName)
{
   var flag1=0;
    var checkobj = document.getElementById(chenckName);
    var checks = checkobj.getElementsByTagName("input");
    for(var n=0;n<checks.length;n++)
    {
        if(checks[n].type=="checkbox" && checks[n].checked==true)
        {
            flag1=1;
        }
    }
    return flag1;

} 
    
      
</script>

<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">窄告定制</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://emarketing.topfo.com/ADbusiness/index.html" target="_blank" class="publica-fbxq">广告服务</a></span></h1>
   
        
     <div class="manage" >
     <table width="100%">
    <tr>
    <td class="f_14px"  style="text-align:right; width:15%; height: 26px;"><span class="hong">*</span>标题:</td>
    <td style="text-align:left; height: 26px;">
    <input runat="server" id="txtTitle" type="text" style="width: 299px; height: 21px" /></td>
    </tr>
    <tr>
    <td style="text-align:right; height: 50px;" class="f_14px">
     描述:</td>
     <td style="text-align:left; height: 50px;">
     <textarea runat="server" id="txtDescript" style="width: 303px; height: 81px"></textarea>
     </td>
    </tr>
    <tr>
    <td style="text-align:right; height: 27px;" class="f_14px">
     链接地址:</td>
     <td style="text-align:left; height: 27px;">
     <input runat="server" id="txtUrl" type="text" style="width: 295px; height: 20px" />
     </td>
    </tr>
     <tr>
    <td style="text-align:left;" class="f_14px" colspan="2">
     设置搜索条件:
     </td>
    </tr>
     <tr>
    <td style="text-align:right;" class="f_14px">
     <span class="hong">*</span>会员类型:</td>
     <td style="text-align:left;">
     <asp:CheckBoxList runat="server" ID="cblMangeType" RepeatColumns="4"  onclick="javascript:CheckIndex();"  RepeatLayout="Table" RepeatDirection="Horizontal" Width="250px">
     <asp:ListItem Value="all">全部</asp:ListItem>
     <asp:ListItem Value="Project">项目方</asp:ListItem>
     <asp:ListItem Value="Capital">投资方</asp:ListItem>
     <asp:ListItem Value="Merchant">招商方</asp:ListItem>
     </asp:CheckBoxList>
     </td>
    </tr>
    
    <tr>
    <td style="text-align:right;" class="f_14px">
     所属区域:</td>
     <td style="text-align:left;">
     <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
     </td>
    </tr>
    
<%--    <tr>
    <td style="text-align:right;" class="f_14px">
     所属行业:</td>
     <td style="text-align:left;">
     <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
     </td>
    </tr>--%>
    
    <tr>
    <td colspan="2" style="text-align:center">
    <asp:ImageButton runat="server" ImageUrl="http://img2.topfo.com/member/images/forget-mima1_19-03.jpg" ID="btnAdd" OnClientClick="return Dopost();" OnClick="btnAdd_Click"   />
    </td>
    </tr>
    </table>
    <div id="imgLoding" Style="position: absolute; 
   display:none; background-color:#A9A9A9;
  top: 200px; text-align:right; width: 100%;
   height:700px; border-left:5px"><%--background-color: #A9A9A9; --%>

               <div style="text-align:center;margin-top:260px" >
                <p>
                    数据正在提交,请稍候...</p>
                <img src="http://img2.topfo.com/member/images/img.gif" alt="Loading"  />
                </div>
        </div>
    <div runat="server" id="spanId" style="display:none">
     <table width="100%" border="0" cellspacing="0" cellpadding="0"  id="add001">
      <thead>
  <tr>
    <td width="12%">
    <a href="Javascript:SelectAll();">全</a>/<a href="Javascript:ReSelect();">反</a></td>
    <td width="26%">帐号</td>
    <%--<td width="20%">行业</td>--%>
    <td width="20%">省份</td>
    <td width="22%">会员类型</td>
  </tr>
  </thead>
  <tbody>
     <asp:Repeater ID="RfList" runat="server">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <label>
                        <input type="checkbox" name="cbxSelect" id="cbxSelect" value="<%#Eval("LoginID")%>" />
                    </label>
                </td>
                <td align="center">
                    <%#Eval("LoginName") %>
                </td>
                <%-- <td align="center">
                  食品饮料
                </td>--%>
                <td align="center">
                    <%#this.ProvinceName(Convert.ToString(Eval("ProvinceID")))%>
              </td>
                <td align="center">
                  <%#this.SumName(Convert.ToString(Eval("ManageTypeID"))) %> 
              </td>
        </ItemTemplate>
      </asp:Repeater>
  </tbody>
</table>
<table border="0" width="100%"  >
        <tr>
            
            <td style="width:80%">
            <cc1:Pager ID="Pager1" runat="server" BackColor="Transparent" BorderStyle="None"
                    PagerStyle="CustomAndNumeric" ControlToPaginate="RfList" PagingMode="NonCached"
                    UseCustomDataSource="False" ShowCount="true"  SortType="DESC"
                     ContentPlaceHolder="ContentPlaceHolder1" 
                    ShowPageCount="true" ></cc1:Pager>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="left">
            <asp:ImageButton runat="server" ImageUrl="http://img2.topfo.com/member/images/forget-mima1_19-1.jpg" ID="IbtSe" OnClientClick="return DoGet();" OnClick="IbtSe_Click"    />

        </td>
        </tr>
    </table>

</div>

    </div>
    
      </div>
</div>
</asp:Content>

