using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrismWpf.WeMail.Common.Consts;
using PrismWpf.WeMail.Dal;
using PrismWpf.WeMail.Dal.Dtos;

namespace PrismWpf.WeMail.Mail.Services
{
    public class MailService
    {
        public static async Task GetMails(Action<Exception> onExcption, Action<List<MailDto>> onResult)
        {
            try
            {
                await HttpHelper.Instance.HttpHandle(HttpMethod.GET, HttpHelper.Address + "getmails", null, onExcption, onResult);
            }
            catch (Exception ex)
            {
                onExcption(ex);
            }
        }
    }
}
