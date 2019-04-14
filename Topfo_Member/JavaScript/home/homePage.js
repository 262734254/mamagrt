// JScript 文件
//专业服务
function ChangeServiceTab(index){
	var objTabs = document.getElementsByName("ServiceTab");
	var objDetailTabs = document.getElementsByName("ServiceDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
    var preMenuIndex = index - 1;
    
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "off";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "on";
	objDetailTabs[index].style.display = "block";
		if(preMenuIndex == 0)
		objTabs[0].className = "off";
	if(preMenuIndex > 0)
		objTabs[0].className = "off";

}
function initMainService(){
    
	ChangeServiceTab(0);
}
//行业引导
function ChangeLeadTab(index){
	var objTabs = document.getElementsByName("LeadTab");
	var objDetailTabs = document.getElementsByName("LeadDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
    var preMenuIndex = index - 1;
    
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "off_rr";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "on";
	objDetailTabs[index].style.display = "block";
	if(preMenuIndex == 0)
		objTabs[0].className = "off_ll";
	if(preMenuIndex > 0)
		objTabs[0].className = "off_rr";

}
function initMainLead(){
    
	ChangeLeadTab(0);
}
//拓富通会员
function ChangeMemberTab(index){
	var objTabs = document.getElementsByName("MemberTab");
	var objDetailTabs = document.getElementsByName("MemberDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
    var preMenuIndex = index - 1;
    
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "off";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "on";
	objDetailTabs[index].style.display = "block";
		if(preMenuIndex == 0)
		objTabs[0].className = "off";
	if(preMenuIndex > 0)
		objTabs[0].className = "off";

}
function initMainMenber(){
    
	ChangeMemberTab(0);
}

//拓富排行
function ChangeQueueTab(index){
	var objTabs = document.getElementsByName("QueueTab");
	var objDetailTabs = document.getElementsByName("QueueDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
    var preMenuIndex = index - 1;
    
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "off";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "on";
	objDetailTabs[index].style.display = "block";
		if(preMenuIndex == 0)
		objTabs[0].className = "off";
	if(preMenuIndex > 0)
		objTabs[0].className = "off";

}
function initMainQueue(){
    
	ChangeQueueTab(0);
}

//搜索


var SiteURL = "";
function initPostUrl(){
	var PostURL = "/Search/SearchResult.aspx?origin=Index";
	document.getElementById("form_Search").action = SiteURL + PostURL;
	var LastMenu = document.getElementsByName("searchmenu").length - 1;
	document.getElementsByName("searchmenu")[LastMenu].className = "otheroff";
}

function ChangeKeyWord(theKeyWord,KeyName){
	var str = theKeyWord.value;
	document.getElementById("hideKey").value = KeyName;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str ==""){
		theKeyWord.helptext="输入" + KeyName + "关键字进行搜索";
		theKeyWord.value="输入" + KeyName + "关键字进行搜索";
	}
}

function ChangeSearchKeyword(index){
	var PostURL = "";
	var theKeyWord = document.getElementById("txtKeyWord");
	switch(index)
	{
		case 0 : //全部
			PostURL = "/Search/SearchResult.aspx";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"");
			break;
		case 1 : //投资
			PostURL = "/Capital/CapitalSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"资本");
			break;
		case 2 : //融资
			PostURL = "/Project/ProjectSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"企业项目");
			break;
		case 3 : //招商
			PostURL = "/Merchant/MerchantSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"政府项目");
			break;
		case 4 : //资讯
			PostURL = "/News/NewsSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"资讯");
			break;
		default:
			break;
	}
	//alert(document.getElementById("form_Search").action);
}

function focusEdit(theKeyWord){
	if ( theKeyWord.value == theKeyWord.helptext ){
		theKeyWord.value = "";
		theKeyWord.helptext ="";
		alert("1");
	}
	return true;
}
function blurEdit(theKeyWord){
	var KeyName = document.getElementById("hideKey").value;
	if ( theKeyWord.value.length == 0 ){
		theKeyWord.value = "输入" + KeyName + "关键字进行搜索";
		theKeyWord.helptext = "输入" + KeyName + "关键字进行搜索";
		alert(theKeyWord.value);
	}
}
function ClearEdit(theKeyWord){
  	theKeyWord.value ="";
	theKeyWord.helptext ="";
}


function ChangeSearchMenu(index){
	var objs = document.getElementsByName("searchmenu");
	var num = objs.length;
	var preMenuIndex = index - 1;
	for(i=0;i<num;i++)
	{
		objs[i].className = "otheroff";
	}
	objs[num - 1].className = "otheroff";
	if(index==0)
	{
	    objs[index].className = "allon";
	}
	else
	{
	    objs[index].className = "otheron";
	}
	if(index!=0)
	{
	    objs[0].className = "alloff";
	}
	if(preMenuIndex >0){
		objs[preMenuIndex].className = "otheroff";
	}
	ChangeSearchKeyword(index);
}


function doSubmit(){
	var theKeyWord = document.getElementById("txtKeyWord");
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索")
	{
		ClearEdit(theKeyWord);
	}
	document.form_Search.submit();
}
