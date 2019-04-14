
function moveOver(a,b) {
alert(a +" ========" +b)
    var sltLocationID = a;
    var sltSubLocationID = b;
    if (sltSubLocationID.options.length >= 5) {
        alert("不能超过5个");
        return;
    }
    var max = sltLocationID.options.length;
    var isMulti;
    var HaveMulti = false;    
    for (var i=0;i<max;i++) {
		isMulti = false;
		if (sltSubLocationID.options.length >= 5) {
					alert("不能超过5个");
					break; 
		}
        if (sltLocationID.options[i].selected) {
            for (var j=0;j<sltSubLocationID.options.length;j++) {
                if (sltSubLocationID.options[j].text == sltLocationID.options[i].text) {                    
                    isMulti = true;
                    HaveMulti = true;    
                    continue;
                }
            }
            if (!isMulti)
            {
				sltSubLocationID.options.add(new Option(sltLocationID.options[i].text,sltLocationID.options[i].value));
				 
			}
        }
       
    }
}

function moveOver1(a,b) {
    var sltLocationID = a;
    var sltSubLocationID = b;
    if (sltSubLocationID.options.length >= 5) 
    {
        alert("不能超过5个");
        return;
    }
   // var max = sltLocationID.options.length;
//    var max=sltLocationID.Nodes.Count;
 //   alert("dddd");
 
 //   var isMulti;
  //  var HaveMulti = false;    
 //     for (var i=0;i<max;i++) {
 //	  isMulti = false;
 //	  if (sltSubLocationID.options.length >= 5)
 //   {
//					alert("不能超过5个");
//				break; 
//	  }
  //      if (sltLocationID.options[i].selected) {
  //         for (var j=0;j<sltSubLocationID.options.length;j++) {
    //            if (sltSubLocationID.options[j].text == sltLocationID.options[i].text) {                    
      //              isMulti = true;
        //            HaveMulti = true;    
          //          continue;
            //    }
           // }
           // if (!isMulti)
           // {
			//	sltSubLocationID.options.add(new Option(sltLocationID.options[i].text,sltLocationID.options[i].value));
				 
			//}
    //    }
       
   // }

    //if (HaveMulti)
		//alert("您不能重复加入");
}

function removeMe(c) {
        var sltSubLocationID = c;
    var max = sltSubLocationID.options.length-1 ;
    for (var i=max;i>=0;i--) {
        if (sltSubLocationID.options[i].selected) {
            sltSubLocationID.options.remove(i);
        }
    }
}

function FillToTxtFeild(a, b,e, thediv) {
    var listFeild = a;
    var textFeild = b;
    var listtext = e;
    var opionText="";
    
    var itemValue = '';
    var max = listFeild.options.length ;
    for (var i= 0 ;i < max;i++) {

		if(listFeild.options[i].value != "")
		{
		itemValue += listFeild.options[i].value;
		opionText +=listFeild.options[i].text;
		/*if(i < max)
		{*/
			itemValue += thediv;
			opionText += thediv;
		//}
		}
    }
    while(itemValue.charAt(itemValue.length-1) == thediv)
    {
		itemValue = itemValue.substring(0,itemValue.length-1)
    }
     while(opionText.charAt(opionText.length-1) == thediv)
    {
		opionText = opionText.substring(0,opionText.length-1)
    }
    textFeild.value = itemValue;   
    e.value = opionText; 
  //  alert( e.value);
}