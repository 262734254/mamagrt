// JavaScript Document ��괥����ť
function qiehuan(num){
		for(var id = 0;id<=7;id++)
		{
			if(id==num)
			{
				document.getElementById("qh_con"+id).style.display="block";
				document.getElementById("mynav"+id).className="nav_on";
			}
			else
			{
				document.getElementById("qh_con"+id).style.display="none";
				document.getElementById("mynav"+id).className="";
			}
		}
	}
	
function GetObj(objName){
if(document.getElementById){
return eval('document.getElementById("' + objName + '")');
}else if(document.layers){
return eval("document.layers['" + objName +"']");
}else
{return eval('document.all.' + objName);}
}
function SetBtn(preFix, idx){
for(var i=0;i<30;i++){
if(GetObj(preFix+"_btn_"+i)) GetObj(preFix+"_btn_"+i).className = "btn_off";
if(GetObj(preFix+"_con_"+i)) GetObj(preFix+"_con_"+i).style.display = "none";
}
GetObj(preFix+"_btn_"+idx).className = "btn_on";
GetObj(preFix+"_con_"+idx).style.display = "block";
}