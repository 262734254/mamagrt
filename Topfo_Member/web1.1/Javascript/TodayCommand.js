function GetTabDetailId(tabGroup,tabIndex){
	return "tab" + tabGroup + "_" + tabIndex + "_Detail";
}

function HideTab(tabGroup,tabSum){
	//alert(tabGroup + " " + tabSum);
	for(i = 1; i<=tabSum;i++){
		tabDetailId = GetTabDetailId(tabGroup,i);
		if(i == 1)
			document.getElementById(tabDetailId).style.display="block";
		else
			document.getElementById(tabDetailId).style.display="none";
	}
}

function ChangeTodayTab(index,childSum){
	var objTabs = document.getElementsByName("TodyTab");
	var objDetailTabs = document.getElementsByName("TodayDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
	 
	var preMenuIndex = index - 1;
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "tb";
	}for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	//HideTab(index,childSum);
	objTabs[index].className = "liwai";
	objDetailTabs[index].style.display = "block";
	if(preMenuIndex == 0)
		objTabs[0].className = "tb1";
	if(preMenuIndex > 0)
		objTabs[0].className = "tb2";
}

function changeMenu(tabGroup,tabIndex,tabSum){
	for(i=1;i<=tabSum;i++)
	{
		tabId = "tab" + tabGroup + "_" + i + "";
		pretabIndex = tabIndex - 1;
		
		pretabId = "tab" + tabGroup + "_" + pretabIndex + "";
		tabDetailId = tabId + "_Detail";

		document.getElementById(tabId).className = "";
		document.getElementById(tabDetailId).style.display="none";
		
		if(i == tabSum)
		{
			document.getElementById(tabId).className = "linone";
		}
		if(tabIndex != 1)
		{
			document.getElementById(pretabId).className = "linone";
		}
		if(i == tabIndex)
		{
			document.getElementById(tabId).className = "liwai";
			document.getElementById(tabDetailId).style.display = "block";
		}
	}
}

function initTodayCommend(){
	ChangeTodayTab(0);
	changeMenu(0,1,4);
	RefreshIntroLink();
}

function changeMenu(tabGroup,tabIndex,tabSum){
	for(i=1;i<=tabSum;i++)
	{
		tabId = "tab" + tabGroup + "_" + i + "";
		pretabIndex = tabIndex - 1;
		
		pretabId = "tab" + tabGroup + "_" + pretabIndex + "";
		tabDetailId = tabId + "_Detail";

		document.getElementById(tabId).className = "";
		document.getElementById(tabDetailId).style.display="none";
		
		if(i == tabSum)
		{
			document.getElementById(tabId).className = "linone";
		}
		if(tabIndex != 1)
		{
			document.getElementById(pretabId).className = "linone";
		}
		if(i == tabIndex)
		{
			document.getElementById(tabId).className = "liwai";
			document.getElementById(tabDetailId).style.display = "block";
		}
	}
}