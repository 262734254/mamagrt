var SiteURL = "";
function initPostUrl(){
	var PostURL = "/Search/SearchResult.aspx?origin=Index";
	document.getElementById("form_Search").action = SiteURL + PostURL;
	var LastMenu = document.getElementsByName("searchmenu").length - 1;
	document.getElementsByName("searchmenu")[LastMenu].className = "bottom1";
}

function ChangeKeyWord(theKeyWord,KeyName){
	var str = theKeyWord.value;
	document.getElementById("hideKey").value = KeyName;
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str ==""){
		theKeyWord.helptext="����" + KeyName + "�ؼ��ֽ�������";
		theKeyWord.value="����" + KeyName + "�ؼ��ֽ�������";
	}
}

function ChangeSearchKeyword(index){
	var PostURL = "";
	var theKeyWord = document.getElementById("txtKeyWord");
	switch(index)
	{
		case 0 : //ȫ��
			PostURL = "/Search/SearchResult.aspx";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"");
			break;
		case 1 : //Ͷ��
			PostURL = "/Capital/CapitalSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"Ͷ��");
			break;
		case 2 : //����
			PostURL = "/Project/ProjectSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"����");
			break;
		case 3 : //����
			PostURL = "/Merchant/MerchantSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"����");
			break;
		case 4 : //��Ѷ
			PostURL = "/News/NewsSearchResult.aspx?origin=Index";
			document.getElementById("form_Search").action = SiteURL + PostURL;
			ChangeKeyWord(theKeyWord,"��Ѷ");
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
	}
	return true;
}
function blurEdit(theKeyWord){
	var KeyName = document.getElementById("hideKey").value;
	if ( theKeyWord.value.length == 0 ){
		theKeyWord.value = "����" + KeyName + "�ؼ��ֽ�������";
		theKeyWord.helptext = "����" + KeyName + "�ؼ��ֽ�������";
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
		objs[i].className = "bottom";
	}
	objs[num - 1].className = "bottom1";
	objs[index].className = "miaobianh_t";
	if(preMenuIndex >= 0){
		objs[preMenuIndex].className = "bottom1";
	}
	ChangeSearchKeyword(index);
}


function doSubmit(){
	var theKeyWord = document.getElementById("txtKeyWord");
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������")
	{
		ClearEdit(theKeyWord);
	}
	document.form_Search.submit();
}
