using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
using Tz888.Model;

public partial class Register_Control_ImageUpLoadForAdditive : System.Web.UI.UserControl
{
    #region  属性
    private int oper = 0;//操作(0 添加 1 删除)
    private string resourceAddr = "";
    private string imageAddr = "";
    public int Oper
    {
        set { oper = value; }
        get { return oper; }
    }
    public string ResourceAddr
    {
        set { resourceAddr = value; }
        get { return resourceAddr; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {       
           // imgCancelPic1.Visible = false;
            Panel1.Visible = false;
            lbName.Text = this.ResourceAddr.Trim();
            if (Image1.ImageUrl == "") Image1.ImageUrl = " ../ ../images/MemberData/men.jpg";
       
    }
    protected void imgbtnPic1_Click1(object sender, EventArgs e)
    {
        //检查上传图片的文件格式与文件大小是否符合要求
        int intImgCount = 0; //上传的图片数目
        switch (Tz888.BLL.Register.common.checkUploadFile(uplPic1))
        {
            case 0:
                //正常可以上传
                intImgCount++;
                break;
            //case 1:
            //    //文件过大
            //    Response.Write("<script>alert('上传的文件不能超过200K!')</script>");
            //    return;
            case 2:
                //不允许上传该类图片文件
                Response.Write("<script>alert('不允许上传该类图片文件!')</script>");
                return;
            case 3:
                //没有上传的图片
                break;
        }
        Image1.ImageUrl = uplPic1.Value;
        string TmpFileName = "";
        //上传文件并返回文件名						
        string UploadServerRootPath = Tz888.BLL.Register.common.GetUploadRootPath();
        string UploadServerPath = Tz888.BLL.Register.common.GetTmpUploadPath(true);
        TmpFileName = Tz888.BLL.Register.common.UploadFileWithThumbnail(uplPic1, UploadServerPath, false, 150, 100, 40);
        if (TmpFileName == "")
            return;

        //this.ViewState["ImgName"] = tbImgName.Text;

        //分离出除图片服务器的根目录
        string FullPath = UploadServerPath + TmpFileName;
        TmpFileName = FullPath.Replace(UploadServerRootPath, "");
        hidePic1.Value = TmpFileName;

        //lbName.Text = tbImgName.Text.Trim();
        //设置状态      
        btOper.Visible = false;
        imgCancelPic1.Visible = true;
        Panel1.Visible = false;
    }
    protected void imgCancelPic1_Click1(object sender, EventArgs e)
    {
        //删除文件
        string TmpFilePath = hidePic1.Value;
        string TmpFileName = "";
        if (TmpFilePath != "")
        {
            TmpFileName = Path.GetFileName(TmpFilePath);
            string UploadServerTmpPath = Tz888.BLL.Register.common.GetTmpUploadPath(true);
            if (File.Exists(UploadServerTmpPath + TmpFileName))
                File.Delete(UploadServerTmpPath + TmpFileName);
            try
            {
                TmpFileName = TmpFileName.Insert(TmpFileName.LastIndexOf("."), "_s");
                if (File.Exists(UploadServerTmpPath + TmpFileName))
                    File.Delete(UploadServerTmpPath + TmpFileName);
            }
            catch { }

            Image1.ImageUrl = "";//默认图片
           // lbName.Text = "";
            btOper.Visible = true;
            imgCancelPic1.Visible = false;
            hidePic1.Value = "";
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = false;
        }
    }

    protected void btOper_Click(object sender, EventArgs e)
    {
        imgCancelPic1.Visible = true;
        Panel1.Visible = true;
        btOper.Visible = false;
    }

    public bool UpLoadImage()
    {
        //转移上传文件
        int i = 0;
        string[] UploadImgFileName = new string[4];
        string UploadServerRootPath = Tz888.BLL.Register.common.GetUploadRootPath();
        string UploadServerTmpPath = Tz888.BLL.Register.common.GetTmpUploadPath(false);//临时路径
        string UploadServerPathDest = Tz888.BLL.Register.common.GetUploadPath("MemberResourceModel", false);
        string TmpFileName;
        string TmpFileNameMin;
        string TmpFilePath;
        bool bl = true;
        TmpFilePath = hidePic1.Value;
        if (TmpFilePath != "")
        {
            //移动
            TmpFileName ="test"+ Path.GetFileName(TmpFilePath);
            if (File.Exists(UploadServerRootPath + UploadServerTmpPath + TmpFileName))
            {
                File.Move(UploadServerRootPath + UploadServerTmpPath + TmpFileName,
                    UploadServerRootPath + UploadServerPathDest + TmpFileName);
            }
            TmpFileNameMin = TmpFileName.Insert(TmpFileName.LastIndexOf("."), "_s");
            if (File.Exists(UploadServerRootPath + UploadServerTmpPath + TmpFileNameMin))
            {
                File.Move(UploadServerRootPath + UploadServerTmpPath + TmpFileNameMin,
                    UploadServerRootPath + UploadServerPathDest + TmpFileNameMin);
            }
          
            if (TmpFileName != "")
            {
                this.ResourceAddr = "MemberResourceModel/" + TmpFileName;
                ////存入数据库
                //Tz888.BLL.MemberResourceBLL obj = new Tz888.BLL.MemberResourceBLL();
                //Tz888.Model.MemberResourceModel modelInfo = new Tz888.Model.MemberResourceModel();

                //modelInfo.ResourceID = 0;
                //modelInfo.LoginName = model.LoginName;
                //modelInfo.ResourceName = TmpFileName;//资源名称
                //modelInfo.ResourceTitle = this.ViewState["ImgName"].ToString().Trim();//资源短标题
                //modelInfo.ResourceDescrib = model.ResourceDescrib;//资源介绍
                //modelInfo.ResourceType = model.ResourceType;//资源类型
                //modelInfo.ResourceAddr = "MemberResourceModel/" + TmpFileName;//资源地址
                //modelInfo.ResourceProperty = model.ResourceProperty;//资源性质
                //modelInfo.ResourcePassword = null;//资源密码
                //modelInfo.UpDate = DateTime.Now;//上传日期
                //modelInfo.IsDel = false;//是否删除
                //modelInfo.remark = model.remark;

                //int ii = obj.Add(modelInfo);
               
                //if (ii > 0)
                //{
                //     bl = true;
                //}
                //else{
                //     bl = false;
                //}
            }
            else {
               
            }
        }
        return bl;
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        Response.Write("fdsafd");
    }
}
