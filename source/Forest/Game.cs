namespace Forest
{
    public class Game
    {
        /// <summary>
        /// 試合で用いるコートをもつ
        /// </summary>
        public Court Court { get; set; }

        /// <summary>
        /// 半分のコートに入る選手①
        /// </summary>
        public Person[] Player1 { get; set; }

        /// <summary>
        /// 半分のコートに入る選手②
        /// </summary>
        public Person[] Player2 { get; set; }

    }
}
