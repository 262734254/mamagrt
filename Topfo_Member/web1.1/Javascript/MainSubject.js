function ChangeSubjectTab(index){
	var objTabs = document.getElementsByName("SubjectTab");
	var objDetailTabs = document.getElementsByName("SubjectDetailTab");
	var numTabs = objTabs.length;
	var numDetailTabs = objDetailTabs.length;
	var preMenuIndex = index - 1;
	for(i=0;i<numTabs;i++){
		objTabs[i].className = "tbz";
	}
	for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
	objTabs[index].className = "liwai";
	objDetailTabs[index].style.display = "block";
	if(preMenuIndex == 0)
		objTabs[0].className = "tbz1";
	if(preMenuIndex > 0)
		objTabs[0].className = "tbz2";
}
function initMainSubject(){
	ChangeSubjectTab(0);
}