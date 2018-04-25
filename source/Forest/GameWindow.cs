using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Forest
{
    public partial class GameWindow : Form
    {
        //試合の詳細が入った配列
        Game[] Games;
        //休憩する人たち
        IEnumerable<Person> BreakPersons;

        PersonHolder PersonHolder;

        public GameWindow(Game[] games, IEnumerable<Person> breakPersons, PersonHolder personHolder)
        {
            InitializeComponent();
            Games = games;
            BreakPersons = breakPersons;
            PersonHolder = personHolder;
        }

        private void LoadGameWindow(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(resultPictureBox.Width, resultPictureBox.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics graphics = Graphics.FromImage(canvas);

            //Penオブジェクトの作成
            Pen black_pen = new Pen(Color.Black, 2);

            //コート（二つ）を表示する
            //penで四角と線をかく
            graphics.DrawRectangle(black_pen, 20, 80, 100, 200);
            graphics.DrawLine(black_pen, 20, 180, 120, 180);
            graphics.DrawRectangle(black_pen, 250, 80, 100, 200);
            graphics.DrawLine(black_pen, 250, 180, 350, 180);
            graphics.Dispose();
            //画面に反映する
            resultPictureBox.Image = canvas;

            //コート名
            courtNameLabel1.Text = Games[0].Court.CourtName;
            //組み合わせ結果
            playerNameLabel1.Text = Games[0].Player1[0].Name;
            playerNameLabel2.Text = Games[0].Player2[0].Name;

            //中身が入って入れば表示する
            if (Games[1] != null)
            {
                //コート名
                courtNameLabel2.Text = Games[1].Court.CourtName;
                //組み合わせ結果
                playerNameLabel3.Text = Games[1].Player1[0].Name;
                playerNameLabel4.Text = Games[1].Player2[0].Name;
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
            foreach (Person person in BreakPersons)
            {
                object[] row = { person.Name };
                this.breakMemberList.Rows.Add(row);
            }

        }

        /// <summary>
        /// 試合終了ボタンが押下されたときに発生するイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndGame(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
