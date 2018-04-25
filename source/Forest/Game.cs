namespace Forest
{
    public class Game
    {
        /// <summary>
        /// 試合で用いるコートをもつ
        /// </summary>
        public Court Court { get; }

        /// <summary>
        /// 半分のコートに入る選手①
        /// </summary>
        public Person[] Player1 { get; }

        /// <summary>
        /// 半分のコートに入る選手②
        /// </summary>
        public Person[] Player2 { get; }

        public Game(Court court, Person[] player1, Person[] player2)
        {
            Court = court;
            Player1 = player1;
            Player2 = player2;
        }

    }
}
