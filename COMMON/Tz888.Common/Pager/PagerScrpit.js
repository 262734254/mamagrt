function setPageTo(pageIndex,panel)
{
    var context=document.getElementById(panel);
    context.innerHTML="数据加载中...";
    var arg=pageIndex;
    <%= ClientScript.GetCallbackEventReference(this, "arg", "onCallServerComplete", "context")%>; 
}
function onCallServerComplete(result,context)
{
    context.innerHTML=result;
}