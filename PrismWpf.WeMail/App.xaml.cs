using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using NLog;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWpf.WeMail.Common.Helpers;
using PrismWpf.WeMail.Common.RegionAdapters;
using PrismWpf.WeMail.Common.User;
using PrismWpf.WeMail.Controls.CustomControls;
using PrismWpf.WeMail.Controls.Views;
using PrismWpf.WeMail.ViewModels;
using PrismWpf.WeMail.Views;
//using PrismWpf.WeMail.Contact;
//using PrismWpf.WeMail.Schedule;


namespace PrismWpf.WeMail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private Microsoft.Extensions.Logging.ILogger _logger;
        private User _user;
        protected override Window CreateShell()
        {
            //UI线程未捕获异常处理事件
            this.DispatcherUnhandledException += OnDispatcherUnhandledException;
            //Task线程内未捕获异常处理事件
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            //多线程异常
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            return Container.Resolve<MainWindow>();
        }
        #region 程序异常的日志
        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //通常全局异常捕捉的都是致命信息，StackTrace堆栈信息
            _logger.LogCritical($"{e.Exception.StackTrace},{e.Exception.Message}");
        }

        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            _logger.LogCritical($"{e.Exception.StackTrace},{e.Exception.Message}");
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            _logger.LogCritical($"{ex.StackTrace},{ex.Message}");

            //记录dump文件
            MiniDump.TryDump($"dumps\\Wemail_{DateTime.Now.ToString("HH-mm-ss-ms")}.dmp");
        } 
        #endregion

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //创建NLog组件实例
            var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            _logger = factory.CreateLogger("NLog");
            //注入到Prism DI容器中
            containerRegistry.RegisterInstance(_logger);

            //注册Dialog窗体
            containerRegistry.RegisterDialog<MessageDialogView,MessageDialogControl>();
            containerRegistry.RegisterDialog<UserLoginView,UserLoginViewModel>();
            _user=new User();
            containerRegistry.RegisterInstance<IUser>(_user);
        }
        /// <summary>
        /// 配置区域适配
        /// </summary>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            //添加自定义区域适配对象，会自动适配标记上prism:RegionManager.RegionName的容器控件为Region
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanelRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(TabControl),Container.Resolve<TabRegionAdapter>());
        }

        //一、通过代码的方式，添加模块，前提是添加了对两个模块项目的引用
        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ContactModule>("Contact");
        //    moduleCatalog.AddModule<ScheduleModule>("Schedule");
        //    base.ConfigureModuleCatalog(moduleCatalog);
        //}

        //二、通过配置文件夹，添加模块
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //指定模块的加载方式为从文件夹中以反射发现并加载Module的dll（推荐用法）
            //return new DirectoryModuleCatalog() { ModulePath = @".\Apps" };
            return new DirectoryModuleCatalog() { ModulePath = @".\" };
        }
    }
}
