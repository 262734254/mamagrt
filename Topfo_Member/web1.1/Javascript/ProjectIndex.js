var para = new Array();
para[0] = "<a href='http://www.tz888.cn/exchange/intro2.aspx' target='_blank' ><span style='color:#FF6600;'> 资源付费交易&gt;&gt;</span></a>";
para[1] = "<a href='http://www.tz888.cn/exchange/intro.aspx' target='_blank' ><span style='color:#FF6600;'> 资源免费互换&gt;&gt;</span></a>";
var tag = 0;
function ChangeTodayTab(index){
	var objTabs = document.getElementsByName("TodyTab");
	var objDetailTabs = document.getElementsByName("TodayDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
	var preMenuIndex = index - 1;
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "tb";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "liwai";
	objDetailTabs[index].style.display = "block";
	if(preMenuIndex == 0)
		objTabs[0].className = "tb1";
	if(preMenuIndex > 0)
		objTabs[0].className = "tb2";
}

function RefreshIntroLink(){
	tag = tag % 2;
	obj = document.getElementById("SysIntro");
	obj.innerHTML=para[tag]; 
	tag++;
	setTimeout("RefreshIntroLink()",5000);
}

function initTodayCommend(){
	ChangeTodayTab(0);
	RefreshIntroLink();
}
