using PrismWpf.WeMail.Common.Mvvm;
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
using System.Windows.Shapes;
using PrismWpf.WeMail.Mail.ViewModels;

namespace PrismWpf.WeMail.Mail.Views
{
    /// <summary>
    /// AddMailView.xaml 的交互逻辑
    /// </summary>
    public partial class AddMailView : Window, IView
    {
        public AddMailView()
        {
            InitializeComponent();
            (DataContext as AddMailViewModel).View = this;
        }
        public bool Launch()
        {
            return false;
        }
        public bool Shutdown()
        {
            Close();
            return true;
        }
    }
}
