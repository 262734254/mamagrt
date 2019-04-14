using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Register
{
  public   class SS_ProfessionalServices
  {
      Tz888.SQLServerDAL.Register.SS_ProfessionalServices mode = new Tz888.SQLServerDAL.Register.SS_ProfessionalServices();
      public void ProfessionalAdd(Tz888.Model.Register.SS_ProfessionalServices model)
      {
         
          mode.ProfessionalAdd(model);
      }
      public bool SS_ProUpdate(Tz888.Model.Register.SS_ProfessionalServices model)
      {
          return mode.SS_ProUpdate(model);
      }
    }
}
