using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Forest
{
    public partial class DeleteCheckDialog : Form
    {
        IPersonRepository PersonRepository;

        List<Person> DeletePersons;

        public DeleteCheckDialog(IPersonRepository personRepository, IReadOnlyList<Person> deletePersons)
        {
            InitializeComponent();

            PersonRepository = personRepository;

            //引数でもらってきたリストをそのままコピー
            foreach (var target in DeletePersons = deletePersons.ToList()) { }

        }

        private void LoadDeleteCheckDialog(object sender, EventArgs e)
        {
            labelDeleteMessage.Text = "以下のメンバーを削除してよろしいですか？";

            //削除される人たちをリストに表示する
            foreach (Person person in DeletePersons)
            {
                object[] row = { person.ID, person.Name, person.Gender, person.Level };
                this.deleteMemberList.Rows.Add(row);
            }

        }

        /// <summary>
        /// 中止ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 削除ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, EventArgs e)
        {
            int result;

            result = PersonRepository.Delete(DeletePersons);

            //一件でも削除できていなければデータベースエラー扱いにする
            if (result == DeletePersons.Count)
            {
                //この画面を閉じる
                this.Close();
            }
            else
            {
                MessageBox.Show("データベースエラーが発生しました。");
            }
        }
    }
}
