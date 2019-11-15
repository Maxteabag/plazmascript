using PlazmaScript.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PlazmaScript
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {

            var xmlPath = Pb2Config.Options.MapPath;

            //Create pb2 map content
            var map = new MapEntry();

            Console.WriteLine("Creating xml document...");
            //Generate xml file
            await XmlManager.GenerateXml(xmlPath, Pb2Config.Map.MapId);
            Console.WriteLine("Xml document generated at "+ xmlPath);

            //Upload xml file to pb2
            if (Pb2Config.Options.UploadToPb2)
            {
                Console.WriteLine("Uploading map to "+ Pb2Config.Map.MapId + "("+Pb2Config.Map.MapUid + ")");

                XmlManager.UploadAndReplaceMap(xmlPath);
            }
            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();

        }


    }

}

