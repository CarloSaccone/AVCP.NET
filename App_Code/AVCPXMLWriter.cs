using AVCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for XMLWriter
/// </summary>
/// 
namespace AVCP
{
    public class AVCPXMLWriter
    {

        public static byte[] WriteXML<T>(T item)
        {
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("legge190", "legge190_1_0");

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));


            MemoryStream memStream = new MemoryStream();
            writer.Serialize(memStream, item, myNamespaces);

            byte[] bytes;
            bytes = memStream.ToArray();
            return bytes;

        }
        public static void WriteXMLFile<T>(T item, string fileNameWithPath)
        {
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("legge190", "legge190_1_0");

            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));

            System.IO.StreamWriter file = new System.IO.StreamWriter(fileNameWithPath);
            writer.Serialize(file, item, myNamespaces);
            file.Close();

        }
    }
}