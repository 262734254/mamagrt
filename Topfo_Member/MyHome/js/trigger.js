// JavaScript Document  Û±Í¥•∑¢∞¥≈•
function GetObj(objName){
if(document.getElementById){
return eval('document.getElementById("' + objName + '")');
}else if(document.layers){
return eval("document.layers['" + objName +"']");
}else
{return eval('document.all.' + objName);}
}
function SetBtn(preFix, idx){
for(var i=0;i<15;i++){
if(GetObj(preFix+"_btn_"+i)) GetObj(preFix+"_btn_"+i).className = "off";
if(GetObj(preFix+"_con_"+i)) GetObj(preFix+"_con_"+i).style.display = "none";
}

GetObj(preFix+"_btn_"+idx).className = "on";
GetObj(preFix+"_con_"+idx).style.display = "block";
}
