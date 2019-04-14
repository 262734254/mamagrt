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

