using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using PrismWpf.WeMail.Common.Models;
using PrismWpf.WeMail.Common.Mvvm;

namespace PrismWpf.WeMail.Mail.ViewModels
{
    public class AddMailViewModel:BindableBase
    {
        private string server = "smtp.163.com";
        private MailModel mailModel;
        public MailModel MailModel
        {
            get { return mailModel; }
            set { mailModel = value; RaisePropertyChanged();}
        }
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged();}
        }
        public IView View { get; set; }
        public DelegateCommand SendCommand => new DelegateCommand(() =>
        {
            var sender = MailModel.Sender;
            var receiver = MailModel.Receiver;
            var cc = MailModel.CC;
            var from = new MailAddress(sender.Mail, sender.Name);
            var to=new MailAddress(receiver.Mail, receiver.Name);
            var message = new MailMessage(from, to);
            message.Subject = MailModel.Subject;
            message.Body = MailModel.Content;
            //抄送
            if (string.IsNullOrWhiteSpace(cc.Mail))
            {
                MailAddress copy=new MailAddress(cc.Mail, cc.Name);
                message.CC.Add(copy);
            }
            //添加附件
            //Attachment attachment1 = new Attachment();
            //message.Attachments.Add(attachment1);
            try
            {
                SmtpClient client = new SmtpClient(server);
                client.Credentials = new NetworkCredential(sender.Mail, "xxxxxx");//授权码
                client.Send(message);
                View.Shutdown();
            }
            catch (Exception ex)
            {
            }

        });
        public DelegateCommand SyncCommand => new DelegateCommand(() =>
        {

        });

        public AddMailViewModel()
        {
            MailModel=new MailModel();
            MailModel.Sender.Mail = "testmail@163.com";
        }

    }
}
