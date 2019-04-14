
function initPostUrl()
{
		var PostURL = "/Merchant/MerchantSearchResult.aspx?origin=Index";
		document.Form1.action = PostURL;

}

	function changeToHand()
	{
		document.body.style.cursor = "hand";
	}

	function doSubmit()
	{
		document.Form1.submit();
	}
	
	
	function changeImg(id)
{

		var theKeyWord = document.getElementById("txtKeyWord");
		focusEdit(theKeyWord);

		document.Form1.hideUrlID.value = id;
		var PostURL = "";
		var hideUrlID = document.Form1.hideUrlID.value;

		switch (hideUrlID)
		{
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
			case "6" ://名片
				PostURL = "/CardChannel/CardSearchResult.aspx";
				break;
			default:
				
		}
		
	
	document.Form1.action = PostURL;

	var theimg1 = document.getElementById("img1");
	var theimg2 = document.getElementById("img2");
	var theimg3 = document.getElementById("img3");
	var theimg4 = document.getElementById("img4");
	var theimg5 = document.getElementById("img5");
	var theimg6 = document.getElementById("img6");
	var theimg7 = document.getElementById("img7");
	var theimg8 = document.getElementById("img8");
	var thetd1 = document.getElementById("td1");
	var thetd2 = document.getElementById("td2");
	var thetd3 = document.getElementById("td3");
	var thetd4 = document.getElementById("td4");
	var thetd5 = document.getElementById("td5");
	var thetd6 = document.getElementById("td6");
	var thetd7 = document.getElementById("td7");
	var thetd8 = document.getElementById("td8");	
	if (id==1)
	{
	
	
	
	thetd1.className ="mianbianhong";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	theimg1.background ="/images/new_12/in_p.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==2)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianhong";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==3)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianhong";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==4)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianhong";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==5)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianhong";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";
    theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==6)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianhong";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianbai";	
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==7)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianhong";
	thetd8.className ="mianbianbai";
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p.gif";
	theimg8.background ="/images/new_12/in_p_1.gif";
	}
	
	if (id==8)
	{
	thetd1.className ="mianbianbai";
	thetd2.className ="mianbianbai";
	thetd3.className ="mianbianbai";
	thetd4.className ="mianbianbai";
	thetd5.className ="mianbianbai";
	thetd6.className ="mianbianbai";
	thetd7.className ="mianbianbai";
	thetd8.className ="mianbianhong";	
	theimg1.background ="/images/new_12/in_p_1.gif";
	theimg2.background ="/images/new_12/in_p_1.gif";
	theimg3.background ="/images/new_12/in_p_1.gif";
	theimg4.background ="/images/new_12/in_p_1.gif";
	theimg5.background ="/images/new_12/in_p_1.gif";
	theimg6.background ="/images/new_12/in_p_1.gif";
	theimg7.background ="/images/new_12/in_p_1.gif";
	theimg8.background ="/images/new_12/in_p.gif";
	}
}
///////////search click////////////////////
function focusEdit(txtKeyWord)
{
 if ( txtKeyWord.value == txtKeyWord.helptext )
 {
 txtKeyWord.value = '';
 txtKeyWord.className = 'input1';
 }
 return true;
}
function blurEdit(txtKeyWord)
{
 if ( txtKeyWord.value.length == 0 )
 {
  txtKeyWord.className = 'input1';
 //txtKeyWord.className = 'editbox Graytitle';
 txtKeyWord.value ="";
 }
}
