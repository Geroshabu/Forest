using System.Collections.Generic;

namespace Forest
{
    /// <summary>
    /// 試合の組み合わせを決めるためのインターフェース
    /// </summary>
    interface IGameGenerator
    {
        /// <summary>
        /// 試合の組み合わせを決める
        /// </summary>
        /// <param name="courtNum">コート数</param>
        /// <param name="attendPersons">試合に参加する人</param>
        /// <param name="accommodateNumber">コートに入れる人数</param>
        /// <returns>試合の組み合わせ結果と休憩者のリスト</returns>
        (Game[] games, IEnumerable<Person> breakPersons) Generate(int courtNum, IReadOnlyList<Person> attendPersons, int accommodateNumber);
    }
}
