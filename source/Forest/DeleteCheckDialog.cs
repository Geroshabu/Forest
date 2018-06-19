using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Forest
{
    public partial class DeleteCheckDialog : Form
    {
        private IPersonRepository personRepository;

        private List<Person> deletePersons;

        public DeleteCheckDialog(IPersonRepository personRepository, IReadOnlyList<Person> deletePersons)
        {
            InitializeComponent();

            this.personRepository = personRepository;

            //引数でもらってきたリストをそのままコピー
            foreach (var target in this.deletePersons = deletePersons.ToList()) { }

        }

        private void LoadDeleteCheckDialog(object sender, EventArgs e)
        {
            //削除される人たちをリストに表示する
            foreach (Person person in deletePersons)
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

            result = personRepository.Delete(deletePersons);

            //一件でも削除できていなければデータベースエラー扱いにする
            if (result == deletePersons.Count)
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
