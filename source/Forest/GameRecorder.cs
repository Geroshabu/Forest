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

            //gamesの数だけ履歴を追加する
            foreach(var game in games)
            {
                Record record;
                //今までに戦ったことがあるのか、検索
                record = Search(Search(Records, game.Player1[0]),game.Player2[0]).FirstOrDefault();
                //nullだったら新たに作る
                if(record == null)
                {
                    record = new Record(game.Player1[0], game.Player2[0]);
                    Records.Add(record);
                }
                //過去に戦ったことがあれば、回数を一回増やす
                else
                {
                    record.Count++;
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
            int result = 0;
            //nullのときは例外を出す
            if (player == null)
            {
                throw new ArgumentNullException("GetTimesメソッドの引数がnullです");
            }

            //探して足し合わせる
            foreach (var record in Search(Records, player))
            {
                result += record.Count;
            }
            return result;
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
            int result = 0;
            //どちらかがnullのときは例外を出す
            if (player1 == null || player2 == null)
            {
                throw new ArgumentNullException("GetTimesメソッドの引数がnullです");
            }

            //探して足し合わせる
            foreach (var record in Search(Search(Records, player1), player2))
            //引数のPersonが同じときは例外を出す
            if (player1 == player2)
            {
                result += record.Count;
                throw new ArgumentException("GetTimesメソッドの引数に同じ人が入っています");
            }
            return result;
        }

        /// <summary>
        /// 引数の人が参加した試合をリストにして返す
        /// </summary>
        /// <param name="targetList">探すリスト</param>
        /// <param name="targetPlayer">探したい人</param>
        /// <returns>参加した試合</returns>
        private IEnumerable<Record> Search(IEnumerable<Record> targetList,Person targetPlayer)
        {
            var resultList = targetList.Where(record => ((record.Opponent[0] == targetPlayer) || (record.Opponent[1] == targetPlayer)));
            return resultList;
            return resultList;
        }
    }
}
