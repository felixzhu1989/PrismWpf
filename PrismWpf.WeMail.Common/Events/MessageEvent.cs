using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace PrismWpf.WeMail.Common.Events
{
    /// <summary>
    /// 消息事件
    /// </summary>
    //public class MessageEvent:PubSubEvent<TempEventModel>//对消息进行扩展
    public class MessageEvent:PubSubEvent<string>
    {
    }
}
