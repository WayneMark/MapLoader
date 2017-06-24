using System;
using System.Reflection;
using System.IO;
using JsonMapLoader.Model;
using Newtonsoft.Json;

namespace JsonMapLoader
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
            Assembly asms = System.Reflection.Assembly.GetEntryAssembly();
            String rootNamespace = asms.FullName.Split(',')[0];
            // you have to change the 'build action' value of the target resource to embedded resource.
            Stream stream = asms.GetManifestResourceStream(rootNamespace+".Resources.Map.json");
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
