using Forest;
using System;
using Xunit;


namespace ForestTest
{
    public class RecordTest
    {
        Person Person01;
        Person Person02;
        Person Person03;

        public RecordTest()
        {
            Gender men = new Gender { GenderNum = 0 };
            Gender women = new Gender { GenderNum = 1 };
            Level beginner = new Level { LevelNum = 0 };
            Level intermediate = new Level { LevelNum = 1 };
            Level advanced = new Level { LevelNum = 2 };

            Person01 = new Person
            {
                ID = "test01",
                Name = "snoopy",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = false
            };
            Person02 = new Person
            {
                ID = "test02",
                Name = "bell",
                Gender = women,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = false
            };
            Person03 = new Person
            {
                ID = "test03",
                Name = "andy",
                Gender = men,
                Level = intermediate,
                DeleteFlag = false,
                AttendFlag = true
            };
        }

        [Fact(DisplayName = "Recordのコンストラクタでセットできていることを確認するテスト")]
        public void RecordTest1()
        {
            Forest.Record testRecord = new Forest.Record(Person01, Person02);

            Assert.Equal(Person01, testRecord.Player1);
            Assert.Equal(Person02, testRecord.Player2);
        }

        [Fact(DisplayName = "プレイヤーが含まれていることを返せていることを確認する")]
        public void ContainTest1()
        {
            Forest.Record testRecord = new Forest.Record(Person01, Person02);
            Assert.True(testRecord.Contain(Person01));
            Assert.True(testRecord.Contain(Person02));
        }

        [Fact(DisplayName = "プレイヤーが含まれていないことを返せていることを確認する")]
        public void ContainTest2()
        {
            Forest.Record testRecord = new Forest.Record(Person01, Person02);
            Assert.False(testRecord.Contain(Person03));
        }

        [Fact(DisplayName = "プレイヤーがnullのときには例外を出すことを確認する")]
        public void ContainTest3()
        {
            Forest.Record testRecord = new Forest.Record(Person01, Person02);
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { testRecord.Contain(null); });
        }
    }
}
