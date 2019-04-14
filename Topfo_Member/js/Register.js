// JScript 文件
//Function:     Member Register
//Author:       Siser(Siser0409@163.com)
//Create Date   2007-10-1
//Modify Date:  2007-10-14

function ChoseType(id)
{
  var GOV_SUBMIT_URL = "RegGovBasicInfo.aspx";
  var COM_SUBMIT_URL = "RegEnterpriseInfo.aspx";
  var PSN_SUBMIT_URL = "RegPersonalInfo.aspx";
  
  var frm = $("frmReg");

  $(eval(id)[0]).className = "inj";
  $(eval(id)[1]).checked = true;
  $(eval(id)[2]).className = "mon";
  ClearStyle(id);
  frm.action =eval( id.toUpperCase()+"_SUBMIT_URL");
 
}
function ClearStyle(pid)
{
  for(var i=0;i<dtrs.length;i++)
  {
    if(pid != dtrs[i])
    {   
        $(eval(dtrs[i])[0]).className = "";
        $(eval(dtrs[i])[2]).className = "mout";
        
    }
  }
}

function $(id)
{
    return document.getElementById(id);
}

var gov = new Array("thgov","radgov","tdgov");
var com = new Array("thcom","radcom","tdcom");
var psn = new Array("thpsn","radpsn","tdpsn");
var dtrs = new Array("gov","com","psn");
