using Forest;
using System;
using Xunit;

namespace ForestTest
{
    public class GameRecorderTest
    {
        GameRecorder GameRecorder;
        Game testGame01;
        Game testGame02;
        Game testGame03;
        Person testPerson01;
        Person testPerson02;
        Person testPerson03;

        public GameRecorderTest()
        {
            //Gameの準備
            Court court = new Court
            {
                CourtName = "テストコート",
                AccommodateNumber = 2
            };

            Gender men = new Gender { GenderNum = 1 };
            Gender women = new Gender { GenderNum = 0 };
            Level beginner = new Level { LevelNum = 0 };
            Level intermediate = new Level { LevelNum = 1 };
            Level advanced = new Level { LevelNum = 2 };

            testPerson01 = new Person
            {
                ID = "test01",
                Name = "snoopy",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = true
            };
            testPerson02 = new Person
            {
                ID = "test02",
                Name = "bell",
                Gender = women,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = true
            };
            testPerson03 = new Person
            {
                ID = "test03",
                Name = "andy",
                Gender = men,
                Level = intermediate,
                DeleteFlag = false,
                AttendFlag = true
            };

            Person[] players1 = { testPerson01 };
            Person[] players2 = { testPerson02 };
            Person[] players3 = { testPerson03 };

            testGame01 = new Game(court, players1, players2);
            testGame02 = new Game(court, players1, players3);
            testGame03 = new Game(court, players2, players3);
        }

        [Fact(DisplayName = "今までに対戦したことのある人たちの記録を更新することができる")]
        public void AddTest01()
        {
            //Arrange
            Game[] games = new Game[] { testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            games = new Game[] { testGame01 };
            GameRecorder.Add(games);
            int expected = 2;
            int actual = GameRecorder.GetTimes(testPerson01, testPerson02);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "今までに対戦したことのない人たちの記録を追加することができる")]
        public void AddTest02()
        {
            //Arrange
            Game[] games = new Game[] { testGame01 };
            GameRecorder = new GameRecorder();

            //Act
            GameRecorder.Add(games);
            int expected = 1;
            int actual = GameRecorder.GetTimes(testPerson01, testPerson02);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "複数件の記録を追加することができる")]
        public void AddTest03()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01, testGame01, testGame01 };
            GameRecorder = new GameRecorder();

            //Act
            GameRecorder.Add(games);
            int expected = 4;
            int actual = GameRecorder.GetTimes(testPerson01, testPerson02);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "nullが来たときは例外を出す")]
        public void AddTest03()
        {
            //Arrange
            GameRecorder = new GameRecorder();

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { GameRecorder.Add(null); });
        }

        [Fact(DisplayName = "引数に空の配列が来たときは例外を出す")]
        public void AddTest05()
        {
            //Arrange
            Game[] games = new Game[] { };
            GameRecorder = new GameRecorder();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            { GameRecorder.Add(games); });
        }

        [Fact(DisplayName = "【一人】引数の人が参加したことのある試合回数を返すことができる")]
        public void GetTimesTest01()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            int actualCount = GameRecorder.GetTimes(testPerson01);
            int expectedCount = 2;

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact(DisplayName = "【一人】試合をしたことのない人の試合回数を返すことができる")]
        public void GetTimesTest02()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            int actualCount = GameRecorder.GetTimes(testPerson03);
            int expectedCount = 0;

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact(DisplayName = "【二人】対戦したことのある人たちの試合回数を返すことができる")]
        public void GetTimesTest03()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01, testGame02 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            int actualCount = GameRecorder.GetTimes(testPerson01, testPerson02);
            int expectedCount = 2;

            //Assert
            Assert.Equal(expectedCount, actualCount);

        }

        [Fact(DisplayName = "【二人】対戦したことのない人たちの試合回数を返すことができる")]
        public void GetTimesTest04()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01, testGame02 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            int actualCount = GameRecorder.GetTimes(testPerson02, testPerson03);
            int expectedCount = 0;

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact(DisplayName = "【一人】nullの時には例外を出す")]
        public void GetTimesTest05()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { GameRecorder.GetTimes(null); });
        }

        [Fact(DisplayName = "【二人】一つ目の引数がnullの時には例外を出す")]
        public void GetTimesTest06()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { GameRecorder.GetTimes(testPerson01, null); });
        }

        [Fact(DisplayName = "【二人】二つ目の引数がnullの時には例外を出す")]
        public void GetTimesTest07()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { GameRecorder.GetTimes(null, testPerson01); });
        }

        [Fact(DisplayName = "【二人】両方の引数がnullの時には例外を出す")]
        public void GetTimesTest08()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { GameRecorder.GetTimes(null, null); });
        }

        [Fact(DisplayName = "【二人】両方の引数が同じの時には例外を出す")]
        public void GetTimesTest09()
        {
            //Arrange
            Game[] games = new Game[] { testGame01, testGame01 };
            GameRecorder = new GameRecorder();
            GameRecorder.Add(games);

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() =>
            { GameRecorder.GetTimes(testPerson01, testPerson01); });
        }

    }
}
