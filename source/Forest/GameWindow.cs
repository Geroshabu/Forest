using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Forest
{
    public partial class GameWindow : Form
    {
        //試合の詳細が入った配列
        private Game[] games;
        //休憩する人たち
        private IEnumerable<Person> breakPersons;

        private PersonHolder personHolder;

        public GameWindow(Game[] games, IEnumerable<Person> breakPersons, PersonHolder personHolder)
        {
            InitializeComponent();
            this.games = games;
            this.breakPersons = breakPersons;
            this.personHolder = personHolder;
        }

        private void loadGameWindow(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(resultPictureBox.Width, resultPictureBox.Height);
            //Penオブジェクトの作成
            Pen blackPen = new Pen(Color.Black, 2);
            //描く
            canvas = DrawCourt(canvas, blackPen,20,80);
            canvas = DrawCourt(canvas, blackPen, 250, 80);
            //画面に反映する
            resultPictureBox.Image = canvas;

            //コート名
            courtNameLabel1.Text = games[0].Court.CourtName;
            //組み合わせ結果
            playerNameLabel1.Text = games[0].Team1[0].Name;
            playerNameLabel2.Text = games[0].Team2[0].Name;

            //中身が入って入れば表示する
            if (games[1] != null)
            {
                //コート名
                courtNameLabel2.Text = games[1].Court.CourtName;
                //組み合わせ結果
                playerNameLabel3.Text = games[1].Team1[0].Name;
                playerNameLabel4.Text = games[1].Team2[0].Name;
            }
            else
            {
                //コート名を空欄にする
                courtNameLabel2.Text = "";
                //組み合わせ結果を空欄にする
                playerNameLabel3.Text = "";
                playerNameLabel4.Text = "";
            }

            //休憩する人を表示する
            foreach (Person person in breakPersons)
            {
                object[] row = { person.Name,person.Gender,person.Level };
                this.breakMemberList.Rows.Add(row);
            }

            //名前の順にソートをする
            SortByName();

        }

        /// <summary>
        /// 名前の順にソートをするメソッド
        /// </summary>
        private void SortByName()
        {
            //自動的に並び替えられるようにする
            foreach (DataGridViewColumn c in breakMemberList.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            //並び替える列を決める
            DataGridViewColumn sortColumn = breakMemberList.Columns[breakMemberList.Columns[0].Name];
            //リストの初期ソートの方向は昇順
            ListSortDirection sortDirection = ListSortDirection.Ascending;
            //並び替えを行う
            breakMemberList.Sort(sortColumn, sortDirection);
        }

        /// <summary>
        /// コートを描く
        /// </summary>
        /// <param name="canvas">描くところ</param>
        /// <param name="blackPen">黒いペン</param>
        /// <param name="x">四角の左端のx座標</param>
        /// <param name="y">四角の左端のy座標</param>
        /// <returns></returns>
        private Bitmap DrawCourt(Bitmap canvas, Pen blackPen, int x, int y)
        {
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics graphics = Graphics.FromImage(canvas);
            //コートを表示する
            int width = 200;
            int height = 200 ;
            //四角を描く
            graphics.DrawRectangle(blackPen, x, y, width, height);
            //線を描く
            graphics.DrawLine(blackPen, x, (y + height/2), (x + width), (y + height / 2));

            graphics.Dispose();

            return canvas;
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
            string name1 = (string)(((DataGridViewRow)row1).Cells)[0].Value;
            Gender gender1 = (Gender)(((DataGridViewRow)row1).Cells)[1].Value;
            Level level1 = (Level)(((DataGridViewRow)row1).Cells)[2].Value;
            //対象の行の全データ②
            int rowIndex2 = e.RowIndex2;
            object row2 = targetList.Rows[rowIndex2];
            string name2 = (string)(((DataGridViewRow)row2).Cells)[0].Value;
            Gender gender2 = (Gender)(((DataGridViewRow)row2).Cells)[1].Value;
            Level level2 = (Level)(((DataGridViewRow)row2).Cells)[2].Value;

            //比較するときに使うリスト
            List<(string columName, int sortResult)> compareList = new List<(string columName, int sortResult)>
            {
                ("breakMemberListName",name1.CompareTo(name2)),
                ("breakMemberListGender",gender1.CompareTo(gender2)),
                ("breakMemberListLevel",level1.CompareTo(level2))
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
        /// 試合終了ボタンが押下されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endGame(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
