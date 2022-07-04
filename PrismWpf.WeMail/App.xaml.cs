using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWpf.WeMail.Common.RegionAdapters;
using PrismWpf.WeMail.Views;

namespace PrismWpf.WeMail
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
           return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
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
        //    moduleCatalog.AddModule<ContactModule>();
        //    moduleCatalog.AddModule<ScheduleModule>();
        //    base.ConfigureModuleCatalog(moduleCatalog);
        //}

        //二、通过配置文件夹，添加模块
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //指定模块的加载方式为从文件夹中以反射发现并加载Module的dll（推荐用法）
            return new DirectoryModuleCatalog() { ModulePath = @".\Apps" };
        }
    }
}
