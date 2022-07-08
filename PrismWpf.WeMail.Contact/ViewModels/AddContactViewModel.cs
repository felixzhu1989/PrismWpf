using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using PrismWpf.WeMail.Common.Models;
using PrismWpf.WeMail.Dal;

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

        public DelegateCommand AddContactCommand => new DelegateCommand(() =>
        {
            if(isInvalid)return;
            HttpHelper.Insert();
        });

        public AddContactViewModel()
        {
            Contact=new ContactModel();
        }
    }
}
