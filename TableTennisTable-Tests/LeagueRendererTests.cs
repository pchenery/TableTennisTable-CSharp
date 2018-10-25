using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTable_CSharp;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class LeagueRendererTests
    {
        [TestMethod]
        public void TestFormatName()
        {
            // Given
            LeagueRenderer leagueRenderer = new LeagueRenderer();
            League league = new League();

            // When
            league.AddPlayer("Bob");

            // Then
            Assert.AreEqual(leagueRenderer.FormatName("Bob"), "       Bob       ");
        }

        [TestMethod]
        public void TestFormatNameGreaterThan17Characters()
        {
            // Given
            LeagueRenderer leagueRenderer = new LeagueRenderer();
            League league = new League();

            // When
            league.AddPlayer("LongerThanSeventeen");

            // Then
            Assert.AreEqual(leagueRenderer.FormatName("LongerThanSeventeen"), "LongerThanSeve...");
        }
    }
}
