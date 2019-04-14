using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;

public partial class ValidateNumber : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DrawImage(5);
        }
    }

    /// <summary>
    /// 随机码认证>>
    /// </summary>
    /// <param name="code">生成认证长度</param>
    protected void DrawImage(int code)
    {
        Session["valationNo"] = this.Str(code,false);
        CreateImages(Session["valationNo"].ToString());

       
    }

    #region 生成验证码
    //private void ValidateCode(string VNum)
    //{
    //    if (VNum == null || VNum.Trim() == String.Empty)
    //        return;

    //    System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling(Convert.ToDouble((VNum.Length * 15))), 25);
    //    Graphics g = Graphics.FromImage(image);

    //    try
    //    {
    //        //生成随机生成器 
    //        Random random = new Random();

    //        //清空图片背景色 
    //        g.Clear(Color.White);

    //        //画图片的背景噪音线 
    //        for (int i = 0; i < 30; i++)
    //        {
    //            int x1 = random.Next(image.Width);
    //            int x2 = random.Next(image.Width);
    //            int y1 = random.Next(image.Height);
    //            int y2 = random.Next(image.Height);

    //            g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
    //        }

    //        Font font = new System.Drawing.Font("Arial", 14, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
    //        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
    //        g.DrawString(VNum, font, brush, 2, 2);

    //        //画图片的前景噪音点 
    //        for (int i = 0; i < 100; i++)
    //        {
    //            int x = random.Next(image.Width);
    //            int y = random.Next(image.Height);

    //            image.SetPixel(x, y, Color.FromArgb(random.Next()));
    //        }

    //        //画图片的边框线 
    //        g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

    //        System.IO.MemoryStream ms = new System.IO.MemoryStream();
    //        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    //        Response.ClearContent();
    //        Response.ContentType = "image/Gif";
    //        Response.BinaryWrite(ms.ToArray());
    //    }
    //    finally
    //    {
    //        g.Dispose();
    //        image.Dispose();
    //    }
    //}

    /// <summary>
    /// /// 生成验证图片
    /// /// </summary>
    /// /// <param name="checkCode">验证字符</param>
    protected void CreateImages(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 15);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 30);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.LightCyan);
        //定义颜色.LightGray
        //Color[] c = { Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray, Color.LightGray};
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple, Color.SkyBlue };
        //定义字体 
        string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体", "Comic Sans MS" };
        Random rand = new Random();
        //随机输出噪点
        for (int i = 0; i <80; i++)
        {
            int x = rand.Next(image.Width);
            int y = rand.Next(image.Height);
            g.DrawPie(new Pen(Color.LightGray, 0), x, y, 6, 6, 1, 1);
        }

        //输出不同字体和颜色的验证码字符
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(6);
            Font _font = new System.Drawing.Font(font[findex], 14, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(c[cindex]);
            int ii = 4;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }
            g.DrawString(checkCode.Substring(i, 1), _font, b, 3 + (i * 12), ii);
        }

        //画一个边框
        g.DrawRectangle(new Pen(Color.Red, 0), 100, 0, image.Width - 1, image.Height - 1);
        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Response.ClearContent();
        Response.ContentType = "image/Jpeg";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }

    #endregion

    #region 产生随机验证码

    /// <summary>
    /// 生成随机字母与数字
    /// </summary>
    /// <param name="Length">生成长度</param>
    /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
    /// <returns></returns>
    public string Str(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(3);
        char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' ,
                                        'a' , 'b' , 'c' , 'd' , 'e' , 'f' , 'g' , 'h' , 'i' , 'j' , 'k' , 'l' , 'm' , 'n' , 'o' , 'p' , 'q' , 'r' , 's' , 't' , 'u' , 'v' , 'w' , 'x' , 'y' , 'z'};
        string result = "";
        int n = Pattern.Length;
        System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
        for (int i = 0; i < Length; i++)
        {
            int rnd = random.Next(0, n);
            result += Pattern[rnd];
        }
        return result;
    }

    #endregion
}
