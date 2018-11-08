﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void TestFileSave()
        {
            var league = new League();
            var renderer = new LeagueRenderer();
            var file = new Mock<IFileService>();

            file.Setup(f => f.Save("TestFile", league));

            var app = new App(league, renderer, file.Object);

            Assert.AreEqual("Saved TestFile", app.SendCommand("save TestFile"));
            file.Verify(f => f.Save("TestFile", league));
        }

        [TestMethod]
        public void TestFileLoad()
        {
            var league = new League();
            var renderer = new LeagueRenderer();
            var file = new Mock<IFileService>();

            file.Setup(f => f.Load("TestFile"));

            var app = new App(league, renderer, file.Object);

            Assert.AreEqual("Loaded TestFile", app.SendCommand("load TestFile"));
            file.Verify(f => f.Load("TestFile"));
        }
    }
}
