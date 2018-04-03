using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Forest
{
    public class PersonContext : DbContext
    {
        /// <summary>
        /// DBの設定を指定せずに初期化する
        /// ForestTest.pdb という名前のファイルが作られる
        /// </summary>
        public PersonContext()
        { }

        /// <summary>
        /// 呼び出し元からDBの設定を指定して初期化する
        /// </summary>
        /// <param name="options">DBの設定</param>
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        { }

        /// <summary>
        /// DBのデータ
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// DBの設定がされていなかったら設定をする
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new SqliteConnectionStringBuilder { DataSource = "forest.db" }.ToString();
                optionsBuilder.UseSqlite(new SqliteConnection(connectionString));
            }
        }

    }
}
