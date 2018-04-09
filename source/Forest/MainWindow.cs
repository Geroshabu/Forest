using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Forest
{
    public partial class MainWindow : Form
    {
        PersonContext Context;
        PersonHolder PersonHolder;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainWindowロードの際にDBからメンバー全員のデータを取得し、
        /// PersonHolderクラスに情報を保持しておく
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //DBに接続
            string dbName = "forest.db";
            var connection = new SqliteConnection("DataSource=" + dbName);
            connection.Open();
            var options = new DbContextOptionsBuilder<PersonContext>().UseSqlite(connection).Options;
            Context = new PersonContext(options);
            //DBが無ければ作る
            Context.Database.EnsureCreated();
            var personDbRepository = new PersonDbRepository(Context);

            //削除されているメンバーも含めてDBからサークルの全メンバーを取得
            var allPersons = new List<Person>();
            allPersons = personDbRepository.GetPersons();

            //PersonHolderを作って全メンバーを保持させる
            PersonHolder = new PersonHolder(allPersons);

            //サークルメンバーを表示
            var persons = PersonHolder.GetAllPersons();
            for (int i = 0; i < persons.Count; i++)
            {
                string[] row = { "false", persons[i].ID, persons[i].Name, persons[i].Gender.ToString(), persons[i].Level.ToString() };
                this.list01.Rows.Add(row);
            }

            //現在登録されている人数を表示
            label03.Text = persons.Count + "人 / 100人";

            //練習に参加しているメンバーを表示
            var attendedPersons = PersonHolder.GetAttendedPersons();
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                string[] row = { "false", attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender.ToString(), attendedPersons[i].Level.ToString() };
                this.list02.Rows.Add(row);
            }

            //ボタンの状態
            //→ボタン
            button01.Enabled = false;
            //←ボタン
            button02.Enabled = false;
            //追加ボタン
            if (persons.Count <= 100)
            {
                button03.Enabled = true;
            }
            //削除ボタン
            button04.Enabled = false;
            //変更ボタン
            button05.Enabled = false;
            //試合開始ボタン
            if (attendedPersons.Count == 0)
            {
                button06.Enabled = false;
            }


        }

        /// <summary>
        /// 「→」ボタンが押下された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAttendedPersons(object sender, EventArgs e)
        {
            //チェック状態を取得
            //IDを取得
            var id_list = new List<string>();
            for (int i = 0; i < PersonHolder.GetAllPersons().Count; i++)
            {
                if (Convert.ToBoolean(list01.Rows[i].Cells[0].Value) == true)
                {
                    string targetId = (string)list01.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを立てる処理を行う。
            PersonHolder.Attend(id_list);

            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttendedPersons();
            //list02は一度クリアする
            this.list02.Rows.Clear();
            //表示。今参加した人は選択状態にする
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                string check = "false";
                foreach (string targetId in id_list)
                {
                    if (attendedPersons[i].ID == targetId)
                    {
                        check = "true";
                    }
                }
                string[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender.ToString(), attendedPersons[i].Level.ToString() };
                this.list02.Rows.Add(row);
            }

            //試合開始ボタン
            if (attendedPersons.Count > 0)
            {
                button06.Enabled = true;
            }
            
            //→ボタン
            button01.Enabled = true;

            //←ボタン
            button02.Enabled = true;

            ButtonManager();

        }

        /// <summary>
        /// 「←」ボタンが押下されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAttendedPersons(object sender, EventArgs e)
        {
            //チェック状態を取得
            //IDを取得
            var id_list = new List<string>();
            for (int i = 0; i < PersonHolder.GetAttendedPersons().Count; i++)
            {
                if (Convert.ToBoolean(list02.Rows[i].Cells[0].Value) == true)
                {
                    string targetId = (string)list02.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを取り消す処理を行う。
            PersonHolder.Cancel(id_list);

            //参加メンバーを取得
            var allPersons = PersonHolder.GetAllPersons();
            //list01は一度クリアする
            this.list01.Rows.Clear();
            //表示。今取り消した人は選択状態にする
            for (int i = 0; i < allPersons.Count; i++)
            {
                string check = "false";
                foreach (string targetId in id_list)
                {
                    if (allPersons[i].ID == targetId)
                    {
                        check = "true";
                    }
                }
                string[] row = { check, allPersons[i].ID, allPersons[i].Name, allPersons[i].Gender.ToString(), allPersons[i].Level.ToString() };
                this.list01.Rows.Add(row);
            }


            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttendedPersons();
            //list02は一度クリアする
            this.list02.Rows.Clear();
            //表示
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                string check = "false";
                string[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender.ToString(), attendedPersons[i].Level.ToString() };
                this.list02.Rows.Add(row);
            }

            //試合開始ボタン
            if (attendedPersons.Count == 0)
            {
                button06.Enabled = false;
            }

            //→ボタン
            button01.Enabled = true;

            //←ボタン
            button02.Enabled = false;

            ButtonManager();

        }

        /// <summary>
        /// List01(サークルメンバーのリスト)が操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageBelongedPersonList(object sender, DataGridViewCellMouseEventArgs e)
        {
            //→ボタン
            button01.Enabled = false;
            //削除ボタン
            button04.Enabled = false;
            //変更ボタン
            button05.Enabled = false;

            //PersonHolderがnullの時（初回起動のとき）はそのまま返す
            if (PersonHolder == null)
            {
                return;
            }

            //チェック列以外がクリックされても何も起きない
            if (e.ColumnIndex != 0) { return; }

            //チェックされていた部分が選択されれば、チェック
            //チェックされていなかった部分が選択されればチェックを外す
            if (list01.CurrentRow.Cells[0].Value.ToString() == "true")
            {
                list01.CurrentRow.Cells[0].Value = "false";
            }
            else
            {
                list01.CurrentRow.Cells[0].Value = "true";
            }
            
            ButtonManager();
        }

        /// <summary>
        /// List02(参加者リスト)が操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageAttendedPersonList(object sender, DataGridViewCellMouseEventArgs e)
        {
            //PersonHolderがnullの時（初回起動のとき）はそのまま返す
            if (PersonHolder == null)
            {
                return;
            }

            //チェック列以外がクリックされても何も起きない
            if (e.ColumnIndex != 0) { return; }

            //チェックされていた部分が選択されれば、チェック
            //チェックされていなかった部分が選択されればチェックを外す
            if (list01.CurrentRow.Cells[0].Value.ToString() == "true")
            {
                list01.CurrentRow.Cells[0].Value = "false";
            }
            else
            {
                list01.CurrentRow.Cells[0].Value = "true";
                //ひとつでもtrueになれば「←」ボタンが押下できるようになる
                button02.Enabled = true;
            }

        }

        /// <summary>
        /// ボタンの活性・非活性の切り替えをする
        /// </summary>
        public void ButtonManager()
        {
            //チェックが入っている個数を数える
            int count = 0;
            string targetId = "";
            for (int i = 0; i < PersonHolder.GetAllPersons().Count; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(list01.Rows[i].Cells[0].Value) == true)
                {
                    count++;
                    //trueの時のIDを保管しておく
                    targetId = (string)list01.Rows[i].Cells[1].Value;
                }
            }

            //trueがひとつだけであれば「変更」ボタンも押せるようになる
            if (count == 1)
            {
                button05.Enabled = true;

            }

            //trueが複数あれば「削除」「→」ボタンも押せるようになる
            if (count >= 1)
            {
                button01.Enabled = true;
                button04.Enabled = true;
            }

        }
    }
}
