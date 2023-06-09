using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWAdata.DbAccess;
using FWAcore.Model;

namespace FWAdata.Business
{
	public partial class UserBusiness
	{
		public IList<User> ListUsers(IScope scope = null)
		{
			return Execute((IScope s) =>
			{
				return s.Db.From<User>().SelectAll().ToList();
			});
		}

		public User? GetObjectByName(string username, IScope scope = null)
		{
			return Execute((IScope s) =>
			{
				return s.Db.From<User>()
					.Where((user) => user.Login == username)
					.SelectAll().ToList().FirstOrDefault();
			}, scope);
		}
	}
}
