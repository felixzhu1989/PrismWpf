using System;
using System.Windows.Controls;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Contact.ViewModels;

namespace PrismWpf.WeMail.Contact.Views
{
    /// <summary>
    /// ContactView.xaml 的交互逻辑
    /// </summary>
    public partial class ContactView : UserControl,IView
    {
        public ContactView()
        {
            InitializeComponent();
            (DataContext as ContactViewModel).View = this;
        }
        public bool Shutdown()
        {
            return true;
        }
        public bool Launch()
        {
            var view = new AddContactView();
            view.ShowDialog();
            return true;
        }
    }
}
