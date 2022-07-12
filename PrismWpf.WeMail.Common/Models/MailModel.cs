using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWpf.WeMail.Common.Models
{
    public class MailModel
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public ContactModel Sender { get; set; }
        public ContactModel Receiver { get; set; }
        public ContactModel CC { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReceiveTime { get; set; }
        public override string ToString()
        {
            return Subject;
        }
        public MailModel()
        {
            Sender = new ContactModel();
            Receiver = new ContactModel();
            CC = new ContactModel();
        }
    }
}
