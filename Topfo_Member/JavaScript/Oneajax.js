/*****************************************************************
	AjaxHelper DotNet Ver 0.7
	Copyright 2005 by Teddy <shijie.ma@gmail.com> (http://ilungasoft.com)
	Based on "prototype1.2", "msncore"
	Last Modified: 2005/11/3
*****************************************************************/

//---------------------------------------compat------------------------------------

if (!Array.prototype.push) {
  Array.prototype.push = function() {
		var startLength = this.length;
		for (var i = 0; i < arguments.length; i++)
      this[startLength + i] = arguments[i];
	  return this.length;
  }
}

if (!Function.prototype.apply) {
  // Based on code from http://www.youngpup.net/
  Function.prototype.apply = function(object, parameters) {
    var parameterStrings = new Array();
    if (!object)     object = window;
    if (!parameters) parameters = new Array();
    
    for (var i = 0; i < parameters.length; i++)
      parameterStrings[i] = 'x[' + i + ']';
    
    object.__apply__ = this;
    var result = eval('obj.__apply__(' + 
      parameterStrings[i].join(', ') + ')');
    object.__apply__ = null;
    
    return result;
  }
}

//---------------------------------------prototype------------------------------------

var Prototype = {
  Version: '@@VERSION@@'
}

var Class = {
  create: function() {
    return function() { 
      this.initialize.apply(this, arguments);
    }
  }
}

var Abstract = new Object();

Object.prototype.extend = function(object) {
  for (property in object) {
    this[property] = object[property];
  }
  return this;
}

Function.prototype.bind = function(object) {
  var method = this;
  return function() {
    method.apply(object, arguments);
  }
}

Function.prototype.bindAsEventListener = function(object) {
  var method = this;
  return function(event) {
    method.call(object, event || window.event);
  }
}

var Try = {
  these: function() {
    var returnValue;
    
    for (var i = 0; i < arguments.length; i++) {
      var lambda = arguments[i];
      try {
        returnValue = lambda();
        break;
      } catch (e) {}
    }
    
    return returnValue;
  }
}

/*--------------------------------------------------------------------------*/

var PeriodicalExecuter = Class.create();
PeriodicalExecuter.prototype = {
  initialize: function(callback, frequency) {
    this.callback = callback;
    this.frequency = frequency;
    this.currentlyExecuting = false;
    
    this.registerCallback();
  },
  
  registerCallback: function() {
    setTimeout(this.onTimerEvent.bind(this), this.frequency * 1000);
  },
  
  onTimerEvent: function() {
    if (!this.currentlyExecuting) {
      try { 
        this.currentlyExecuting = true;
        this.callback(); 
      } finally { 
        this.currentlyExecuting = false;
      }
    }
    
    this.registerCallback();
  }
}

/*--------------------------------------------------------------------------*/

function $() {
  var elements = new Array();
  
  for (var i = 0; i < arguments.length; i++) {
    var element = arguments[i];
    try
    {
		if (typeof element == 'string')
		element = document.getElementById(element) || document.all(element) || document.forms(0).all(element);
    }
    catch(ex)
    {
		element = null;
    }

    if (arguments.length == 1) 
      return element;
      
    elements.push(element);
  }
  
  return elements;
}

//--------------------------------------string-----------------------------------------

String.prototype.lTrim = function () {return this.replace(/^\s*/, "");}
String.prototype.rTrim = function () {return this.replace(/\s*$/, "");}
String.prototype.trim = function () {return this.rTrim().lTrim();}
String.prototype.endsWith = function(sEnd) {return (this.substr(this.length-sEnd.length)==sEnd);}
String.prototype.startsWith = function(sStart) {return (this.substr(0,sStart.length)==sStart);}
String.prototype.format = function()
{ var s = this; for (var i=0; i < arguments.length; i++)
{ s = s.replace("{" + (i) + "}", arguments[i]);}
return(s);}
String.prototype.removeSpaces = function()
{ return this.replace(/ /gi,'');}
String.prototype.removeExtraSpaces = function()
{ return(this.replace(String.prototype.removeExtraSpaces.re, " "));}
String.prototype.removeExtraSpaces.re = new RegExp("\\s+", "g"); String.prototype.removeSpaceDelimitedString = function(r)
{ var s = " " + this.trim() + " "; return s.replace(" " + r,"").rTrim();}
String.prototype.isEmpty = function() {return this.length==0;}; String.prototype.validateURL = function()
{ var urlRegX = /[^a-zA-Z0-9-]/g; return sURL.match(urlRegX, "");}
String.prototype.isEmail = function()
{ var emailReg = /^\w+([-.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/; return emailReg.test(this);}
String.prototype.isAlphaNumeric = function()
{ var alphaReg = /[^a-zA-Z0-9]/g; return !alphaReg.test(this);}
String.prototype.encodeURI = function()
{ var returnString; returnString = escape( this )
returnString = returnString.replace(/\+/g,"%2B"); return returnString
}
String.prototype.decodeURI = function() {return unescape(this)}

//--------------------------------------Array-----------------------------------------

Array.prototype.indexOf = function(p_var)
{ 
	for (var i=0; i<this.length; i++)
	{ 
		if (this[i] == p_var)
		{ 
			return(i);
		}
	}
	return(-1);
}
Array.prototype.exists = function(p_var) {return(this.indexOf(p_var) != -1);}
Array.prototype.queue = function(p_var) {this.push(p_var)}
Array.prototype.dequeue = function() {return(this.shift());}
Array.prototype.removeAt = function(p_iIndex) {return this.splice(p_iIndex, 1);}
Array.prototype.remove = function(o)
{ 
	var i = this.indexOf(o); if (i>-1) this.splice(i,1); return (i>-1)
}
Array.prototype.clear = function()
{ 
	var iLength = this.length; 
	for (var i=0; i < iLength; i++)
	{ 
		this.shift();
	}
}
Array.prototype.addArray = function(p_a)
{ 
	if (p_a)
	{ 
		for (var i=0; i < p_a.length; i++)
		{ 
			this.push(p_a[i]);
		}
	}
}

//--------------------------------------ajax-------------------------------------------

var Ajax = {
  getTransport: function() {
    return Try.these(
      function() {return new ActiveXObject('Msxml2.XMLHTTP')},
      function() {return new ActiveXObject('Microsoft.XMLHTTP')},
      function() {return new XMLHttpRequest()}
    ) || false;
  },
  
  emptyFunction: function() {}
}

Ajax.Base = function() {};
Ajax.Base.prototype = {
  setOptions: function(options) {
    this.options = {
      method:       'post',
      asynchronous: true,
      parameters:   ''
    }.extend(options || {});
  }
}

Ajax.Request = Class.create();
Ajax.Request.Events = 
  ['Uninitialized', 'Loading', 'Loaded', 'Interactive', 'Complete'];

Ajax.Request.prototype = (new Ajax.Base()).extend({
  initialize: function(url, options) {
    this.transport = Ajax.getTransport();
    this.setOptions(options);
  
    try {
      if (this.options.method == 'get')
        url += '?' + this.options.parameters + '&_=';
    
      this.transport.open(this.options.method, url, true);
      
      if (this.options.asynchronous) {
        this.transport.onreadystatechange = this.onStateChange.bind(this);
        setTimeout((function() {this.respondToReadyState(1)}).bind(this), 10);
      }
              
      this.transport.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
      this.transport.setRequestHeader('X-Prototype-Version', Prototype.Version);

      if (this.options.method == 'post') {
        this.transport.setRequestHeader('Connection', 'close');
        this.transport.setRequestHeader('Content-type',
          'application/x-www-form-urlencoded');
      }
      
      this.transport.send(this.options.method == 'post' ? 
        this.options.parameters + '&_=' : null);
                      
    } catch (e) {
    }    
    return this.transport;
  },
      
  onStateChange: function() {
    var readyState = this.transport.readyState;
    if (readyState != 1)
      this.respondToReadyState(this.transport.readyState);
  },
  
  respondToReadyState: function(readyState) {
    var event = Ajax.Request.Events[readyState];
    (this.options['on' + event] || Ajax.emptyFunction)(this.transport);
  }
});

//-----------------------------------AjaxHelper------------------------------------

var AjaxProxyUrl = new String('../Ajax.aspx');

var AjaxHelper = new Object();

AjaxHelper.Updater = function (ajaxTemplate, output, params, onComplete)
{
	var FormatContent = function(str)
	{
		var content = new String(str);
		var prefix = new String('<!--AjaxContent-->');
		content = content.substring(content.indexOf(prefix, 0) + prefix.length, content.length - 9);
		return content;
	}
	if (typeof output == 'string')
	{
		output = $(output);
	}
	if (output != null  && output.innerHTML)
	{
		output.innerHTML = '正在验证中...';
	}
	
	if (params == null || (params != null && params.length == 0))
	{
		params = '_null=';
	}
	var xmlhttp = new Ajax.Request
	(
		AjaxProxyUrl, 
		{ 
			onComplete: 
				function(transport) 
				{ 
					if (output != null && output.innerHTML) 
					{ 
						output.innerHTML = FormatContent(transport.responseText); 
					}
					if (onComplete != null) 
					{ 
						onComplete(FormatContent(transport.responseText)) 
					} 
				}, 
				parameters: params + '&AjaxTemplate=' + ajaxTemplate
		}
	);
	
	return xmlhttp;
}

//The param "direction" 's value can be "beforeBegin", "afterBegin", "beforeEnd" ,"afterEnd"
AjaxHelper.Inserter = function (element, direction, content, tagName)
{
	if (typeof element == 'string')
	{
		element = $(element);
	}

	if (element.insertAdjacentHTML)
	{
		element.insertAdjacentHTML(direction, content);
	}
	else
	{
		content = new String(content).trim();

		var fragment;

		if (tagName == null)
		{
			fragment = element.ownerDocument.createElement('span');
		}
		else
		{
			fragment = element.ownerDocument.createElement(tagName);
		}

		fragment.innerHTML = content;
		
		if (element != null)
		{
			if (direction == 'beforeBegin')
			{
				element.parentNode.insertBefore(fragment, element);
			}
			else if (direction == 'afterBegin')
			{
				element.insertBefore(fragment, element.firstChild);
			}
			else if (direction == 'beforeEnd')
			{
				element.appendChild(fragment);
			}
			else if (direction == 'afterEnd')
			{
				element.parentNode.insertBefore(fragment, element.nextSibling);
			}
		}
	}
}

//The param "direction" 's value can be "beforeBegin", "afterBegin", "beforeEnd" ,"afterEnd"
AjaxHelper.Appender = function (ajaxTemplate, output, direction, params, onComplete)
{
	if (typeof output == 'string')
	{
		output = $(output);
	}
	
	if (output != null)
	{
		return AjaxHelper.Updater(ajaxTemplate, null, params, function(responseText){AjaxHelper.Inserter(output, direction, responseText); if (onComplete != null) onComplete(responseText);})
	}
}

//-----------------------------------------------RemoteScripting---------------------------------------------------

var tempRSCallBack;

AjaxHelper.RSCallback = function (scriptPath, output, params, callback)
{
	if (params == null || (params != null && params.length == 0))
	{
		params = '_null=';
	}

	if (output != null)
	{
		if (typeof output != 'string')
		{
			if (output.id != null && output.id.length > 0)
			{
				output = output.id;
			}
			else
			{
				//work out a random id
				output.id = 'id' + Math.floor((Math.random() * 10000));
				output = output.id;
			}
		}
	}
	else
	{
		output = '';
	}

	if (callback != null)
	{
		if (typeof callback != 'string')
		{
			tempRSCallBack = callback;
			callback = 'tempRSCallBack';
		}	
	}
	else
	{
		callback = '';
	}

	var script = document.createElement('script');
	script.type = 'text\/javascript';
	script.language = 'javascript';
	script.src = scriptPath + '?' + params + '&output=' + output + '&callback=' + callback;

	//you may write any custom code in return script to operate the output element and call back callback function
	document.body.appendChild(script);
	
	return script;
}

//you must specify the remoteScriptPath as the remote AjaxHelper Based App's RemoteScript.aspx's path
//for example: set remoteScriptPath = http://teddy.cn/AhaxHelper/RemoteScript.aspx
//the ajaxTemplate here is the user control path relitive to remoteScriptPath on the remote server
AjaxHelper.RSUpdater = function (remoteScriptPath, ajaxTemplate, output, params, onComplete)
{
	if (params == null || (params != null && params.length == 0))
	{
		params = '_null=';
	}

	return AjaxHelper.RSCallback(remoteScriptPath, output, params + '&AjaxTemplate=' + ajaxTemplate, onComplete);
}

AjaxHelper.Params = new Array();

//parse ajax params after '#' in the url to Ajax.Params
var _paramStr = new String(window.location.href);
var _sharpPos = _paramStr.indexOf('#');
if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1)
{
    _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
}
else
{
    _paramStr = '';
}
if (_paramStr.length > 0)
{
    var _paramArr = _paramStr.split('&');
    for (var i = 0; i < _paramArr.length; i++)
    {
        if (_paramArr[i].indexOf('=') >= 0)
        {
            var _paramKeyVal = _paramArr[i].split('=');
            AjaxHelper.Params[_paramKeyVal[0]] = _paramKeyVal[1];
        }
        else
        {
            AjaxHelper.Params[_paramArr[i]] = _paramArr[i];
        }
    }
}

AjaxHelper.Params.toString = function()
{
	var _retStr = _paramStr;
	var _andPos = _retStr.indexOf('&');
	if (_andPos > 0  && _andPos != _retStr.length)
	{
		_retStr = _retStr.substring(_andPos + 1, _retStr.length);
	}
	_andPos = _retStr.indexOf('&');
	if (_andPos > 0  && _andPos != _retStr.length)
	{
		_retStr = _retStr.substring(_andPos + 1, _retStr.length);
	}
	else
	{
		_retStr = null;
	}
	return _retStr;
};

//set the default Updater & Appender handler
AjaxHelper.Updater2 = function(ajaxTemplate, output, params, onComplete)
{
	if (typeof output != 'string')
	{
		return;
	}
    AjaxHelper.Updater(ajaxTemplate, output, params, onComplete);
   // window.location = '#ajaxTemplate=' + ajaxTemplate + '&output=' + output + (params != null ? '&' + params : '');
};

AjaxHelper.OnPageLoad = function ()
{
	if (AjaxHelper.Params['ajaxTemplate'] != null)
	{
		AjaxHelper.Updater2(AjaxHelper.Params['ajaxTemplate'], AjaxHelper.Params['output'], AjaxHelper.Params.toString());
	}
};