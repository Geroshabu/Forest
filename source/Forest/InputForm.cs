﻿using System;
using System.Windows.Forms;

namespace Forest
{
    public partial class InputForm : Form
    {
        IPersonRepository PersonRepository;

        Person Person;

        enum Order
        {
            Add,
            Update
        }

        Order CurrentOrder;

        public InputForm(IPersonRepository personRepository, Person person)
        {
            InitializeComponent();
            PersonRepository = personRepository;
            Person = person;
            //追加なのか、変更なのか
            if (Person == null)
            {
                CurrentOrder = Order.Add;
                Person = new Person();
            }
            else
            {
                CurrentOrder = Order.Update;
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //追加の時は新規に、変更の時は元のIDを入れる
            if(CurrentOrder == Order.Add)
            {
                Person.ID = CreateId();
            }
            else
            {
                string id = Person.ID;
                Person = new Person();
                Person.ID = id;
            }

            //入力された名前を入れる
            Person.Name = nameTextBox.Text;
            //選択された性別を入れる
            if (radioButtonMale.Checked)
            {
                Person.Gender = new Gender { GenderNum = 0 };
            }
            else if (radioButtonFemale.Checked)
            {
                Person.Gender = new Gender { GenderNum = 1 };
            }
            //選択されたレベルを入れる
            if (radioButtonBeginner.Checked)
            {
                Person.Level = new Level { LevelNum = 0 };
            }
            else if (radioButtonIntermediate.Checked)
            {
                Person.Level = new Level { LevelNum = 1 };
            }
            else if (radioButtonSenior.Checked)
            {
                Person.Level = new Level { LevelNum = 2 };
            }

            //追加の時はIDとフラグも設定する
            if (CurrentOrder == Order.Add)
            {
                //削除フラグは立てない
                Person.DeleteFlag = false;
                //参加フラグも立てない
                Person.AttendFlag = false;
            }

            //追加、変更の結果
            bool result;

            if (CurrentOrder == Order.Add)
            {
                result = PersonRepository.Add(Person);
            }
            //変更する場合
            else
            {
                result = PersonRepository.Update(Person);
            }

            if (result)
            {
                //この画面を閉じる
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
        private void InputForm_Load(object sender, EventArgs e)
        {
            if (CurrentOrder == Order.Update)
            {
                //名前を入れる
                nameTextBox.Text = Person.Name;
                //性別を入れる
                if (Person.Gender == new Gender { GenderNum = 0 })
                {
                    radioButtonMale.Checked = true;
                }
                else if (Person.Gender == new Gender { GenderNum = 1 })
                {
                    radioButtonFemale.Checked = true;
                }
                //選択されたレベルを入れる
                if (Person.Level == new Level { LevelNum = 0 })
                {
                    radioButtonBeginner.Checked = true;
                }
                else if (Person.Level == new Level { LevelNum = 1 })
                {
                    radioButtonIntermediate.Checked = true;
                }
                else if (Person.Level == new Level { LevelNum = 2 })
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
            id = groupCode + PersonRepository.GetAll().Count.ToString();

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

            //チェック項目のカウント
            //全部で3項目あるから、値が3になれば
            int checkCount = 0;

            //名前が1文字以上20文字以内で入力されていればOK
            if ((CountText(nameTextBox.Text)) >= 1 && (CountText(nameTextBox.Text)) <= 20)
            {
                checkCount++;
            }

            //男女どちらかが選択されていれば押下OK
            if (radioButtonMale.Checked || radioButtonFemale.Checked)
            {
                checkCount++;
            }

            //レベルのどれかが押下されていればOK
            if (radioButtonBeginner.Checked || radioButtonIntermediate.Checked || radioButtonSenior.Checked)
            {
                checkCount++;
            }

            if (checkCount == 3)
            {
                registerButton.Enabled = true;
            }

        }

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
