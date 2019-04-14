using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.BLL.Register;
public partial class PayManage_RechargeCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string LoginName = this.Page.User.Identity.Name;
        if (txtLoginName.Text.Trim() != "")
        {
            int result = 0;
            MemberInfoBLL memberBll = new MemberInfoBLL();

            int result1 = memberBll.ValideNameUseable(txtLoginName.Text.Trim());
            if (result1 > 0)
            {
                result = memberBll.RechargeCard(txtNumber.Text.ToString().Trim());
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "充值帐号不正确请重新输入！");
            }
            if (result > 0)
            {   //不可用
                int passresult = memberBll.CardPassWord(txtNumber.Text.ToString().Trim(), txtpassword.Text.ToString().Trim());
                if (passresult > 0)
                {
                    int state = memberBll.RechargeStateCard(txtNumber.Text.ToString().Trim());
                    if (state == 0)
                    {
                        string Money = memberBll.CarMoney(txtNumber.Text.ToString().Trim());
                        Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
                        Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

                        model.PayTypeCode = "Card";
                        model.LoginName = LoginName;              //充值人
                        model.StrikeLoginName = txtLoginName.Text.Trim();          //充值帐户
                        model.TotalCount = Convert.ToDouble(Money);
                        model.BuyType = "Pre-Paid";                             //购买类型
                        if (txtBank.Text.ToString().Trim() == "")
                        {
                            model.remark = txtLoginName.Text.Trim() + "使用银行汇款充值" + Money + "元" + " 操作人 " + LoginName;//备注
                        }
                        else
                        { model.remark = txtBank.Text.ToString().Trim(); }
                        model.OperationMan = LoginName;

                        int orderno = dal.CreateStrikeOrder(model);
                        if (orderno > 0)
                        {
                            Tz888.BLL.StrikeOrder dall = new Tz888.BLL.StrikeOrder();
                            bool b = dall.RechargeCardSuccess(Convert.ToString(orderno), "Card", "", LoginName, txtNumber.Text.ToString().Trim(), Convert.ToInt32(1));
                            if (b)
                            {
                                Tz888.BLL.Order.BusStrikeRecBLL RecBLL = new Tz888.BLL.Order.BusStrikeRecBLL();
                                Tz888.Model.Orders.BusStrikeRecTab BusModel = new Tz888.Model.Orders.BusStrikeRecTab();
                                BusModel.CardNo = Convert.ToInt64(orderno);
                                BusModel.ChangeBy = LoginName;
                                BusModel.ChangeTime = System.DateTime.Now;
                                BusModel.Email = txtEmail.Text.ToString().Trim();
                                BusModel.Tel = txtTelCountry.Value.ToString().Trim() + txtTelZoneCode.Value.ToString().Trim() + txtTelNumber.Value.ToString().Trim();
                                BusModel.PointCount = Convert.ToDecimal(Money);
                                if (txtBank.Text.ToString().Trim() == "")
                                {
                                    BusModel.Remark = txtLoginName.Text.Trim() + "使用银行汇款充值" + Money + "元" + " 操作人 " + LoginName;//备注
                                }
                                else
                                {
                                    BusModel.Remark =txtBank.Text.ToString().Trim(); 
                                }
                                BusModel.StrikeType = "Card";
                                BusModel.Mobile = txtMobile.Value.ToString().Trim();
                                BusModel.LoginName = txtLoginName.Text.ToString().Trim();
                                BusModel.Free = Convert.ToInt32(1);
                                BusModel.CardNumber = txtNumber.Text.ToString().Trim();
                                int num = RecBLL.Add(BusModel);
                                if (num > 0)
                                {
                                    Tz888.Common.MessageBox.Show(this.Page, "充值成功!");
                                }
                            }
                        }
                        else
                        {
                            Tz888.Common.MessageBox.Show(this.Page, "订单提交失败!请重试!");
                        }
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "该卡号已充值，不能重复充值！");
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "充值卡密码不正确请重新输入！");
                }
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "充值卡号不正确请重新输入！");
            }

        }

        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "帐号不为空或者帐号不正确!");
            return;
        }
    }
}
