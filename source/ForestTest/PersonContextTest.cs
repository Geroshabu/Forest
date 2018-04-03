using System;
using Xunit;
using Forest;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ForestTest
{
    public class PersonContextTest : IDisposable
    {
        string DirectoryName = "./forestTest";

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
            File.Delete("./ForestTest.pdb");
        }

        /// <summary>
        /// 引数なしコンストラクタを呼び出したときに例外が発生しないことを確認するテスト
        /// </summary>
        [Fact]
        public void ConstructorTest01()
        {
            var personContext = new PersonContext();
        }

        /// <summary>
        /// 引数ありコンストラクタを呼び出したときに例外が発生しないことを確認するテスト
        /// </summary>
        [Fact]
        public void ConstructorTest02()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
            var personContext = new PersonContext(options);

        }

        /// <summary>
        /// 引数ありコンストラクタに渡された設定情報が不適切である場合に
        /// SqliteExceptionを投げることを確認するテスト
        /// </summary>
        [Fact]
        public void ConstructorTest03()
        {
            Assert.Throws<SqliteException>(delegate
            {
                //存在しないディレクトリを指定
                var connection = new SqliteConnection("DataSource=/a/damy");
                connection.Open();
                var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
                var personContext = new PersonContext(options);
            });

        }

        /// <summary>
        /// DBの設定を指定しなかったときに想定通りの場所にDBが作られていることを確認するテスト
        /// </summary>
        [Fact]
        public void ConstructorTest04()
        {
            //DBを作成
            var personContext = new PersonContext();
            //現在の場所を取得
            var fullPath = Path.GetFullPath(".");
            //現在の場所にテスト用のDBが作られているかを確認
            Assert.True(File.Exists(fullPath + "/ForestTest.pdb"));
        }

        /// <summary>
        /// DBの設定を指定したときに指定通りの場所にDBが作られていることを確認するテスト
        /// </summary>
        [Fact]
        public void ConstructorTest05()
        {
            //作成するDBの名前
            string dbName = "/test.db";

            //DBを作成
            var connection = new SqliteConnection("DataSource=" + DirectoryName + dbName);
            connection.Open();
            var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
            var personContext = new PersonContext(options);
            connection.Close();

            //指定場所に指定した名前のDBファイルがあるかを確認
            Assert.True(File.Exists(DirectoryName + dbName));

        }

    }
}
