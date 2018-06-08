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

        private void loadDeleteCheckDialog(object sender, EventArgs e)
        {
            //削除される人たちをリストに表示する
            foreach (Person person in deletePersons)
            {
                object[] row = { person.ID, person.Name, person.Gender, person.Level };
                this.deleteMemberList.Rows.Add(row);
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
            string name1 = (string)(((DataGridViewRow)row1).Cells)[1].Value;
            Gender gender1 = (Gender)(((DataGridViewRow)row1).Cells)[2].Value;
            Level level1 = (Level)(((DataGridViewRow)row1).Cells)[3].Value;
            //対象の行の全データ②
            int rowIndex2 = e.RowIndex2;
            object row2 = targetList.Rows[rowIndex2];
            string name2 = (string)(((DataGridViewRow)row2).Cells)[1].Value;
            Gender gender2 = (Gender)(((DataGridViewRow)row2).Cells)[2].Value;
            Level level2 = (Level)(((DataGridViewRow)row2).Cells)[3].Value;

            //比較するときに使うリスト
            List<(string columName, int sortResult)> compareList = new List<(string columName, int sortResult)>
            {
                ("deleteMemberListName",name1.CompareTo(name2)),
                ("deleteMemberListGender",gender1.CompareTo(gender2)),
                ("deleteMemberListLevel",level1.CompareTo(level2))
            };

            //対象の列でまず比較
            (string columName, int sortResult) = compareList.Single(tuple => tuple.columName == targetColum);
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
        /// 中止ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 削除ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete(object sender, EventArgs e)
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
