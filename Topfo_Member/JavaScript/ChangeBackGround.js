
function initPostUrl()
{
		var PostURL = "/Search/SearchResult.aspx?origin=Index";
		document.Form1.action = PostURL;

}

	function changeToHand()
	{
		document.body.style.cursor = "hand";
	}

	function doSubmit()
	{
		var theKeyWord = document.getElementById("txtKeyWord");
	
		var str = theKeyWord.value;
		if (str.substring(str.length-7,str.length)=="关键字进行搜索")
		{
			ClearEdit(theKeyWord);
		}
		
		document.Form1.submit();
	}
	
	
	function changeImg(id)
{

		var theKeyWord = document.getElementById("txtKeyWord");
		var hideTxt = document.getElementById("hideTxt");
		//ClearEdit(theKeyWord);

		document.Form1.hideUrlID.value = id;
		var PostURL = "";
		var hideUrlID = document.Form1.hideUrlID.value;

		switch (hideUrlID)
		{
			case "0" : //全部
				PostURL = "/Search/SearchResult.aspx";
				break;
			case "7" : //新闻
				PostURL = "/News/NewsSearchResult.aspx?origin=Index";
				break;
			case "1" : //招商
				PostURL = "/Merchant/MerchantSearchResult.aspx?origin=Index";
				break;
			case "2" : //投资
				PostURL = "/Capital/CapitalSearchResult.aspx?origin=Index";
				break;
			case "3" : //融资
				PostURL = "/Project/ProjectSearchResult.aspx?origin=Index";
				break;
			case "8" : //政策
				PostURL = "/News/PolicyList.aspx?origin=Index";
				break;
			case "4" : //创业
				PostURL = "/CarveOut/CarveOutSearchResult.aspx";
				break;
			case "5" : //商机
				PostURL = "/Opportunity/OpportunitySearchResult.aspx?origin=Index";
				break;
		//	case "6" ://名片
		//		PostURL = "/CardChannel/CardSearchResult.aspx";
				break;
			default:
				break;
		}
		
	
	document.Form1.action = PostURL;

   var theimg0 = document.getElementById("img0");
	var theimg1 = document.getElementById("img1");
	var theimg2 = document.getElementById("img2");
	var theimg3 = document.getElementById("img3");
	var theimg4 = document.getElementById("img4");
	var theimg5 = document.getElementById("img5");
//	var theimg6 = document.getElementById("img6");
	var theimg7 = document.getElementById("img7");
	var theimg8 = document.getElementById("img8");
	
	var thetd0 = document.getElementById("td0");
	var thetd1 = document.getElementById("td1");
	var thetd2 = document.getElementById("td2");
	var thetd3 = document.getElementById("td3");
	var thetd4 = document.getElementById("td4");
	var thetd5 = document.getElementById("td5");
//  var thetd6 = document.getElementById("td6");
	var thetd7 = document.getElementById("td7");
	var thetd8 = document.getElementById("td8");	
	
	
	if (id==0)//全部
	{
	thetd0.className ="mianbianhong";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	
	theimg0.background ="/images/new_12/in_p.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	
		theKeyWord.helptext="输入关键字进行搜索";
		theKeyWord.value="输入关键字进行搜索";
	}

	theimg8.focus();
	}
	
	
	if (id==1)//招商
	{
	
	
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianhong";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="" )
	{
		theKeyWord.helptext="输入招商关键字进行搜索";
		theKeyWord.value="输入招商关键字进行搜索";
	}
	theimg8.focus();
	}
	
	if (id==2)//投资
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianhong";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入投资关键字进行搜索";
	theKeyWord.value="输入投资关键字进行搜索";
	}
	theimg8.focus();
	}
	
	if (id==3)//融资
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianhong";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入融资关键字进行搜索";
	theKeyWord.value="输入融资关键字进行搜索";
	}
	
	theimg8.focus();
	}
	
	if (id==4)//创业
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianhong";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入创业关键字进行搜索";
	theKeyWord.value="输入创业关键字进行搜索";
	}
	theimg8.focus();
	}
	
	if (id==5)//商机
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianhong";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
    theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入商机关键字进行搜索";
	theKeyWord.value="输入商机关键字进行搜索";
	}
	theimg8.focus();
	}
	
/*if (id==6)//名片
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianhong";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";	
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	theKeyWord.helptext="输入名片关键字进行搜索";
	theKeyWord.value="输入名片关键字进行搜索";
	theimg8.focus();
	}
	*/
	if (id==7)//资讯
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianhong";
	thetd8.className ="mianbianbai";
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入资讯关键字进行搜索";
	theKeyWord.value="输入资讯关键字进行搜索";
	}
	theimg8.focus();
	}
	
	if (id==8)//政策
	{
	thetd0.className ="mianbianbai";
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
//	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianhong";	
	
	theimg0.background ="/images/new_12/in_p_1.gif";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
//	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p.gif";
	
	var str = theKeyWord.value;
	if (str.substring(str.length-7,str.length)=="关键字进行搜索" || str =="")
	{
	theKeyWord.helptext="输入政策关键字进行搜索";
	theKeyWord.value="输入政策关键字进行搜索";
	}
	theimg8.focus();
	
	}
	

}
///////////search click////////////////////
function focusEdit(theKeyWord)
{
 if ( theKeyWord.value == theKeyWord.helptext )
 {
 theKeyWord.value = "";
  theKeyWord.helptext ="";
 //theKeyWord.className = 'input1';
 }
 return true;
}
function blurEdit(theKeyWord)
{

 if ( theKeyWord.value.length == 0 )
 {
	theKeyWord.value ="";
	theKeyWord.helptext ="";
 }
 }
 function ClearEdit(theKeyWord)
 {
  	theKeyWord.value ="";
	theKeyWord.helptext ="";
 }
