using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWpf.WeMail.Common.Mvvm
{
    public interface IView
    {
        bool Shutdown();
        bool Launch();
    }
}
