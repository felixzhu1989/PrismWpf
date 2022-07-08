using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.User;

namespace PrismWpf.WeMail.Common.Extensions
{
    public static class LoginExtension
    {
        public static void Login(this IDialogService dialogService,IUser user)
        {
            dialogService.ShowDialog("UserLoginView", back =>
            {
                var result = back.Result;
                if (result == ButtonResult.OK)
                {
                    var loginStatus = back.Parameters.GetValue<bool>("LoginStatus");
                    user.SetUserLoginState(loginStatus);
                }
            });
        }
    }
}
