namespace PrismWpf.WeMail.WebApi
{
    public enum Gender_e
    {
        Female,
        Male
    }
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
    public class ContactDto
    {
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender_e Gender { get; set; }
    }
}
