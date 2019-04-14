<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publishproject3.aspx.cs" Inherits="Publish_Publishproject3" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布融资需求</span></span><span class="fr pb-mg01"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>

        <div class="fbcg">
         <div class="fbcg1">
         <img src="http://img2.topfo.com/member/images/fbcq_03.jpg"  class="fl"/>
         <div class="fbcg1-1">
          <h3>恭喜您的需求已发布成功，已提交审核！</h3>
          <ul>
          <li>重要提示：我们会在一个工作日内审核，审核通过后，您发布的信息会在我们网站展示，被搜索和匹配！</li>
         <li><a href="Professional/PublishProfessional.aspx"><img src="http://img2.topfo.com/member/images/fbcq_06.jpg"  /></a></li>
         <li class="fc30">传真号码：0755-82213698    咨询电话：0755-82210116 82212980</li>
         </ul>
         </div>
         </div>
         
         <div class="fbcg2 "> 
          <span class="hong"><img src="http://img2.topfo.com/member/img/gif-0857.gif" /> 我们为您找到了 <span id="spCount" class="hong">-</span> 条关于"<span><%=this.title %></span>"的匹配资源，或许您的机会就在这里！</span> <a href="../Manage/PertinentLink.aspx?InfoID=<%=this._infoID %>&type=Project" class="lan1">点击查看</a>│<a href="/helper/MatchingInfo.aspx" class="lan1">定阅此类资源</a>
         </div>
           <div class="fbcg3"> 
            <h3>您还可以发布一下相关服务：</h3>
            <ul>
             <li>
             <img src="http://img2.topfo.com/member/images/fbcq_11.jpg"  class="fl"/>
              <div class="fbcg3-1">
               <h4><a href="Professional/PublishProfessional.aspx">发布专业服务需求</a></h4>
               <p>企业有哪些融资新渠道？ 规定：股权出质登记是指以公司股东股权为标的物而设定的质押行为。按照我市工商部门的规定，企业可以按照《江苏省工商行政管理机关公司</p>
               
              </div>
             </li>
            <li>
             <img src="http://img2.topfo.com/member/images/fbcq_15.jpg"  class="fl"/>
              <div class="fbcg3-1">
               <h4><a href="Professional/PublishProtalent.aspx">发布专业服务人才</a></h4>
               <p>企业有哪些融资新渠道？ 规定：股权出质登记是指以公司股东股权为标的物而设定的质押行为。按照我市工商部门的规定，企业可以按照《江苏省工商行政管理机关公司</p>
               
              </div>
             </li>
       
              <li>
             <img src="http://img2.topfo.com/member/images/fbcq_19.jpg"  class="fl"/>
              <div class="fbcg3-1">
               <h4><a href="Professional/PublishProOrg.aspx">申请专业机构需求</a></h4>
               <p>企业有哪些融资新渠道？ 规定：股权出质登记是指以公司股东股权为标的物而设定的质押行为。按照我市工商部门的规定，企业可以按照《江苏省工商行政管理机关公司</p>
               
              </div>
             </li>
            </ul>
            <p class="f_14px f_black">您还可以联系我们专业的线下运作团队帮您解决招商问题，<a href="#" class=" lan1">了解一下专业服务</a></p>
          </div>
        </div>

    </div>
      </div>
         <script type="text/javascript" language="javascript">
    var infoid = <%=this._infoID %>;
    PublishProject.GetMatchCount(infoid,
            function(result){
                   document.getElementById("spCount").innerHTML = result.value;
            });
    </script>
</asp:Content>

