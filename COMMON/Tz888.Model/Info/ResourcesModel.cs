using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
  public  class ResourcesModel
    {
    private  int  _infoid;
    private int _resourceid;
    private int _orderNumberid;

      /// <summary>
      /// InfoID
      /// </summary>
      public int InfoID
      {
          set { _infoid = value; }
          get { return _infoid; }
      }
      /// <summary>
      /// �Ƽ��б�ID
      /// </summary>
      public int ResourceID
      {
          set { _resourceid = value; }
          get { return _resourceid; }
      }
      /// <summary>
      /// �Ƽ������к�
      /// </summary>
      public int OrderNumberID
      {
          set { _orderNumberid = value; }
          get { return _orderNumberid;}
      
      }
  
  
  }

}
