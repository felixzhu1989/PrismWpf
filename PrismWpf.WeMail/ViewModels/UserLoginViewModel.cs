using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismWpf.WeMail.Dal;

namespace PrismWpf.WeMail.ViewModels
{
    public class UserLoginViewModel : BindableBase, IDialogAware
    {
        public string Title => "用户登录";
        public event Action<IDialogResult>? RequestClose;
        private string account;
        public string Account
        {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; RaisePropertyChanged(); }
        }

        public DelegateCommand LoginCommand => new(() =>
        {
            var userDto = HttpHelper.Login(Account, Password);
            if (userDto != null && !string.IsNullOrWhiteSpace(userDto.Token))
            {
                var parameter = new DialogParameters();
                parameter.Add("LoginStatus", true);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, parameter));
            }
        });
        public DelegateCommand CancelCommand => new(() => { RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel)); });
        
        public bool CanCloseDialog()
        {
            return true;
        }
        public void OnDialogClosed()
        {
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
