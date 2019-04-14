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

function ChangeTodayTab(index){
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
	{	     
		objTabs[0].className = "tb2";
	}	
	
	if(index>2)
	{	    
	    document.getElementById("DispUp").style.display="none";
	    document.getElementById("DispDown").style.display="block";	    
	}
	else
	{	     
	   document.getElementById("DispUp").style.display="block";
	   document.getElementById("DispDown").style.display="none";
	}
	 
	if(index=="0")
	{		    
	    document.getElementById("UserCenter_Inner").style.display="block";
	    document.getElementById("dgInner").style.display="none";	   
	    fillGrid("dgInner","dgGetInner");
	}	 
	
	if(index=="1")
	{	
	    document.getElementById("UserCenter_divMsgToMe").style.display="block";
	    document.getElementById("dgMsgToMe").style.display="none";	   
	    fillGrid("dgMsgToMe","dgGetRecieveMsg");
	}
	
	if(index=="2")
	{	  
	    document.getElementById("UserCenter_DingYue").style.display="block";
	    document.getElementById("dgMyDingYue").style.display="none";	   
	    fillGrid("dgMyDingYue","dgGetDingYue");	    
	}
	
	if(index=="3")
	{   
	    document.getElementById("UserCenter_FocuseMe").style.display="block";
	    document.getElementById("dgFocuseMe").style.display="none";
	    fillGrid("dgFocuseMe","dgGetFocuseMe");	
	}	 
	
	if(index=="5")
	{	     
	    document.getElementById("UserCenter_Cart").style.display="block";
	    document.getElementById("dgCart").style.display="none";	   
	    fillGrid("dgCart","dgGetCart");	    
	    document.getElementById("UserCenter_Cart").style.display="none";
	    document.getElementById("dgCart").style.display="block"
	}	 
}

function ChangeTodayTabIndex(index){
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
	objTabs[index].className = "on";
	objTabs[2].className="last";
	objTabs[5].className="last";
	if(index==2)
	{
		objTabs[index].className = "on2";
		objTabs[5].className="last";
	}
	if(index==5)
	{
		objTabs[index].className = "on2";
		objTabs[2].className="last";
	}
	
	objDetailTabs[index].style.display = "block";
	if(preMenuIndex == 0)
		objTabs[0].className = "tb1";
	if(preMenuIndex > 0)
	{	     
		objTabs[0].className = "tb2";
	}	
	
	if(index>2)
	{	    
	    document.getElementById("DispUp").style.display="none";
	    document.getElementById("DispDown").style.display="block";	    
	}
	else
	{	     
	   document.getElementById("DispUp").style.display="block";
	   document.getElementById("DispDown").style.display="none";
	}
	 
	if(index=="0")
	{		    
	    document.getElementById("UserCenter_Inner").style.display="block";
	    document.getElementById("dgInner").style.display="none";	   
	   // fillGrid("dgInner","dgGetInner");
	}	 
	
	if(index=="1")
	{	
	    document.getElementById("UserCenter_divMsgToMe").style.display="block";
	    document.getElementById("dgMsgToMe").style.display="none";	   
	    //fillGrid("dgMsgToMe","dgGetRecieveMsg");
	}
	
	if(index=="2")
	{	  
	    document.getElementById("UserCenter_DingYue").style.display="block";
	    document.getElementById("dgMyDingYue").style.display="none";	   
	   // fillGrid("dgMyDingYue","dgGetDingYue");	    
	}
	
	if(index=="3")
	{   
	    document.getElementById("UserCenter_FocuseMe").style.display="block";
	    document.getElementById("dgFocuseMe").style.display="none";
	   // fillGrid("dgFocuseMe","dgGetFocuseMe");	
	}	 
	
	if(index=="5")
	{	     
	    document.getElementById("UserCenter_Cart").style.display="block";
	    document.getElementById("dgCart").style.display="none";	   
	    fillGrid("dgCart","dgGetCart");	    
	    document.getElementById("UserCenter_Cart").style.display="none";
	   // document.getElementById("dgCart").style.display="block"
	}	 
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