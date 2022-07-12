using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismWpf.WeMail.Common.Events;
using PrismWpf.WeMail.Common.Extensions;
using PrismWpf.WeMail.Common.User;
using PrismWpf.WeMail.Models;

namespace PrismWpf.WeMail.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        //Region管理对象
        private readonly IRegionManager _regionManager;
        private readonly IModuleCatalog _moduleCatalog;
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _aggregator;
        private IUser _user;

        //导航日志
        private IRegionNavigationJournal _journal;

        //标题栏
        private string title = "Prism Application";
        public string Title
        {
            get => title;
            set { title = value; RaisePropertyChanged(); }
        }
        //模块信息集合，用于绑定ListBox，用来显示模块名称
        private ObservableCollection<MenuModel> modules;
        public ObservableCollection<MenuModel> Modules => modules ??= new ObservableCollection<MenuModel>();


        //绑定到ListBox中SelectedItem，选中的对象
        private MenuModel moduleInfo;
        public MenuModel ModuleInfo
        {
            get => moduleInfo;
            //直接执行跳转
            set { moduleInfo = value; Navigate(value); }
        }
        //在窗口后台中绑定到Loaded事件，然后执行LoadModules加载模块信息
        public DelegateCommand LoadModulesCommand => new (InitModules);
        public DelegateCommand<string> OpenCommand => new (OpenView);
        public DelegateCommand GoBackCommand => new (() => { if (_journal is { CanGoBack: true }) _journal.GoBack(); });
        public DelegateCommand GoForwardCommand => new (() => { if (_journal is { CanGoForward: true }) _journal.GoForward(); });
        public DelegateCommand ShowDialogCommand => new (ShowDialog);
        public DelegateCommand<string> ParamCommand => new (ParamAction);
        public DelegateCommand LoginCommand => new(() =>
        {
            _dialogService.Login(_user);//使用扩展方法登录
        });

        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog,ILogger logger,IDialogService dialogService,IEventAggregator aggregator,IUser user)
        {
            //Prism框架内依赖注入RegionManager
            _regionManager = regionManager;
            _moduleCatalog=moduleCatalog;
            _dialogService = dialogService;
            _aggregator = aggregator;
            _user = user;
            //测试NLog，log文件将在应用程序目录中，log记录的内容通过NLog.config文件配置
            logger.LogInformation("Hello NLog");
        }
        public void InitModules()
        {
            //代码添加模块的方式
            //Modules.AddRange(_moduleCatalog.Modules);

            //文件夹添加模块的方式
            var dirModuleCatalog = _moduleCatalog  as DirectoryModuleCatalog;
            //Modules.AddRange(dirModuleCatalog!.Modules);
            foreach (var module in dirModuleCatalog.Items)
            {
                var tempModule = module as ModuleInfo;
                switch (tempModule.ModuleName)
                {
                    case "Contact":
                        Modules.Add(new MenuModel { DisplayName = "联系人", ModuleName = tempModule.ModuleName, IconName = "AccountBoxOutline" });
                        break;
                    case "Schedule":
                        Modules.Add(new MenuModel { DisplayName = "规划", ModuleName = tempModule.ModuleName, IconName = "ClockOutline" });
                        break;
                    case "Mail":
                        Modules.Add(new MenuModel { DisplayName = "邮件", ModuleName = tempModule.ModuleName, IconName = "EmailSyncOutline" });
                        break;
                }
            }
        }
        private void Navigate(MenuModel info)
        {
            //发布消息
            _aggregator.GetEvent<MessageEvent>().Publish("我发布的消息");
            //切换视图
            var parameter = new NavigationParameters();
            //任意key,value，导航到的视图按照约定key获取value值。
            parameter.Add($"{info.ModuleName}", DateTime.Now.ToString());
            _regionManager.RequestNavigate("ContentRegion", $"{info.ModuleName}View", back => { _journal = back.Context.NavigationService.Journal; }, parameter);
        }
        private void OpenView(string obj)
        {
            //back记录导航日志上下文
            _regionManager.RequestNavigate("ContentRegion", obj, back => { _journal = back.Context.NavigationService.Journal;});
        }
        private void ShowDialog()
        {
            var param = new DialogParameters();
            param.Add("Title","Add");
            _dialogService.ShowDialog("MessageDialogView", param, (r) =>
            {
                var result=r.Result;
                if (result == ButtonResult.OK)
                {
                    var parameter = r.Parameters.GetValue<string>("MessageContent");
                }
            });
        }
        private void ParamAction(string param)
        {
            Debug.WriteLine(param);
            //发布消息
            _aggregator.GetEvent<MessageEvent>().Publish(param);
        }
    }
}
