using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismWpf.WeMail.Views;

namespace PrismWpf.WeMail.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        //Region管理对象
        private readonly IRegionManager _regionManager;
        private IModuleCatalog _moduleCatalog;

        private string title="Prism Application";
        public string Title
        {
            get { return title; }
            set { title = value;RaisePropertyChanged(); }
        }

        private ObservableCollection<IModuleInfo> modules;
        //模块集合
        public ObservableCollection<IModuleInfo> Modules
        {
            get => modules ?? (modules = new ObservableCollection<IModuleInfo>());
        }
       
        private DelegateCommand loadModules;
        public DelegateCommand LoadModules
        {
            get => loadModules = new DelegateCommand(InitModules);
        }

        private IModuleInfo _moduleInfo;
        public IModuleInfo ModuleInfo
        {
            get { return _moduleInfo; }

            set { _moduleInfo = value; Navigate(value); }
        }

        private void Navigate(IModuleInfo info)
        {
            _regionManager.RequestNavigate("ContentRegion", $"{info.ModuleName}View"); ;
        }


        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            //Prism框架内依赖注入RegionManager
            _regionManager = regionManager;
            _moduleCatalog=moduleCatalog;
        }
        public void InitModules()
        {
            var dirModuleCatalog= _moduleCatalog  as DirectoryModuleCatalog;
            Modules.AddRange(dirModuleCatalog.Modules);
        }


        
    }
}
