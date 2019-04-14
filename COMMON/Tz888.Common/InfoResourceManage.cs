using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Common
{
    public enum ResourceType : int
    {
        Others = 0, //其他
        Image = 1, //图片
        Video = 2  //视频
    }

    public enum ResourceProperty : int
    {
        Others = 0, //其他
        InfoImage = 1, //信息图片
        ProjectWarrant = 2, //项目批文件
        TradePlan = 3, //商业计划书
        Video = 4  //视频
    }
    public enum MemberResourceProperty : int
    {
        ///0 公司介绍（多图片）
        ///1营业执照
        ///2税务登记证(国税)
        ///3税务登记证(地税)
        ///4荣誉和证书
        ///5其它*/
        RP0 = 0, //公司介绍
        RP1 = 1, //营业执照
        RP2 = 2, //税务登记证
        RP3 = 3, //税务登记证
        RP4 = 4, //荣誉和证书
        RP5 = 5

    }

    public class InfoResourceManage
    {
        /// <summary>
        /// 转移已上产的文件
        /// </summary>
        /// <param name="InfoID">资源所属信息ID</param>
        /// <param name="InfoResources">已经上传资源列表</param>
        /// <returns>保存后的资源列表</returns>
        public static List<Tz888.Model.Info.InfoResourceModel> ImageTransfer(string FileType, string InfoType, ResourceType rType, ResourceProperty rProperty, List<Tz888.Model.Info.InfoResourceModel> InfoResources)
        {
            if (InfoResources == null || InfoResources.Count == 0)
                return null;

            List<Tz888.Model.Info.InfoResourceModel> Lists = new List<Tz888.Model.Info.InfoResourceModel>();

            foreach (Tz888.Model.Info.InfoResourceModel model in InfoResources)
            {
                Tz888.Model.Info.InfoResourceModel item = new Tz888.Model.Info.InfoResourceModel();
                string OldFile = model.ResourceAddr;
                string NewFile = Tz888.Common.Common.GetUploadFilePath(FileType, InfoType, false);
                NewFile = Tz888.Common.FileManage.TransferFile(OldFile, NewFile, true, true, false);
                item.ResourceAddr = NewFile.Replace(@"\", "/");
                item.ResourceDescrib = model.ResourceDescrib;
                item.IsDel = false;
                item.remark = "";
                item.UpDate = DateTime.Now;
                item.ResourceName = InfoType;
                item.ResourceTitle = model.ResourceDescrib;
                item.ResourceType = (int)rType;
                item.ResourceProperty = (int)rProperty;
                Lists.Add(item);
            }
            return Lists;
        }

        /// <summary>
        /// 转移已上产的文件
        /// </summary>
        /// <param name="InfoID">资源所属信息ID</param>
        /// <param name="InfoResources">已经上传资源列表</param>
        /// <returns>保存后的资源列表</returns>
        public static List<Tz888.Model.MemberResourceModel> MemberImageTransfer(string FileType, string InfoType, ResourceType rType, MemberResourceProperty rProperty, List<Tz888.Model.MemberResourceModel> InfoResources)
        {
            if (InfoResources == null || InfoResources.Count == 0)
                return null;

            List<Tz888.Model.MemberResourceModel> Lists = new List<Tz888.Model.MemberResourceModel>();

            foreach (Tz888.Model.MemberResourceModel model in InfoResources)
            {
                Tz888.Model.MemberResourceModel item = new Tz888.Model.MemberResourceModel();
                string OldFile = model.ResourceAddr;
                string NewFile = Tz888.Common.Common.GetUploadFilePath(FileType, InfoType, false);
                NewFile = Tz888.Common.FileManage.TransferFile(OldFile, NewFile, true, true, false);
                item.ResourceAddr = NewFile.Replace(@"\", "/");
                item.ResourceDescrib = model.ResourceDescrib;
                item.IsDel = false;
                item.remark = "";
                item.UpDate = DateTime.Now;
                item.ResourceName = InfoType;
                item.ResourceTitle = model.ResourceDescrib;
                item.ResourceType = (int)rType;
                item.ResourceProperty = (int)rProperty;
                Lists.Add(item);
            }
            return Lists;
        }        
    }


}
