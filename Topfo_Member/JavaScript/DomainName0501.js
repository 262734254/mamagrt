function cuturl()
		{
		
			
            var area_arry = new Array("glcf","sh158","kmcf","jdzcf","ungn","xccf","srcf","hzcf","hzhcf","hz888","jsszcf","lycf","wzkt","wzcf","tacf","zzcf","tycf","hkhualong","cqcf","yinglai","aspb","szba","yzcf","cscf","bjcf","syhd","jxcf","nncf","cdcf","fycf","ndcf","nbcf","hscf","ahhscf","ybcf","jzcf","hacf","chdcf","hycf","qingdao","whcf","zjnbcf","woshiyipianyun","zibo","shun6666","yijianfengyun","nihaoma");
            var location_Url=location.href;
            var areaurl;
            var url_tail;
             if(location_Url.substring(location_Url.length-10,location_Url.length)=='/index.htm')
            {
            location_Url=location_Url.substring(0,location_Url.length-10)
            }
           if(location_Url.indexOf(".")>0)
           {
              var index = location_Url.indexOf(".");
             areaurl=location_Url.substring(7,index);
           }
       
            
            for(var i=0;i<area_arry.length;i++)
            {
               if (area_arry[i]==areaurl)
                   {
                          var url=location_Url+"ViSitestatic/Agent/"+area_arry[i].toString()+"/Index.htm";
		                  
		  	              location.href =url;
		  	              return;
		  	            
                    }
            }
		
	      }