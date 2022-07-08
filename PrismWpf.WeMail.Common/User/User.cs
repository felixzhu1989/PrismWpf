using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.Consts;

namespace PrismWpf.WeMail.Common.User
{
    public class User : IUser
    {
        public bool IsLoginStatus { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Role_e Role { get; set; }
        public bool IsLogin()
        {
            return IsLoginStatus;
        }
        public void SetUserLoginState(bool state)
        {
            IsLoginStatus=state;
        }
    }
}
