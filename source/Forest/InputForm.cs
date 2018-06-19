using System;
using System.Windows.Forms;

namespace Forest
{
    public partial class InputForm : Form
    {
        private IPersonRepository personRepository;

        private Person person;

        private enum Order
        {
            Add,
            Update
        }

        //変更なのか、追加なのか
        private Order currentOrder;

        /// <summary>
        /// 変更時に用いるコンストラクタ
        /// </summary>
        /// <param name="personRepository">インスタンス</param>
        /// <param name="person">変更情報</param>
        public InputForm(IPersonRepository personRepository, Person person)
        {
            InitializeComponent();

            this.personRepository = personRepository;
            this.person = person;
            currentOrder = Order.Update;
        }

        /// <summary>
        /// 追加時に用いるコンストラクタ
        /// </summary>
        /// <param name="personRepository">インスタンス</param>
        public InputForm(IPersonRepository personRepository)
        {
            InitializeComponent();

            this.personRepository = personRepository;
            currentOrder = Order.Add;
            person = new Person();
        }

        /// <summary>
        /// 登録ボタンを押下したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register(object sender, EventArgs e)
        {
            //追加、変更の結果
            bool result;

            //追加のとき
            if (currentOrder == Order.Add)
            {
                //新規にIDを作成する
                person.ID = CreateId();
                //入力された名前を入れる
                person.Name = nameTextBox.Text;
                //選択された性別を入れる
                if (radioButtonMale.Checked)
                {
                    person.Gender = new Gender { GenderNum = 1 };
                }
                else if (radioButtonFemale.Checked)
                {
                    person.Gender = new Gender { GenderNum = 0 };
                }
                //選択されたレベルを入れる
                if (radioButtonBeginner.Checked)
                {
                    person.Level = new Level { LevelNum = 0 };
                }
                else if (radioButtonIntermediate.Checked)
                {
                    person.Level = new Level { LevelNum = 1 };
                }
                else if (radioButtonSenior.Checked)
                {
                    person.Level = new Level { LevelNum = 2 };
                }
                //削除フラグは立てない
                person.DeleteFlag = false;
                //参加フラグも立てない
                person.AttendFlag = false;

                result = personRepository.Add(person);
            }
            //変更のとき
            else
            {
                //入力された名前を入れる
                person.Name = nameTextBox.Text;
                //選択された性別を入れる
                if (radioButtonMale.Checked)
                {
                    person.Gender.GenderNum = 1;
                }
                else if (radioButtonFemale.Checked)
                {
                    person.Gender.GenderNum = 0;
                }
                //選択されたレベルを入れる
                if (radioButtonBeginner.Checked)
                {
                    person.Level.LevelNum = 0;
                }
                else if (radioButtonIntermediate.Checked)
                {
                    person.Level.LevelNum = 1;
                }
                else if (radioButtonSenior.Checked)
                {
                    person.Level.LevelNum = 2;
                }

                result = personRepository.Update(person);
            }

            //成功したら画面を閉じる
            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("データベースエラーが発生しました。");
            }

        }

        /// <summary>
        /// 変更された場合には現在のデータを入力画面に表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadInputForm(object sender, EventArgs e)
        {
            if (currentOrder == Order.Update)
            {
                //名前を入れる
                nameTextBox.Text = person.Name;
                //性別を入れる
                if (person.Gender == new Gender { GenderNum = 1 })
                {
                    radioButtonMale.Checked = true;
                }
                else if (person.Gender == new Gender { GenderNum = 0 })
                {
                    radioButtonFemale.Checked = true;
                }
                //選択されたレベルを入れる
                if (person.Level == new Level { LevelNum = 0 })
                {
                    radioButtonBeginner.Checked = true;
                }
                else if (person.Level == new Level { LevelNum = 1 })
                {
                    radioButtonIntermediate.Checked = true;
                }
                else if (person.Level == new Level { LevelNum = 2 })
                {
                    radioButtonSenior.Checked = true;
                }
            }

            //ボタンの制御
            ManageButton();

        }

        /// <summary>
        /// 重複のないIDを生成するメソッド
        /// </summary>
        /// <returns>新たなID</returns>
        private string CreateId()
        {
            //所属グループによって異なるコード
            string groupCode;
            string id;

            groupCode = "A";
            id = groupCode + personRepository.GetAllCount().ToString();

            return id;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 『登録ボタン』を制御するメソッド
        /// </summary>
        private void ManageButton()
        {
            registerButton.Enabled = false;

            //名前が1文字以上20文字以内で入力されていればOK
            if ((CountText(nameTextBox.Text)) >= 1 && (CountText(nameTextBox.Text)) <= 20)
            { }
            else
            {
                return;
            }

            //男女どちらかが選択されていれば押下OK
            if (radioButtonMale.Checked || radioButtonFemale.Checked)
            { }
            else
            {
                return;
            }

            //レベルのどれかが押下されていればOK
            if (radioButtonBeginner.Checked || radioButtonIntermediate.Checked || radioButtonSenior.Checked)
            { }
            else
            {
                return;
            }

            registerButton.Enabled = true;

        }

        /// <summary>
        /// テキストの文字数を数えるメソッド
        /// </summary>
        /// <param name="target">数えたいテキスト</param>
        /// <returns>文字数</returns>
        private int CountText(string target)
        {
            //数えた結果
            int result;

            //前後の空白を削除した文字列
            string removeBlankTarget = target.Trim();

            //nullであれば0文字
            if (removeBlankTarget == null)
            {
                result = 0;
            }
            //文字数を結果に入れる
            else
            {
                result = removeBlankTarget.Length;
            }

            return result;
        }

        //以下、それぞれの編集可能項目を選択されたときのイベント
        //ボタンの制御のみを行う

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();
        }

        private void radioButtonMale_Click(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();

        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();

        }

        private void radioButtonSenior_CheckedChanged(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();

        }

        private void radioButtonIntermediate_CheckedChanged(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();

        }

        private void radioButtonBeginner_CheckedChanged(object sender, EventArgs e)
        {
            //ボタンの制御
            ManageButton();

        }
    }
}
