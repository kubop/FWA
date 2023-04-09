using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWAdata.DbAccess;

namespace FWAdata.Business
{
	public interface IScope : IDisposable, IGenericScope
	{
		DbContext Db { get; }
	}

	public interface IGenericScope {}
}

