using Prism.Ioc;
using Prism.Modularity;
using System;
using Prism.Regions;
using PrismWpf.WeMail.Contact.Views;

namespace PrismWpf.WeMail.Contact
{
    [Module(ModuleName = "Contact")]
    public class ContactModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //ͨ��ע��RegionManager�����ContactView
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //ͨ��ContentRegion������Ĭ�ϳ�ʼҳ��ContactView
            var contentRegion = regionManager.Regions["ContentRegion"];
            contentRegion.RequestNavigate(nameof(ContactView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContactView>();
        }
    }
}
