// JScript 文件

    function Email()
{
 var Nemail=document.getElementById("txtemail").value;
 var name="cn";
   $.ajax({type:"get",url:"Control/ResponseAjax.aspx",data:"name="+name+"&type=email&email="+Nemail+"",success:function(msg) 
   { 
   alert(msg);
    if(msg==1)
    {
      document.getElementById("showemail").InnerHtml="<span style='color:red'>邮箱已存在</span>";
      return false;
    }
    else 
    {
       document.getElementById("showemail").InnerHtml="";
    }
   }});
}

