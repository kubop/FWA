using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWAdata.DbAccess;
using FWAcore.Model;

namespace FWAdata.Business
{
	public partial class UserViewBusiness
	{
        public IList<UserView> ListForGrid(IScope scope = null)
        {
            return Execute((IScope s) =>
            {
                return s.Db.From<UserView>().SelectAll().ToList();
            });
        }
    }
}
