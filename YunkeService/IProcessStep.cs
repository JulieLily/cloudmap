using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using TOPSUN.ERP.Common.Data.Manufacture;

namespace TOPSUN.YunkeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IProcessStep
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetProcessInfo/{cardid}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        IList<ProcessInfo> GetProcessInfo(string cardid);

        [OperationContract]
        [WebGet(UriTemplate = "GetCardInfo/{cardid}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        CardInfo GetCardInfo(string cardid);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "SaveProcessStep",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        bool SaveProcessStep(ProcessStepData step);
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class ProcessStepData
    {
        [DataMember(Name = "CardID")]
        public string CardID
        {
            get;
            set;
        }

        [DataMember(Name = "ProcessID")]
        public string ProcessID
        {
            get;
            set;
        }

        [DataMember(Name = "TR_Number")]
        public string TR_Number
        {
            get;
            set;
        }

        [DataMember(Name = "HG_Number")]
        public string HG_Number
        {
            get;
            set;
        }

        [DataMember(Name = "BF_Number")]
        public string BF_Number
        {
            get;
            set;
        }

        //[DataMember(Name = "MachineID")]
        //public string MachineID
        //{
        //    get;
        //    set;
        //}

        [DataMember(Name = "UserID")]
        public string UserID
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ProcessInfo
    {
        [DataMember(Name = "ProcessID")]
        public string ProcessID
        {
            get;
            set;
        }

        [DataMember(Name = "ProcessName")]
        public string ProcessName
        {
            get;
            set;
        }
    }

    [DataContract]
    public class CardInfo
    {
        [DataMember(Name = "CPXH")]
        public string CPXH
        {
            get;
            set;
        }

        [DataMember(Name = "ZZDH")]
        public string ZZDH
        {
            get;
            set;
        }

        [DataMember(Name = "SCPH")]
        public string SCPH
        {
            get;
            set;
        }

        [DataMember(Name = "CPZZ")]
        public string CPZZ
        {
            get;
            set;
        }

        [DataMember(Name = "JDDJ")]
        public string JDDJ
        {
            get;
            set;
        }

        [DataMember(Name = "WDTX")]
        public string WDTX
        {
            get;
            set;
        }

        [DataMember(Name = "ZLDJ")]
        public string ZLDJ
        {
            get;
            set;
        }

        [DataMember(Name = "ZXBZ")]
        public string ZXBZ
        {
            get;
            set;
        }

        [DataMember(Name = "HTH")]
        public string HTH
        {
            get;
            set;
        }

        [DataMember(Name = "TCSL")]
        public string TCSL
        {
            get;
            set;
        }

        [DataMember(Name = "SM")]
        public string SM
        {
            get;
            set;
        }
    }
}
