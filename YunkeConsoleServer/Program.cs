using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TOPSUN.YunkeConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(AccountService)))
            {
                host.Open();
                Console.WriteLine("AccountService Address:");
                foreach (var endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine(endpoint.Address.ToString());
                }
                Console.WriteLine("AccountService Started,Press any key to stop service...");
                Console.ReadKey();
                host.Close();
            }
        }
    }

    [ServiceContract]
    public interface IAccountJsonService
    {
        [OperationContract(Name = "GetAccountDataJson")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAccountData", BodyStyle = WebMessageBodyStyle.Bare)]
        List<Account> GetAccountData();

        [OperationContract(Name = "SendMessageJson")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SendMessage/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string SendMessage(string Message);
    }

    [ServiceContract]
    public interface IAccountXmlService
    {
        [OperationContract(Name = "GetAccountDataXml")]
        [WebGet(RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetAccountData", BodyStyle = WebMessageBodyStyle.Bare)]
        List<Account> GetAccountData();

        [OperationContract(Name = "SendMessageXml")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "SendMessage/{Message}", BodyStyle = WebMessageBodyStyle.Bare)]
        string SendMessage(string Message);
    }


    public class AccountService : IAccountJsonService, IAccountXmlService
    {
        public List<Account> GetAccountData()
        {
            return MockAccount.AccountList;
        }
        public string SendMessage(string Message)
        {
            return " Message:" + Message;
        }
    }

    [DataContract]
    public class Account
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
    }

    public class MockAccount
    {
        public static List<Account> AccountList
        {
            get
            {
                var list = new List<Account>();
                list.Add(new Account { Name = "Bill Gates", Address = "YouYi East Road", Age = 56, Birthday = DateTime.Now });
                list.Add(new Account { Name = "Steve Paul Jobs", Address = "YouYi West Road", Age = 57, Birthday = DateTime.Now });
                list.Add(new Account { Name = "John D. Rockefeller", Address = "YouYi North Road", Age = 65, Birthday = DateTime.Now });
                return list;
            }
        }
    }
}
