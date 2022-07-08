using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;
using PrismWpf.WeMail.Common.Extensions;
using PrismWpf.WeMail.Common.User;

namespace PrismWpf.WeMail.Schedule.ViewModels
{
    public class ScheduleViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService _dialogService;
        private IUser _user;
        private string message= "Wemail.Schedule Prism Module";
        public string Message
        {
            get => message;
            set { message=value;RaisePropertyChanged(); }
        }

        public ScheduleViewModel(IDialogService dialogService,IUser user)
        {
            _dialogService = dialogService;
            _user = user;
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (!_user.IsLogin())
            {
                _dialogService.Login(_user);
                if (!_user.IsLogin())return;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
