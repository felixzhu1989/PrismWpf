using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using PrismWpf.WeMail.Common.Consts;
using PrismWpf.WeMail.Dal.Dtos;

namespace PrismWpf.WeMail.Dal
{
    public class HttpHelper
    {
        //Minimal api 实现真实web api 服务
        //http://localhost:5293
        
        #region 单例
        private static HttpHelper _instance;
        private static readonly object _lock = new object();
        public static HttpHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            return _instance = new HttpHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        private HttpHelper() { }
        #endregion
        
        //当服务端的web api 部署到不同的服务器上时需要请求不同地址
        public static readonly string Address = @"http://localhost:5293/";

        public async Task HttpHandle<T>(HttpMethod method, string address, Dictionary<string, object> parameters,
            Action<Exception> onException, Action<T> onResult) where T : class
        {
            HttpWebRequest httpWebRequest=null;
            HttpWebResponse httpWebResponse=null;
            StreamReader streamReader=null;
            try
            {
                string methodConfig = string.Empty;
                httpWebRequest = (HttpWebRequest) HttpWebRequest.Create(address);
                httpWebRequest.ContentType = "application/json";
                switch (method)
                {
                    case HttpMethod.GET:
                        methodConfig = "GET";
                        break;
                    case HttpMethod.POST:
                        methodConfig = "POST";
                        break;
                    case HttpMethod.PUT:
                        methodConfig = "PUT";
                        break;
                    case HttpMethod.TRACE:
                        methodConfig = "TRACE";
                        break;
                    case HttpMethod.DELETE:
                        methodConfig = "DELETE";
                        break;
                }
                //设置请求类型
                httpWebRequest.Method = methodConfig;
                //设置超时时间
                httpWebRequest.Timeout = 10 * 1000;
                if (parameters != null)
                {
                    //字符串转换为字节码
                    byte[] prameterBytes = parameters == null ? new byte[0] : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(parameters));
                    //参数数据长度
                    httpWebRequest.ContentLength = prameterBytes.Length;
                    //将参数写入请求地址中
                    httpWebRequest.GetRequestStream().Write(prameterBytes, 0, prameterBytes.Length);
                }
                //发送请求
                httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                //读取返回数据
                streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
                string responseContent = await streamReader.ReadToEndAsync();
                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    onResult(default(T));
                }
                else
                {
                    var resultDto = JsonConvert.DeserializeObject<T>(responseContent);
                    if (resultDto != null)
                    {
                        onResult(resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                onException.Invoke(e);
            }
            finally
            {
                if (streamReader!=null) streamReader.Close();
                if (httpWebResponse!=null) httpWebResponse.Close();
                if (httpWebRequest!=null) httpWebRequest.Abort();
            }

        }



        #region 伪代码，模拟逻辑
        /// <summary>
        /// 用户登录
        /// </summary>
        public static UserDto Login(string account, string password)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password)) return null;
            if (account.Equals("felix") && password.Equals("123"))
                return new UserDto() { Role = Role_e.Admin, Token = "0ca175b9c0f726a831d895e269332461" };
            return null;
        }
        /// <summary>
        /// 添加联系人
        /// </summary>
        public static bool Insert(string mail, string phone, string name, int age, Gender_e gender)
        {
            contacts.Add(new ContactDto() { Mail = mail, Phone = phone, Name = name, Age = age, Gender = gender });
            return true;
        }
        private static List<ContactDto> contacts = new List<ContactDto>()
        {
            new ContactDto(){Mail = "felix.zhu@163.com",Age = 18,Name = "felix",Gender = Gender_e.Male,Phone = "17623332333"}
        };
        public static List<ContactDto> GetContacts()
        {
            var result = new List<ContactDto>();
            result.AddRange(contacts);
            return result;
        }

        //public static List<MailDto> GetMails()
        //{
        //    var sender = new ContactDto() { Mail = "zz@163.com", Age = 18, Name = "felix", Gender = Gender_e.Male, Phone = "12345678910" };
        //    var receiver = new ContactDto() { Mail = "ff@11.com", Age = 18, Name = "felix", Gender = Gender_e.Male, Phone = "12345678910" };
        //    var mails = new List<MailDto>()
        //    {
        //        new MailDto(){Subject = "test mail 1",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 1"},
        //        new MailDto(){Subject = "test mail 2",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 2"},
        //    new MailDto(){Subject = "test mail 3",Sender = sender,Receiver = receiver,SendTime = DateTime.Now,ReciverTime = DateTime.Now,Content = "Test Mail Content 3"}
        //    };
        //    return mails;
        //}

        #endregion



    }
}
