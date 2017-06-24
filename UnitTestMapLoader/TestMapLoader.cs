using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapLoader;
using MapLoader.Model;

namespace UnitTestMapLoader
{
    [TestClass]
    public class TestMapLoader
    {
        [TestMethod]
        public void TestLoadingResourceMap()
        {
            MapModel model = Loader.Load("Map.json", true);
        }
    }
}
