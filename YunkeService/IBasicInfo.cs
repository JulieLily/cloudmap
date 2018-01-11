using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using TOPSUN.ERP.Common.Data.Manufacture;


namespace TOPSUN.YunkeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBasicInfo”。
    [ServiceContract]
    public interface IBasicInfo
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetUser/{userid}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        UserData GetUser(string userid);
    }

    [DataContract]
    public class UserData
    {
        [DataMember(Name = "ID")]
        public string ID
        {
            get;
            set;
        }

        [DataMember(Name = "Name")]
        public string Name
        {
            get;
            set;
        }

        [DataMember(Name = "Department")]
        public string Department
        {
            get;
            set;
        }
    }
}
