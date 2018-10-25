using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTable_CSharp;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class LeagueTests
    {
        [TestMethod]
        public void TestAddPlayer()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");

            // Then
            var rows = league.GetRows();
            Assert.AreEqual(1, rows.Count);
            var firstRowPlayers = rows.First().GetPlayers();
            Assert.AreEqual(1, firstRowPlayers.Count);
            CollectionAssert.Contains(firstRowPlayers, "Bob");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddSamePlayerThrowsException()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Bob");
        }

        [TestMethod]
        public void TestGetRows()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Ted");

            // Then
            var rows = league.GetRows();
            Assert.AreEqual(2, rows.Count);
        }

        [TestMethod]
        public void TestRecordWin()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Ted");

            // Then
            league.RecordWin("Ted", "Bob");
            var rows = league.GetRows();

            Assert.AreEqual("Ted", rows.First().GetPlayers().First());
            Assert.AreNotEqual("Bob", rows.First().GetPlayers().First());
        }

        [TestMethod]
        public void TestForfeit()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Ted");

            // Then
            league.RecordForfeit("Bob", "Ted");
            var rows = league.GetRows();
            
            Assert.AreEqual("Bob", rows.First().GetPlayers().First());
            Assert.AreNotEqual("Ted", rows.First().GetPlayers().First());
        }

        [TestMethod]
        public void TestThreeForfeits()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Ted");
            league.AddPlayer("Cara");

            // Then
            league.RecordForfeit("Bob", "Ted");
            league.RecordForfeit("Bob", "Ted");
            league.RecordForfeit("Bob", "Cara");
            var rows = league.GetRows();

            Assert.AreEqual("Cara", rows.First().GetPlayers().First());
            Assert.AreNotEqual("Bob", rows.First().GetPlayers().First());

        }

        [TestMethod]
        public void TestGetWinner()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");
            league.AddPlayer("Ted");

            var rows = league.GetRows();

            // Then
            Assert.AreEqual("Bob", rows.First().GetPlayers().First());
            Assert.AreNotEqual("Ted", rows.First().GetPlayers().First());
        }
    }
}
