using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismWpf.WeMail.Common.Mvvm;
using PrismWpf.WeMail.Contact.ViewModels;

namespace PrismWpf.WeMail.Contact.Views
{
    /// <summary>
    /// AddContactView.xaml 的交互逻辑
    /// </summary>
    public partial class AddContactView : Window,IView
    {
        //依赖倒置，把自己初始化的时机交给使用者
        public AddContactView()
        {
            InitializeComponent();
            (DataContext as AddContactViewModel).View = this;
        }
        public bool Shutdown()
        {
            Close();
            return true;
        }
        public bool Launch()
        {
            return false;
        }
    }
}
