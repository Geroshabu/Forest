using Forest;
using Xunit;


namespace ForestTest
{
    public class RecordTest
    {
        Person person01;
        Person person02;

        public RecordTest()
        {
            Gender men = new Gender { GenderNum = 0 };
            Gender women = new Gender { GenderNum = 1 };
            Level beginner = new Level { LevelNum = 0 };
            Level advanced = new Level { LevelNum = 2 };

            person01 = new Person
            {
                ID = "test01",
                Name = "snoopy",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = false
            };
            person02 = new Person
            {
                ID = "test02",
                Name = "bell",
                Gender = women,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = false
            };
        }

        [Fact(DisplayName = "Recordのコンストラクタでセットできていることを確認するテスト")]
        public void RecordTest1()
        {
            Forest.Record testRecord = new Forest.Record(person01,person02);

            int expectedCount = 1;//対戦回数の初期値は1

            Assert.Equal(person01,testRecord.Opponent[0]);
            Assert.Equal(person02, testRecord.Opponent[1]);
            Assert.Equal(expectedCount, testRecord.Count);

        }

    }
}
