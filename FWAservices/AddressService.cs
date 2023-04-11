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

        public Address GetObjectById(int addressId, IGenericScope scope = null)
        {
            return _business.Get<AddressBusiness>().GetObject(addressId, scope as IScope);
        }

        public IList<Address> GetAllAddresses(IGenericScope scope = null)
        {
            return _business.Get<AddressBusiness>().GetAllAddresses();
        }

        public IList<Address> GetAllAddressesWithCount(IGenericScope scope = null)
        {
            return _business.Get<AddressBusiness>().GetAllAddressesWithCount();
        }

        public void SoftDelete(Address address, IGenericScope scope = null)
        {
            _business.Get<AddressBusiness>().Delete(address);
        }

        public void Update(Address obj, IGenericScope scope = null)
        {
            _business.Get<AddressBusiness>().Update(obj);
        }
    }
}
