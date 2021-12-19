using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Commons.Configuration
{
    public static class SMTPconfig
    {
        public static bool SaveConfiguration(string smtpServer, string smtpUser, string smtpPassword, string emailFrom, bool enableSSL, string smtpPort)
        {
            try
            {
                //string aConfigPath = Application.ExecutablePath + ".config";
                string aConfigPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                //string aConfigPath = Application.ExecutablePath + ".config";

                //if (System.IO.File.Exists(aConfigPath) == false)
                //{
                //    Application.ExitThread();
                //}

                XmlNode xmlNode;
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(aConfigPath);
                xmlNode = xmlDoc.DocumentElement.SelectSingleNode("appSettings");

                if (!(xmlNode == null))
                {
                    bool bSMTPServer = false;
                    bool bSMTPUserName = false;
                    bool bSMTPPassword = false;
                    bool bSMTPShouldAuthenticate = false;
                    bool bNotificationEmailFrom = false;
                    bool bSSL = false;
                    bool bPort = false;

                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (!(childNode.Attributes == null))
                        {
                            if ((childNode.Attributes.Count == 2))
                            {
                                XmlAttribute xmlAttr = childNode.Attributes["key"];
                                if (!(xmlAttr == null))
                                {
                                    switch (xmlAttr.Value)
                                    {
                                        case "SMTPServer":
                                            childNode.Attributes["value"].Value = smtpServer;
                                            bSMTPServer = true;
                                            break;
                                        case "SMTPUserName":
                                            childNode.Attributes["value"].Value = smtpUser;
                                            bSMTPUserName = true;
                                            break;
                                        case "SMTPPassword":
                                            childNode.Attributes["value"].Value = SecurityManager.Encrypt(smtpPassword);
                                            bSMTPPassword = true;
                                            break;
                                        case "SMTPShouldAuthenticate":
                                            childNode.Attributes["value"].Value = "True";
                                            bSMTPShouldAuthenticate = true;
                                            break;
                                        case "eMailFrom":
                                            childNode.Attributes["value"].Value = emailFrom;
                                            bNotificationEmailFrom = true;
                                            break;
                                        case "EnableSSL":
                                            childNode.Attributes["value"].Value = "True";
                                            bSSL = true;
                                            break;
                                        case "SMTPPort":
                                            childNode.Attributes["value"].Value = smtpPort;
                                            bPort = true;
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    if ((bSMTPServer == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "SMTPServer";
                        objNode.Attributes[1].Value = smtpServer;
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bSMTPUserName == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "SMTPUserName";
                        objNode.Attributes[1].Value = smtpUser;
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bSMTPPassword == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "SMTPPassword";
                        objNode.Attributes[1].Value = SecurityManager.Encrypt(smtpPassword);
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bSMTPShouldAuthenticate == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "SMTPShouldAuthenticate";
                        objNode.Attributes[1].Value = "True";
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bNotificationEmailFrom == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "eMailFrom";
                        objNode.Attributes[1].Value = emailFrom;
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bSSL == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "EnableSSL";
                        objNode.Attributes[1].Value = "True";
                        xmlNode.AppendChild(objNode);
                    }

                    if ((bPort == false))
                    {
                        XmlNode objNode;
                        objNode = xmlDoc.CreateNode(XmlNodeType.Element, "add", "");
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("key"));
                        objNode.Attributes.Append(xmlDoc.CreateAttribute("value"));
                        objNode.Attributes[0].Value = "SMTPPort";
                        objNode.Attributes[1].Value = smtpPort;
                        xmlNode.AppendChild(objNode);
                    }
                }

                xmlDoc.Save(aConfigPath);
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
