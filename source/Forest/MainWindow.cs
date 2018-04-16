using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Forest
{
    public partial class MainWindow : Form
    {
        PersonHolder PersonHolder;
        IPersonRepository PersonRepository;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainWindowロードの際にメンバー全員のデータを取得し、
        /// PersonHolderクラスに情報を保持しておく
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainWindow_Load(object sender, EventArgs e)
        {
            PersonRepository = new PersonDbRepository();

            //サークルの削除されていない全メンバーを取得
            var allPersons = PersonRepository.GetAll();

            //PersonHolderを作ってメンバーを保持させる
            PersonHolder = new PersonHolder(allPersons);


            //自動的に並び替えられるようにする
            foreach (DataGridViewColumn c in list01.Columns)
                c.SortMode = DataGridViewColumnSortMode.Automatic;
            foreach (DataGridViewColumn c in list02.Columns)
                c.SortMode = DataGridViewColumnSortMode.Automatic;


            //サークルメンバーを表示
            var persons = PersonHolder.GetAll();
            foreach(Person person in persons)
            {
                object[] row = { false, person.ID, person.Name, person.Gender, person.Level };
                this.list01.Rows.Add(row);
            }

            //現在登録されている人数を表示
            label03.Text = persons.Count + "人 / 100人";

            //練習に参加しているメンバーを表示
            var attendedPersons = PersonHolder.GetAttended();
            foreach (Person person in attendedPersons)
            {
                object[] row = { false, person.ID, person.Name, person.Gender, person.Level };
                this.list02.Rows.Add(row);
            }


            //並び替える列を決める
            DataGridViewColumn sortColumn1 = list01.Columns["List01Name"];
            DataGridViewColumn sortColumn2 = list02.Columns["List02Name"];

            //並び替えの方向（昇順か降順か）を決める
            ListSortDirection sortDirection1 = ListSortDirection.Ascending;
            if (list01.SortedColumn != null &&
                list01.SortedColumn.Equals(sortColumn1))
            {
                sortDirection1 =
                    list01.SortOrder == SortOrder.Ascending ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            ListSortDirection sortDirection2 = ListSortDirection.Ascending;
            if (list02.SortedColumn != null &&
                list02.SortedColumn.Equals(sortColumn2))
            {
                sortDirection2 =
                    list02.SortOrder == SortOrder.Ascending ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
            }

            //並び替えを行う
            list01.Sort(sortColumn1, sortDirection1);
            list02.Sort(sortColumn2, sortDirection2);

            ManageButton();

        }

        /// <summary>
        /// 「→」ボタンが押下された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddAttendedPersons(object sender, EventArgs e)
        {
            //チェック状態を取得
            //IDを取得
            var id_list = new List<string>();
            for (int i = 0; i < PersonHolder.GetAll().Count; i++)
            {
                if (Convert.ToBoolean(list01.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)list01.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを立てる処理を行う。
            PersonHolder.Attend(id_list);

            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttended();
            //list02は一度クリアする
            this.list02.Rows.Clear();
            //表示。今参加した人は選択状態にする
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                bool check = false;
                foreach (string targetId in id_list)
                {
                    if (attendedPersons[i].ID == targetId)
                    {
                        check = true;
                    }
                }
                object[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender, attendedPersons[i].Level };
                this.list02.Rows.Add(row);
            }

            ManageButton();

        }

        /// <summary>
        /// 「←」ボタンが押下されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteAttendedPersons(object sender, EventArgs e)
        {
            //チェック状態を取得
            //IDを取得
            var id_list = new List<string>();
            for (int i = 0; i < PersonHolder.GetAttended().Count; i++)
            {
                if (Convert.ToBoolean(list02.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)list02.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを取り消す処理を行う。
            PersonHolder.Cancel(id_list);

            //参加メンバーを取得
            var allPersons = PersonHolder.GetAll();
            //list01は一度クリアする
            this.list01.Rows.Clear();
            //表示。今取り消した人は選択状態にする
            for (int i = 0; i < allPersons.Count; i++)
            {
                bool check = false;
                foreach (string targetId in id_list)
                {
                    if (allPersons[i].ID == targetId)
                    {
                        check = true;
                    }
                }
                object[] row = { check, allPersons[i].ID, allPersons[i].Name, allPersons[i].Gender, allPersons[i].Level };
                this.list01.Rows.Add(row);
            }


            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttended();
            //list02は一度クリアする
            this.list02.Rows.Clear();
            //表示
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                bool check = false;
                object[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender, attendedPersons[i].Level };
                this.list02.Rows.Add(row);
            }

            ManageButton();

        }

        /// <summary>
        /// List01(サークルメンバーのリスト)が操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ManageBelongedPersonList(object sender, DataGridViewCellMouseEventArgs e)
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
            if (Convert.ToBoolean(list01.CurrentRow.Cells[0].Value) == true)
            {
                list01.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                list01.CurrentRow.Cells[0].Value = true;
            }

            ManageButton();
        }

        /// <summary>
        /// List02(参加者リスト)が操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ManageAttendedPersonList(object sender, DataGridViewCellMouseEventArgs e)
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
            if (Convert.ToBoolean(list02.CurrentRow.Cells[0].Value) == true)
            {
                list02.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                list02.CurrentRow.Cells[0].Value = true;
            }

            ManageButton();

        }

        /// <summary>
        /// ボタンの活性・非活性の切り替えをする
        /// </summary>
        public void ManageButton()
        {
            //ボタンの状態（デフォルト）
            //→ボタン
            button01.Enabled = false;
            //←ボタン
            button02.Enabled = false;
            //追加ボタン
            if (PersonHolder.GetAll().Count < 100)
            {
                button03.Enabled = true;
            }
            //削除ボタン
            button04.Enabled = false;
            //変更ボタン
            button05.Enabled = false;
            //試合開始ボタン
            if (PersonHolder.GetAttended().Count <= 1)
            {
                button06.Enabled = false;
            }

            //List01のチェックが入っている個数を数える
            int count1 = 0;
            string targetId1 = "";
            for (int i = 0; i < PersonHolder.GetAll().Count; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(list01.Rows[i].Cells[0].Value))
                {
                    count1++;
                    //trueの時のIDを保管しておく
                    targetId1 = (string)list01.Rows[i].Cells[1].Value;
                }
            }

            //trueがひとつだけであれば「変更」ボタンも押せるようになる
            if (count1 == 1)
            {
                button05.Enabled = true;

            }

            //trueが複数あれば「削除」「→」ボタンも押せるようになる
            if (count1 >= 1)
            {
                button01.Enabled = true;
                button04.Enabled = true;
            }

            //List02のチェックが入っている個数を数える
            int count2 = 0;
            string targetId2 = "";
            for (int i = 0; i < PersonHolder.GetAttended().Count; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(list02.Rows[i].Cells[0].Value))
                {
                    count2++;
                    //trueの時のIDを保管しておく
                    targetId2 = (string)list02.Rows[i].Cells[1].Value;
                }
            }
            //trueが複数あれば「←」ボタンも押せるようになる
            if (count2 >= 1)
            {
                button02.Enabled = true;
            }

        }

        /// <summary>
        /// ソートをするときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void list01_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            object obj1 = e.CellValue1;
            object obj2 = e.CellValue2;

            switch (obj1)
            {
                case string name:
                    e.SortResult  = name.CompareTo(obj2 as string);
                    break;
                case Gender gender:
                    e.SortResult = gender.CompareTo(obj2 as Gender);
                    break;
                case Level level:
                    e.SortResult = level.CompareTo(obj2 as Level);
                    break;
            }

            //処理したことを知らせる
            e.Handled = true;

        }

        /// <summary>
        /// 追加ボタンを押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button03_Click(object sender, EventArgs e)
        {
            //using(InputForm inputForm = new InputForm(PersonRepository))
            //{
            //    //Form2を表示する
            //    //ここではモーダルダイアログボックスとして表示する
            //    //オーナーウィンドウにthisを指定する
            //    inputForm.ShowDialog(this);
            //}

            //Listとラベルだけ更新する処理
            //→メソッドにする
        }

    }
}
