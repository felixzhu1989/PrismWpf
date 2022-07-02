using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;
using PrismWpf.WeMail.Views;

namespace PrismWpf.WeMail.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string title="欢迎使用WeMail!";
        public string Title
        {
            get { return title; }
            set { title = value;RaisePropertyChanged(); }
        }


        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            regionManager.RegisterViewWithRegion("TabRegion", typeof(TempView));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(Temp2View));
            regionManager.RegisterViewWithRegion("WorkRegion", typeof(Temp3View));
        }
    }
}
