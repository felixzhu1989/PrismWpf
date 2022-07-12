using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismWpf.WeMail.Common.Extensions;
using PrismWpf.WeMail.Common.Models;
using PrismWpf.WeMail.Common.User;
using PrismWpf.WeMail.Dal;
using PrismWpf.WeMail.Dal.Dtos;
using PrismWpf.WeMail.Mail.Services;
using PrismWpf.WeMail.Mail.Views;

namespace PrismWpf.WeMail.Mail.ViewModels
{
    public class MailViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService _dialogService;
        private IUser _user;
        private ObservableCollection<MailModel> mails;

        public ObservableCollection<MailModel> Mails
        {
            get { return mails; }
            set
            {
                mails = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SendCommand => new DelegateCommand(() =>
        {
            AddMailView addMailView = new AddMailView();
            addMailView.ShowDialog();
        });

        public DelegateCommand SyncCommand => new DelegateCommand(InitData);

        private List<MailModel> ConvertToModel(List<MailDto> mailsDto)
        {
            var result = new List<MailModel>();
            mailsDto.ForEach(mail =>
            {
                var sender = new ContactModel() {Name = mail.Sender.Name, Mail = mail.Sender.Mail, Phone = mail.Sender.Phone, Age = mail.Sender.Age, Gender = mail.Sender.Gender};
                var receiver = new ContactModel() {Name = mail.Receiver.Name, Mail = mail.Receiver.Mail, Phone = mail.Receiver.Phone, Age = mail.Receiver.Age, Gender = mail.Receiver.Gender};
                var cc = new ContactModel() { Name = mail.CC.Name, Mail = mail.CC.Mail, Phone = mail.CC.Phone, Age = mail.CC.Age, Gender = mail.CC.Gender };
                result.Add(new MailModel(){Sender = sender,Receiver = receiver,CC = cc,Subject = mail.Subject,Content = mail.Content,SendTime = mail.SendTime,ReceiveTime = mail.ReciverTime});
            });
            return result;
        }

        public MailViewModel(IDialogService dialogService,IUser user)
        {
            _dialogService = dialogService;
            _user = user;
            Mails=new ObservableCollection<MailModel>();
        }

        private async void InitData()
        {
            //Mails.Clear();
            //var result = HttpHelper.GetMails();
            //Mails.AddRange(ConvertToModel(result));
            await MailService.GetMails(OnGetmailsExcptionCallback, OnGetmailsCallback);
        }
        private void OnGetmailsCallback(List<MailDto> mails)
        {
            Mails.Clear();
            Mails.AddRange(ConvertToModel(mails));
        }
        private void OnGetmailsExcptionCallback(Exception exception)
        {
            //log.Error(exception.Message);
            Console.WriteLine(exception.Message);
        }
        
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (!_user.IsLogin())
            {
                _dialogService.Login(_user);
                if (!_user.IsLogin())return;
            }
            InitData();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
