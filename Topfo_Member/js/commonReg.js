// JScript 文件
//Function:     Tz888.cn Member Register Module
//Author:       Siser(Siser0409@163.com)
//Modify Date:  2007-11-8

var RegInfo = new Array();
RegInfo[0] = new Array("该会员名可以注册。","您的填写有误。会员登陆名由4-16个英文字母、数字、下划线组成，不区分大小写。",
                "会员登陆名由4-16个英文字母、数字、下划线组成，不区分大小写。登录名不能修改，请谨慎填写。",
                  "该会员名已被注册。" ,"正在检查会员名....");
var usrname = new Element("usrname",RegInfo[0],"nameinfo");
//-------------------------
RegInfo[1] = new Array("填写正确。","密码设置错误。密码由6-20个英文字母或数字组成。",
                        "由6-20个英文字母或数字组成");
var pwd = new Element("pwd",RegInfo[1],"pwdinfo");
//--------------------------
RegInfo[2] = new Array("填写正确。","两次输入的密码不一致。请再输入一次您上面输入的密码。","请再输入一遍您上面填写的密码");
var repwd = new Element("repwd",RegInfo[2],"repwdinfo");
//------------------------
RegInfo[3] = new Array("该昵称可用。","您的填写有误。1-14个字符，一个汉字为2个字符。",
                        "昵称可填写中文，不超过14个字符，请使用您的单位名作为您的昵称，如“中国招商投资网”","该昵称已被注册。",
                        "正在检查昵称....");
var nikename = new Element("nikename",RegInfo[3],"nikeinfo");
//--------------------
RegInfo[4] = new Array("填写正确。","您的填写有误。我们需要通过邮箱对您进行认证。请填写真实并且最常用的邮箱。",
    "请填写您最常用的邮箱，这是客户联系您的重要方式。 如果您没有邮箱，<a href=\"http://mail.163.com\" target=\"_blank\"> 注册网易邮箱</a> <a href=\"http://mail.yahoo.com.cn\" target=\"_blank\"> 注册雅虎邮箱</a>",
    "该邮箱已被注册，请更换别邮箱。");
var email = new Element("email",RegInfo[4],"emailinfo");
//----------------------
var country = "";
//----------------------
//RegInfo[5] = new Array("填写正确。","填写有误,区号应为3或4位整数。",
 //                   "");
//var zone = new Element("zone",RegInfo[5],"zoneinfo");
//----------------------
RegInfo[6] = new Array("填写正确。","您的填写有误。区号为3-4位整数,电话号码应为7-8位整数,要输入多个电话号码,请使用“/”分隔。",
                    "如果要输入多个电话号码,请使用“/”分隔，分机号码用“-”分隔。","电话号码和手机两项至少要填写一项。");
var phone = new Element("phone",RegInfo[6],"phoneinfo","mobile");
var zone = new Element("zone",RegInfo[6],"phoneinfo");
//-----------------------
RegInfo[7] = new Array("填写正确。","您的填写有误。手机号码应为以13,15开头的11位整数。",
                        "手机和固定电话请至少填写一项","电话号码和手机两项至少要填写一项。");
var mobile = new Element("mobile",RegInfo[7],"mobileinfo","phone");
//----------------------
RegInfo[8] = new Array("填写正确。","您的填写有误。单位名称由3个以上英文字母和中文 或 3个以上中文组成",
                        "请填写真实、准确的招商机构名称，如深圳招商局");
var comname = new Element("comname",RegInfo[8],"comnameinfo");
//-----------------------
RegInfo[9] = new Array("填写正确。","","填写邀请您注册的朋友昵称，如果没有则可不填。","您填写的邀请人不存在，请确定您的邀请人。");
var invite = new Element("invite",RegInfo[9],"inviteinfo");
//-----------
RegInfo[10] = new Array("","验证码错误，请准确输入。","","验证码不正确。","登陆已超时,请刷新验证码。");
var vercode = new Element("vercode",RegInfo[10],"vercodeinfo");
//----------------
RegInfo[11] = new Array("","注册前请阅读并接受接受服务协议","");
var protocal = new Element("protocal",RegInfo[11],"protocalinfo");
//-------------------
RegInfo[12] = new Array("由于您选择了政府会员，所以只能选择“政府招商”和“项目融资”意向。 <a href=\"register.aspx\"> 重新选择会员类型</a>","请选择您的意向。",
                    "由于您选择了政府会员，所以只能选择“政府招商”和“项目融资”意向。 <a href=\"register.aspx\"> 重新选择会员类型</a>");
var coo = new Element("coo",RegInfo[12],"cooinfo");
var coo1 = new Element("coo1",RegInfo[12],"cooinfo");
//-----------------------
RegInfo[13] = new Array("","请选择您的意向。","");
var intent = new Element("intent",RegInfo[13],"intentinfo");
//--------------------－－－

RegInfo[14] = new Array("填写正确。","您的填写有误。请用2个字以上中文填写真实、准确的地址","请用中文填写真实、准确的地址");
var address = new Element("address",RegInfo[14],"addressinfo");

//RegInfo[15] = new Array("填写正确。","为了您的账号安全，请设置密码保护问题。","");
//var question = new Element("question",RegInfo[15],"questioninfo");

RegInfo[16] = new Array("填写正确。","请填写工商局注册的企业完整名称。","请填写工商局注册的企业完整名称。"
                        ,"请填写真实、准确的招商机构名称，如深圳招商局。");
var company = new Element("company",RegInfo[16],"companyinfo");

RegInfo[17] = new Array("填写正确。","请填写工商局注册的企业完整名称。","请填写工商局注册的企业完整名称。"
                        ,"请填写工商局注册的企业完整名称。");
var contactname = new Element("contactname",RegInfo[16],"");

RegInfo[18] = new Array("填写正确。","请填写工商局注册的企业完整名称。","请填写工商局注册的企业完整名称。"
                        ,"请填写工商局注册的企业完整名称。");
var contacttitle = new Element("contacttitle",RegInfo[16],"");

//-------------------

initFrm();


function Element(evtobj,info,infobox,relObj)
{
    this.o = evtobj;
    this.m = info;
    this.i = infobox;
    if(relObj)
     this.r = relObj;
}

function initFrm()
{
    var e =  document.getElementsByTagName("input");

    for(var i=0;i<e.length;i++)
	{
		if((e[i].type == 'text' || e[i].type == 'password' || e[i].type == 'checkbox') &&
		    e[i].name != 'intent')
		{
			e[i].onfocus = onFocus;
			e[i].onblur = onBlur;
		}
	}
	
	//特殊FORM元素事件
	$("email").onkeyup = showDefaultDes;
	//$("question").onchange = onBlur;
}

function showDefaultDes()
{
    if($("email").value != "")
        $("emailinfo").innerHTML = "重要！我们需要通过邮箱对您的账号进行认证。<span>请暂时不要使用新浪邮箱和Hotmail。</span></a>";
    else
         $("emailinfo").innerHTML = email.m[2];
}

function onBlur(evnt)
{
	var obj;
	if (isIE()) {
        obj = event.srcElement;
    }else {
        obj = evnt.target;
    }
    
	ValidData(obj);
}

function onFocus(evnt)
{
	var obj;
	if (isIE()){
        obj = event.srcElement;
    }else {
        obj = evnt.target;
    }
	
	if( GetInfoBox(obj))
	 {    
	    GetInfoBox(obj).innerHTML = eval(obj.id).m[2];
	    GetInfoBox(obj).className="desc";
	  }
}

function ValidData(obj,isSubmit,isAsyc,asyc)
{
    if(isAsyc)
    {   
       return showResult(asyc,obj);    
    }
    else
    {        
     if(!isSubmit)      //非提交时，未填数据处理

     {
        if(GetInfoBox(obj))
        {
            GetInfoBox(obj).className="commonly";
        }
        if(!obj.value)
            return null;
     }
     
     if(obj.id)
     {
	    var type = obj.id;
	    var result = -1;
	    switch(type)
	    {
	        case "usrname":
	            result = VName(obj);
	            break;
		    case "email": 
			    result = Vmail(obj);
			    break;
		    case "pwd":
		        result = VPWD(obj);
		        break;
		    case "repwd":
		        result = VRepeatPWD(obj);
		        break;
		     case "nikename":
		        result = VNikeName(obj);
		        break;
		     case "company":
		        result = VAnswer(obj);
		        break;
		     case "zone":
		        result = VTelMobile($("phone"));
		        break;
		     case "phone":
		        result = VTelMobile(obj);
		        //result = VPhone(obj);
		        break;
		     case "comname":
		        result = VComName(obj);
		        break;
		     case "mobile":
		        result = VTelMobile(obj);
		        //result = VMobile(obj);
		        break;
		     case "invite":
		        result = VContect(obj);
		        break;
		     case "vercode":
		        result = VVercode(obj);
		        break;
		     case "coo":
		     case "coo1":
		        result = Vcoo(obj);
		        break;
		     case "intent":
		        result = VIntent(obj);
		        break;
		     case "address":
		        result = VAddress(obj);
		        break;
		     case "protocal":
		        result = VProtocal(obj);
		        break;
	    }
	    return showResult(result,obj);
       }
 }
}
//////////////////////////////////验证函数///////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////
function CheckAll()
{
    var result = true;

    var e =  document.getElementsByTagName("input");  
   
    for(var i=0;i<e.length;i++)
	{
		if(e[i].type == 'text' || e[i].type == 'password' || e[i].type == 'checkbox')
		{
		    var tmpresult = ValidData(e[i],true);
		    if(typeof(tmpresult) != 'undefined')
		    {  
		        result &= tmpresult;
		     }
		}
	}
     return (result == "0"?false:true);
}
//验证用户名

var check =null;
function VName(obj)
{
    var Rex = /^([A-Za-z0-9]\_*){4,16}$/;
    GetInfoBox(obj).innerHTML = "检测中，请稍等...";
    if(Rex.test(obj.value))
    {
        Request.CheckName(obj);
        //**********
        if(GetInfoBox(obj).className == "fault")
            return "NO";
        else
            return "OK";
    }
    else
        return 1;
}

//密码保护问题
function VQuestion(obj)
{
    var Rex = /^\s*$/
   if(!Rex.test($("answer").value))
    {
        GetInfoBox($("answer")).className = 'commonly';
        GetInfoBox($("answer")).innerHTML = eval("answer").m[0];
    }
 
    if(Rex.test(obj.value))
        return 1;
    else
        return 0;
        
}

//密码保护答案
function VAnswer(obj)
{
    var Rex = /^\s*$/;
    if(Rex.test(obj.value))
        return 1;
    else
      return 0;
}

//验证区号
function VZone(obj)
{
   
    var Rex = /^[0-9]{3,4}$/;
    if(obj.value.length > 1)
    {
        if(Rex.test(obj.value))
            return 0;
        else
            return 1;
        } 
}
//电话号码
function VPhone(obj)
{
      var zone = $("zone").value;
      var tel = zone+"-"+obj.value;

      if(tel.value.length > 2)
      {
        var Rex = /^[0-9]{3,4}\-([0-9]{7,8}(-[0-9]{3,4})?\/?)+$/; //电话
        if(Rex.test(tel))
            return 0;
        else
            return 1;
      }

}
//手机号

function VMobile(obj)
{
    var Rex = /^(13|15|18)[0-9]{9}$/;
    if(obj.value.length > 0)
    {
        if(Rex.test(obj.value))
            return 0;
        else
            return 1;
    }
    //UnRequest(obj);
   
}
//电话号码／手机二者选一
function VTelMobile(obj)
{
    if(obj.id == "phone" && $("phone").value.length > 0)
    {
        var zone = $("zone").value;
        var tel = zone+"-"+obj.value;
        
        var Rex =/^[0-9]{3,4}\-([0-9]{7,8}(-[0-9]{3,4})?\/?)+$/;  //电话
        if(Rex.test(tel) )
        {
           showResult(0,$(eval(obj.id).r));
            return 0;
         }
        else
            return 1;
    }
    if(obj.id== "mobile" && $("mobile").value.length > 0)
    {
         var Rex = /^(13|15)[0-9]{9}$/;
        if(obj.value.length > 0)
        {
            if(Rex.test(obj.value))
            {
                if($(eval(obj.id).r).value.length < 1)showResult(0,$(eval(obj.id).r));
                return 0;
             }   
            else
                return 1;
        }
    }
    if($("phone").value.length < 1 && $("mobile").value.length < 1)
    {
        return 3;
    }
}

//公司名称
function VComName(obj)
{
    var Rex = /^([a-zA-Z]{4,}[\u4e00-\u9fa5]*)|([\u4e00-\u9fa5]{4,})$/;
    if(Rex.test(obj.value))
        return 0;
    else
        return 1;
}
//地址
function VAddress(obj)
{
    var Rex = /^(([\u4e00-\u9fa5]|[a-zA-Z]){2,}\d*([\u4e00-\u9fa5]|[a-zA-Z])*)+$/;
    if(obj.value.length > 0)
    {
        if(Rex.test(obj.value))
            return 0;
        else
            return 1;
    }
   UnRequest(obj);
}

//邀请人
function VContect(obj)
{
    if(obj.value.length > 0)
      {   
         GetInfoBox(obj).innerHTML = "检测中，请稍等...";
         Request.CheckNikeName(obj,"reverse");   
         
        if(GetInfoBox(obj).className == "fault")
            return "NO";
        else
            return "OK"; 
      }
    else
       { UnRequest(obj);}   
}
//----验证码

function　VVercode(obj)
{
    var Rex = /^([A-Za-z0-9]\_*){4,20}$/;
    if(Rex.test(obj.value))
    {
        Request.CheckValidCode(obj);
        if(GetInfoBox(obj).className == "fault")
            return "NO";
        else
            return "OK";
    }
    else
        return 1;
}
//------------
function Vcoo(obj)
{
    var coo = document.getElementsByName("coop");
    var count = 0;
    for(i=0;i < coo.length; i++)
    {
        if(coo[i].checked)
            count++;
    }
    
    if(count > 0)
        return 0;
    else
        return 1;
}
//--------------服务协议
function VProtocal(obj)
{
    if(obj.checked)
        return 0;
    else
        return 1;
}

//验证密码
var pwdv = "";
function VPWD(obj)
{
    var Rex = /^[A-Za-z0-9]{6,20}$/;
    pwdv = obj.value;
    if(Rex.test(pwdv))
        return 0;
    else
        return 1;
}

function VRepeatPWD(obj)
{
    if(obj.value == pwdv && obj.value.length > 0)
        return 0;
    else
        return 1;
    pwdv = null;
}

//验证昵称
function VNikeName(obj)
{
    var Rex = /^[A-Za-z0-9\u4e00-\u9fa5]{1,14}$/;
    GetInfoBox(obj).innerHTML = "检测中，请稍等...";
    
    if(Rex.test(obj.value) && ChkLen(obj.value) <= 14)
    {
        Request.CheckNikeName(obj,"");
        if(GetInfoBox(obj).className == "fault")
            return "NO";
        else
            return "OK";
     }
    else
        return 1;
}
//验证EMAIL 
function Vmail(obj)
{
	var Rex = /^[\w-]+(\.[\w-]+)*@([\w-]\.|[\w-]+)+\.(com|com.cn|cn|net|net.cn|info|org|org.cn|gov|gov.cn|tv)\s*$/i;
	GetInfoBox(obj).innerHTML = "检测中，请稍等...";
	if (Rex.test(obj.value))
	{
	    Request.CheckValidEmail(obj);
	    if(GetInfoBox(obj).className == "fault")
            return "NO";
        else
            return "OK";
	}
	else
		return 1;
}

//验证意向
function VIntent(obj)
{
    var intent = document.getElementsByTagName("input");
    var count = 0;
    for(var i=0;i < intent.length; i++)
    {
        if(intent[i].name == "intent" && intent[i].type == "checkbox")
        {
            if(intent[i].checked)
                count++;
        }
    }

    if(count > 0)
        return 0;
    else
        return 1;
}


//意向选择
function IntentOnSelect(obj)
{
    var chk  = obj.childNodes[0].childNodes[0];

    if(obj.className == "")
    {
        obj.className = "oncheck";
        if(isIE() && chk.type == "checkbox")
            chk.checked = true;
        else
            obj.childNodes[1].childNodes[0].checked = true;
         
    }else
    {
        obj.className = "";
        if(isIE())
        {
             if(chk.type == "checkbox");
                chk.checked = false;
         }
         else
         {
            obj.childNodes[1].childNodes[0].checked = false;
          }
    }
   
  var result =  VIntent($("intent")); 
  showResult(result,$("intent"));
}
//非必填项
function UnRequest(obj)
{
    GetInfoBox(obj).innerHTML = eval(obj.id).m[2];
    GetInfoBox(obj).className = "commonly";
    //去掉勾  
    if(isIE())
    {        
        var s = $(obj.id).parentNode.parentNode.childNodes[0];
        if(s.childNodes[0].nodeName == "IMG" && obj.type != "checkbox")
         s.removeChild(s.childNodes[0]);
     }else
     {
        var s = $(obj.id).parentNode.parentNode.childNodes[1];
        var startIndex = s.innerHTML.indexOf(">")+1;
        s.innerHTML = s.innerHTML.substring(startIndex);
            
     }
      
}

//////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////

//result:0 true ,1 false

function showResult(result,obj)
{   
    if(obj)
    {
       var RIGHT_IMG_URL = '<img src = "../images/right.gif" width=19 height=16/>';
        
        if(result == "NO")
        {
           return false;
        }
        if(result == "OK")
        {
            return true;
        }
        
        var spanNode;
	    if(isIE())spanNode = 0;
	    else spanNode = 1;
	       
        if(result > 0)
        {   
            //去掉勾  
          
            var s = $(obj.id).parentNode.parentNode.childNodes[spanNode];
            if(isIE() && obj.type != "checkbox")
            {
                if(s.childNodes[0].nodeName == "IMG" && obj.type != "checkbox")
                 s.removeChild(s.childNodes[0]);
            }
            if(!isIE() && obj.type != "checkbox")
            {
                var startIndex = s.innerHTML.indexOf(">")+1;
                s.innerHTML = s.innerHTML.substring(startIndex);
            }
            GetInfoBox(obj).className = "fault";
	        GetInfoBox(obj).innerHTML = eval(obj.id).m[result];
	        obj.parentNode.focus();
	        return false;
	    }
	    if(result == 0 )
	    {
	        //打勾
	       if(obj.type != 'checkbox')
	       {
	           var Draw = $(obj.id).parentNode.parentNode.childNodes[spanNode].innerHTML;
        	  
    	       if(Draw.indexOf("right.gif") == -1 )
	                $(obj.id).parentNode.parentNode.childNodes[spanNode].innerHTML  = RIGHT_IMG_URL+Draw;
            }
	        GetInfoBox(obj).innerHTML = eval(obj.id).m[result];
	        GetInfoBox(obj).className = "commonly";
	        return true;
	    }
	}
	
}

//获取显示区域
function GetInfoBox(obj)
{
	if(obj.id )
	{
		if(eval(obj.id).i && $(eval(obj.id).i))
			return $(eval(obj.id).i);
		else
		    return;
	}
	return;
}

function ChkLen(str)
{
   var len=0;
   for(var i=0; i<str.length; i++)
   {
     var c=str.charCodeAt(i);
     //半角
     if(c<256||(c>=0xff61&&c<=0xff9f))
          len=len+1;
     else //全角
          len=len+2;
   }
   return len;
} 

function $(id)
{
    if(id)
       {return document.getElementById(id);}
}

function ChangeValidCode(id)
{
   $(id).src = "../ValidateNumber.aspx?r="+Math.random();
  
}

function isIE() {

	if(document.all) return true;

	return false;

}

//document.onkeydown=function(evnt){

//    if(isIE()&&window.event.keyCode==13){
//        $("ImageButton1").focus();
//    }

//}

function killErrors() 
{ 
return true; 
}   
window.onerror = killErrors; 