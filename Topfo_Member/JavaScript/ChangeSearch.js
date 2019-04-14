
	function changeImg(id)
{
	
		var Searchfrm= document.getElementById("searchfrm");
		
			switch (id)
		{
			case 0 : //全部
				Searchfrm.src = "/Search/AllSearch.html";
				break;
			case 1 : //招商
				Searchfrm.src = "/Merchant/MerchantSearch.html";
				break;	
			
			case 2 : //投资
				Searchfrm.src  = "/capital/CapitalSearch.html";
				break;
			case 3 : //融资
				Searchfrm.src = "/Project/ProjectSearch.html";
				break;
				
			case 4 : //新闻
				Searchfrm.src = "/News/NewsSearch.html";
				break;
	
	
		
			case 5 : //创业
				Searchfrm.src = "/CarveOut/CarveOutSearch.html";
				break;
			case 6 : //商机
				Searchfrm.src = "/Opportunity/OpportunitySearch.html";
				break;
				
			case 7 : //政策
				Searchfrm.src = "/News/PolicySearch.html";
				break;
			case 8 ://会展
				Searchfrm.src = "/Exhibition/ExhibitionSearch.html";
				break;
			
			case 9 ://产权交易
				Searchfrm.src = "/Property/PropertySearch.html";
				break;
				
			
			case 10 ://招标投标
				Searchfrm.src = "/Bid/BidSearch.html";
				break;
				
			
			case 11 ://中标
				Searchfrm.src = "/Bid/BidFinishSearch.html";
				break;
				
			
			case 12 ://案例
				Searchfrm.src = "/Elite/CasesSearch.html";
				break;
				
			case 13 ://人物
				Searchfrm.src = "/Elite/EliteSearch.html";
				break;
		
			case 14 ://专家咨询
				Searchfrm.src = "/Expert/ExpertSearch.html";
				break;
				
		//	case 15 ://论坛
		//		Searchfrm.src = "/Fourum/FourumSearch.html";
		//		break;					
			default:			
				Searchfrm.src = "/Search/AllSearch.html";			
				break;
		}
		
		
		
		
}



