﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.BLL;
using Tz888.Model.Register;
using Tz888.BLL.Common;
using Tz888.BLL;

public partial class Register_VIPRegisterSubmit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ApplyID = Convert.ToInt32(Request.QueryString["ApplyID"]);
        hlUpdate.NavigateUrl = "VIPMemberRegister.aspx?ApplyID=" + ApplyID;
        getMessage(ApplyID);
    }

    public void getMessage(int ApplyID)
    {
        Tz888.BLL.Register.VIPMemberRegister obj = new Tz888.BLL.Register.VIPMemberRegister();
        Tz888.Model.Register.VIPMemberRegister model = new Tz888.Model.Register.VIPMemberRegister();
        try
        {
            model = obj.GetVIPMemberModel(ApplyID);
            lbOrgName.Text = model.OrgName;
            lbtbRealName.Text = model.RealName;
            lbSex.Text = model.Sex ? "男士" : "女士";

            if (model.BuyTerm.ToString().Trim() == "1")
            {
                lbBuyTerm.Text = "三个月";
            }
            else if (model.BuyTerm.ToString().Trim() == "2")
            {
                lbBuyTerm.Text = "半年";
            }
            else if (model.BuyTerm.ToString().Trim() == "3")
            {
                lbBuyTerm.Text = "一年";
            }

            switch (model.ManageTypeID.Trim())
            {
                case "1001":
                    lbManageType.Text = "个人";
                    lbPrice.Text = obj.getPriceByType("1001", Convert.ToInt32(model.BuyTerm.ToString().Trim()));
                    break;
                case "1003":
                    lbManageType.Text = "企业";
                    lbPrice.Text = obj.getPriceByType("1003", Convert.ToInt32(model.BuyTerm.ToString().Trim()));
                    break;
                case "1004":
                    lbManageType.Text = "政府";
                    lbPrice.Text = obj.getPriceByType("1004", Convert.ToInt32(model.BuyTerm.ToString().Trim()));
                    break;
            }
        }
        catch { }
      
        lbTel.Text = model.TelCountryCode + "-" + model.TelStateCode + "-" + model.TelNum;
        lbEmail.Text = model.Email;
    }
}
