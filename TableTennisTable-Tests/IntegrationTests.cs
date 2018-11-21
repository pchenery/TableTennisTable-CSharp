using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TableTennisTable_CSharp;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void TestPrintsEmptyGame()
        {
            var app = CreateApp();

            Assert.AreEqual("No players yet", app.SendCommand("print"));
        }

        private App CreateApp()
        {
            return new App(new League(), new LeagueRenderer(), new FileService());
        }

        [TestMethod]
        public void TestLoadsGame()
        {
            var app = CreateApp();

            var actual = app.SendCommand("load C:\\test\\game");
            var expected = "Loaded C:\\test\\game";

            Assert.AreEqual(expected, actual);
        }
    }
}
