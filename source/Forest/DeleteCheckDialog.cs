using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //削除される人たちをリストに表示する
            foreach (Person person in DeletePersons)
            {
                object[] row = { person.ID, person.Name, person.Gender, person.Level };
                this.deleteMemberList.Rows.Add(row);
            }

        }

        private void DeleteCheckDialog_Load(object sender, EventArgs e)
        {
            labelDeleteMessage.Text = "以下のメンバーを削除してよろしいですか？";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int result;

            result = PersonRepository.Delete(DeletePersons);

            if(result == DeletePersons.Count)
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
