using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
    public class Card
    {
        private readonly ICard dal = DataAccess.CreateICard();

        public int Insert(Tz888.Model.Card model)
        {
            return dal.Insert(model);
        }
        public int Update(Tz888.Model.Card model)
        {
            return dal.Update(model);
        }

        public bool Delete(long CardNo)
        {
            return dal.Delete(CardNo);
        }

    }
}
