﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Forest
{
    public partial class MainWindow : Form
    {

        private PersonHolder personHolder;
        private IPersonRepository personRepository;

        private GameRecorder gameRecorder;
        private IGameGeneratorFactory gameGeneratorFactory;

        /// <summary>
        /// コンストラクタでgameRecorderとgameGeneratorFactoryをセット
        /// </summary>
        /// </param name="gameGeneratorFactory">gameGeneratorのファクトリー</param>
        public MainWindow(IGameGeneratorFactory gameGeneratorFactory)
        {
            InitializeComponent();
            this.gameGeneratorFactory = gameGeneratorFactory;
            gameRecorder = GameRecorder.GetInstance;
        }

        /// <summary>
        /// MainWindowロードの際にメンバー全員のデータを取得し、
        /// PersonHolderクラスに情報を保持しておく
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadMainWindow(object sender, EventArgs e)
        {
            personRepository = new PersonDbRepository();

            //サークルの削除されていない全メンバーを取得
            var allPersons = personRepository.Get();

            if (personHolder == null)
            {
                //PersonHolderを作ってメンバーを保持させる
                personHolder = new PersonHolder(allPersons);
            }

            //組み合わせ決定アルゴリズムの初期値は完全ランダム
            generateSettingComboBox.SelectedIndex = 0;

            //表示する
            DisplayMainWindow(new List<Person>(), new List<Person>());
        }

        /// <summary>
        /// 「→」ボタンが押下された時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAttendedPersons(object sender, EventArgs e)
        {
            //チェック状態を取得
            //IDを取得
            var idList = new List<string>();
            for (int i = 0; i < personHolder.GetAll().Count; i++)
            {
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)allMemberList.Rows[i].Cells[1].Value;
                    idList.Add(targetId);
                }
            }

            //参加フラグを立てる処理を行う。
            personHolder.Attend(idList);

            //参加メンバーを取得
            var attendedPersons = personHolder.GetAttended();

            //参加者リストを一度クリアする
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

            //現在選択されている条件でソートを行う
            SortByCurrentSetting(attendMemberList);

            //ボタンの制御を行う
            ManageButton();

        }

        /// <summary>
        /// 「←」ボタンが押下されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAttendedPersons(object sender, EventArgs e)
        {
            //チェックされている人のIDを取得
            var id_list = new List<string>();
            for (int i = 0; i < personHolder.GetAttended().Count; i++)
            {
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    string targetId = (string)attendMemberList.Rows[i].Cells[1].Value;
                    id_list.Add(targetId);
                }
            }

            //参加フラグを取り消す処理を行う。
            personHolder.Cancel(id_list);

            //全メンバーを取得
            var allPersons = personHolder.GetAll();
            //全メンバーのリストは一度クリアする
            this.allMemberList.Rows.Clear();
            //表示。今、参加を取り消した人は選択状態にする
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
            var attendedPersons = personHolder.GetAttended();
            //参加者のリストは一度クリアする
            this.attendMemberList.Rows.Clear();
            //表示
            for (int i = 0; i < attendedPersons.Count; i++)
            {
                bool check = false;
                object[] row = { check, attendedPersons[i].ID, attendedPersons[i].Name, attendedPersons[i].Gender, attendedPersons[i].Level };
                this.attendMemberList.Rows.Add(row);
            }

            //現在の条件でソートを行う
            SortByCurrentSetting(allMemberList);
            SortByCurrentSetting(attendMemberList);

            //ボタンの制御を行う
            ManageButton();

        }

        /// <summary>
        /// サークルメンバーのリストが操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageAllMemberList(object sender, DataGridViewCellMouseEventArgs e)
        {
            //リストの制御をする
            Managelist(allMemberList, e);
            //ボタンの制御を行う
            ManageButton();
        }

        /// <summary>
        /// 参加者リストが操作されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageAttendMemberList(object sender, DataGridViewCellMouseEventArgs e)
        {
            //リストの制御をする
            Managelist(attendMemberList, e);
            //ボタンの制御を行う
            ManageButton();

        }

        /// <summary>
        /// リストのチェック状態の切り替えをする
        /// </summary>
        /// <param name="targetList">切り替え対象のリスト</param>
        /// <param name="e">マウスのイベントのデータ</param>
        private void Managelist(DataGridView targetList, DataGridViewCellMouseEventArgs e)
        {
            //PersonHolderがnullの時（初回起動のとき）はそのまま返す
            if (personHolder == null)
            {
                return;
            }

            //チェック列以外とヘッダーがクリックされても何も起きない
            if (e.ColumnIndex != 0　|| e.RowIndex == -1 ) { return; }

            //チェックされていた部分が選択されれば、チェック
            //チェックされていなかった部分が選択されればチェックを外す
            if (Convert.ToBoolean(targetList.CurrentRow.Cells[0].Value) == true)
            {
                targetList.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                targetList.CurrentRow.Cells[0].Value = true;
            }

        }

        /// <summary>
        /// ボタンの活性・非活性の切り替えをする
        /// </summary>
        private void ManageButton()
        {
            //ボタンの状態（デフォルト）
            //→ボタン
            attendButton.Enabled = false;
            //←ボタン
            attendCancelButton.Enabled = false;
            //追加ボタン
            addButton.Enabled = true;
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

            //全メンバーのリストにチェックが入っている個数を数える
            int checkCountInAllMemberList = 0;
            for (int i = 0; i < allMemberList.RowCount; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    checkCountInAllMemberList++;
                }
            }

            //trueがひとつだけであれば「変更」ボタンも押せるようになる
            if (checkCountInAllMemberList == 1)
            {
                updateButton.Enabled = true;

            }

            //trueが複数あれば「削除」「→」ボタンも押せるようになる
            if (checkCountInAllMemberList >= 1)
            {
                attendButton.Enabled = true;
                deleteButton.Enabled = true;
            }

            //参加メンバーのリストのチェックが入っている個数を数える
            int checkCountInAttendMemberList = 0;
            for (int i = 0; i < attendMemberList.RowCount; i++)
            {
                //trueの数を数える
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    checkCountInAttendMemberList++;
                }
            }
            //trueが複数あれば「←」ボタンも押せるようになる
            if (checkCountInAttendMemberList >= 1)
            {
                attendCancelButton.Enabled = true;
            }

        }

        /// <summary>
        /// リストをソートをするときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberListSortCompare(object sender, DataGridViewSortCompareEventArgs e)
        { 
            //列の名前
            string targetColum = e.Column.Name;

            object obj1 = e.CellValue1;
            object obj2 = e.CellValue2;

            //ソートするリスト
            DataGridView targetList = (DataGridView)sender;

            //対象の行の全データ①
            int rowIndex1 = e.RowIndex1;
            object row1 = targetList.Rows[rowIndex1];
            string name1 = (string)(((DataGridViewRow)row1).Cells)[2].Value;
            Gender gender1 = (Gender)(((DataGridViewRow)row1).Cells)[3].Value;
            Level level1 = (Level)(((DataGridViewRow)row1).Cells)[4].Value;
            //対象の行の全データ②
            int rowIndex2 = e.RowIndex2;
            object row2 = targetList.Rows[rowIndex2];
            string name2 = (string)(((DataGridViewRow)row2).Cells)[2].Value;
            Gender gender2 = (Gender)(((DataGridViewRow)row2).Cells)[3].Value;
            Level level2 = (Level)(((DataGridViewRow)row2).Cells)[4].Value;

            //比較するときに使うリスト
            List<(string columName, int sortResult)> compareList01 = new List<(string columName, int sortResult)>
            {
                ("allMemberListName",name1.CompareTo(name2)),
                ("allMemberListGender",gender1.CompareTo(gender2)),
                ("allMemberListLevel",level1.CompareTo(level2))
            };
            List<(string columName, int sortResult)> compareList02 = new List<(string columName, int sortResult)>
            {
                ("attendMemberListName",name1.CompareTo(name2)),
                ("attendMemberListGender",gender1.CompareTo(gender2)),
                ("attendMemberListLevel",level1.CompareTo(level2))
            };

            //リストによって比較するときのリストが異なる
            var compareListDictionary = new Dictionary<DataGridView, List<(string columName, int sortResult)>>
            {
                { allMemberList,compareList01 },
                { attendMemberList,compareList02 }
            };

            //今使うべきリストを調べる
            var compareList = compareListDictionary[targetList];

            //対象の列でまず比較
            (string columName, int sortResult)  = compareList.FirstOrDefault(tuple => tuple.columName == targetColum);
            //0じゃなければ返す
            if (sortResult != 0)
            {
                e.SortResult = sortResult;
                e.Handled = true;
                return;
            }

            foreach (var compare in compareList)
            {
                //同じだったら次に行く
                if (compare.columName == targetColum)
                {
                    continue;
                }
                //sortResultが0でなかったら入れる
                if (compare.sortResult != 0)
                {
                    e.SortResult = compare.sortResult;
                    e.Handled = true;
                    return;
                }
            }

            //入っていなかったら0を入れる
            e.SortResult = 0;
            //処理したことを知らせる
            e.Handled = true;

        }

        /// <summary>
        /// 追加ボタンを押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPerson(object sender, EventArgs e)
        {
            if (allMemberList.RowCount >= 100)
            {
                MessageBox.Show("メンバーをこれ以上登録できません。");
            }
            else
            {
                //追加前のメンバーのチェック状態を保持
                var checkedInAllMembers = new List<Person>();
                for (int i = 0; i < allMemberList.RowCount; i++)
                {
                    if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                    {
                        //チェックされていた人のID
                        string targetId = (string)allMemberList.Rows[i].Cells[1].Value;
                        //IDが一致する人をリストに保持
                        checkedInAllMembers.Add(personHolder.GetAll().Where(x => x.ID == targetId).FirstOrDefault());
                    }
                }
                //追加前の参加メンバーのチェック状態を保持
                var checkedInAttendMembers = new List<Person>();
                for (int i = 0; i < attendMemberList.RowCount; i++)
                {
                    if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                    {
                        //チェックされていた人のID
                        string targetId = (string)attendMemberList.Rows[i].Cells[1].Value;
                        //IDが一致する人をリストに保持
                        checkedInAttendMembers.Add(personHolder.GetAttended().Where(x => x.ID == targetId).FirstOrDefault());
                    }
                }

                using (InputForm inputForm = new InputForm(personRepository))
                {
                    //オーナーウィンドウにthisを指定し、入力画面をモーダルダイアログとして表示
                    inputForm.ShowDialog(this);
                }

                //サークルの削除されていない全メンバーを取得
                var allPersons = personRepository.Get();

                //PersonHolderを作ってメンバーを保持させる
                personHolder = new PersonHolder(allPersons);

                //ダイアログを閉じたらListとラベルだけ更新
                this.allMemberList.Rows.Clear();
                this.attendMemberList.Rows.Clear();
                DisplayMainWindow(checkedInAllMembers, checkedInAttendMembers);
            }

        }

        /// <summary>
        /// MainWindowのリストとラベルを表示するためのメソッド
        /// </summary>
        /// <param name="checkInAllMenberList">チェックボックスにチェックを入れる人のリスト</param>
        private void DisplayMainWindow(IEnumerable<Person> checkInAllMenberList, IEnumerable<Person> checkInAttendMenberList)
        {
            //サークルメンバーを表示
            var persons = personHolder.GetAll();
            foreach (Person person in persons)
            {
                //checkMemberのチェックボックスにはチェックを入れる
                var check = false;
                foreach (Person target in checkInAllMenberList)
                {
                    if (target.ID == person.ID)
                    {
                        check = true;
                    }
                }

                object[] row = { check, person.ID, person.Name, person.Gender, person.Level };
                this.allMemberList.Rows.Add(row);
            }

            //現在登録されている人数を表示
            memberCountLabel.Text = allMemberList.RowCount + "人 / 100人";

            //練習に参加しているメンバーを表示
            var attendedPersons = personHolder.GetAttended();
            foreach (Person person in attendedPersons)
            {
                //checkMemberのチェックボックスにはチェックを入れる
                var check = false;
                foreach (Person target in checkInAttendMenberList)
                {
                    if (target.ID == person.ID)
                    {
                        check = true;
                    }
                }

                object[] row = { check, person.ID, person.Name, person.Gender, person.Level };
                this.attendMemberList.Rows.Add(row);
            }

            //現在の条件でソートを行う
            SortByCurrentSetting(allMemberList);
            SortByCurrentSetting(attendMemberList);

            //最初はどの行も選択していない
            allMemberList.CurrentCell = null;
            attendMemberList.CurrentCell = null;
            
            //ボタンの制御を行う
            ManageButton();

        }

        /// <summary>
        /// 現在の条件でソートを行う
        /// </summary>
        /// <param name="targetList">ソートを行うリスト</param>
        /// <param name="currentSetting">現在のソート対象のカラム名</param>
        private void SortByCurrentSetting(DataGridView targetList)
        {
            //ソート対象のカラム名
            string currentSetting;
            //初期ソートの条件は名前(3行目)
            if (targetList.SortedColumn == null)
            {
                currentSetting = targetList.Columns[2].Name;
            }
            else
            {
                currentSetting = targetList.SortedColumn.Name;
            }

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

        /// <summary>
        /// 変更ボタンを押下したときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updatePerson(object sender, EventArgs e)
        {
            Person updatePerson = new Person();
            string id = "";

            //変更する人(メンバーリストでチェックが入っている人)のIDを取得
            for (int i = 0; i < allMemberList.RowCount; i++)
            {
                if (Convert.ToBoolean(allMemberList.Rows[i].Cells[0].Value))
                {
                    id = (string)allMemberList.Rows[i].Cells[1].Value;
                    //IDが一致する人を探して保持
                    updatePerson = personHolder.GetAll().Where(x => x.ID == id).FirstOrDefault();
                }
            }
            //変更前の参加メンバーのチェック状態を保持
            var checkedIdInAttendMembers = new List<string>();
            var checkedInAttendMembers = new List<Person>();
            for (int i = 0; i < attendMemberList.RowCount; i++)
            {
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    //チェックされていた人のID
                    string targetId = (string)attendMemberList.Rows[i].Cells[1].Value;
                    checkedIdInAttendMembers.Add(targetId);
                    //IDが一致する人をリストに保持
                    checkedInAttendMembers.Add(personHolder.GetAttended().Where(x => x.ID == targetId).FirstOrDefault());
                }
            }

            using (InputForm inputForm = new InputForm(personRepository, updatePerson))
            {
                //オーナーウィンドウにthisを指定し、入力画面をモーダルダイアログとして表示
                inputForm.ShowDialog(this);
            }

            //サークルの削除されていない全メンバーを取得
            var allPersons = personRepository.Get();

            //参加メンバーに入っていたら参加フラグを立て直す
            foreach (var targetId in checkedIdInAttendMembers)
            {
                if (updatePerson.ID == targetId)
                {
                    allPersons.Where(x => x.ID == targetId).FirstOrDefault().AttendFlag = true;

                }
            }

            //PersonHolderを作ってメンバーを保持させる
            personHolder = new PersonHolder(allPersons);

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();
            var updatePersons = new List<Person> { updatePerson };
            DisplayMainWindow(updatePersons, checkedInAttendMembers);
        }

        /// <summary>
        /// 削除ボタンを押下したときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePersons(object sender, EventArgs e)
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
                    deletePersons.Add(personHolder.GetAll().Where(x => x.ID == id).FirstOrDefault());

                }
            }

            //削除前の参加メンバーのチェック状態を保持
            var checkedInAttendMembers = new List<Person>();
            for (int i = 0; i < attendMemberList.RowCount; i++)
            {
                if (Convert.ToBoolean(attendMemberList.Rows[i].Cells[0].Value))
                {
                    //チェックされていた人のID
                    string targetId = (string)attendMemberList.Rows[i].Cells[1].Value;
                    //IDが一致する人をリストに保持
                    checkedInAttendMembers.Add(personHolder.GetAll().Where(x => x.ID == targetId).FirstOrDefault());
                }
            }

            using (DeleteCheckDialog deletecheckDialog = new DeleteCheckDialog(personRepository, deletePersons))
            {
                //オーナーウィンドウにthisを指定し、削除確認画面をモーダルダイアログとして表示
                deletecheckDialog.ShowDialog(this);
            }

            //サークルの削除されていない全メンバーを取得
            var allPersons = personRepository.Get();

            //PersonHolderを作ってメンバーを保持させる
            personHolder = new PersonHolder(allPersons);

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();
            DisplayMainWindow(deletePersons, checkedInAttendMembers);

        }

        /// <summary>
        /// 試合開始ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startGame(object sender, EventArgs e)
        {
            //コート数は暫定二つでシングルス
            int courtNum = 2;
            int accommodateNumber = 2;

            //練習に参加するメンバー
            var attendMember = personHolder.GetAttended();

            //今設定しているアルゴリズムのモードを調べる
            var generateModeDictionary = new Dictionary<string, GenerateMode>()
            {
                { "完全ランダム",GenerateMode.Random },
                {"男女別",GenerateMode.RandomByGender },
                {"レベル別",GenerateMode.RandomByLebel },
                {"戦ったことのない人優先",GenerateMode.FewMatchPriority }
            };
            GenerateMode selectedGenerateMode = generateModeDictionary[generateSettingComboBox.SelectedItem.ToString()];

            //gameGeneratorFactoryで今のGeneratorを作り、試合を決めてもらう
            IGameGenerator gameGenerator = gameGeneratorFactory.Create(selectedGenerateMode);
            (Game[] games, IEnumerable<Person> breakPersons) result = gameGenerator.Generate(courtNum, attendMember, accommodateNumber);

            //試合の組み合わせ結果を表示する
            using (GameWindow gameWindow = new GameWindow(result.games, result.breakPersons, personHolder))
            {
                //オーナーウィンドウにthisを指定し、結果画面をモーダルダイアログとして表示
                gameWindow.ShowDialog(this);
            }

            //今回の試合を対戦履歴に追加
            gameRecorder.Add(result.games.Where(game => game != null).ToArray());

            //ダイアログを閉じたらListとラベルだけ更新
            this.allMemberList.Rows.Clear();
            this.attendMemberList.Rows.Clear();
            DisplayMainWindow(new List<Person>(), new List<Person>());
        }

        /// <summary>
        /// フォームが閉じる直前に発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closingMainWindow(object sender, FormClosingEventArgs e)
        {
            //アプリケーションを終了する
            Application.Exit();
        }

        /// <summary>
        /// MainWindowを表示するときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shownMainWindow(object sender, EventArgs e)
        {
            //最初はどの行も選択していない
            allMemberList.CurrentCell = null;
            attendMemberList.CurrentCell = null;
        }
    }
}
