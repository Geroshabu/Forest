using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Forest;
using System.Linq;

namespace ForestTest
{
    public class PersonDbRepositoryTest
    {
        [Fact]
        public void TestMethod1()
        {
            Assert.Equal(1,1);
        }

        [Fact]
        public void Test()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;

                using (var context = new PersonContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using(var context = new PersonContext(options))
                {
                    var personDbRepository = new PersonDbRepository(context);

                    var testPerson = new Person();

                    var men = new Gender();
                    men.GenderNum = 0;

                    var pro = new Level();
                    pro.LevelNum = 2;

                    testPerson.ID = "test01";
                    testPerson.Name = "snoopy";
                    testPerson.Gender = men;
                    testPerson.Level = pro;
                    testPerson.DeleteFlag = false;
                    testPerson.AttendFlag = false;

                    personDbRepository.AddPerson(testPerson);

                }

                using (var context = new PersonContext(options))
                {
                    //一件登録されているかどうか
                    Assert.Equal(1,context.Persons.Count());
                    Assert.Equal("test01", context.Persons.Single().ID);//singleかfirst
                }


            }
            finally
            {
                connection.Close();
            }
        }

    }
}
