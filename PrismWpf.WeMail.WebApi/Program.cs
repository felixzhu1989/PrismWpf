//创建web应用

using PrismWpf.WeMail.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
var sender = new ContactDto() { Mail = "zz@163.com", Age = 18, Name = "felix", Gender = Gender_e.Male, Phone = "12345678910" };
var receiver = new ContactDto() { Mail = "ff@11.com", Age = 18, Name = "felix", Gender = Gender_e.Male, Phone = "12345678910" };
List<MailDto> mails=new List<MailDto>()
{
    new MailDto(){Id=1,Subject = "test mail 1",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 1"},
    new MailDto(){Id=2,Subject = "test mail 2",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 2"},
    new MailDto(){Id=3,Subject = "test mail 3",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 3"}
};
//获取邮件列表
app.MapGet("/getmails", () =>
{
    return mails;
});
//删除邮件
app.MapDelete("/delmail/{id}", (int id) =>
{
    string resultMsg = string.Empty;
    var mail = mails.FirstOrDefault(i => i.Id.Equals(id));
    if (mail != null)
    {
        mails.Remove(mail);
        resultMsg = "Delete completed.";
    }
    else
    {
        resultMsg = "Nothing to do.";
    }
    return resultMsg;
});
//添加mail
app.MapPost("/addmail", (MailDto mail) =>
{
    string resultMsg = string.Empty;
    if (mail!=null)
    {
        mails.Add(mail);
        resultMsg = "add mail completed .";
    }
    else
    {
        resultMsg = "add mail failed!";
    }
    return resultMsg;
});


app.Run();