using FWAcore.Model;
using FWAdata.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWAservices
{
    public class AddressService
    {
        private readonly IBusinessProvider _business;

        public AddressService(IBusinessProvider business)
        {
            _business = business;
        }

        public IList<Address> GetAllAddresses(IGenericScope scope = null)
        {
            return _business.Get<AddressBusiness>().GetAllAddresses();
        }

        public IList<Address> GetAllAddressesWithCount(IGenericScope scope = null)
        {
            return _business.Get<AddressBusiness>().GetAllAddressesWithCount();
        }
    }
}
