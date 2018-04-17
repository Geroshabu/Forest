using System;
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
                //IDを新規に定める
                Person.ID = CreateId();
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
    }
}
