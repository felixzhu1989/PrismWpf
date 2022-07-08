using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismWpf.WeMail.Common.Events;
using PrismWpf.WeMail.Common.Extensions;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Common.User;

namespace PrismWpf.WeMail.Contact.ViewModels
{
    public class ContactViewModel:BindableBase,INavigationAware
    {
        private readonly IEventAggregator _aggregator;
        private readonly IDialogService _dialogService;
        public IView View { get; set; }
        private IUser _user;
        private ObservableCollection<string> _contacts;
        public ObservableCollection<string> Contacts => _contacts ??= new ObservableCollection<string>();
        private string message;
        public string Message
        {
            get => message;
            set { message = value; RaisePropertyChanged();}
        }
        public ContactViewModel(IEventAggregator aggregator,IDialogService dialogService,IUser user)
        {
            //获取框架内聚合器事件的引用
            _aggregator = aggregator;
            _dialogService = dialogService;
            _user = user;
        }
        /// <summary>
        /// 进入页面，接收从上一个页面传递过来的参数
        /// </summary>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //根据约定的key（Contact）拿到参数
            var parameter = navigationContext.Parameters["Contact"];
            if(parameter == null)return;
            //导航到当前页面，此处可以传递过来的参数以及是否允许导航等动作的控制
            Debug.WriteLine($"{parameter.ToString()} To Contact View");
            //订阅消息
            _aggregator.GetEvent<MessageEvent>().Subscribe(OnSubscribeMessage, false);
            //如果没有登录则执行登录过程
            if (!_user.IsLogin())
            {
                _dialogService.Login(_user);//扩展方法
                if (!_user.IsLogin())return;
            }
            InitData();
        }

        private void OnSubscribeMessage(string message)
        {
            //输出接收到的消息内容
            Debug.WriteLine($"WeMail.Contact receive message:{message}");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //根据业务需要调整该视图，是否创建新实例，为true的时候表示不创建实例，页面还是之前的
            return true;
        }
        /// <summary>
        /// 导航离开当前页面
        /// </summary>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Debug.WriteLine("Leave Contact View");
        }

        private void InitData()
        {
            Message = "Wemail.Contact Prism Module";
            Contacts.Add("联系人张某");
            Contacts.Add("联系人王某");
        }
    }
}
