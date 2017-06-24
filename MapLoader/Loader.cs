using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MapLoader.Model;
using Newtonsoft.Json;

namespace MapLoader
{
    public static class Loader
    {
        public static MapModel Load(string name,bool fromResource = true)
        {
            if (fromResource)
            {
                return LoadResource(name);
            }
            else
            {
                return LoadPath(name);
            }
        }
        private static MapModel LoadResource(string filename)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            // you have to change the 'build action' value of the target resource to embedded resource.
            Stream stream = asm.GetManifestResourceStream("MapLoader.Resources.Map.json");
            return LoadStream(new StreamReader(stream));
        }
        private static MapModel LoadPath(string path)
        {
            FileInfo target = new FileInfo(path);
            if (!target.Exists)
                throw new FileNotFoundException();
            else
            {
                StreamReader sr = new StreamReader(path);
                MapModel map = LoadStream(sr);
                if (map.MapSelfCheck())
                    return map;
                throw new Exception("Unable to identify object");
            }
        }
        private static MapModel LoadStream(StreamReader sr)
        {
            string content = sr.ReadToEnd();
            if (content.Length == 0)
                throw new Exception("Empty file exception");
            return  JsonConvert.DeserializeObject<MapModel>(content);
        }
    }
}
