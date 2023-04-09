using FWAcore.Model;
using FWAdata.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWAservices;

public class UserService
{
    private readonly IBusinessProvider _business;

    public UserService(IBusinessProvider business)
    {
        _business = business;
    }

    public User GetObjectById(int userId, IGenericScope scope = null)
    {
        return _business.Get<UserBusiness>().GetObject(userId, scope as IScope);
    }

    public IList<User> GetUsers(IGenericScope scope = null)
    {
        return _business.Get<UserBusiness>().ListUsers();
    }

    public IList<UserView> ListForGrid(IGenericScope scope = null)
    {
        return _business.Get<UserViewBusiness>().ListForGrid();
    }

    public void SoftDelete(User user, IGenericScope scope = null)
    {
        _business.Get<UserBusiness>().Delete(user);
    } 
}
