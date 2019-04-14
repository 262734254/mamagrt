using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;

using Tz888.BLL;
using Tz888.BLL.Login;
using Tz888.Model;
using System.Data;
using System.IO;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;


/// <summary>
/// communicate 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class communicate : System.Web.Services.WebService
{

    public communicate()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    /// <summary>
    /// 添加好友
    /// </summary>
    /// <param name="ContactName"></param>
    /// <returns></returns>
    [WebMethod]
    public string AddFriend(string ContactName)
    {
        string username = "";
        string grade = "";
        string type = "";
        grade = Tz888.BLL.Login.LoginInfoBLL.getCookieNameByCookieType(1);
        type = Tz888.BLL.Login.LoginInfoBLL.getCookieNameByCookieType(2);
        bool success = false;
        try
        {
            Tz888.Model.GoodFriend friendSet = new Tz888.Model.GoodFriend();
            Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
            friendSet = friendBll.GetFriendSet(ContactName);
            if (friendSet != null)
            {
                bool res = false;
                if (friendSet.MemberGrade == 2)
                {
                    res=(grade=="MG1002");
                }
                if (res)
                {
                    switch (friendSet.MemberType)
                    {
                        case 0:
                            success = true;
                            break;
                        case 1:
                            success = (type=="GT1004");
                            break;
                        case 2:
                            success = (type == "GT1003");
                            break;
                        case 3:
                            success = (type == "GT1001");
                            break;
                    }
                }
            }
            else
            {
                success = true;
            }

            if (success)
            {
                Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
                model.LoginName = Tz888.BLL.Login.LoginInfoBLL.getCookieNameByCookieType(0);
                model.ContactName = ContactName;
                model.GroupId = 1;
                friendBll.AddFriend(model);
                return "ok";
            }
            else
            {
                return "failed";
            }
        }
        catch (Exception e)
        {
           string err = e.Message.ToString();
            return err;
        }
    }
    /// <summary>
    /// 留言
    /// </summary>
    /// <param name="ContactName"></param>
    /// <returns></returns>
    [WebMethod]
    public string AddComment(int infoId, string commentName, string telNum, string email, string commentText)
    {
        try
        {
            Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model.InfoID = infoId;
            model.LoginName = commentName.Trim();
            model.CommentContent = commentText.Trim();
            model.FatherID = 0;
            model.CommentTime = DateTime.Now;
            bool result = msgBll.SetResponse(model);
            if (result)
            {
                return "ok";
            }
            else
            {
                return "failed";
            }
        }
        catch (Exception e)
        {
            string err = e.Message.ToString();
            return err;
        }
    }

}

