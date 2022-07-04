using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PrismWpf.WeMail.Contact.ViewModels
{
    public class ContactViewModel:BindableBase
    {
        private ObservableCollection<string> _contacts;

        public ObservableCollection<string> Contacts
        {
            get => _contacts ?? (_contacts = new ObservableCollection<string>());
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; RaisePropertyChanged();}
        }

        public ContactViewModel()
        {
            Message = "Wemail.Contact Prism Module";
            Contacts.Add("联系人张某");
            Contacts.Add("联系人王某");
        }
    }
}
