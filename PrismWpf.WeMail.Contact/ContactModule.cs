using Prism.Ioc;
using Prism.Modularity;
using System;
using Prism.Regions;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Contact.ViewModels;
using PrismWpf.WeMail.Contact.Views;

namespace PrismWpf.WeMail.Contact
{
    [Module(ModuleName = "Contact")]
    public class ContactModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContactView>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
