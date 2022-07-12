using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWpf.WeMail.Dal.Dtos
{
    public class MailDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ContactDto Sender { get; set; }
        public ContactDto Receiver { get; set; }
        public ContactDto CC { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReciverTime { get; set; }
        public override string ToString()
        {
            return Subject;
        }
        public MailDto()
        {
            Sender=new ContactDto();
            Receiver=new ContactDto();
            CC=new ContactDto();
        }
    }
}
