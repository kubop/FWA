using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FWAweb.Auth;

public class LoginModel
{
    [DisplayName("Username")]
    public string Login { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
}
