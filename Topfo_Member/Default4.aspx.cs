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

public partial class Default4 : System.Web.UI.Page
{

  static public ArrayList hif = new ArrayList(); // 保存文件列表
  public int filesUploaded = 0; // 上传文件的数量

   
  private void Page_Load(object sender, System.EventArgs e)
  {
     // FileList.DataSource = dt;
    //  FileList.datat
  }
  /// <summary>
  /// 从listbox中删除指定的文件
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
   public void RemvFile_Click(object sender, System.EventArgs e)
  {
   if(FileList.SelectedIndex == -1)
   {
    TipInfo.Text = "错误 - 必须指定要删除的文件.";
    return;
   }
   else if(FileList.Items.Count != 0)
   {
    hif.RemoveAt(FileList.SelectedIndex);
    FileList.Items.Remove(FileList.SelectedItem.Text);
    TipInfo.Text = "";
   }          
  }

  /// <summary>
  /// 循环上传listbox中的文件到指定的文件夹下
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  public void Upload_ServerClick(object sender, System.EventArgs e)
  {
   string baseLocation = Server.MapPath("UploadFiles/"); // 上传路径   
   string status = "";  // 上传成功后显示的文件列表        
           
   if((FileList.Items.Count == 0) && (filesUploaded == 0))
   {
    TipInfo.Text = "错误 - 必须指定要上传的文件.";
    return;
   }
   else
   {
    foreach(System.Web.UI.HtmlControls.HtmlInputFile HIF in hif)
    {
     try
     {
      string fn = System.IO.Path.GetFileName(HIF.PostedFile.FileName);
      HIF.PostedFile.SaveAs(baseLocation + fn);
      filesUploaded++;
      status += fn + "<br>";
     }
     catch(Exception err)
     {
      TipInfo.Text = "上传错误 " + baseLocation
       + "<br>" + err.ToString();
     }
    }

    if(filesUploaded == hif.Count)
    {
      TipInfo.Text = "共上传了 " + filesUploaded + " 个文件。 <br>" + status;
    }
    hif.Clear();
    FileList.Items.Clear();
   }
  }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (Page.IsPostBack)
        {
            if (FindFile.PostedFile.ContentLength == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "请选取文件！");
                return;
            }
            else if (FindFile.PostedFile.ContentLength < 500 * 1024)
            {                   
                for (int i = 0; i < FileList.Items.Count; i++)
                {
                    if (FileList.Items[i].Text == FindFile.PostedFile.FileName)
                        {
                            Tz888.Common.MessageBox.Show(this.Page, "此文件己有上传！");
                            return;                                 
                        }                              
                    }
                }

                //string []Name=FindFile.PostedFile.FileName.Split('\\');  
                //  FileList.Items.Add(Name[Name.Length-1]);  
                hif.Add(FindFile); Response.Write("bbbbbb");
                FileList.Items.Add(FindFile.PostedFile.FileName);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "此文件过大，最大500K！");
            }
    }
  
}
