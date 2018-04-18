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

            //表示する
            DisplayMainWindow();
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
            var idList = new List<string>();
            for (int i = 0; i < PersonHolder.GetAll().Count; i++)
            {
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)allMemberList.Rows[i].Cells[1].Value;
                    idList.Add(targetId);
                }
            }

            //参加フラグを立てる処理を行う。
            PersonHolder.Attend(idList);

            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttended();

            //list02は一度クリアする
            this.attendMemberList.Rows.Clear();
            //表示。今参加した人は選択状態にする
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                bool check = false;
                foreach (string targetId in idList)
                {
                    if (attendedPersons[i].ID == targetId)
                    {
                        check = true;
                    }
                }
                object[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender, attendedPersons[i].Level };
                this.attendMemberList.Rows.Add(row);
            }

            //現在の条件でソートを行う
            SortByCurrentSetting(attendMemberList, attendMemberList.SortedColumn.Name);

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
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)attendMemberList.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを取り消す処理を行う。
            PersonHolder.Cancel(id_list);

            //参加メンバーを取得
            var allPersons = PersonHolder.GetAll();
            //list01は一度クリアする
            this.allMemberList.Rows.Clear();
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
                this.allMemberList.Rows.Add(row);
            }

            //参加メンバーを取得
            var attendedPersons = PersonHolder.GetAttended();
            //list02は一度クリアする
            this.attendMemberList.Rows.Clear();
            //表示
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                bool check = false;
                object[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender, attendedPersons[i].Level };
                this.attendMemberList.Rows.Add(row);
            }

            //現在の条件でソートを行う
            SortByCurrentSetting(allMemberList, allMemberList.SortedColumn.Name);
            SortByCurrentSetting(attendMemberList, attendMemberList.SortedColumn.Name);

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
            if (Convert.ToBoolean(allMemberList.CurrentRow.Cells[0].Value) == true)
            {
                allMemberList.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                allMemberList.CurrentRow.Cells[0].Value = true;
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
            if (Convert.ToBoolean(attendMemberList.CurrentRow.Cells[0].Value) == true)
            {
                attendMemberList.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                attendMemberList.CurrentRow.Cells[0].Value = true;
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
            attendButton.Enabled = false;
            //←ボタン
            attendCancelButton.Enabled = false;
            //追加ボタン
            if (allMemberList.RowCount < 100)
            {
                addButton.Enabled = true;
            }
            else
            {
                addButton.Enabled = false;
            }
            //削除ボタン
            deleteButton.Enabled = false;
            //変更ボタン
            updateButton.Enabled = false;
            //試合開始ボタン
            if (attendMemberList.RowCount <= 1)
            {
                startButton.Enabled = false;
            }
            else
            {
                startButton.Enabled = true;
            }

            //List01のチェックが入っている個数を数える
            int count1 = 0;
            for (int i = 0; i < allMemberList.RowCount; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    count1++;
                }
            }

            //trueがひとつだけであれば「変更」ボタンも押せるようになる
            if (count1 == 1)
            {
                updateButton.Enabled = true;

            }

            //trueが複数あれば「削除」「→」ボタンも押せるようになる
            if (count1 >= 1)
            {
                attendButton.Enabled = true;
                deleteButton.Enabled = true;
            }

            //List02のチェックが入っている個数を数える
            int count2 = 0;
            for (int i = 0; i < attendMemberList.RowCount; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    count2++;
                }
            }
            //trueが複数あれば「←」ボタンも押せるようになる
            if (count2 >= 1)
            {
                attendCancelButton.Enabled = true;
            }

        }

        /// <summary>
        /// ソートをするときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void allMemberList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            object obj1 = e.CellValue1;
            object obj2 = e.CellValue2;

            switch (obj1)
            {
                case string name:
                    e.SortResult = name.CompareTo(obj2 as string);
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
        private void addButton_Click(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm(PersonRepository, null))
            {
                //オーナーウィンドウにthisを指定し、imputFormをモーダルダイアログとして表示
                inputForm.ShowDialog(this);
            }

            //サークルの削除されていない全メンバーを取得
            var allPersons = PersonRepository.GetAll();

            //PersonHolderを作ってメンバーを保持させる
            PersonHolder = new PersonHolder(allPersons);

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();

            DisplayMainWindow();
        }

        private void DisplayMainWindow()
        {
            //サークルメンバーを表示
            var persons = PersonHolder.GetAll();
            foreach (Person person in persons)
            {
                object[] row = { false, person.ID, person.Name, person.Gender, person.Level };
                this.allMemberList.Rows.Add(row);
            }

            //現在登録されている人数を表示
            memberCountLabel.Text = allMemberList.RowCount + "人 / 100人";

            //練習に参加しているメンバーを表示
            var attendedPersons = PersonHolder.GetAttended();
            foreach (Person person in attendedPersons)
            {
                object[] row = { false, person.ID, person.Name, person.Gender, person.Level };
                this.attendMemberList.Rows.Add(row);
            }

            //現在の条件でソートを行う
            var currentSettingInAllMemberList = allMemberList.SortedColumn;
            if (currentSettingInAllMemberList == null)
            {
                SortByCurrentSetting(allMemberList, "allMemberListName");
            }
            else
            {
                SortByCurrentSetting(allMemberList, currentSettingInAllMemberList.Name);
            }

            var currentSettingInAttendMemberList = attendMemberList.SortedColumn;
            if (currentSettingInAttendMemberList == null)
            {
                SortByCurrentSetting(attendMemberList, "attendMemberListName");
            }
            else
            {
                SortByCurrentSetting(attendMemberList, currentSettingInAttendMemberList.Name);
            }

            ManageButton();

        }

        void SortByCurrentSetting(DataGridView targetList, string currentSetting)
        {
            //自動的に並び替えられるようにする
            foreach (DataGridViewColumn c in targetList.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            //並び替える列を決める
            DataGridViewColumn sortColumn = targetList.Columns[currentSetting];
            //リストの初期ソートの方向は昇順
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            //並び替えを行う
            targetList.Sort(sortColumn, sortDirection);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            string id = "";

            //チェックが入っているPersonを探す
            for (int i = 0; i < allMemberList.RowCount; i++)
            {
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    id = (string)allMemberList.Rows[i].Cells[1].Value;
                    break;
                }
            }

            foreach (Person target in PersonHolder.GetAll())
            {
                if(target.ID == id)
                {
                    person = target;
                    break;
                }
            }

            using (InputForm inputForm = new InputForm(PersonRepository, person))
            {
                //オーナーウィンドウにthisを指定し、imputFormをモーダルダイアログとして表示
                inputForm.ShowDialog(this);
            }

            //サークルの削除されていない全メンバーを取得
            var allPersons = PersonRepository.GetAll();

            //PersonHolderを作ってメンバーを保持させる
            PersonHolder = new PersonHolder(allPersons);

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();

            DisplayMainWindow();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var deletePersons = new List<Person>();
            var person = new Person();
            var idList = new List<String>();
            string id = "";

            //チェックが入っているPersonを探す
            for (int i = 0; i < allMemberList.RowCount; i++)
            {
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    id = (string)allMemberList.Rows[i].Cells[1].Value;
                    idList.Add(id);
                }
            }

            foreach (Person target in PersonHolder.GetAll())
            {
                foreach(string targetId in idList)
                {
                    if (target.ID == targetId)
                    {
                        person = target;
                        deletePersons.Add(person);
                    }
                }
            }

            using (DeleteCheckDialog deletecheckDialog = new DeleteCheckDialog(PersonRepository,deletePersons))
            {
                //オーナーウィンドウにthisを指定し、削除確認画面をモーダルダイアログとして表示
                deletecheckDialog.ShowDialog(this);
            }

            //サークルの削除されていない全メンバーを取得
            var allPersons = PersonRepository.GetAll();

            //PersonHolderを作ってメンバーを保持させる
            PersonHolder = new PersonHolder(allPersons);

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();

            DisplayMainWindow();

        }
    }
}
