using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using AjaxPro;


namespace Tz888.BLL.Info
{
    public class InfoDefaultCommon
    {
        const string DisableScript = @"<script language='javascript'>
<!-- 
	var DisableEl = new Array({0});
	for(var i=0 ;i<DisableEl.length;i++)
	{{
	
		var el = document.getElementById(DisableEl[i]);
		el.onclick=awarn;
		//el.style.backgroundColor=""#cccc"";
		//el.disabled=true;
		//alert(el.checked);
	}}
function awarn(){{this.checked=true;return false;}}
//-->
</script>";
        const string ajaxInvoke = @"<script language='javascript'>
<!--
var contentEl = 'keywordContent';
function ViewStr(infoID,infoTypeID,defaultValueID,orginEL,strDiv,defType)
{
	var originStr = document.getElementById(orginEL).value;
	switch(defType)
	{
		case 1://����
			checkEL = 'chkTitle';
			defaultEL = 'chkTitleDefault';
			contentEl = 'titleContent';
			break;
		case 2://�ؼ���
			checkEL = 'chkKeyWord';
			defaultEL = 'chkKeyWordDefault';
			contentEl = 'keyWordContent';
			break;
		case 4://����
			checkEL = 'chkDes';
			defaultEL = 'chkDesDefault';
			contentEl = 'desContent';
			if(originStr != '')
			{
				document.getElementById(contentEl).innerHTML = originStr;
				return;
			}		
			break;
	}
	var els=document.getElementById(checkEL).getElementsByTagName('Input');
	var subDefaultIds='';
	var useDefault = '1';
	if(els.length == 0)//û�����ò���,ֱ�ӷ���
	{
		document.getElementById(contentEl).innerHTML = originStr;
		return;
	}
	if(document.getElementById(defaultEL).checked == false)
	{
		useDefault = '0';
	}
	for(var i=0;i<els.length;i++)
	{
		if(els[i].checked)
		{
			subDefaultIds +=  '1,';
		}
		else
		{
			subDefaultIds +=  '0,';
		}
	}
	if(subDefaultIds != '')
	{
		subDefaultIds = subDefaultIds.substring(0,subDefaultIds.length - 1);
	}
		InfoDefaultCommon.GetPreString(infoID,infoTypeID,defaultValueID,useDefault,subDefaultIds,originStr, strDiv,defType,Pre_Callback);
	}

	function Pre_Callback(response)
{
	document.getElementById(contentEl).innerHTML = response.value;
}
//-->
</script>";
        public InfoDefaultCommon()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ����infoID,�Լ���CheckBoxList��ֵ���档
        /// </summary>
        /// <param name="infoID"></param>
        /// <param name="chkKeyWord"></param>
        /// <param name="chkTitles"></param>
        /// <param name="chkDes"></param>
        public static void SaveKeyWordTitleDes(long infoID, string[][] allDefaults, CheckBoxList chkKeyWord, bool keyworkDefault, CheckBoxList chkTitles, bool titleDefault, CheckBoxList chkDes, bool desDefault)
        {
            Tz888.BLL.Info.InfoDefaultDEFRule infoDefault = new InfoDefaultDEFRule();

            infoDefault.DeSelect(infoID);//��������Ϣ��ԭ�ж���ȫ����ѡ��

            //����ؼ���
            if (keyworkDefault == false)
            {
                for (int i = 0; i < chkKeyWord.Items.Count; i++)
                {

                    if (chkKeyWord.Items[i].Selected)
                    {
                        Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                        model.InfoID = infoID;
                        model.DefType = 2;//�ؼ�������
                        model.IsSelect = 1;
                        model.SubDefaultValueID = Convert.ToInt64(chkKeyWord.Items[i].Value);
                        infoDefault.Insert(model);
                    }
                }
            }
            else//ʹ��Ĭ�Ϲؼ���
            {
                //dvDefault.RowFilter = "(IsDefaultSelect =1 OR IsNeeded=1) AND (DefType=2 OR DefType=3 OR DefType=6 OR DefType=7) ";
                for (int i = 0; i < allDefaults[0].Length; i++)
                {
                    Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                    model.InfoID = infoID;
                    model.DefType = 2;//�ؼ�������
                    model.IsSelect = 1;
                    model.SubDefaultValueID = Convert.ToInt64(allDefaults[0][i]);
                    infoDefault.Insert(model);
                }

            }

            //������ⶨ��
            if (titleDefault == false)
            {
                for (int i = 0; i < chkTitles.Items.Count; i++)
                {
                    if (chkTitles.Items[i].Selected)
                    {
                        Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                        model.InfoID = infoID;
                        model.DefType = 1;//��������
                        model.IsSelect = 1;
                        model.SubDefaultValueID = Convert.ToInt64(chkTitles.Items[i].Value);
                        infoDefault.Insert(model);
                    }
                }
            }
            else
            {//����Ĭ������
                //dvDefault.RowFilter = "(IsDefaultSelect =1 OR IsNeeded=1) AND (DefType=1 OR DefType=3 OR DefType=5 OR DefType=7) ";
                for (int i = 0; i < allDefaults[1].Length; i++)
                {
                    Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                    model.InfoID = infoID;
                    model.DefType = 1;//��������
                    model.IsSelect = 1;
                    model.SubDefaultValueID = Convert.ToInt64(allDefaults[0][i]);
                    infoDefault.Insert(model);
                }
            }

            //��������
            if (desDefault == false)
            {
                for (int i = 0; i < chkDes.Items.Count; i++)
                {
                    if (chkDes.Items[i].Selected)
                    {
                        Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                        model.InfoID = infoID;
                        model.DefType = 4;//��������
                        model.IsSelect = 1;
                        model.SubDefaultValueID = Convert.ToInt64(chkDes.Items[i].Value);
                        infoDefault.Insert(model);
                    }
                }
            }
            else
            {//����Ĭ������
                //dvDefault.RowFilter = "(IsDefaultSelect =1 OR IsNeeded=1) AND (DefType=4 OR DefType=5 OR DefType=6 OR DefType=7) ";
                for (int i = 0; i < allDefaults[2].Length; i++)
                {
                    Tz888.Model.Info.InfoDefaultDEFModel model = new Tz888.Model.Info.InfoDefaultDEFModel();
                    model.InfoID = infoID;
                    model.DefType = 4;//��������
                    model.IsSelect = 1;
                    model.SubDefaultValueID = Convert.ToInt64(allDefaults[2][i]);
                    infoDefault.Insert(model);
                }
            }
        }

        public static string[][] InitKeywordTitleDes(System.Web.UI.Page page, long infoID, Tz888.Model.Info.MainInfoModel model, CheckBoxList chkKeyWord, CheckBoxList chkTitles, CheckBoxList chkDes, ref string defaultValueID)
        {
            bool isPostback = page.IsPostBack;//��ʼ��ʱ��Ҫ�ж��Ƿ���PostBack
            ArrayList disableInputs = new ArrayList();
            PageIniControl pic = new PageIniControl();

            //ע��ajax�ű�
            if (page.IsClientScriptBlockRegistered("ajaxInvokeadfsf") == false)
            {
                page.RegisterClientScriptBlock("ajaxInvokeadfsf", ajaxInvoke);
            }

            DataTable dt = null;
            if (isPostback == false)// || defaultValueID == null || defaultValueID == "" || defaultValueID == "0" )
            {
                dt = pic.DefaultViewDataBind(model).Table;//Load��Ӧ��Ϣ���͵Ĺؼ��ֵ�����
                if (dt != null && dt.Rows.Count > 0)
                {
                    defaultValueID = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    return new string[][]{new string[]{},
						new string[]{},
						new string[]{}
										 };
                }
            }
            else
            {
                if (defaultValueID == null || defaultValueID == "" || defaultValueID == "0")
                {
                    return new string[][]{new string[]{},
											 new string[]{},
											 new string[]{}
										 };//���ؿմ�
                }
                long currentPage = 1;
                long pageCount = 0;
                Tz888.BLL.Info.SetSubDefaultValueRule ssdv = new SetSubDefaultValueRule();
                dt = (ssdv.GetList("ID as SubDefaultID,DefType,IsNeeded,IsDefaultSelect", "SetDefaultValueID=" + defaultValueID, "", ref currentPage, -1, ref pageCount)).Table;
            }

            bool isFirst = true;//������Ϣ��һ�μ���
            //Load����Ϣ�Ĺؼ��ֵ�����

            Tz888.BLL.Info.InfoDefaultDEFRule infoDefault = new InfoDefaultDEFRule();

            DataView dvInfoDefault = infoDefault.GetList(infoID, 0);
            DataView dvKeyWord = new DataView(dt);

            if (isPostback == false)
            {

                dvKeyWord.Sort = "Seq";
                dvKeyWord.RowFilter = "DefType=2 OR DefType=3 OR DefType=6 OR DefType=7";
                chkKeyWord.DataSource = dvKeyWord;
                chkKeyWord.DataBind();

                //����Ϣ�Ķ���

                dvInfoDefault.RowFilter = "DefType = 2";
                for (int i = 0; i < dvInfoDefault.Count; i++)
                {
                    string subDefaultValueID = dvInfoDefault[i]["SubDefaultValueID"].ToString().Trim();
                    ListItem li = chkKeyWord.Items.FindByValue(subDefaultValueID);
                    if (li != null)
                    {
                        li.Selected = true;
                        isFirst = false;
                    }

                }
            }
            ArrayList keyDefaults = new ArrayList();//Ĭ��ѡ��ͱ�����,ID�ļ���
            //Ĭ��ѡ��
            for (int i = 0; i < dvKeyWord.Count; i++)
            {
                bool isDefaultSelect = Convert.ToBoolean(dvKeyWord[i]["IsDefaultSelect"]);
                bool isNeeded = Convert.ToBoolean(dvKeyWord[i]["IsNeeded"]);
                string subDefaultID = dvKeyWord[i]["SubDefaultID"].ToString().Trim();
                if (isDefaultSelect || isNeeded)
                {
                    keyDefaults.Add(subDefaultID);
                }
                if ((isDefaultSelect && isFirst) || isNeeded)
                {

                    ListItem li = chkKeyWord.Items.FindByValue(subDefaultID);
                    if (li != null)
                    {
                        if (isPostback == false)
                        {
                            li.Selected = true;
                        }
                        if (isNeeded)
                        {

                            disableInputs.Add(chkKeyWord.ClientID + "_" + chkKeyWord.Items.IndexOf(li).ToString());
                        }
                    }

                }
            }


            dvKeyWord = null;
            //��Title
            isFirst = true;//������Ϣ��һ�μ���
            ArrayList titleDefaults = new ArrayList();//Ĭ��ѡ��ͱ�����,ID�ļ���
            DataView dvTitle = new DataView(dt);
            if (isPostback == false)
            {

                dvTitle.Sort = "Seq";
                dvTitle.RowFilter = "DefType=1 OR DefType=3 OR DefType=5 OR DefType=7";
                chkTitles.DataSource = dvTitle;
                chkTitles.DataBind();
                dvInfoDefault.RowFilter = "DefType = 1";
                for (int i = 0; i < dvInfoDefault.Count; i++)
                {
                    string subDefaultValueID = dvInfoDefault[i]["SubDefaultValueID"].ToString().Trim();
                    ListItem li = chkTitles.Items.FindByValue(subDefaultValueID);
                    if (li != null)
                    {
                        li.Selected = true;
                        isFirst = false;
                    }
                }
            }
            //Ĭ��ѡ��
            for (int i = 0; i < dvTitle.Count; i++)
            {
                bool isDefaultSelect = Convert.ToBoolean(dvTitle[i]["IsDefaultSelect"]);
                bool isNeeded = Convert.ToBoolean(dvTitle[i]["IsNeeded"]);
                string subDefaultID = dvTitle[i]["SubDefaultID"].ToString().Trim();
                if (isDefaultSelect || isNeeded)
                {
                    titleDefaults.Add(subDefaultID);
                }
                if ((isDefaultSelect && isFirst) || isNeeded)
                {

                    ListItem li = chkTitles.Items.FindByValue(subDefaultID);
                    if (li != null)
                    {
                        if (isPostback == false)
                        {
                            li.Selected = true;
                        }
                        if (isNeeded)
                        {
                            disableInputs.Add(chkTitles.ClientID + "_" + chkTitles.Items.IndexOf(li).ToString());
                        }
                    }

                }
            }

            dvTitle = null;
            //������
            isFirst = true;//������Ϣ��һ�μ���
            DataView dvDes = new DataView(dt);
            if (isPostback == false)
            {
                dvDes.Sort = "Seq";
                dvDes.RowFilter = "DefType=4 OR DefType=5 OR DefType=6 OR DefType=7";
                chkDes.DataSource = dvDes;
                chkDes.DataBind();
                dvInfoDefault.RowFilter = "DefType = 4";
                for (int i = 0; i < dvInfoDefault.Count; i++)
                {
                    string subDefaultValueID = dvInfoDefault[i]["SubDefaultValueID"].ToString().Trim();
                    ListItem li = chkDes.Items.FindByValue(subDefaultValueID);
                    if (li != null)
                    {
                        li.Selected = true;
                        isFirst = false;
                    }
                }
            }
            //Ĭ��ѡ��
            ArrayList desDefaults = new ArrayList();//Ĭ��ѡ��ͱ�����,ID�ļ���
            for (int i = 0; i < dvDes.Count; i++)
            {
                bool isDefaultSelect = Convert.ToBoolean(dvDes[i]["IsDefaultSelect"]);
                bool isNeeded = Convert.ToBoolean(dvDes[i]["IsNeeded"]);
                string subDefaultID = dvDes[i]["SubDefaultID"].ToString().Trim();
                if (isDefaultSelect || isNeeded)
                {
                    desDefaults.Add(subDefaultID);
                }
                if ((isDefaultSelect && isFirst) || isNeeded)
                {

                    ListItem li = chkDes.Items.FindByValue(subDefaultID);
                    if (li != null)
                    {
                        if (isPostback == false)
                        {
                            li.Selected = true;
                        }

                        if (isNeeded)
                        {
                            disableInputs.Add(chkDes.ClientID + "_" + chkDes.Items.IndexOf(li).ToString());
                        }
                    }

                }
            }

            dvDes = null;

            string disableInputStr = "";
            for (int i = 0; i < disableInputs.Count; i++)
            {
                disableInputStr += @"'" + disableInputs[i].ToString() + @"',";
            }
            if (disableInputStr != "")//ע����ñ�ѡ��Ľű�
            {
                disableInputStr = disableInputStr.TrimEnd(new char[] { ',' });
                if (page.IsStartupScriptRegistered("DisabledScript") == false)
                {
                    page.RegisterStartupScript("DisabledScritp", string.Format(DisableScript, disableInputStr));
                }
            }

            string[][] allDefaults = new string[3][];
            allDefaults[0] = new string[keyDefaults.Count];
            allDefaults[1] = new string[titleDefaults.Count];
            allDefaults[2] = new string[desDefaults.Count];
            keyDefaults.CopyTo(allDefaults[0]);
            titleDefaults.CopyTo(allDefaults[1]);
            desDefaults.CopyTo(allDefaults[2]);
            return allDefaults;
        }

        [AjaxPro.AjaxMethod]
        public static string GetPreString(string infoID, string infoTypeID, string defaultValueID, string useDefault, string subDefaultIds, string originStr, string strDiv, string defType)
        {
            Tz888.BLL.Info.SetSubDefaultValueRule obj = new SetSubDefaultValueRule();

            long pageCount = 0;
            long currentPage = 1;
            DataView dv = null;
            try
            {
                dv = obj.GetList("ID,Seq,DefType,IsNeeded,IsDefaultSelect", "SetDefaultValueID=" + defaultValueID, "Seq", ref currentPage, -1, ref pageCount);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            string[] subDefaults = subDefaultIds.Split(new char[] { ',' });
            dv.Sort = "seq";
            bool isKeyword = false;
            switch (defType)
            {
                case "1"://��ҳ����
                    dv.RowFilter = "DefType=1 OR DefType=3 OR DefType=5 OR DefType=7";
                    break;
                case "2"://�ؼ���
                    dv.RowFilter = "DefType=2 OR DefType=3 OR DefType=6 OR DefType=7";
                    isKeyword = true;
                    break;
                case "4"://����
                    dv.RowFilter = "DefType=4 OR DefType=5 OR DefType=6 OR DefType=7";
                    break;
                default:
                    break;

            }
            string subDefaultIDStr = "";
            if (useDefault.Trim() == "1")//ʹ��ȱʡֵ
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    if (Convert.ToBoolean(dv[i]["IsNeeded"]) || Convert.ToBoolean(dv[i]["IsDefaultSelect"]))
                    {
                        subDefaultIDStr += dv[i]["ID"].ToString().Trim() + ",";
                    }
                }
            }
            else
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    if (subDefaults[i] == "1")
                    {
                        subDefaultIDStr += dv[i]["ID"].ToString().Trim() + ",";
                    }
                }
            }
            if (subDefaultIDStr != "")
            {
                subDefaultIDStr = subDefaultIDStr.TrimEnd(new char[] { ',' });
            }
            else
            {
                return originStr;
            }
            char div = strDiv.ToCharArray()[0];
            try
            {
                Tz888.BLL.Info.InfoDefaultDEFRule infoDef = new InfoDefaultDEFRule();

                return infoDef.GetKeyWordOrTitleOrDes(infoID, infoTypeID, subDefaultIDStr, originStr, div, isKeyword);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}