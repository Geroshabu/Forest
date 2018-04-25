using System;

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

        /// <summary>
        /// 各要素はコンストラクタにてセットする。セットしたものは各プロパティから取得できる。
        /// </summary>
        /// <param name="court">試合で用いるコート</param>
        /// <param name="player1">半分のコートに入る選手</param>
        /// <param name="player2">半分のコートに入る選手</param>
        public Game(Court court, Person[] player1, Person[] player2)
        {
            Court = court ?? throw new ArgumentNullException("Courtにnullを設定しようとしています");
            Player1 = player1;
            Player2 = player2;
        }

    }
}
