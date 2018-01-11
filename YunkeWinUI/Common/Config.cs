using System;
using System.Collections.Generic;

using System.Text;

using System.IO;
using System.Xml;

namespace TOPSUN.YunkeWinUI.Common
{
   public struct CurrentUser
    {
        public string Role;
        public string DepartmentID;
        public string UserName;
        public string UserID;
        public string Name;
        public string DepartmentName;
    }

    class Config
    {
        private const string CONFIGFILM = "./Config/XMLCon.xml";
        private const string CURRENTUSER_GROUP = "CurrentUser";
        private const string USERNAME_SECTION = "UserName";
        private const string USERID_SECTION = "ID";
        private const string NAME_SECTION = "Name";
        private const string DEPARTMENTID_SECTION = "DepartmentID";
        private const string DEPARTMENTNAME_SECTION = "DepartmentName";
        private const string ROLE_SECTION = "Role";

        public string error = null;

        CurrentUser user = new CurrentUser();

        public Config()
        {

            XmlDocument xml = new XmlDocument();

            try
            {
                string path = Path.GetFullPath(CONFIGFILM);
                if (File.Exists(path))
                {
                    xml.Load(path);

                    XmlElement element = xml.DocumentElement;

                    XmlNode node;
                    int count;

                    

                    node = element.SelectSingleNode("Server");
                    count = node.ChildNodes.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (node.ChildNodes[i].Name == "PWD")
                        {
                            PWD = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == "TraceTime")
                        {
                            RefTime = int.Parse(node.ChildNodes[i].InnerText.Trim());
                            continue;
                        }
                    }

                    node = element.SelectSingleNode(CURRENTUSER_GROUP);
                    count = node.ChildNodes.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (node.ChildNodes[i].Name == ROLE_SECTION)
                        {
                            user.Role = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == USERNAME_SECTION)
                        {
                            user.UserName = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == USERID_SECTION)
                        {
                            user.UserID = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == NAME_SECTION)
                        {
                            user.Name = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == DEPARTMENTID_SECTION)
                        {
                            user.DepartmentID = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                        if (node.ChildNodes[i].Name == DEPARTMENTNAME_SECTION)
                        {
                            user.DepartmentName = node.ChildNodes[i].InnerText.Trim();
                            continue;
                        }
                    }
                }
                else
                {
                    error = "配置文件不存在！";
                }
            }
            catch
            {
                error = "读取配置文件失败，请验证配置文件格式";
            }

        }

        #region 设置当前用户
        public void SetCurrentUser(CurrentUser para)
        {
            XmlDocument xml = new XmlDocument();
            error = null;

            try
            {
                string path = Path.GetFullPath(CONFIGFILM);
                if (File.Exists(path))
                {
                    xml.Load(path);

                    XmlElement element = xml.DocumentElement;

                    XmlNode node, childNode;

                    node = element.SelectSingleNode(CURRENTUSER_GROUP);
                    if (node == null)
                    {
                        node = xml.CreateElement(CURRENTUSER_GROUP);
                        element.AppendChild(node);
                    }
                    else
                    {
                        node.RemoveAll();
                    }

                    childNode = xml.CreateElement(ROLE_SECTION);
                    childNode.InnerText = para.Role.ToString();
                    node.AppendChild(childNode);

                    childNode = xml.CreateElement(USERNAME_SECTION);
                    childNode.InnerText = para.UserName.ToString();
                    node.AppendChild(childNode);

                    childNode = xml.CreateElement(USERID_SECTION);
                    childNode.InnerText = para.UserID.ToString();
                    node.AppendChild(childNode);

                    childNode = xml.CreateElement(NAME_SECTION);
                    childNode.InnerText = para.Name.ToString();
                    node.AppendChild(childNode);

                    childNode = xml.CreateElement(DEPARTMENTID_SECTION);
                    childNode.InnerText = para.DepartmentID.ToString();
                    node.AppendChild(childNode);

                    childNode = xml.CreateElement(DEPARTMENTNAME_SECTION);
                    childNode.InnerText = para.DepartmentName.ToString();
                    node.AppendChild(childNode);
                    xml.Save(path);
                }
                else
                {
                    error = "配置文件不存在！";
                }
            }
            catch
            {
                error = "写入配置文件失败，请验证配置文件格式";
            }
        }
        #endregion



        public CurrentUser GetCurrentUser
        {
            get
            {
                return user;
            }
            set
            {
                SetCurrentUser(value);
            }
        }

        public string PWD
        { get; set; }

        public int RefTime
        { get; set; }
    }
}
