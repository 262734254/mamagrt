using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Common
{
    public enum ResourceType : int
    {
        Others = 0, //����
        Image = 1, //ͼƬ
        Video = 2  //��Ƶ
    }

    public enum ResourceProperty : int
    {
        Others = 0, //����
        InfoImage = 1, //��ϢͼƬ
        ProjectWarrant = 2, //��Ŀ���ļ�
        TradePlan = 3, //��ҵ�ƻ���
        Video = 4  //��Ƶ
    }
    public enum MemberResourceProperty : int
    {
        ///0 ��˾���ܣ���ͼƬ��
        ///1Ӫҵִ��
        ///2˰��Ǽ�֤(��˰)
        ///3˰��Ǽ�֤(��˰)
        ///4������֤��
        ///5����*/
        RP0 = 0, //��˾����
        RP1 = 1, //Ӫҵִ��
        RP2 = 2, //˰��Ǽ�֤
        RP3 = 3, //˰��Ǽ�֤
        RP4 = 4, //������֤��
        RP5 = 5

    }

    public class InfoResourceManage
    {
        /// <summary>
        /// ת�����ϲ����ļ�
        /// </summary>
        /// <param name="InfoID">��Դ������ϢID</param>
        /// <param name="InfoResources">�Ѿ��ϴ���Դ�б�</param>
        /// <returns>��������Դ�б�</returns>
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
        /// ת�����ϲ����ļ�
        /// </summary>
        /// <param name="InfoID">��Դ������ϢID</param>
        /// <param name="InfoResources">�Ѿ��ϴ���Դ�б�</param>
        /// <returns>��������Դ�б�</returns>
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
