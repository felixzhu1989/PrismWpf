using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismWpf.WeMail.Controls.CustomControls
{
    public class MessageDialogControl:BindableBase,IDialogAware
    {
        public string Title { get; set; }
        public event Action<IDialogResult>? RequestClose;
        private string messageContent;
        public string MessageContent
        {
            get { return messageContent; }
            set { messageContent = value;RaisePropertyChanged(); }
        }

        private DelegateCommand getMessageCommand;
        public DelegateCommand GetMessageCommand => getMessageCommand?? new DelegateCommand(() =>
        {
            var parameter = new DialogParameters();
            parameter.Add("MessageContent",MessageContent);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK,parameter));
        });
        private DelegateCommand cancelMessageCommand;
        public DelegateCommand CancelMessageCommand => cancelMessageCommand?? new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        });
        public bool CanCloseDialog()
        {
            //允许用户手动关闭当前窗口
            return true;
        }
        public void OnDialogClosed()
        {
            //关闭Dialog的操作
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            //Dialog接收传递的参数
            Title=parameters.GetValue<string>("Title");
        }
    }
}
