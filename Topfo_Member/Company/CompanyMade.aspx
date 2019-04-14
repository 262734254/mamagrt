<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyMade.aspx.cs" Inherits="Company_CompanyMade" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<style type="text/css">
        #add001 tbody td{ color:#0c70df}
		.xunze{ text-align:left; margin-left:10px}
		.xunze li{ height:32px; line-height:32px}
		
        </style>--%> 
<script language="javascript" type="text/javascript" src="../js/twoCalendar.js"></script>
<script language="javascript" type="text/javascript">  
   function CheckIndex()
   { 
    var tb = document.getElementById("ctl00_ContentPlaceHolder1_cblIndex"); 
    for(var i=0;i < tb.rows.length;i++)         
    {
        var chk = tb.rows[i].firstChild.firstChild;
       if(chk != event.srcElement)                 
       {   chk.checked = false;}         
     }     
 } 
 function CheckRz()
   { 
    var tb = document.getElementById("ctl00_ContentPlaceHolder1_cblRz"); 
    for(var i=0;i < tb.rows.length;i++)         
    {
        var chk = tb.rows[i].firstChild.firstChild;
       if(chk != event.srcElement)                 
       {   chk.checked = false;}         
     }     
 } 
 function CheckTz()
   { 
    var tb = document.getElementById("ctl00_ContentPlaceHolder1_cblTz"); 
    for(var i=0;i < tb.rows.length;i++)         
    {
        var chk = tb.rows[i].firstChild.firstChild;
       if(chk != event.srcElement)                 
       {   chk.checked = false;}         
     }     
 } 
 function CheckZs()
   { 
    var tb = document.getElementById("ctl00_ContentPlaceHolder1_cblZs"); 
    for(var i=0;i < tb.rows.length;i++)         
    {
        var chk = tb.rows[i].firstChild.firstChild;
       if(chk != event.srcElement)                 
       {   chk.checked = false;}         
     }     
 }
   
   function Mid()
   {
      var index="<%=this.cblIndex.ClientID %>";
      var Rz="<%=this.cblRz.ClientID %>";
      var Tz="<%=this.cblTz.ClientID %>";
      var Zs="<%=this.cblZs.ClientID %>";
      if(GetChenckBox(index)==0 & GetChenckBox(Rz)==0 &GetChenckBox(Tz)==0 &GetChenckBox(Zs)==0)
      {
          alert("请至少选择一个广告定制");
          return false;
      }
      
      var beg=document.getElementById("ctl00_ContentPlaceHolder1_begTime").value;
      var end=document.getElementById("ctl00_ContentPlaceHolder1_endTime").value;
      var d1 = new Date(beg.replace(/-/g,"/"));  //把所有的“-”转成“/”
      var d2 = new Date(end.replace(/-/g,"/"));
      if(beg.length<=0)
      {
         alert("请输入开始日期");
         document.getElementById("ctl00_ContentPlaceHolder1_begTime").focus();
         return false;
      }else if(end.length<=0)
      {
          alert("请输入结束日期");
          document.getElementById("ctl00_ContentPlaceHolder1_endTime").focus();
          return false;
      }else
      {
        if(Date.parse(d1) > Date.parse(d2))  
       {
          alert("开始日期不能大于结束日期！");
          return false;
       }
      }
      var man=document.getElementById("ctl00_ContentPlaceHolder1_LinkName");
      if(man.value=="")
      {
          alert("请填写联系人！");
          man.focus();
          return false;
      } 
      var tel=document.getElementById("ctl00_ContentPlaceHolder1_TelPhone");
      if(tel.value=="")
      {
          alert("请填写电话号码！");
          tel.focus();
          return false;
      }
    var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
    var Temail=document.getElementById("ctl00_ContentPlaceHolder1_Email");
    if(!filtEmial.test(Temail.value))
    {
         alert("电子邮箱格式不正确，请重新输入");
         Temail.focus();
         return false;
     }
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
      <h1><span class="fl"><span class="f_14px strong f_cen">广告定制</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://emarketing.topfo.com/ADbusiness/index.html" target="_blank" class="publica-fbxq">广告服务</a></span></h1>
   
        
     <div class="manage" >
     <table width="100%" border="0" cellspacing="0" cellpadding="0"  id="add001">
      <thead>
  <tr>
    <td width="12%">频道</td>
    <td width="26%">广告位</td>
    <td width="20%">尺寸</td>
    <td width="20%">价格</td>
    <td style="width: 156px">选择</td>
  </tr>
  </thead>
  <tbody>
  <tr>
    <td rowspan="9" ><span class="lanl f_14px" >首页</span></td>
    <td>顶部通栏</td>
    <td>640*97px</td>
    <td>2万元/月</td>
    <td rowspan="9" style="width: 156px" > 
    <div class="xunze">

      <asp:CheckBoxList onclick="javascript:CheckIndex();"    ID="cblIndex" runat="server" Width="144px"  >  
         <asp:ListItem   Value="A1">顶部通栏</asp:ListItem>   
         <asp:ListItem   Value="A2">首页轮换</asp:ListItem>  
         <asp:ListItem   Value="A3">右上小块</asp:ListItem>   
         <asp:ListItem   Value="A4">右上大块</asp:ListItem>
         <asp:ListItem   Value="A5">中屏通栏</asp:ListItem>  
         <asp:ListItem   Value="A6">右下方块</asp:ListItem> 
         <asp:ListItem   Value="A7">品牌栏目</asp:ListItem>   
         <asp:ListItem   Value="A8">左底部栏</asp:ListItem>  
         <asp:ListItem   Value="A9">右底部栏</asp:ListItem> 
          </asp:CheckBoxList> 
    </div>   </td>
  </tr>
  <tr>
    <td>首页轮换</td>
    <td>718*217px</td>
    <td>8千元/帧/月</td>
    </tr>
  <tr>
    <td>右上小方块</td>
    <td>230*95px</td>
    <td>6千元/月</td>
    </tr>
    <tr>
    <td>右上大方块</td>
    <td>300*170px</td>
    <td>8千元/月</td>
    </tr>
    <tr>
    <td>中屏通栏</td>
    <td>960*90px</td>
    <td>1.2万元/月</td>
    </tr>
  <tr>
    <td>右下方块</td>
    <td>312*88px</td>
    <td>5千元/月</td>
    </tr>
  <tr>
    <td>品牌推广栏目</td>
    <td>145*124px</td>
    <td>4800元/月</td>
    </tr>
  <tr>
  <td>底部通栏（左）</td>
    <td>640*97px</td>
    <td>3800元/月</td>
    </tr>
  <tr>
  <td>底部通栏（右）</td>
    <td>312*97px</td>
    <td>4800元/月</td>
    </tr>
   <tr>
    <td rowspan="7" ><span class="lanl f_14px">融资</span></td>
    <td>顶部左方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    <td rowspan="7" style="width: 156px"><div class="xunze">
        <asp:CheckBoxList ID="cblRz" onclick= "javascript:CheckRz();" runat="server" Height="191px" Width="144px" >
            <asp:ListItem Value="B1" >顶部左块</asp:ListItem>
            <asp:ListItem Value="B2" >顶部中间</asp:ListItem>
            <asp:ListItem Value="B3" >顶部右块</asp:ListItem>
            <asp:ListItem Value="B4" >内页轮播</asp:ListItem>
            <asp:ListItem Value="B5" >右上方块</asp:ListItem>
            <asp:ListItem Value="B6" >中上通栏</asp:ListItem>
            <asp:ListItem Value="B7" >中下通栏</asp:ListItem>
        </asp:CheckBoxList></div>
        </td>
  </tr>
 
  <tr>
    <td>顶部中间</td>
    <td>664*80px</td>
    <td>5千元/月</td>
    </tr>
  <tr>
    <td>顶部右方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    </tr>
  <tr>
  <td>内页轮播</td>
    <td>400*150px</td>
    <td>2千元/帧/月</td>
    </tr>
    <tr>
    <td>右上方块</td>
    <td>260*90px</td>
    <td>2千元/月</td>
    </tr>

  <tr>
  <td>中上通栏</td>
    <td>960*90px</td>
    <td>6千元/月</td>
    </tr>
  <tr>
  <td>中下通栏</td>
    <td>960*90px</td>
    <td>4800元/月</td>
    </tr>
  
   <tr>
    <td rowspan="8" ><span class="lanl f_14px">投资</span></td>
    <td>顶部左方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    <td rowspan="8" style="width: 156px">
    <div class="xunze">

        <asp:CheckBoxList runat="server" onclick= "javascript:CheckTz();"  ID="cblTz" Width="141px" >
          <asp:ListItem Value="C1">顶部左块</asp:ListItem>
          <asp:ListItem Value="C2">顶部中间</asp:ListItem>
          <asp:ListItem Value="C3">顶部右块</asp:ListItem>
          <asp:ListItem Value="C4">右上方块</asp:ListItem>
          <asp:ListItem Value="C5">中上通栏</asp:ListItem>
          <asp:ListItem Value="C6">左下方块</asp:ListItem>
          <asp:ListItem Value="C7">中下通栏</asp:ListItem>
          <asp:ListItem Value="C8">右下方块</asp:ListItem>
          </asp:CheckBoxList>
    </div>
    </td>
  </tr>
  <tr>
    <td>顶部中间</td>
    <td>664*80px</td>
    <td>5千元/月</td>
    </tr>
  <tr>
    <td>顶部右方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    </tr>
  <tr>
    <td>右上方块</td>
    <td>260*90px</td>
    <td>2千元/月</td>
    </tr>
  <tr>
  <td>中上通栏</td>
    <td>960*90px</td>
    <td>6千元/月</td>
    </tr>
  <tr>
  <td>左下方块</td>
    <td>310*80px</td>
    <td>2千元/月</td>
    </tr>
  <tr>
  <td>中下通栏</td>
    <td>960*90px</td>
    <td>4800元/月</td>
    </tr>
  <tr>
  <td>右下方块</td>
    <td>260*110px</td>
    <td>1千元/月</td>
    </tr>
    
    <tr>
    <td rowspan="8" ><span class="lanl f_14px">招商</span></td>
    <td>顶部左方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    <td rowspan="8" style="width: 156px">
    <div class="xunze">

        <asp:CheckBoxList runat="server" onclick= "javascript:CheckZs();"  ID="cblZs" Width="141px" >
          <asp:ListItem Value="D1">顶部左块</asp:ListItem>
          <asp:ListItem Value="D2">顶部中间</asp:ListItem>
          <asp:ListItem Value="D3">顶部右块</asp:ListItem>
          <asp:ListItem Value="D4">中上通栏</asp:ListItem>
          <asp:ListItem Value="D5">右下方块</asp:ListItem>
          <asp:ListItem Value="D6">左下方块</asp:ListItem>
          </asp:CheckBoxList>
    </div>
    </td>
  </tr>
  <tr>
    <td>顶部中间</td>
    <td>664*80px</td>
    <td>5千元/月</td>
    </tr>
  <tr>
    <td>顶部右方块</td>
    <td>130*80px</td>
    <td>1千元/月</td>
    </tr>
  <tr>
    <td>中上通栏</td>
    <td>960*90px</td>
    <td>6千元/月</td>
    </tr>


  <tr>
  <td>右下方块</td>
    <td>220*80px</td>
    <td>2000千元/月</td>
    </tr>
    <tr>
  <td>左下方块</td>
    <td>960*90px</td>
    <td>4800千元/月</td>
    </tr>
  </tbody>
  

  <tr>
    <td colspan="5">
    <table width="100%">
    <tr>
    <td class="f_14px">开始时间:</td>
    <td align="left">
    <input type="text" class="text" id="begTime" name="begTime" runat="server"
									   onfocus="if(this.value==''){this.value='';this.style.color='#000';}MyCalendar.SetDate(this) "  
									   onblur="if(this.value=='') {this.value='';this.style.color='#888';}" />
    <%--<input runat="server" type="text" id="begTime" class="pawwword-input" onclick="WdatePicker({lang:'zh-cn'})"/>
    <img onclick="WdatePicker({el:$dp.$('ctl00_ContentPlaceHolder1_begTime')})" alt="" src="../My97DatePicker/skin/datePicker.gif"  style="cursor:pointer" />--%>
    </td>
    <td class="f_14px">结束时间:</td>
    <td align="left">
    <input type="text" class="text" id="endTime" name="endTime" runat="server"
									   onfocus="if(this.value==''){this.value='';this.style.color='#000';}MyCalendar.SetDate(this) "  
									   onblur="if(this.value=='') {this.value='';this.style.color='#888';}" />
    <%--<input runat="server" type="text" id="endTime" class="pawwword-input" onclick="WdatePicker({lang:'zh-cn'})" />
    <img onclick="WdatePicker({el:$dp.$('ctl00_ContentPlaceHolder1_endTime')})" alt="" src="../My97DatePicker/skin/datePicker.gif"  style="cursor:pointer" />--%>
    </td>
    </tr>
    <tr>
    <td colspan="4" style="text-align:left;" class="f_14px">
     联 系 人:<input name="" id="LinkName" runat="server" type="text"  class="pawwword-input"/>
     
        </td>
    </tr>
     <tr>
    <td colspan="4" style="text-align:left;" class="f_14px">
     联系电话:<input name="" type="text" id="TelPhone" runat="server"  class="pawwword-input"/></td>
    </tr>
     <tr>
    <td colspan="4" style="text-align:left;" class="f_14px">
     E - mail:<input name="" type="text" id="Email" runat="server"  class="pawwword-input"/>
     <span class="hong">示例:xxx@xx.com</span></td>
    </tr>
    <tr>
    <td colspan="4">
    <div style="text-align:left;">

    <asp:ImageButton runat="server" ImageUrl="http://img2.topfo.com/member/images/forget-mima1_19-1.jpg" ID="btnAdd" OnClientClick="return Mid();" OnClick="btnAdd_Click" />
    </div>
    </td>
    </tr>
    </table>

     </td>
    </tr>
</table>


    </div>
    
      </div>
</div>
</asp:Content>

