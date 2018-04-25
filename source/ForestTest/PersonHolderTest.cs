using System.Collections.Generic;
using System.Linq;
using Forest;
using Xunit;

namespace ForestTest
{
    public class PersonHolderTest
    {
        List<Person> persons;

        Person testPerson01;
        Person testPerson02;
        Person testPerson03;
        Person testPerson04;
        Person testPerson05;
        Person testPerson06;

        /// <summary>
        /// テストの準備をする。テストデータの初期化
        /// </summary>
        public PersonHolderTest()
        {
            Gender men = new Gender { GenderNum = 0 };
            Gender women = new Gender { GenderNum = 1 };
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
                AttendFlag = false
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
                DeleteFlag = true,
                AttendFlag = false
            };
            testPerson04 = new Person
            {
                ID = "test04",
                Name = "marbles",
                Gender = men,
                Level = advanced,
                DeleteFlag = true,
                AttendFlag = true
            };
            testPerson05 = new Person
            {
                ID = "test05",
                Name = "spike",
                Gender = men,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = false
            };
            testPerson06 = new Person
            {
                ID = "test06",
                Name = "olaf",
                Gender = men,
                Level = intermediate,
                DeleteFlag = false,
                AttendFlag = true
            };

        }

        /// <summary>
        /// PersonHplderに登録しておくためのデータの配列を用意し、返す
        /// </summary>
        /// <returns>データのリスト</returns>
        public List<Person> PrepareData01()
        {
            persons = new List<Person>
            {
                testPerson01,
                testPerson02,
                testPerson03,
                testPerson04,
                testPerson05,
                testPerson06
            };

            return persons;
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "参加フラグを立てられることを確認する")]
        public void AttendTest01()
        {
            //Arrange
            //データの準備
            var testPersons = PrepareData01();
            var personHolder = new PersonHolder(testPersons);
            //期待値
            var expected = new List<Person>
            {
                testPerson01,
                testPerson05,
                testPerson02,
                testPerson06
            };

            //参加メンバーのIDをリストにセット
            var idList = new List<string>
            {
                "test01",
                "test05"
            };

            //Act
            //実行
            personHolder.Attend(idList);

            //Assert
            Assert.Empty(expected.Except(personHolder.GetAttended()));
            Assert.Empty(personHolder.GetAttended().Except(expected));
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "参加を取り消せることを確認する")]
        public void Cancelest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());
            //期待値
            var expected = new List<Person>
            {
                testPerson02,
            };

            //参加を取り消すメンバーのIDをリストにセット
            var idList = new List<string> { "test06" };

            //Act
            //実行
            personHolder.Cancel(idList);

            //Assert
            Assert.Empty(expected.Except(personHolder.GetAttended()));
            Assert.Empty(personHolder.GetAttended().Except(expected));
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "削除されていないメンバーを取得できることを確認する")]
        public void GetAllPersonsTest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());
            //期待値
            var expected = new List<Person>
            {
                testPerson02,
                testPerson01,
                testPerson06,
                testPerson05
            };

            //Act
            //実行
            var actual = personHolder.GetAll();

            //Assert
            Assert.Empty(expected.Except(actual));
            Assert.Empty(actual.Except(expected));

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "GetAllメソッドにおいてメンバーがいないときに空のリストを返すことを確認する")]
        public void GetAllPersonsTest02()
        {
            //Arrange
            //データの準備
            var emptyPersons = new List<Person>();
            var personHolder = new PersonHolder(emptyPersons);

            //Act
            //実行
            var actual = personHolder.GetAll();

            //Assert
            Assert.Empty(actual);

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "削除されておらずに参加フラグが立っているメンバーを取得できることを確認する")]
        public void GetAttendedPersonsTest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());
            //期待値
            var expected = new List<Person>
            {
                testPerson02,
                testPerson06
            };

            //Act
            //実行
            var actual = personHolder.GetAttended();

            //Assert
            Assert.Empty(expected.Except(actual));
            Assert.Empty(actual.Except(expected));

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "GetAttendedメソッドにおいてメンバーがいないときに空のリストを返すことを確認する")]
        public void GetAttendedPersonsTest02()
        {
            //Arrange
            //データの準備
            var emptyPersons = new List<Person>();
            var personHolder = new PersonHolder(emptyPersons);

            //Act
            //実行
            var actual = personHolder.GetAttended();

            //Assert
            Assert.Empty(actual);

        }




    }
}
