﻿using System;
using Xunit;
using Forest;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ForestTest
{
    public class PersonContextTest : IDisposable
    {
        string DirectoryName = "./forestTest01";

        /// <summary>
        /// 前処理として、テスト用のフォルダを作成する
        /// </summary>
        public PersonContextTest()
        {
            Directory.CreateDirectory(DirectoryName);
        }

        /// <summary>
        /// 後処理として、テスト用フォルダとテスト用DBファイルを削除する
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(DirectoryName, true);
            File.Delete("forest.db");

        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "引数なしコンストラクタを呼び出したときに例外が発生しないことを確認する")]
        public void ConstructorTest01()
        {
            //Arrange：特になし

            //Act
            var personContext = new PersonContext();

            //Assert：特になし
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "引数ありコンストラクタを呼び出したときに例外が発生しないことを確認する")]
        public void ConstructorTest02()
        {
            //Arrange
            using (var connection = new SqliteConnection("DataSource=:memory:"))
            {
                var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;

                //Act
                var personContext = new PersonContext(options);
                personContext.Database.EnsureCreated();
            }

            //Assert：特になし

        }

        [Trait("分類", "異常系")]
        [Fact(DisplayName = "設定情報が不適切である場合に例外を投げることを確認する")]
        public void ConstructorTest03()
        {
            //Arrange
            //存在しないディレクトリを指定

            using (var connection = new SqliteConnection("DataSource=/a/damy"))
            {
                var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;

                using (var personContext = new PersonContext(options))
                {
                    Assert.Throws<SqliteException>(() =>
                    { personContext.Database.EnsureCreated(); });
                }
            }


        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = " DBの設定を指定しなかったときに想定通りの場所にDBが作られていることを確認する")]
        public void ConstructorTest04()
        {
            //Arrange：特になし

            //Act
            //DBを作成
            var personContext = new PersonContext();
            personContext.Database.EnsureCreated();

            //Assert
            //現在の場所を取得
            var fullPath = Path.GetFullPath(".");
            //現在の場所にテスト用のDBが作られているかを確認
            Assert.True(File.Exists(fullPath + "/Forest.db"));
        }

        [Trait("分類", "正常系")]
        [Fact(DisplayName = "DBの設定を指定したときに指定通りの場所にDBが作られていることを確認する")]
        public void ConstructorTest05()
        {
            //Arrange
            //作成するDBの名前
            string dbName = "/test.db";

            //Act
            //DBを作成
            using (var connection = new SqliteConnection("DataSource=" + DirectoryName + dbName))
            {
                var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
                var personContext = new PersonContext(options);
                personContext.Database.EnsureCreated();
            }

            //Assert
            //指定場所に指定した名前のDBファイルがあるかを確認
            Assert.True(File.Exists(DirectoryName + dbName));

        }

    }
}
