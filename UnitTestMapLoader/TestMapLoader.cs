using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonMapLoader;
using JsonMapLoader.Model;

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
