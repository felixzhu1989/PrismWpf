using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Schedule.ViewModels;
using PrismWpf.WeMail.Schedule.Views;

namespace PrismWpf.WeMail.Schedule
{
    [Module(ModuleName = "Schedule")]
    public class ScheduleModule:IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ScheduleView>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
