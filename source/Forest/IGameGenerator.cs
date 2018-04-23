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
        /// <param name="breakPersons">休憩する人</param>
        /// <returns>試合の組み合わせ結果</returns>
        Game[] Generate(int courtNum, List<Person> attendPersons, out List<Person> breakPersons);
    }
}
