using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.Consts;

namespace PrismWpf.WeMail.Common.User
{
    /// <summary>
    /// 约束User必须有角色，登录状态
    /// </summary>
    public interface IUser
    {
        Role_e Role { get; set; }
        bool IsLogin();
        void SetUserLoginState(bool state);
    }
}
