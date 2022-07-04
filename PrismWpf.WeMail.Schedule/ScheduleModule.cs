using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWpf.WeMail.Schedule.Views;

namespace PrismWpf.WeMail.Schedule
{
    [Module(ModuleName = "Schedule")]
    public class ScheduleModule:IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //ͨ��ע��RegionManager�����ContactView
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //ͨ��ContentRegion������Ĭ�ϳ�ʼҳ��ContactView
            var contentRegion = regionManager.Regions["ContentRegion"];
            contentRegion.RequestNavigate(nameof(ScheduleView));
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ScheduleView>();
        }

       
    }
}
