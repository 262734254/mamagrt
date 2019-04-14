function $(id)
{
    return document.getElementById(id);
}
document.writeln("<div id=\"mdiv\" style=\" position:absolute;display:none;FILTER: Alpha(Opacity=10);\"><\/div>");
document.writeln("<div id='loading' style='BORDER-RIGHT: #dbdce3 1px solid; BORDER-TOP: #dbdce3 1px solid; DISPLAY: none; BORDER-LEFT: #dbdce3 1px solid; BORDER-BOTTOM: #dbdce3 1px solid; POSITION: absolute; BACKGROUND-COLOR: #ffffae'><IMG height='32' src='images/loading.gif' width='32' align='absMiddle'>");
document.writeln("正在加载,请稍后……");
document.writeln("<\/div>");
function Init()
{
	$("loading").style.left = (document.body.clientWidth)/3;
    $("loading").style.top = document.body.scrollTop+(document.body.clientHeight)/3;
    $('loading').style.display    = '';
    $('loading').style.zIndex    = 200;
    $("mdiv").style.backgroundColor = "#000000";
    $('mdiv').style.display        = '';
    $('mdiv').style.zIndex        = 100;
    $('mdiv').style.height        = document.body.offsetHeight;
    $('mdiv').style.width        = document.body.offsetWidth;
}
function unLoad()
{
	$('loading').style.display    = 'none';
    $('mdiv').style.display        = 'none';
}
