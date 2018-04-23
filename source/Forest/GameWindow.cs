using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Forest
{
    public partial class GameWindow : Form
    {
        Game[] Games;
        List<Person> BreakPersons;
        PersonHolder PersonHolder;

        public GameWindow(Game[] games, List<Person> breakPersons, PersonHolder personHolder)
        {
            InitializeComponent();
            Games = games;
            BreakPersons = breakPersons;
            PersonHolder = personHolder;
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(resultPictureBox.Width, resultPictureBox.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics graphics = Graphics.FromImage(canvas);

            //Penオブジェクトの作成
            Pen black_pen = new Pen(Color.Black, 2);

            //コートを表示する
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
            //組み合わせ結果を表示する
            playerNameLabel1.Text = Games[0].Player1[0].Name;
            playerNameLabel2.Text = Games[0].Player2[0].Name;

            if ((Games[1].Player1[0] != null) && (Games[1].Player2[0] != null))
            {
                //コート名
                courtNameLabel2.Text = Games[1].Court.CourtName;
                //組み合わせ結果を表示する
                playerNameLabel3.Text = Games[1].Player1[0].Name;
                playerNameLabel4.Text = Games[1].Player2[0].Name;
            }
            //人が入っていないコートは空欄にする
            else
            {
                //コート名
                courtNameLabel2.Text = "";
                //組み合わせ結果
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

        private void endGameButton_Click(object sender, EventArgs e)
        {
            //todo メイン画面を表示する
            MainWindow mainWindow = new MainWindow(PersonHolder);

            //メイン画面を表示
            mainWindow.Show();
            this.Visible = false;

        }
    }
}
