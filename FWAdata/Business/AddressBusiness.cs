using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWAcore.Model;

namespace FWAdata.Business
{
	public partial class AddressBusiness
	{
		public List<Address> GetAllAddresses()
		{
            return Execute((IScope s) =>
            {
                return s.Db.From<Address>().SelectAll().ToList();
            });
        }
	}
}
