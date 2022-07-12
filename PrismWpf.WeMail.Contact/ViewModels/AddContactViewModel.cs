using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Regions;
using PrismWpf.WeMail.Common.Models;
using PrismWpf.WeMail.Dal;
using PrismWpf.WeMail.Common.Mvvm;

namespace PrismWpf.WeMail.Contact.ViewModels
{
    public class AddContactViewModel : BindableBase
    {
        private ContactModel contact;
        public ContactModel Contact
        {
            get { return contact; }
            set { contact = value; RaisePropertyChanged();}
        }
        private bool isInvalid;
        public bool IsInvalid
        {
            get { return isInvalid; }
            set { isInvalid = value; RaisePropertyChanged();}
        }
        public IView View { get; set; }
        public DelegateCommand LaunchCommand => new DelegateCommand(() => View.Launch());

        public DelegateCommand AddContactCommand => new DelegateCommand(() =>
        {
            if(isInvalid)return;//当验证有异常，则不提交新增联系人
            HttpHelper.Insert(Contact.Mail,Contact.Phone,Contact.Name,Contact.Age,Contact.Gender);
            View.Shutdown();
        });

        public AddContactViewModel()
        {
            Contact=new ContactModel();
        }
    }
}
