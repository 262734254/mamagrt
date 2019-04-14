// JScript 文件
//Function:     Ajax Chat
//Author:       Siser(Siser0409@163.com)
//Modify Date:  2007-10-1
var Request=new function()
{
  
    /**
     * 创建新的通信对象
     * @return 一个新的通信对象
     */
    this.createInstance=function()
    {
        var instance=null;
        if (window.XMLHttpRequest)
        {
            //mozilla
            instance=new XMLHttpRequest();
            //有些版本的Mozilla浏览器处理服务器返回的未包含XML mime-type头部信息的内容时会出错。因此，要确保返回的内容包含text/xml信息
            if (instance.overrideMimeType)
            {
                instance.overrideMimeType="text/xml";
            }
        }
        else if (window.ActiveXObject)
        {
            //IE
            var MSXML = ['MSXML2.XMLHTTP.5.0', 'Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
            for(var i = 0; i < MSXML.length; i++)
            {
                try
                {
                    instance = new ActiveXObject(MSXML[i]);
                    break;
                }
                catch(e)
                {                    
                }
            }
        }
        return instance;
    }
    /////////////////////////////////
    ////////////////检查
  
   this.CheckName = function(obj)
   {
        var _url = "../Register/Control/ResponseAjax.aspx?type=name&name="+ obj.value +"&p="+(new Date).getTime();
        this.Chat(_url,obj);
      
   }
   //-----------------------------------
   this.CheckNikeName = function(obj,isre)
   {
        var _url = "../Register/Control/ResponseAjax.aspx?type=nick&name="+ escape(obj.value) +"&p="+(new Date).getTime()+"&isre="+isre;
        this.Chat(_url,obj);
   }
   //-------------------------------
   this.CheckValidCode = function(obj)
   {
      var _url = "../Register/Control/ResponseAjax.aspx?type=vercode&name="+ obj.value +"&p="+(new Date).getTime();
      this.Chat(_url,obj);
    
   }
   //------------------------------
   this.ChangeEmail = function(name,newEmail,validUrl,domain)
   {
        var _url = "../Register/Control/ResponseAjax.aspx?type=chEmail&name="+ name +"&email="+newEmail+
        "&validurl="+validUrl+"&domain="+domain+"&p="+(new Date).getTime();
        //document.write(_url);
        this.Chat(_url,null);
   }
   //-------------------------------
   this.ReSend = function(name,newEmail,validUrl,domain)
   {
         var _url = "../Register/Control/ResponseAjax.aspx?type=resend&name="+ name +"&email="+newEmail+
        "&validurl="+validUrl+"&domain="+domain+"&p="+(new Date).getTime();
        //document.write(_url);
        this.Chat(_url,null);
   }
   //-----------------------
   this.CheckValidEmail = function(obj)
   {
      var _url = "../Register/Control/ResponseAjax.aspx?type=email&name=111&email="+escape(obj.value)+"&p="+(new Date).getTime();
     //window.location = _url;
      this.Chat(_url,obj);
   }
   ///-----------------------
   this.HomeCheckRole = function()
   {
        var _url = "ResponseAjax.aspx?type=home&name=";
        
        return this.CheckRole(_url);
   }
   
   
   ////////////////////////////////////
   
   //----------------------------------------
  //aID 链接对象ID
  //type 操作类型　organization 机构／公司 exhibit　网上展厅
  this.CheckRole = function(url)
  {
        var _url = url; 
        var _asynchronous = false;
        var instance2 = this.createInstance();

        instance2.open("GET",_url,_asynchronous);
        instance2.send(null);
        if(instance2.status == 200)
        {
           return instance2.responseText;
        }else
        {
            return null;
        }
    }
   
   ///////////////////////////////
   ///////////////////////////////
   
   this.Chat = function(url,obj)
   {
        var _url = url; 
        var _asynchronous = true;
        var instance = this.createInstance();
        //var result = new Result;
        instance.open("GET",_url,_asynchronous);
        instance.send(null);
        
      instance.onreadystatechange=function()
        {
            if (instance.readyState == 4) // 判断对象状态            {
                if (instance.status == 200) // 信息已经成功返回，开始处理信息                {
                    if(obj)
                    { 
                        if(instance.responseText == "0") //=0可用
                        {  
                           invite = true;
                           showResult(0,obj);
                        }
                        else if(instance.responseText == "-1")////验证码超时                        { 
                            showResult(4,obj);
                         }
                        else　 //不可用
                         { 
                           invite = false;
                            showResult(3,obj);
                            
                         }    
                     }
                   
                }
                else
                {
                    showResult(4,obj);
                }
            }
        }
     }
 
}

function $(id)
{
    return document.getElementById(id);
}