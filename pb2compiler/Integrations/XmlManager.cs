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
using static PlazmaScript.Pb2Config;

namespace PlazmaScript
{
    public static class XmlManager
    {

        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        static IEnumerable<XElement> SimpleStreamAxis(byte[] inputMap)
        {
            var settings = new XmlReaderSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
            };

            MemoryStream ms = new MemoryStream(inputMap);

            var lol = Encoding.UTF8.GetString(inputMap);
            var list = new List<XElement>();


            using (XmlReader reader = XmlReader.Create(ms, settings))
            {
                reader.MoveToContent();

                while (!reader.EOF)
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        //if (reader.Name == elementName)
                        //{
                        var el = XNode.ReadFrom(reader) as XElement;
                        if (el != null)
                        {
                            list.Add(el);
                        }
                        //}
                    }
                    else reader.Read();

            }

            return list;
        }

        public static List<XElement> GetMapElementsExcludeFragment(string fragmentName, byte[] originalMap)
        {

            var map = SimpleStreamAxis(originalMap).ToList();

            try
            {
                var mapComponents = map.Where(x => x.HasAttributes && x.Attribute("comp") != null && x.Attribute("comp").Value == fragmentName).ToList();
                map.RemoveAll(x => x.Attribute("comp") != null && x.Attribute("comp").Value == fragmentName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            return map;


        }

        public static void UploadAndReplaceMap(string newMapPath)
        {

            var formData = new MultipartFormDataContent();

            var byteArray = File.ReadAllBytes(newMapPath);

            formData.Add(new ByteArrayContent(byteArray), "uploadfile", "newMap.xml");

            using (var client = new WebClientEx())
            {

                var authenticationCookie = GetAuthenticationCooke();

                var url = "https://www.plazmaburst2.com?m=" + Pb2Config.Map.MapId + "&id=" + Pb2Config.Map.MapUid + "&uid=" + Pb2Config.Map.MapUid + "&a&s=10";


                HttpUploadFile(url, newMapPath, "uploadfile", "application/xml", new NameValueCollection(), authenticationCookie);
            }

        }

        private static CookieContainer GetAuthenticationCooke()
        {
            Cookie cookie = new Cookie("password", Pb2Config.User.GetPassword());
            Cookie cookie2 = new Cookie("pb2uid", Pb2Config.User.Uid);
            Cookie cookie3 = new Cookie("login", Pb2Config.User.Login);

            cookie.Domain = ".www.plazmaburst2.com";
            cookie2.Domain = ".www.plazmaburst2.com";
            cookie3.Domain = ".www.plazmaburst2.com";

            var cookies = new CookieContainer();


            cookies.Add(cookie);
            cookies.Add(cookie2);
            cookies.Add(cookie3);

            return cookies;
        }

  
        public static async Task GenerateXml(string newMap, string mapId = "")
        {


            byte[] originalMap = null;
            if (!string.IsNullOrWhiteSpace(mapId))
            {
                originalMap = await DownloadFile("https://www.plazmaburst2.com/level_editor/map_download.php?a=load&ext=xml&r=" + mapId);
            }


            var utf8noBOM = new UTF8Encoding(false);

            var writingSettings = new XmlWriterSettings
            {
                ConformanceLevel = ConformanceLevel.Fragment,
                Encoding = utf8noBOM,
                Async = true
            };

            var cancel = new System.Threading.CancellationToken();

            using (var write = XmlWriter.Create(newMap, writingSettings))
            {
                if (originalMap != null)
                {
                    var originalMapList = GetMapElementsExcludeFragment(Fragment.Id, originalMap);
                     originalMapList.ForEach(async x => await x.WriteToAsync(write, cancel));
                }

                foreach (var x in PB2Map.MapObjects)
                {
                    var xmlElement = x.CreateXmlElement();
                    xmlElement.SetAttributeValue("comp", Pb2Config.Fragment.Id);
                    await xmlElement.WriteToAsync(write, cancel);
                }

                write.Close();
            }
        }

        public static async Task<byte[]> DownloadFile(string url)
        {

            using (var handler = new HttpClientHandler() { CookieContainer = GetAuthenticationCooke() })
            using (var client = new HttpClient(handler))
            {

                using (var result = await client.GetAsync(url))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsByteArrayAsync();
                    }

                }
            }

            return null;
        }

        public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc, CookieContainer cookies)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            wr.CookieContainer = cookies;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                Console.WriteLine(string.Format("File uploaded successfully."));
            }
            catch (Exception ex)
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                Console.WriteLine("Error upload file ", ex);
            }
            finally
            {
                wr = null;
            }
        }
    }



    public class WebClientEx : WebClient
    {
        public CookieContainer _cookieContainer = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = _cookieContainer;
            }
            return request;
        }
    }
}
