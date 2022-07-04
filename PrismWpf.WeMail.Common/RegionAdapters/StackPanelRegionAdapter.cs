using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace PrismWpf.WeMail.Common.RegionAdapters
{
    /// <summary>
    /// customer region adapter for stackpanel
    /// </summary>
    public class StackPanelRegionAdapter:RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
        /// <summary>
        /// 适配器
        /// </summary>
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    regionTarget.Children.Clear();
                    foreach (var item in e.NewItems)
                    {
                        regionTarget.Children.Add(item as UIElement);
                    }
                }
            };
        }
        /// <summary>
        /// 创建Region方法
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
