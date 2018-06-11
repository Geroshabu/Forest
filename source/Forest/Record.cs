using System;

namespace Forest
{
    /// <summary>
    /// 対戦履歴
    /// </summary>
    public class Record
    {
        public Record(Person player1, Person player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        /// <summary>
        /// 試合をした人①
        /// </summary>
        public Person Player1 { get; }

        /// <summary>
        /// 試合をしたした人②
        /// </summary>
        public Person Player2 { get; }

        /// <summary>
        /// 引数の人がこのレコードに含まれているかを返す
        /// </summary>
        /// <param name="person">探したい人</param>
        /// <returns>含まれているかどうか</returns>
        public bool Contain(Person person)
        {
            //引数がnullのときには例外を出す
            if (person == null)
            {
                throw new ArgumentNullException("引数がnullです");
            }

            return (person == Player1 || person == Player2);
        }

    }
}
