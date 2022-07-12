using System;
using Prism.Ioc;
using Prism.Modularity;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Mail.Views;

namespace PrismWpf.WeMail.Mail
{
    [Module(ModuleName = "Mail")]
    public class MailModule:IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MailView>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }
    }
}
