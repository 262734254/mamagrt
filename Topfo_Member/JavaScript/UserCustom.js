function VisibleCheck(objName){
	var obj = document.getElementById(objName);
	if( objName == "SubM1" )
	{
		var lbError = document.getElementById("MemberLeft2nd1_lbError");
		if( lbError != null )
		{
		   obj.style.display ="none";
		}
		else
		{
		   obj.style.display ="";
		}
	}
	else
	{
	  
	    var vvvv = getCookie(objName);
	    alert(objName);
	    alert(vvvv);
	    
	    if (getCookie(objName) == '1')
		{		
			obj.style.display ="none";
		}
		else
		{
			obj.style.display ="";		
		}
	}
}

function VisibleCheck1(objName,objImageName){
	var obj = document.getElementById(objName);
	var objImage = document.getElementById(objImageName);
	if( objName == "SubM1" )
	{
		var lbError = document.getElementById("MemberLeft2nd1_lbError");
		if( lbError != null )
		{
		   obj.style.display ="none";
		}
		else
		{
		   obj.style.display ="";
		}
	}
	else
	{
	  
	    var vvvv = getCookie(objName);
	 
	    	    
	    if (getCookie(objName) == '1')
		{		
			obj.style.display ="none";
			objImage.src="/images/icon_openB.gif"
		}
		else
		{
			obj.style.display ="";	
			objImage.src="/images/icon_openA.gif"	
		}
	}
}

function VisibleCheckFHY(objName,objImageName){
	var obj = document.getElementById(objName);
	var objImage = document.getElementById(objImageName);
		  
    var vvvv = getCookie(objName);   	    
    if (getCookie(objName) == '1')
	{		
		obj.style.display ="none";
		objImage.src="/images_fhy/expand.gif"
	}
	else
	{
		obj.style.display ="";	
		objImage.src="/images_fhy/collapse.gif"	
	}	 
}

function SetVisible(objName){	

  
	var obj = document.getElementById(objName);
	if (obj.style.display != "")
	{
		obj.style.display = "";
		setCookie(objName, 0, 100000000) 
	}
	else
	{
		obj.style.display = "none";
		setCookie(objName, 1, 100000000) 
	}
}

function SetVisible1(objName,objNameImage){
   
	var obj = document.getElementById(objName);
	var objimage=document.getElementById(objNameImage);
	
	    if (obj.style.display != "")
	    {
		    obj.style.display = "";
		    //objimage.src="//images/MemberImg/Manageimg/jian.gif"
		    objimage.src="/images/icon_openA.gif"
		    objimage.alt="收起结点"
		    setCookie(objName, 0, 100000000) 
	    }
	    else
	    {
		    obj.style.display = "none";
		    //objimage.src="//images/MemberImg/Manageimg/jia.gif"
		    objimage.src="/images/icon_openB.gif"
		    objimage.alt="展开结点"
		    setCookie(objName, 1, 100000000) 
	    }
	
}
function setSearchType()
    {
        var sel = new String(document.getElementById("select").value);
        var frm = document.getElementById("form_Search");
        if(sel=="all")
            frm.action = "http://search.topfo.com/SearchAllResult.aspx";
        else
            frm.action = "http://search.topfo.com/SearchResult"+sel+".aspx";
    }
    function setkey()
    {
        if(document.getElementById("txtKeyWord").value=="请输入关键字")
        {document.getElementById("txtKeyWord").value="";return false;}
    }