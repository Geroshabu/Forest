﻿using System.Collections.Generic;
using System.Linq;
using Forest;
using Xunit;


namespace ForestTest
{
    public class RandomByLevelGeneratorTest
    {
        RandomByLevelGenerator randomByLevelGenerator;

        Person testPerson01;
        Person testPerson02;
        Person testPerson03;
        Person testPerson04;
        Person testPerson05;
        Person testPerson06;

        /// <summary>
        /// コンストラクタでテストの準備
        /// </summary>
        public RandomByLevelGeneratorTest()
        {
            randomByLevelGenerator = new RandomByLevelGenerator();

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
            (Game[] games, IEnumerable<Person> breakPersons) result = randomByLevelGenerator.Generate(courtNum, attendMember, accommodateNumber);

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
            (Game[] games, IEnumerable<Person> breakPersons) result = randomByLevelGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            Assert.Equal(expectedGameCount, result.games.Length);
            Assert.NotNull(result.games[0]);
            Assert.Null(result.games[1]);
            Assert.Equal(expectedBreakPersonCount, result.breakPersons.Count<Person>());

        }

        [Fact(DisplayName = "初級者、中級者、上級者の順番に並んでいることを確認する")]
        public void GenerateTest3()
        {
            //Arrange
            //シングルスでコート数2、参加者4人とする
            int accommodateNumber = 2;
            int courtNum = 2;
            List<Person> attendMember = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
                testPerson06,
            };
            //期待結果
            Level beginner = new Level { LevelNum = 0 };
            Level intermediate = new Level { LevelNum = 1 };
            Level advanced = new Level { LevelNum = 2 };
            Level[] expectedType = { beginner, intermediate, intermediate, advanced };

            //act
            (Game[] games, IEnumerable<Person> breakPersons) result = randomByLevelGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //assert
            for (int i = 0; i < result.games.Length; i += 2)
            {
                Assert.Equal(expectedType[i], result.games[i].Player1[0].Level);
                Assert.Equal(expectedType[i + 1], result.games[i].Player2[0].Level);
            }

        }
    }
}
