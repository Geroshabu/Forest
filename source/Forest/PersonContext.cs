using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Forest
{
    public class PersonContext : DbContext
    {
        public PersonContext()
        { }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        { }

        /// <summary>
        /// ●DBのテーブルを定義している
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// ●DB作成のために必要なメソッド
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                var connectionString = new SqliteConnectionStringBuilder { DataSource = "forest.db" }.ToString();
                optionsBuilder.UseSqlite(new SqliteConnection(connectionString));
            }
        }

    }
}
