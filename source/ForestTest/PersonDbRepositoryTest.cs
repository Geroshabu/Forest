using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Forest;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ForestTest
{
    public class PersonDbRepositoryTest : IDisposable
    {
        //作成するフォルダの名前
        string DirectoryName = "./forestTest02";

        PersonContext Context;

        /// <summary>
        /// テストの前処理
        /// ・テスト用フォルダの作成
        /// ・テスト用DBの作成
        /// </summary>
        public PersonDbRepositoryTest()
        {
            //テスト用フォルダの作成
            Directory.CreateDirectory(DirectoryName);

            //作成するDBの名前
            string dbName = "/test.db";
            //テスト用DBを作成
            var connection = new SqliteConnection("DataSource=" + DirectoryName + dbName);
            connection.Open();
            var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
            Context = new PersonContext(options);
            Context.Database.EnsureCreated();
            connection.Close();

        }

        /// <summary>
        /// テストの後処理
        /// ・テスト用フォルダの削除
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(DirectoryName, true);
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "正常に登録できることを確認する")]
        public void AddTest01()
        {
            using (Context)
            {
                //Arrange
                //登録するデータの準備
                var testPerson = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };

                //Act
                //登録の実行
                var personDbRepository = new PersonDbRepository(Context);
                var actual = personDbRepository.Add(testPerson);

                //Assert
                //登録できていればtrueが返る
                Assert.True(actual);
                //DBの中身も確認
                Assert.Equal(1, Context.Persons.Count());
                Assert.Equal(testPerson, Context.Persons.Single());

            }
        }

        [Trait("分類", "異常系")]
        [Fact(DisplayName = "すでに登録されているIDは登録できないことを確認する")]
        public void AddTest02()
        {
            using (Context)
            {
                //Arrange
                //登録するデータの準備
                //同じIDのデータを二つ用意する
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };
                var testPerson02 = new Person
                {
                    ID = "test01",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = false,
                    AttendFlag = true
                };

                //Act
                //データ登録の実行
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson01);
                var actual02 = personDbRepository.Add(testPerson02);

                //Assert
                //登録できないのでfalseが返る
                Assert.False(actual02);
                //DBの中身も確認（testPerson01のみが登録されている）
                Assert.Equal(1, Context.Persons.Count());
                Assert.Equal(testPerson01, Context.Persons.Single());

            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "正常に削除できることを確認する")]
        // （正常な削除 → 削除フラグを立てる、削除件数を返す）
        public void DeleteTest01()
        {
            using (Context)
            {
                //Arrange
                //削除するデータの準備
                var testPerson = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };

                //削除リストに追加
                var testPersons = new List<Person>();
                testPersons.Add(testPerson);

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson);

                //Act
                //削除の実行
                int actual = personDbRepository.Delete(testPersons);

                //Assert
                //削除フラグが立っているかどうか
                Assert.True(Context.Persons.Single().DeleteFlag);
                //削除件数が返っているかどうか
                int expected = 1;
                Assert.Equal(expected, actual);

            }
        }

        [Trait("分類", "異常系")]
        [Fact(DisplayName = "対応するIDの人がいないときはそれまでに削除した件数が返ることを確認する")]
        public void DeleteTest02()
        {
            using (Context)
            {
                //Arrange
                //削除するデータの準備
                //データを二つ用意する
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };
                var testPerson02 = new Person
                {
                    ID = "test02",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = false,
                    AttendFlag = true
                };

                //test01のみ削除リストに追加
                var testPersons = new List<Person>();
                testPersons.Add(testPerson01);

                //test02のみDBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson02);

                //Act
                //削除の実行
                int actual = personDbRepository.Delete(testPersons);

                //Assert
                //-1が返っているかどうか
                int expected = 0;
                Assert.Equal(expected, actual);

            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "すでに削除されているときの動作を確認する")]
        // （正常な動作 → 削除フラグが立ったまま、削除件数を増やす）
        public void DeleteTest03()
        {
            using (Context)
            {
                //Arrange
                //削除するデータの準備
                var testPerson = new Person
                {
                    ID = "test03",
                    Name = "andy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 1 },
                    DeleteFlag = true,
                    AttendFlag = false
                };

                //削除リストに追加
                var testPersons = new List<Person>();
                testPersons.Add(testPerson);

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson);

                //Act
                //削除の実行
                int actual = personDbRepository.Delete(testPersons);

                //Assert
                //削除フラグが立っているかどうか
                Assert.True(Context.Persons.Single().DeleteFlag);
                //削除件数が返っているかどうか
                int expected = 1;
                Assert.Equal(expected, actual);
            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "DBに一件も登録されていないときに登録件数0が返ることを確認する")]
        public void GetAllCountTest01()
        {
            using (Context)
            {
                //Arrange：なにもしない

                //Act
                //DBから取得
                var personDbRepository = new PersonDbRepository(Context);
                var actual = personDbRepository.GetAllCount();

                //Assert
                var expected = new List<Person>().Count;
                Assert.Equal(expected, actual);
            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "DBの全データ件数を正常に取得できることを確認する")]
        public void GetAllCountTest02()
        {
            using (Context)
            {
                //Arrange
                //登録するデータの準備
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };
                var testPerson02 = new Person
                {
                    ID = "test02",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = false,
                    AttendFlag = true
                };

                //登録するデータをリストに入れる
                List<Person> expected = new List<Person>
                {
                    testPerson01,
                    testPerson02
                };
                var expectedCount = expected.Count;

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson01);
                personDbRepository.Add(testPerson02);

                //Act
                //DBから取得
                var actual = personDbRepository.GetAllCount();

                //Assert
                Assert.Equal(expectedCount, actual);
            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "DBの削除されていないデータを正常に取得できることを確認する")]
        public void GetTest01()
        {
            using (Context)
            {
                //Arrange
                //登録するデータの準備
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };
                var testPerson02 = new Person
                {
                    ID = "test02",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = true,
                    AttendFlag = true
                };

                //登録するデータをリストに入れる
                List<Person> expected = new List<Person>
                {
                    testPerson01
                };

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson01);
                personDbRepository.Add(testPerson02);

                //Act
                //DBから取得
                var actual = personDbRepository.Get();

                //Assert
                Assert.Empty(expected.Except(actual));
                Assert.Empty(actual.Except(expected));
            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "正常にデータの変更が行えることを確認する")]
        public void UpdateTest01()
        {
            using (Context)
            {
                //Arrange
                //変更するデータの準備
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };
                var testPerson02 = new Person
                {
                    ID = "test01",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = false,
                    AttendFlag = true
                };

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson01);

                //Act
                //testPerson01→testPerson02の内容への変更を実行
                var actual = personDbRepository.Update(testPerson02);

                //Assert
                //変更できていればtrueが返る
                Assert.True(actual);
                //DBの中身も確認
                Assert.Equal(1, Context.Persons.Count());
                Assert.Equal(testPerson02.Name, Context.Persons.Single().Name);
                Assert.Equal(testPerson02.Gender, Context.Persons.Single().Gender);
                Assert.Equal(testPerson02.Level, Context.Persons.Single().Level);
                Assert.Equal(testPerson02.DeleteFlag, Context.Persons.Single().DeleteFlag);
                Assert.Equal(testPerson02.AttendFlag, Context.Persons.Single().AttendFlag);

            }
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "対応するIDが存在しなかったときに変更が行えないことを確認する")]
        public void UpdateTest02()
        {
            using (Context)
            {
                //Arrange
                //変更するデータの準備
                var testPerson01 = new Person
                {
                    ID = "test01",
                    Name = "snoopy",
                    Gender = new Gender { GenderNum = 0 },
                    Level = new Level { LevelNum = 2 },
                    DeleteFlag = false,
                    AttendFlag = false
                };

                //変更データと異なるIDにする
                var testPerson02 = new Person
                {
                    ID = "test02",
                    Name = "bell",
                    Gender = new Gender { GenderNum = 1 },
                    Level = new Level { LevelNum = 0 },
                    DeleteFlag = false,
                    AttendFlag = true
                };

                //DBに登録
                var personDbRepository = new PersonDbRepository(Context);
                personDbRepository.Add(testPerson01);

                //Act
                //testPerson01→testPerson02の内容への変更を実行
                var actual = personDbRepository.Update(testPerson02);

                //Assert
                //変更できないのでfalseが返る
                Assert.False(actual);
                //DBの中身も確認
                Assert.Equal(1, Context.Persons.Count());
                Assert.Equal(testPerson01, Context.Persons.Single());
            }
        }

    }
}