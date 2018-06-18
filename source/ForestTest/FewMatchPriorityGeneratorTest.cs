using System;
using System.Collections.Generic;
using System.Linq;
using Forest;
using Xunit;

namespace ForestTest
{
    public class FewMatchPriorityGeneratorTest
    {
        GameRecorder gameRecorder;
        FewMatchPriorityGenerator fewMatchPriorityGenerator;

        Person testPerson01;
        Person testPerson02;
        Person testPerson03;
        Person testPerson04;
        Person testPerson05;
        Person testPerson06;

        Game testGame01;
        Game testGame02;
        Game testGame03;
        Game testGame04;
        Game testGame05;
        Game testGame06;
        Game testGame07;
        Game testGame08;
        Game testGame09;

        /// <summary>
        /// コンストラクタでテストの準備をする
        /// </summary>
        public FewMatchPriorityGeneratorTest()
        {
            gameRecorder = GameRecorder.GetInstance;
            fewMatchPriorityGenerator = new FewMatchPriorityGenerator();

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
            testPerson04 = new Person
            {
                ID = "test04",
                Name = "marbles",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = true
            };
            testPerson05 = new Person
            {
                ID = "test05",
                Name = "woodstock",
                Gender = men,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = true
            };
            testPerson06 = new Person
            {
                ID = "test06",
                Name = "harriet",
                Gender = women,
                Level = intermediate,
                DeleteFlag = false,
                AttendFlag = true
            };

            //Gameの準備
            Court court = new Court
            {
                CourtName = "テストコート",
                AccommodateNumber = 2
            };

            Person[] players1 = { testPerson01 };
            Person[] players2 = { testPerson02 };
            Person[] players3 = { testPerson03 };
            Person[] players4 = { testPerson04 };
            Person[] players5 = { testPerson05 };
            Person[] players6 = { testPerson06 };

            testGame01 = new Game(court, players1, players2);
            testGame02 = new Game(court, players1, players3);
            testGame03 = new Game(court, players1, players4);
            testGame04 = new Game(court, players1, players5);
            testGame05 = new Game(court, players1, players6);
            testGame06 = new Game(court, players2, players3);
            testGame07 = new Game(court, players2, players3);
            testGame08 = new Game(court, players2, players4);
            testGame09 = new Game(court, players3, players4);
        }

        [Fact(DisplayName = "コート2つとも人が入り、休憩者もいる場合")]
        public void GenerateTest1()
        {
            //Arrange
            //シングルスのコートが2つ、参加者6人とする
            int accommodateNumber = 2;
            int courtNum = 2;
            List<Person> attendMember = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
                testPerson04,
                testPerson05,
                testPerson06
            };
            //期待結果
            int expectedGameCount = 2;
            int expectedBreakPersonCount = 2;

            //act
            (Game[] games, IEnumerable<Person> breakPersons) result = fewMatchPriorityGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            Assert.Equal(expectedGameCount, result.games.Length);
            Assert.NotNull(result.games[0]);
            Assert.NotNull(result.games[1]);
            Assert.Equal(expectedBreakPersonCount, result.breakPersons.Count<Person>());

        }

        [Fact(DisplayName = "コートが一つあまり(ひとつはnull)、休憩者もいる場合")]
        public void GenerateTest2()
        {
            //Arrange
            //シングルスのコート数2、参加者3人とする
            int accommodateNumber = 2;
            int courtNum = 2;
            List<Person> attendMember = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
            };
            //期待結果
            int expectedGameCount = 2;
            int expectedBreakPersonCount = 1;

            //act
            (Game[] games, IEnumerable<Person> breakPersons) result = fewMatchPriorityGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            Assert.Equal(expectedGameCount, result.games.Length);
            Assert.NotNull(result.games[0]);
            Assert.Null(result.games[1]);
            Assert.Equal(expectedBreakPersonCount, result.breakPersons.Count<Person>());

        }

        [Fact(DisplayName = "参加試合回数の多い人が休憩者に入っているを確認する")]
        public void GenerateTest3()
        {
            //arrange
            //シングルスのコートが2つ、参加者6人とする
            int accommodateNumber = 2;
            int courtNum = 2;
            List<Person> attendMember = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
                testPerson04,
                testPerson05,
                testPerson06
            };

            //対戦履歴の作成
            Game[] games = new Game[] { testGame01 , testGame02 , testGame03 , testGame04,
                testGame05,testGame06,testGame07,testGame08};
            gameRecorder.Add(games);
            //期待結果
            var expectedBreakPerson = new List<Person> { testPerson01, testPerson02 };

            //act
            (Game[] games, IEnumerable<Person> breakPersons) result = fewMatchPriorityGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            Assert.Empty(expectedBreakPerson.Except(result.breakPersons));
            Assert.Empty(result.breakPersons.Except(expectedBreakPerson));
        }

        [Fact(DisplayName = "対戦回数の少ない人が当たっていることを確かめる")]
        public void GenerateTest4()
        {
            //arrange
            //シングルスのコートが2つ、参加者4人とする
            int accommodateNumber = 2;
            int courtNum = 2;
            List<Person> attendMember = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
                testPerson04,
            };

            //対戦履歴の作成(1-2,3-4,1-3,2-4)
            Game[] games = new Game[] { testGame01, testGame09, testGame02, testGame08 };
            gameRecorder.Add(games);
            //期待結果 → (1-4,2-3)

            //act
            (Game[] games, IEnumerable<Person> breakPersons) result = fewMatchPriorityGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            //1と4が当たっていることを確認する
            if (result.games[0].Team1.Any(person => person == testPerson01))
            {
                Assert.Contains(result.games[0].Team2, person => person == testPerson04);
            }
            else if (result.games[0].Team2.Any(person => person == testPerson01))
            {
                Assert.Contains(result.games[0].Team1, person => person == testPerson04);
            }
            else if (result.games[1].Team1.Any(person => person == testPerson01))
            {
                Assert.Contains(result.games[1].Team2, person => person == testPerson04);
            }
            else if (result.games[1].Team2.Any(person => person == testPerson01))
            {
                Assert.Contains(result.games[1].Team1, person => person == testPerson04);
            }
            else
            {
                throw new Exception("1-4になっていない");
            }

            //2と3が当たっていることを確認する
            if (result.games[0].Team1.Any(person => person == testPerson02))
            {
                Assert.Contains(result.games[0].Team2, person => person == testPerson03);
            }
            else if (result.games[0].Team2.Any(person => person == testPerson02))
            {
                Assert.Contains(result.games[0].Team1, person => person == testPerson03);
            }
            else if (result.games[1].Team1.Any(person => person == testPerson02))
            {
                Assert.Contains(result.games[1].Team2, person => person == testPerson03);
            }
            else if (result.games[1].Team2.Any(person => person == testPerson02))
            {
                Assert.Contains(result.games[1].Team1, person => person == testPerson03);
            }
            else
            {
                throw new Exception("2-3になっていない");
            }


        }
    }
}
