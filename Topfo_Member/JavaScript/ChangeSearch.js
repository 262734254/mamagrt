
	function changeImg(id)
{
	
		var Searchfrm= document.getElementById("searchfrm");
		
			switch (id)
		{
			case 0 : //ȫ��
				Searchfrm.src = "/Search/AllSearch.html";
				break;
			case 1 : //����
				Searchfrm.src = "/Merchant/MerchantSearch.html";
				break;	
			
			case 2 : //Ͷ��
				Searchfrm.src  = "/capital/CapitalSearch.html";
				break;
			case 3 : //����
				Searchfrm.src = "/Project/ProjectSearch.html";
				break;
				
			case 4 : //����
				Searchfrm.src = "/News/NewsSearch.html";
				break;
	
	
		
			case 5 : //��ҵ
				Searchfrm.src = "/CarveOut/CarveOutSearch.html";
				break;
			case 6 : //�̻�
				Searchfrm.src = "/Opportunity/OpportunitySearch.html";
				break;
				
			case 7 : //����
				Searchfrm.src = "/News/PolicySearch.html";
				break;
			case 8 ://��չ
				Searchfrm.src = "/Exhibition/ExhibitionSearch.html";
				break;
			
			case 9 ://��Ȩ����
				Searchfrm.src = "/Property/PropertySearch.html";
				break;
				
			
			case 10 ://�б�Ͷ��
				Searchfrm.src = "/Bid/BidSearch.html";
				break;
				
			
			case 11 ://�б�
				Searchfrm.src = "/Bid/BidFinishSearch.html";
				break;
				
			
			case 12 ://����
				Searchfrm.src = "/Elite/CasesSearch.html";
				break;
				
			case 13 ://����
				Searchfrm.src = "/Elite/EliteSearch.html";
				break;
		
			case 14 ://ר����ѯ
				Searchfrm.src = "/Expert/ExpertSearch.html";
				break;
				
		//	case 15 ://��̳
		//		Searchfrm.src = "/Fourum/FourumSearch.html";
		//		break;					
			default:			
				Searchfrm.src = "/Search/AllSearch.html";			
				break;
		}
		
		
		
		
}



