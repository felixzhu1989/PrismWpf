using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.Consts;

namespace PrismWpf.WeMail.Common.Models
{
    public class ContactModel
    {
        public string  Mail { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender_e Gender { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
