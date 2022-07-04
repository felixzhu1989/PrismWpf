using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismWpf.WeMail.Common.RegionAdapters
{
    /// <summary>
    /// 对现有的Adapter进行更改
    /// </summary>
    public class TabRegionAdapter : RegionAdapterBase<TabControl>
    {
        public TabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (var item in e.NewItems)
                        {
                            regionTarget.Items.Add(new TabItem()
                            {
                                Content = item as UIElement,//显示的View
                                Header = DateTime.Now.ToString()//新建了一个标题
                            });
                        }
                    }
                };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
