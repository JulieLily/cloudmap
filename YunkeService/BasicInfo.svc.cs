using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.Common.Data.BaseSystem;

namespace TOPSUN.YunkeService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BasicInfo”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BasicInfo.svc 或 BasicInfo.svc.cs，然后开始调试。
    public class BasicInfo : IBasicInfo
    {
        public UserData GetUser(string id)
        {
            StaffData data = (new StaffSystem()).GetStaffInfoById(id);
            if (data.Tables[StaffData.STAFFINFO_TABLE].Rows.Count == 1)
            {
                UserData result = new UserData();
                result.ID = data.Tables[StaffData.STAFFINFO_TABLE].Rows[0][StaffData.ID_FIELD].ToString().Trim();
                result.Name = data.Tables[StaffData.STAFFINFO_TABLE].Rows[0][StaffData.NAME_FIELD].ToString().Trim();
                result.Department = data.Tables[StaffData.STAFFINFO_TABLE].Rows[0][StaffData.DEPARTMENTNAME_FIELD].ToString().Trim();
                return result;
            }
            else
                return null;
        }
    }
}
