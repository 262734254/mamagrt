// JavaScript Document 
function SetHome(obj,vrl){ 
    try{ 
       obj.style.behavior='url(#default#homepage)';obj.setHomePage(vrl); 
    } 
    catch(e){ 
        if(window.netscape) {
            try { 
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect"); 
            } 
            catch (e) { 
                alert("�˲�����������ܾ���\n�����������ַ�����롰about:config�����س�\nȻ�� [signed.applets.codebase_principal_support]��ֵ����Ϊ'true',˫�����ɡ�"); 
            } 
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch); 
            prefs.setCharPref('browser.startup.homepage',vrl); 
         } 
    } 
} 

function ChangeKeyWord(theKeyWord,KeyName){
	var str = theKeyWord.value;
	document.getElementById("hideKey").value = KeyName;
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str ==""){
		if(KeyName.length == 0){KeyName = "";}
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
			PostURL = "http://search.topfo.com/SearchAllResult.aspx";
			document.getElementById("form_Search").action = PostURL;
			ChangeKeyWord(theKeyWord,"");
			break;
		case 1 : //Ͷ��
			PostURL = "http://search.topfo.com/SearchResultCapital.aspx";
			document.getElementById("form_Search").action = PostURL;
			ChangeKeyWord(theKeyWord,"�ʱ�");
			break;
		case 2 : //����
			PostURL = "http://search.topfo.com/SearchResultProject.aspx";
			document.getElementById("form_Search").action = PostURL;
			ChangeKeyWord(theKeyWord,"��ҵ��Ŀ");
			break;
		case 3 : //����
			PostURL = "http://search.topfo.com/SearchResultMerchant.aspx";
			document.getElementById("form_Search").action = PostURL;
			ChangeKeyWord(theKeyWord,"������Ŀ");
			break;
		case 4 : //��Ѷ
			PostURL = "http://search.topfo.com/SearchResultNews.aspx";
			document.getElementById("form_Search").action = PostURL;
			ChangeKeyWord(theKeyWord,"��Ѷ");
			break; 
		default:
			break;
	}
}

function focusEdit(theKeyWord){
	if ( theKeyWord.value == theKeyWord.helptext ){
		theKeyWord.value = "";
		theKeyWord.helptext ="";
	}
	return true;
}
function blurEdit(theKeyWord){
	var KeyName = "";
	KeyName = document.getElementById("hideKey").value;
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
	var spobjs = document.getElementsByName("searchmenusp");
	if(Number(index)<10)
	{
	    var num = objs.length;
	    var preMenuIndex = index - 1;
	    for(i=0;i<5;i++)
	    {
		    objs[i].className = "";
		    spobjs[i].className = "";
	    }//alert(index);
	    objs[num - 1].className = "nolast";
	    if(index == 0 || index == 1)
		    objs[index].className = "on1";
	    else if(index == (num - 1))
		    objs[index].className = "nolast on1";
	    else
		    objs[index].className = "on2";
    		
	    spobjs[index].className = "lineSelect";
    	
	    ChangeSearchKeyword(index);	
	}
	else
	{
	    for(i=5;i<13;i++)
	    {
		    objs[i].className = "";
		    spobjs[i].className = "";
	    }
	    initOptions(index);
	    index=Number(index)-5;
	    objs[index].className = "on21";
	    spobjs[index].className = "lineSelect2";
	}
}

//---------------------------------
/******  var Options1 = Options[0];
function initOptions(selnum)
{
    var temp_index = (Number(selnum)-10);
    Options1 = [];
    Options1 = Options[temp_index];
	document.getElementById("searchType2").value=selnum;
    document.getElementById("search2").value="��ѡ������������";
    if(document.getElementById("_li_search2")!=null)
    {
        document.getElementById("_li_search2").innerHTML="";
        document.getElementById("_li_search2").style.display="none";
    }
    $.dmSelect("search2","sel_search2",Options1);
}
//---------------------------------

$.dmSelect = function(name,value,data){
    $("#" + name).attr("readonly","readonly");  //���ÿؼ�ֻ��
    var top = $("#" + name).offset().top;   //��ȡ�ؼ�top��leftλ�ú�width��height
    var left = $("#" + name).offset().left;
    var height = $("#" + name).height();
    var width = $("#" + name).width()-50;
    var option_open = false;      //����Ƿ������option
    function __dropheight(l){var h;if(l>10 || l<1){h = 10 * 20;}else{h = l * 20; h += 2;}return h;}  //��������option��ʾ�߶�
    var div_html = "<div id='_li_"+name+"' style='position:absolute;background-color:#FFFFFF;top:"+(top+height+5)+"px;left:"+left+"px;width:"+((width<30)?30:width)+"px;height:"+__dropheight(data.length)+"px;border:1px #666666 solid;overflow-x:hidden;overflow-y:auto;display:none;z-index:99999;'>";
    //forѭ�����option
    for(var i = 0;i < data.length; i++){div_html += "<div style='text-align:left;padding-left:5px; text-indent:10px;line-height:22px;' value='" + data[i][1] + "'>" + data[i][0] + "</div>";}
    div_html += "</div>";
    $("#" + name).after(div_html);  //��ӵ�input�ؼ�����
    function __open_option(){$("div[id^='_li_']").hide();$("#_li_" + name).show();option_open=true;}  //��ʾ����option
    function __hide_option(){$("#_li_" + name).hide();option_open=false;$(document).unbind("click",__hide_option);}  //��������option
    $("#" + name).click(function(event){if(option_open){__hide_option();}else{__open_option();$(document).bind("click",__hide_option)}event.stopPropagation();});
    $("#_li_" + name + " > div").hover(function(){$(this).css({"background-color":"#CCCCCC"});},function(){$(this).css({"background-color":"#FFFFFF"});})
    .click(function(){
        $("#" + name).val($(this).html());
        $("#" + value).val($(this).attr("value")); 
    });
};

$(document).ready(function(){
    $.dmSelect("search2","sel_search2",Options1);
    
});

function getURL(type)
{
    var bid=document.getElementById("searchType2").value;
    var mid=document.getElementById("search2").value;
    if(mid=='��ѡ������������')
    {
        mid="";
    }
    var myurl="http://union.topfo.com/searchAgencies.aspx";
    if(type==2)
    {
         myurl="http://union.topfo.com/searchService.aspx";
    }
    window.open(myurl+"?t="+bid+"&m="+escape(mid));
}

************/