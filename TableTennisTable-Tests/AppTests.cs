using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TableTennisTable_CSharp;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void TestPrintsCurrentState()
        {
            var league = new League();
            var renderer = new Mock<ILeagueRenderer>();
            renderer.Setup(r => r.Render(league)).Returns("Rendered League");

            var app = new App(league, renderer.Object, null);

            Assert.AreEqual("Rendered League", app.SendCommand("print"));
        }

        [TestMethod]
        public void TestSave()
        {
            var league = new League();
            var renderer = new LeagueRenderer();
            var file = new Mock<IFileService>();

            file.Setup(f => f.Save("Name", league));

            var app = new App(league, renderer, null);
            app.SendCommand("save");

            //Assert.AreEqual("PathName", app.SendCommand("save"));
            file.Verify(f => f.Save("Name", league));
        }
    }
}
