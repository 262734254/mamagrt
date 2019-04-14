using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Register;
using Tz888.Model.Register;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Register
{
   public class SEOLoginTabBLL
    {
       private static readonly Tz888.IDAL.Register.ISEOLoginTab dal = DataAccess.CreateSEOLoginObj();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void  Add(Tz888.Model.Register.SEOLoginTabModel model)
        {
             dal.Add(model);
        }
    }
}
