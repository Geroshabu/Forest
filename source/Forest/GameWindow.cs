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
            //Penオブジェクトの作成
            Pen blackPen = new Pen(Color.Black, 2);
            //描く
            canvas = DrawCourt(canvas, blackPen,20,80);
            canvas = DrawCourt(canvas, blackPen, 250, 80);
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
            //コート（二つ）を表示する
            int width = 100;
            int height = 200 ;
            //四角を描く
            graphics.DrawRectangle(blackPen, x, y, width, height);
            //線を描く
            graphics.DrawLine(blackPen, x, (y + width), (x + width), (y + width));

            graphics.Dispose();

            return canvas;
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
