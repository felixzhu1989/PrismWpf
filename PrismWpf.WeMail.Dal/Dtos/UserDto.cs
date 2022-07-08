using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.Consts;

namespace PrismWpf.WeMail.Dal.Dtos
{
    public class UserDto
    {
        public  Role_e Role { get; set; }
        public string Token { get; set; }
    }
}
