using System;
using System.Collections.Generic;
using System.Windows.Documents;
using PrismWpf.WeMail.Common.Consts;
using PrismWpf.WeMail.Dal.Dtos;

namespace PrismWpf.WeMail.Dal
{
    public class HttpHelper
    {
        //Minimal api ʵ����ʵweb api ����




        #region α���룬ģ���߼�
        /// <summary>
        /// �û���¼
        /// </summary>
        public static UserDto Login(string account, string password)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password)) return null;
            if (account.Equals("felix") && password.Equals("123456"))
                return new UserDto() { Role = Role_e.Admin, Token = "0ca175b9c0f726a831d895e269332461" };
            return null;
        }
        /// <summary>
        /// �����ϵ��
        /// </summary>
        public static bool Insert(string mail, string phone, string name, int age, Gender_e gender)
        {
            contacts.Add(new ContactDto(){Mail = mail,Phone = phone,Name = name,Age = age,Gender = gender});
            return true;
        }
        private static List<ContactDto> contacts=new List<ContactDto>()
        {
            new ContactDto(){Mail = "felix.zhu@163.com",Age = 18,Name = "felix",Gender = Gender_e.Male,Phone = "17623332333"}
        };
        public static List<ContactDto> GetContacts()
        {
            var result = new List<ContactDto>();
            result.AddRange(contacts);
            return result;
        }



        #endregion



    }
}
