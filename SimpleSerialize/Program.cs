using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Fun with Object Serialization ****");
            StringData sd = new StringData();
            SaveAsSoapFormat(sd, "sd.soap");

            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 89.3,105.3,97.1};
            jbc.theRadio.hasTweeters = true;
            //SaveAsBinaryFormat(jbc, "jbc.txt");
            //LoadFromBinaryFile(@"jbc.txt");
          //  SaveAsSoapFormat(jbc, "jbc.soap");
           // LoadFromSoapFile(@"jbc.soap");
            SaveAsXMLFormat(jbc, "jbc.xml");
            LoadFromXMLFile(@"jbc.xml");
            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object obj, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, obj);
            }
            Console.WriteLine(" => save car in binary format");
        }
        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)binFormat.Deserialize(fstream);
                Console.WriteLine(jbc.theRadio.hasTweeters+"---"+jbc.theRadio.stationPresets.ToString());
            }
        }

        static void SaveAsSoapFormat(object obj, string fileName)
        {
            SoapFormatter sf = new SoapFormatter();
            using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                sf.Serialize(fstream,obj);
            }
            Console.WriteLine(" => save car in Soap format");
        }
        static void LoadFromSoapFile(string fileName)
        {
            SoapFormatter sf = new SoapFormatter();
            using (Stream fstream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)sf.Deserialize(fstream);
                Console.WriteLine(jbc.theRadio.hasTweeters + "---" + jbc.theRadio.stationPresets.ToString());
            }
        }

        //xml 序列化
        static void SaveAsXMLFormat(object obj, string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(JamesBondCar));//以要序列化的对象的类型作为参数
            using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xs.Serialize(fstream, obj);
            }
            Console.WriteLine(" => save car in XML format");
        }

        static void LoadFromXMLFile(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fstream = File.OpenRead(fileName))
            {
                JamesBondCar jbc = (JamesBondCar)xs.Deserialize(fstream);
                Console.WriteLine(jbc.theRadio.hasTweeters + "---" + jbc.theRadio.stationPresets.ToString());
            }
        }
    }
}
