using robotManager.Helpful;
using robotManager.Products;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Drawing.Design;
using System.Text;
using System.Threading.Tasks;

public class PathSettings : Settings
{
    public static List<Vector3> Path { get; set; }
    public static string XmlDirection
    {
        get {
            return Others.GetCurrentDirectory + "\\PathFinder_Path";
        }
    }
    public static string XmlPath 
    {
        get {
            return XmlDirection + "\\PathEdit.xml";
        }
    }
    public static string XmlPathOut
    {
        get
        {
            return XmlDirection + "\\PathEditOut.xml";
        }
    }

    public static string path = XmlPath;
    public PathSettings()
    {
        Path = new List<Vector3>();
    }
    public static async Task<bool> ReadFile()
    {
        Main.Path.Clear();
        //List<Vector3> xpath = new List<Vector3>();
        try
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader stream = new StreamReader(fs, Encoding.UTF8);
            string content = stream.ReadToEnd();
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(content);
            var result = doc.GetElementsByTagName("Vectors3");
            var item = result.Item(0);

            int nodeindex = 0;

            foreach (XmlNode n in item.ChildNodes)
            {
                var X = n.Attributes[0].Value;
                var Y = n.Attributes[1].Value;
                var Z = n.Attributes[2].Value;
                string major = n.Attributes[3].Value;
                string type = n.Attributes.Count == 4 ? "None" : n.Attributes[4].Value;
                MyVector3 v3 = new MyVector3(float.Parse(X), float.Parse(Y), float.Parse(Z), type, major.Equals("1"));
                //xpath.Add(v3);
                Main.Path.Add(v3);
                //Methods.LuaPrint(Methods.FormatLua(@"read N{0} - X:{1} Y:{2} Z:{3}", nodeindex, v3.X, v3.Y, v3.Z));
                nodeindex += 1;
            }
        }
        catch (Exception e)
        {
            Logging.WriteError(e.ToString());
        }
        if (Main.Path.Count == 0)
        {
            Logging.WriteError("No points in path");
        }
        await Task.Delay(3000);

        return true;
    }

    public static bool WriteFile()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            if (File.Exists(path))
            {
                doc.Load(path);
                root = doc.DocumentElement;
            }
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                root = doc.CreateElement("Vectors3");
                doc.AppendChild(root);
            }
            root.RemoveAll();
            foreach (MyVector3 v in Main.Path)
            {
                XmlElement node = doc.CreateElement("Vector3");
                node.SetAttribute("X", v.Position.X.ToString());
                node.SetAttribute("Y", v.Position.Y.ToString());
                node.SetAttribute("Z", v.Position.Z.ToString());
                node.SetAttribute("M", "0");
                root.AppendChild(node);
            }
            doc.Save(path);
        }
        catch (Exception e)
        {
            Logging.WriteError(e.ToString());
        }
        return true;
    }
    public static bool HODLWriteFile()
    {
        try
        {
            string path = XmlPathOut;

            XmlWriter xmlWriter = XmlWriter.Create(path);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Vectors3");

            xmlWriter.WriteStartElement("Vector3");
            xmlWriter.WriteAttributeString("X", "42.000");
            xmlWriter.WriteAttributeString("Y", "42.000");
            xmlWriter.WriteAttributeString("Z", "42.000");
            xmlWriter.WriteAttributeString("M", "0");
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }
        catch (Exception e)
        {
            Logging.WriteError(e.ToString());
        }

        return true;
    }

    public static bool Load()
    {
        //string path = Others.GetCurrentDirectory + "Settings\\" + "PathEditOut.xml";
        //ReadFile();
        try
        {
            if (File.Exists(path))
            {
                Task<bool> task = ReadFile();
                return true;
            }
        }
        catch (Exception e)
        {
            Logging.Write("CustomPlugin-PathEditor > Load(): " + e);
        }
        return false;
    }
    public static bool ReLoad(string name) 
    {
        path = XmlDirection + "\\" + name;
        return Load();
    }

    public static bool Save()
    {
        //WriteFile();
        try
        {
            return WriteFile();
        }
        catch (Exception e)
        {
            Logging.WriteError("CustomPlugin-PathEditor > Save(): " + (object)e, true);
            return false;
        }
    }
    public List<Vector3> GetPathFromXml(string path)
    {
        List<Vector3> xpath = new List<Vector3>();
        try
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader stream = new StreamReader(fs, Encoding.UTF8);
            string content = stream.ReadToEnd();
            XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(content);
            var result = doc.GetElementsByTagName("Vectors3");
            var item = result.Item(0);

            foreach (XmlNode n in item.ChildNodes)
            {
                var X = n.Attributes[0].Value;
                var Y = n.Attributes[1].Value;
                var Z = n.Attributes[2].Value;
                string type = n.Attributes.Count == 3 ? "None" : n.Attributes[3].Value;
                Vector3 v3 = new Vector3(float.Parse(X), float.Parse(Y), float.Parse(Z), type);
                xpath.Add(v3);
            }
            Logging.WriteError(" Xml file parsed !" + path);

        }
        catch (Exception e)
        {
            Logging.WriteError(e.ToString());
        }
        if (xpath.Count == 0) Logging.WriteError("No points in path");
        return xpath;
    }
    /// <summary>
    /// scan xml direction and collect file name
    /// </summary>
    public static string ReadPathFileName()
    {
        StringBuilder re = new StringBuilder();
        DirectoryInfo di = new DirectoryInfo(XmlDirection);
        if (di.Exists) 
        {
            FileInfo[] fis =  di.GetFiles();
            for (int i = 0; i < fis.Length; i++)
            {
                if (fis[i].Extension.Equals(".xml"))
                {
                    re.Append(fis[i].Name);
                }
                if (i < fis.Length - 1)
                {
                    re.Append(",");
                }
            }
        }
        return re.ToString();
    }
}

//class sTemp : Settings
//{
//    public List<Vector3> GetPathFromXml(string path)
//    {
//        List<Vector3> xpath = new List<Vector3>();

//        try
//        {
//            FileStream fs = new FileStream(path, FileMode.Open);
//            StreamReader stream = new StreamReader(fs, Encoding.UTF8);
//            string content = stream.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(content);
//            var result = doc.GetElementsByTagName("Vectors3");
//            var item = result.Item(0);

//            foreach (XmlNode n in item.ChildNodes)
//            {
//                var X = n.Attributes[0].Value;
//                var Y = n.Attributes[1].Value;
//                var Z = n.Attributes[2].Value;
//                string type = n.Attributes.Count == 3 ? "None" : n.Attributes[3].Value;
//                Vector3 v3 = new Vector3(float.Parse(X), float.Parse(Y), float.Parse(Z), type);
//                xpath.Add(v3);
//            }

//            Logging.WriteError(" Xml file parsed !" + path);

//        }
//        catch (Exception e)
//        {
//            Logging.WriteError(e.ToString());
//        }
//        if (xpath.Count == 0) Logging.WriteError("No points in path");

//        return xpath;
//    }
//    public static void CreateHmpSetting()
//    {
//        var filePath = AdviserFilePathAndName("CustomPlugin-Master", ObjectManager.Me.Name + "." + Usefuls.RealmName);

//var fileContent =
//@"<?xml version=""1.0"" encoding=""utf-8""?>﻿
//<PluginSettings xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
//  <TransactionId>123456789</TransactionId>
//  <AutoEquipBlacklist>
//    <int>7005</int>
//    <int>7005</int>
//    <int>7005</int>
//    <int>7005</int>
//  </AutoEquipBlacklist>
//  <FirstAid>false</FirstAid>
//  <TrainFirstAid>false</TrainFirstAid>
//  <Food>false</Food>
//  <Drink>false</Drink>
//  <BlackListIds />
//  <Looting>false</Looting>
//  <Skinning>false</Skinning>
//  <TrainingLevels />
//  <TrainerBlacklist />
//  <EscapeElite>true</EscapeElite>
//  <EscapePercentMana>0</EscapePercentMana>
//  <EscapePercentManaEnemies>0</EscapePercentManaEnemies>
//  <SmartPulls>false</SmartPulls>
//</PluginSettings>";

//        Others.WriteFile(filePath, fileContent);

//        //MessageBox.Show("HMP file created");
//    }
//}