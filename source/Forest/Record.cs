namespace Forest
{
    /// <summary>
    /// 対戦履歴
    /// </summary>
    public class Record
    {
        public Record(Person player1,Person player2)
        {
            Opponent = new Person[2];
            Opponent[0] = player1;
            Opponent[1] = player2;
            Count = 1;
        }

        /// <summary>
        /// 対戦した組み合わせ
        /// </summary>
        public Person[] Opponent { get; }

        /// <summary>
        /// 戦った回数
        /// </summary>
        public int Count { get; set; }
    }
}
