
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
		if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������")
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
			case "0" : //ȫ��
				PostURL = "/Search/SearchResult.aspx";
				break;
			case "7" : //����
				PostURL = "/News/NewsSearchResult.aspx?origin=Index";
				break;
			case "1" : //����
				PostURL = "/Merchant/MerchantSearchResult.aspx?origin=Index";
				break;
			case "2" : //Ͷ��
				PostURL = "/Capital/CapitalSearchResult.aspx?origin=Index";
				break;
			case "3" : //����
				PostURL = "/Project/ProjectSearchResult.aspx?origin=Index";
				break;
			case "8" : //����
				PostURL = "/News/PolicyList.aspx?origin=Index";
				break;
			case "4" : //��ҵ
				PostURL = "/CarveOut/CarveOutSearchResult.aspx";
				break;
			case "5" : //�̻�
				PostURL = "/Opportunity/OpportunitySearchResult.aspx?origin=Index";
				break;
		//	case "6" ://��Ƭ
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
	
	
	if (id==0)//ȫ��
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	
		theKeyWord.helptext="����ؼ��ֽ�������";
		theKeyWord.value="����ؼ��ֽ�������";
	}

	theimg8.focus();
	}
	
	
	if (id==1)//����
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="" )
	{
		theKeyWord.helptext="�������̹ؼ��ֽ�������";
		theKeyWord.value="�������̹ؼ��ֽ�������";
	}
	theimg8.focus();
	}
	
	if (id==2)//Ͷ��
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="����Ͷ�ʹؼ��ֽ�������";
	theKeyWord.value="����Ͷ�ʹؼ��ֽ�������";
	}
	theimg8.focus();
	}
	
	if (id==3)//����
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="�������ʹؼ��ֽ�������";
	theKeyWord.value="�������ʹؼ��ֽ�������";
	}
	
	theimg8.focus();
	}
	
	if (id==4)//��ҵ
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="���봴ҵ�ؼ��ֽ�������";
	theKeyWord.value="���봴ҵ�ؼ��ֽ�������";
	}
	theimg8.focus();
	}
	
	if (id==5)//�̻�
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="�����̻��ؼ��ֽ�������";
	theKeyWord.value="�����̻��ؼ��ֽ�������";
	}
	theimg8.focus();
	}
	
/*if (id==6)//��Ƭ
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
	
	theKeyWord.helptext="������Ƭ�ؼ��ֽ�������";
	theKeyWord.value="������Ƭ�ؼ��ֽ�������";
	theimg8.focus();
	}
	*/
	if (id==7)//��Ѷ
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="������Ѷ�ؼ��ֽ�������";
	theKeyWord.value="������Ѷ�ؼ��ֽ�������";
	}
	theimg8.focus();
	}
	
	if (id==8)//����
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
	if (str.substring(str.length-7,str.length)=="�ؼ��ֽ�������" || str =="")
	{
	theKeyWord.helptext="�������߹ؼ��ֽ�������";
	theKeyWord.value="�������߹ؼ��ֽ�������";
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
