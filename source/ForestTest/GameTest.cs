using Forest;
using Xunit;

namespace ForestTest
{
    public class GameTest
    {
        [Fact(DisplayName = "Gameのテスト")]
        public void TestMethod1()
        {
            Court court = new Court
            {
                CourtName = "テストコート",
                AccommodateNumber = 2
            };

            Gender men = new Gender { GenderNum = 0 };
            Gender women = new Gender { GenderNum = 1 };
            Level beginner = new Level { LevelNum = 0 };
            Level advanced = new Level { LevelNum = 2 };

            Person person01 = new Person
            {
                ID = "test01",
                Name = "snoopy",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = false
            };
            Person person02 = new Person
            {
                ID = "test02",
                Name = "bell",
                Gender = women,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = false
            };
            Person[] players1 = { person01 };
            Person[] players2 = { person02 };

            Game game = new Game(court,players1,players2);

            Assert.Equal(court,game.Court);
            Assert.Equal(players1, game.Player1);
            Assert.Equal(players2, game.Player2);
        }

    }
}
