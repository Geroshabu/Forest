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
        public Person[] Team1 { get; }

        /// <summary>
        /// 半分のコートに入る選手②
        /// </summary>
        public Person[] Team2 { get; }

        /// <summary>
        /// 各要素はコンストラクタにてセットする。セットしたものは各プロパティから取得できる。
        /// </summary>
        /// <param name="court">試合で用いるコート</param>
        /// <param name="team1">半分のコートに入る選手</param>
        /// <param name="team2">半分のコートに入る選手</param>
        public Game(Court court, Person[] team1, Person[] team2)
        {
            Court = court ?? throw new ArgumentNullException("Courtにnullを設定しようとしています");
            Team1 = team1;
            Team2 = team2;
        }

    }
}
