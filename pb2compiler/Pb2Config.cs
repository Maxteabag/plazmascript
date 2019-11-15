using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlazmaScript
{
    public class Pb2Config
    {
        public static class Map
        {
            /// <summary>
            /// This is the id of the map
            /// </summary>
            public static string MapId { get; set; } = "Max teabag-test";
            /// <summary>
            /// Map UId, can be found in the URL in the map page
            /// </summary>
            public static string MapUid { get; set; } = "960532";
        }
        public static class User
        {
            /// <summary>
            /// This is your PB2 username
            /// </summary>
            public static string Login { get; set; } = "Max teabag";
          
            /// <summary>
            /// Create a "password.txt" file in project root and insert your hashed password - can be found in cookies on plazmaburst2.com
            /// </summary>
            public static string GetPassword()
            {
                string wanted_path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
                wanted_path = wanted_path + "/password.txt";

                string text = System.IO.File.ReadAllText(wanted_path);

                return text;

            }
            /// <summary>
            /// User Uid, can be found in cookies
            /// </summary>
            public static string Uid { get; set; } = "554";
        }

        public static class Fragment
        {
            /// <summary>
            /// Id for map fragment. When uploading map to existing PB2 map, it will replace all the map objects with the same fragment id
            /// </summary>
            public static string Id { get; set; } = "a0";
        }

        /// <summary>
        /// Whether or not the changes will be automatically uploaded to the map
        /// </summary>
        public static class Options
        {
            /// <summary>
            /// Whether or not the map will be automatically uploaded to the pb2 map (Map-id, and password/username must be set)
            /// </summary>
            public static bool UploadToPb2 { get; set; } = true;
            /// <summary>
            /// Path to where the pb2 map is generated
            /// </summary>
            public static string MapPath { get; set; } = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")) +"/GeneratedMaps/" + Fragment.Id  + ".xml";
        }

    }
}
