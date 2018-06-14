using System;
using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    /// <summary>
    /// 対戦履歴を管理するクラス
    /// </summary>
    public class GameRecorder
    {
        /// <summary>
        /// システムを起動してからの対戦履歴
        /// </summary>
        private List<Record> Records;

        /// <summary>
        /// コンストラクタで空のリストを作成する
        /// </summary>
        public GameRecorder()
        {
            Records = new List<Record>();
        }

        /// <summary>
        /// 試合を対戦履歴に追加する
        /// </summary>
        /// <param name="games">記録したい試合</param>
        /// <exception cref="ArgumentNullException">引数のGameがnullのとき</exception>
        public void Add(Game[] games)
        {
            //nullのときは例外を出す
            if (games == null)
            {
                throw new ArgumentNullException("引数のGameがnullです");
            }
            //空のときは例外を出す
            if (games.Count() == 0)
            {
                throw new ArgumentException("引数のGameが空です");
            }

            //ゲームの数だけ対戦履歴を増やす
            foreach (var game in games)
            {
                if(game != null)
                {
                    Records.Add(new Record(game.Team1[0], game.Team2[0]));
                }
            }
        }

        /// <summary>
        /// 引数の人が参加したことのある試合の回数を返す
        /// </summary>
        /// <param name="player">知りたい人</param>
        /// <returns>参加したことのある試合の回数</returns>
        /// <exception cref="ArgumentNullException">引数がnullのとき</exception>
        public int GetTimes(Person player)
        {
            //nullのときは例外を出す
            if (player == null)
            {
                throw new ArgumentNullException("GetTimesメソッドの引数がnullです");
            }

            return Search(Records, player).Count();
        }

        /// <summary>
        /// 引数の人が対戦したことのある試合の回数を返す
        /// </summary>
        /// <param name="player1">知りたい人</param>
        /// <param name="player2">知りたい人</param>
        /// <returns>対戦回数</returns>
        /// <exception cref="ArgumentNullException">引数のどちらかがnullのとき</exception>
        /// <exception cref="ArgumentException">引数がどちらも同じとき</exception>
        public int GetTimes(Person player1, Person player2)
        {
            //どちらかがnullのときは例外を出す
            if (player1 == null || player2 == null)
            {
                throw new ArgumentNullException("GetTimesメソッドの引数がnullです");
            }

            //引数のPersonが同じときは例外を出す
            if (player1 == player2)
            {
                throw new ArgumentException("GetTimesメソッドの引数に同じ人が入っています");
            }

            return Search(Search(Records, player1), player2).Count();
        }

        /// <summary>
        /// 引数の人が参加した試合をリストにして返す
        /// </summary>
        /// <param name="targetList">探すリスト</param>
        /// <param name="targetPlayer">探したい人</param>
        /// <returns>参加した試合</returns>
        private IEnumerable<Record> Search(IEnumerable<Record> targetList, Person targetPlayer)
        {
            var resultList = targetList.Where(record => (record.Contain(targetPlayer)));
            return resultList;
        }
    }
}
