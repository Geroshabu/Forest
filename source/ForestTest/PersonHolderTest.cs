using System.Collections.Generic;
using System.Linq;
using Forest;
using Xunit;

namespace ForestTest
{
    public class PersonHolderTest
    {
        List<Person> persons;

        /// <summary>
        /// PersonHplderに登録しておくためのデータを用意する
        /// </summary>
        /// <returns>データのリスト</returns>
        public List<Person> PrepareData01()
        {
            persons = new List<Person>();

            var men = new Gender { GenderNum = 0 };
            var women = new Gender { GenderNum = 1 };
            var beginner = new Level { LevelNum = 0 };
            var intermediate = new Level { LevelNum = 1 };
            var advanced = new Level { LevelNum = 2 };

            var testPerson01 = new Person
            {
                ID = "test01",
                Name = "snoopy",
                Gender = men,
                Level = advanced,
                DeleteFlag = false,
                AttendFlag = false
            };
            var testPerson02 = new Person
            {
                ID = "test02",
                Name = "bell",
                Gender = women,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = true
            };
            var testPerson03 = new Person
            {
                ID = "test03",
                Name = "andy",
                Gender = men,
                Level = intermediate,
                DeleteFlag = true,
                AttendFlag = false
            };
            var testPerson04 = new Person
            {
                ID = "test04",
                Name = "marbles",
                Gender = men,
                Level = advanced,
                DeleteFlag = true,
                AttendFlag = true
            };
            var testPerson05 = new Person
            {
                ID = "test05",
                Name = "spike",
                Gender = men,
                Level = beginner,
                DeleteFlag = false,
                AttendFlag = false
            };
            var testPerson06 = new Person
            {
                ID = "test06",
                Name = "olaf",
                Gender = men,
                Level = intermediate,
                DeleteFlag = false,
                AttendFlag = true
            };

            persons.Add(testPerson01);
            persons.Add(testPerson02);
            persons.Add(testPerson03);
            persons.Add(testPerson04);
            persons.Add(testPerson05);
            persons.Add(testPerson06);

            return persons;
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "参加フラグを正常に立てられることを確認する")]
        public void AttendTest01()
        {
            //Arrange
            //データの準備
            var testPersons = PrepareData01();
            var personHolder = new PersonHolder(testPersons);
            //参加数メンバーのIDをリストにセット
            var idList = new List<string>();
            idList.Add("test01");
            idList.Add("test05");

            //Act
            //実行
            personHolder.Attend(idList);

            //Assert
            //PersonData01の人を保持しておいて、その中の人のフラグが変更されているかを見る
            //Attendした後とで比較

            //Assertする前
            //Assert.False(testPersons.Where(x => x.ID == "test01").);



            //Assert.True(personHolder.Persons.Where(x => x.ID == "test01").FirstOrDefault().AttendFlag);
            //Assert.True(personHolder.Persons.Where(x => x.ID == "test02").FirstOrDefault().AttendFlag);
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test03").FirstOrDefault().AttendFlag);
            //Assert.True(personHolder.Persons.Where(x => x.ID == "test04").FirstOrDefault().AttendFlag);
            //Assert.True(personHolder.Persons.Where(x => x.ID == "test05").FirstOrDefault().AttendFlag);
            //Assert.True(personHolder.Persons.Where(x => x.ID == "test06").FirstOrDefault().AttendFlag);

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "参加を正常に取り消せることを確認する")]
        public void Cancelest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());
            //参加を取り消すメンバーのIDをリストにセット
            var idList = new List<string>();
            idList.Add("test02");
            idList.Add("test06");

            //Act
            //実行
            personHolder.Cancel(idList);

            ////Assert
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test01").FirstOrDefault().AttendFlag);
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test02").FirstOrDefault().AttendFlag);
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test03").FirstOrDefault().AttendFlag);
            //Assert.True(personHolder.Persons.Where(x => x.ID == "test04").FirstOrDefault().AttendFlag);
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test05").FirstOrDefault().AttendFlag);
            //Assert.False(personHolder.Persons.Where(x => x.ID == "test06").FirstOrDefault().AttendFlag);

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "削除されていないメンバーを取得できることを確認する")]
        public void GetAllPersonsTest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());

            //Act
            //実行
            var actual = personHolder.GetAll();

            //Assert
            Assert.Equal(PrepareData01().Where(x => x.DeleteFlag == false).Count(), actual.Count);

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "メンバーがいないときに空のリストを返すことを確認する")]
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
        [Fact(DisplayName = "参加フラグが立っているメンバーを取得できることを確認する")]
        public void GetAttendedPersonsTest01()
        {
            //Arrange
            //データの準備
            var personHolder = new PersonHolder(PrepareData01());

            //Act
            //実行
            var actual = personHolder.GetAttended();

            //Assert
            Assert.Equal(PrepareData01().Where(x => (x.DeleteFlag == false)&&(x.AttendFlag == true)).Count(), actual.Count);

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "メンバーがいないときに空のリストを返すことを確認する")]
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
