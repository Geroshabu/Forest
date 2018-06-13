using System;
using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    /// <summary>
    /// 男女別。男同士、女同士で当たりやすくするアルゴリズム。
    /// </summary>
    public class RandomByGenderGenerator : Generator, IGameGenerator
    {
        /// <summary>
        /// 休憩者をランダムに決める
        /// </summary>
        /// <param name="breakPersonsNumber"></param>
        /// <param name="attendPersons"></param>
        /// <returns>試合の参加者と休憩者</returns>
        protected override (List<Person> players, List<Person> breakPersons) DecideBreakPersons(int breakPersonsNumber, IReadOnlyList<Person> attendPersons)
        {
            //参加者のリストをコピーする
            var playerList = new List<Person>(attendPersons);
            var breakPersons = new List<Person>();

            //参加者の中からランダムに休憩者を決める
            Random random;
            for (int i = 0; i < breakPersonsNumber; i++)
            {
                random = new Random();
                var target = random.Next(playerList.Count);
                //休憩者リストに入れる
                breakPersons.Add(playerList[target]);
                //試合には参加できないのでリストから消す
                playerList.Remove(playerList[target]);
            }
            return (players: playerList, breakPersons: breakPersons);
        }

        /// <summary>
        /// 対戦相手を決める
        /// </summary>
        /// <param name="players">試合の参加者</param>
        /// <returns>残りの試合の参加者と対戦の組み合わせ</returns>
        protected override (List<Person> remainPlayers, List<Person> player1, List<Person> player2) DecideOpponent(List<Person> players, int accommodateNumber)
        {
            //シャッフルしてから男、女の順番で並び替える
            var playerList = ProcessList.Shuffle(players).OrderByDescending(person => person.Gender).ToList();

            //コートに入れられる人数分だけ繰り返す
            var team1 = new List<Person>();
            var team2 = new List<Person>();
            for (int playerCounter = 0; playerCounter < accommodateNumber;)
            {
                //コートの半分ずつ入れていく
                for (int courtCounter = 0; courtCounter < (accommodateNumber / 2); courtCounter++)
                {
                    team1.Add(new Person
                    {
                        ID = playerList.First().ID,
                        Gender = playerList.First().Gender,
                        Name = playerList.First().Name
                    });
                    playerList.RemoveAt(0);
                    playerCounter++;
                }
                for (int courtCounter = 0; courtCounter < (accommodateNumber / 2); courtCounter++)
                {
                    team2.Add( new Person
                    {
                        ID = playerList.First().ID,
                        Gender = playerList.First().Gender,
                        Name = playerList.First().Name
                    });
                    playerList.RemoveAt(0);
                    playerCounter++;
                }
            }
            return (remainPlayers: playerList, player1: team1, player2: team2);
        }
    }
}
