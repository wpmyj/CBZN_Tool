using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
namespace Bll
{
    public class XmlHelper
    {
        public string FilePath { get; set; }

        private XmlDocument XmlDoc;

        public XmlHelper(string filepath)
        {
            this.FilePath = filepath;
        }

        public bool Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return false;
                }

                XmlDoc = new XmlDocument();
                XmlDoc.Load(FilePath);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(string version, string encoding, string loclname)
        {
            try
            {
                XmlDoc = new XmlDocument();
                XmlDeclaration dec = XmlDoc.CreateXmlDeclaration(version, encoding, null);
                XmlDoc.AppendChild(dec);
                XmlElement element = XmlDoc.CreateElement(null, loclname, null);
                XmlDoc.AppendChild(element);
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add<T>(T t)
        {
            try
            {
                if (XmlDoc == null) return false;
                Type type = typeof(T);
                XmlElement xe = XmlDoc.CreateElement(type.Name);
                PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo item in pis)
                {
                    string value = string.Empty;
                    XmlElement xenode = XmlDoc.CreateElement(null, item.Name, null);
                    object obj = item.GetValue(t, null);
                    if (obj != null)
                        value = obj.ToString();
                    xenode.InnerText = value;
                    xe.AppendChild(xenode);
                }
                XmlDoc.DocumentElement.AppendChild(xe);
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(string elementname, Dictionary<string, string> nodes)
        {
            return Add(elementname, null, nodes);
        }

        public bool Add(string elementname, Dictionary<string, string> attributes, Dictionary<string, string> nodes)
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlElement ele = XmlDoc.CreateElement(elementname);
                if (attributes != null)
                {
                    foreach (KeyValuePair<string, string> item in attributes)
                    {
                        XmlAttribute attribute = XmlDoc.CreateAttribute(item.Key);
                        attribute.InnerText = item.Value;
                        ele.Attributes.Append(attribute);
                    }
                }
                if (nodes != null)
                {
                    foreach (KeyValuePair<string, string> item in nodes)
                    {
                        XmlElement node = XmlDoc.CreateElement(item.Key);
                        node.InnerText = item.Value;
                        ele.AppendChild(node);
                    }
                }
                XmlDoc.DocumentElement.AppendChild(ele);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update<T>(T t)
        {
            try
            {
                if (XmlDoc == null) return false;
                Type type = typeof(T);
                XmlNode findnode = GetFindNode(XmlDoc.ChildNodes, type.Name);
                if (findnode != null)
                {
                    PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    foreach (PropertyInfo item in pis)
                    {
                        string value = string.Empty;
                        XmlNode node = findnode.SelectSingleNode(item.Name);
                        if (node != null)
                        {
                            object obj = item.GetValue(t, null);
                            if (obj != null)
                                value = obj.ToString();
                            node.InnerText = value;
                        }
                    }
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update<T>(T t, int index)
        {
            try
            {
                if (XmlDoc == null) return false;
                Type type = typeof(T);
                XmlNodeList nodelist = GetFindNodes(XmlDoc.ChildNodes, type.Name);
                if (nodelist != null && nodelist.Count > 0)
                {
                    if (index < 0 && index >= nodelist.Count)
                    {
                        throw new ArgumentOutOfRangeException("索引超出数组范围");
                    }
                    XmlNode node = nodelist[index];
                    PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    foreach (PropertyInfo item in pis)
                    {
                        XmlNode findnode = node.SelectSingleNode(item.Name);
                        if (findnode != null)
                        {
                            string value = string.Empty;
                            object obj = item.GetValue(t, null);
                            if (obj != null)
                                value = obj.ToString();
                            findnode.InnerText = value;
                        }
                    }
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private XmlNodeList GetFindNodes(XmlNodeList nodelist, string elementname)
        {
            foreach (XmlNode item in nodelist)
            {
                XmlNodeList nodes = item.SelectNodes(elementname);
                if (nodes != null && nodes.Count > 0)
                {
                    return nodes;
                }
                if (item.ChildNodes.Count > 0)
                {
                    XmlNodeList Ret = GetFindNodes(item.ChildNodes, elementname);
                    if (Ret != null && Ret.Count > 0)
                        return Ret;
                }
            }
            return null;
        }

        private XmlNode GetFindNode(XmlNodeList nodelist, string elementname)
        {
            foreach (XmlNode item in nodelist)
            {
                if (item.Name.Equals(elementname))
                {
                    return item;
                }
                if (item.ChildNodes.Count > 0)
                {
                    XmlNode Ret = GetFindNode(item.ChildNodes, elementname);
                    if (Ret != null)
                        return Ret;
                }

            }
            return null;
        }

        public bool Update(string elementname, string elementvalue)
        {
            return Update(elementname, elementvalue, null, null);
        }

        public bool Update(Dictionary<string, string> elements)
        {
            try
            {
                if (XmlDoc == null) return false;
                foreach (KeyValuePair<string, string> item in elements)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, item.Key);
                    if (node != null)
                    {
                        node.InnerText = item.Value;
                    }
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(string elementname, Dictionary<string, string> attributes)
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                if (node != null)
                {
                    if (attributes != null)
                        foreach (KeyValuePair<string, string> item in attributes)
                        {
                            node.Attributes[item.Key].InnerText = item.Value;
                        }
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(string elementname, string elementvalue, string attributename, string attributevalue)
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlNode findnode = GetFindNode(XmlDoc.ChildNodes, elementname);
                if (findnode != null)
                {
                    findnode.InnerText = elementvalue;
                    if (!string.IsNullOrEmpty(attributename) && !string.IsNullOrEmpty(attributevalue))
                        findnode.Attributes[attributename].InnerText = attributevalue;
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Del(string elementname)
        {
            return Del(elementname, null);
        }

        public bool Del(string elementname, int index)
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlNodeList nodelist = GetFindNodes(XmlDoc.ChildNodes, elementname);
                if (nodelist != null && nodelist.Count > 0)
                {
                    if (index < 0 && index >= nodelist.Count)
                    {
                        throw new ArgumentOutOfRangeException("索引超出数组范围");
                    }
                    XmlNode node = nodelist[index];
                    node.ParentNode.RemoveChild(node);
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Del(string elementname, string attributename)
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlNodeList nodelist = GetFindNodes(XmlDoc.ChildNodes, elementname);
                if (nodelist != null && nodelist.Count > 0)
                {
                    if (!string.IsNullOrEmpty(attributename))
                    {
                        foreach (XmlNode item in nodelist)
                        {
                            item.ParentNode.RemoveChild(item);
                        }
                    }
                    else
                    {
                        foreach (XmlNode item in nodelist)
                        {
                            item.Attributes.RemoveNamedItem(attributename);
                        }
                    }
                }
                return Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReadContent(string elementname)
        {
            string Result = string.Empty;
            try
            {
                if (XmlDoc != null)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                    if (node != null)
                    {
                        Result = node.InnerText;
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadContent(string elementname, ref Dictionary<string, string> nodes, ref Dictionary<string, string> attributes)
        {
            try
            {
                if (XmlDoc != null)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                    if (node != null && (node.ChildNodes.Count > 0 || node.Attributes.Count > 0))
                    {
                        if (nodes == null) nodes = new Dictionary<string, string>();
                        foreach (XmlNode item in node.ChildNodes)
                        {
                            nodes.Add(item.Name, item.InnerText);
                        }
                        if (attributes == null) attributes = new Dictionary<string, string>();
                        foreach (XmlAttribute item in node.Attributes)
                        {
                            attributes.Add(item.Name, item.InnerText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> ReadContents(string elementname)
        {
            Dictionary<string, string> diclist = null;
            try
            {
                if (XmlDoc != null)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                    if (node != null && node.ChildNodes.Count > 0)
                    {
                        diclist = new Dictionary<string, string>();
                        foreach (XmlNode item in node.ChildNodes)
                        {
                            diclist.Add(item.Name, item.InnerText);
                        }
                    }
                }
                return diclist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReadAttribute(string elementname, string attribute)
        {
            string Result = string.Empty;
            try
            {
                if (XmlDoc != null)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                    if (node != null)
                    {
                        Result = node.Attributes[attribute].InnerText;
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> ReadAttributes(string elementname)
        {
            Dictionary<string, string> dic = null;
            try
            {
                if (XmlDoc != null)
                {
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, elementname);
                    if (node != null && node.Attributes.Count > 0)
                    {
                        dic = new Dictionary<string, string>();
                        foreach (XmlAttribute item in node.Attributes)
                        {
                            dic.Add(item.Name, item.InnerText);
                        }
                    }
                }
                return dic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Read<T>()
        {
            T t = default(T);
            try
            {
                if (XmlDoc != null)
                {
                    Type type = typeof(T);
                    XmlNode node = GetFindNode(XmlDoc.ChildNodes, type.Name);
                    if (node != null)
                    {
                        t = Activator.CreateInstance<T>();
                        PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        foreach (PropertyInfo item in pis)
                        {
                            XmlNode selectednode = node.SelectSingleNode(item.Name);
                            if (selectednode != null)
                            {
                                object obj = GetDataType(item, selectednode.InnerText);
                                item.SetValue(t, obj, null);
                            }
                        }
                    }
                }
                return t;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> ReadList<T>()
        {
            List<T> tlist = null;
            try
            {
                if (XmlDoc != null)
                {
                    Type type = typeof(T);
                    XmlNodeList nodelist = GetFindNodes(XmlDoc.ChildNodes, type.Name);
                    if (nodelist != null && nodelist.Count > 0)
                    {
                        tlist = new List<T>();
                        PropertyInfo[] pis = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        foreach (XmlNode item in nodelist)
                        {
                            T t = Activator.CreateInstance<T>();
                            foreach (PropertyInfo pitem in pis)
                            {
                                object obj = GetDataType(pitem, item.SelectSingleNode(pitem.Name).InnerText);
                                pitem.SetValue(t, obj, null);
                            }
                            tlist.Add(t);
                        }
                    }
                }
                return tlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object GetDataType(PropertyInfo t, object obj)
        {
            if (t.PropertyType == typeof(int))
            {
                obj = Convert.ToInt32(obj);
            }
            else if (t.PropertyType == typeof(DateTime))
            {
                obj = Convert.ToDateTime(obj);
            }
            else if (t.PropertyType == typeof(bool))
            {
                obj = Convert.ToBoolean(obj);
            }
            else if (t.PropertyType == typeof(double))
            {
                obj = Convert.ToDouble(obj);
            }
            return obj;
        }

        public bool Save()
        {
            try
            {
                if (XmlDoc == null) return false;
                XmlDoc.Save(FilePath);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
