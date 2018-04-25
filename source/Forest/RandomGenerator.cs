using System;
using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    public class RandomGenerator : IGameGenerator
    {
        /// <summary>
        /// 試合の組み合わせと休憩する人を決める
        /// </summary>
        /// <param name="courtNum">コート数</param>
        /// <param name="attendPersons">試合に参加する人</param>
        /// <returns></returns>
        public (Game[] games, IEnumerable<Person> breakPersons) Generate(int courtNum, List<Person> attendPersons)
        {
            //参加者リストをコピーしてシャッフルする
            var attendPersonsList = attendPersons.ToList();
            ShuffleMember(attendPersonsList);

            //コート数分だけ用意されたGameインスタンスの配列
            var games = new Game[courtNum];
            int courtCounter;

            //参加者の添え字
            int index = 0;
            //コート数分だけGameを作っていく
            for (courtCounter = 0; courtCounter < courtNum; courtCounter++)
            {
                //参加者2人をを試合に入れられるときは処理を行う
                if ((index + 1) < attendPersonsList.Count)
                {
                    //コートの用意
                    var court = new Court
                    {
                        CourtName = "コート" + (courtCounter + 1),
                        AccommodateNumber = 2 //今はシングルスのみだから todo 今後のことを考えると変数作った方がいい気がする
                    };

                    //試合をする人を入れる
                    var player1 = new Person[court.AccommodateNumber / 2];
                    player1[0] = new Person
                    {
                        ID = attendPersonsList[index].ID,
                        Name = attendPersonsList[index++].Name
                    };
                    var player2 = new Person[court.AccommodateNumber / 2];
                    player2[0] = new Person
                    {
                        ID = attendPersonsList[index].ID,
                        Name = attendPersonsList[index++].Name
                    };

                    //Gameのインスタンスを作って入れる
                    var game = new Game(court, player1, player2);
                    games[courtCounter] = game;
                }
                //人を入れられないときは抜ける
                else
                {
                    break;
                }

            }

            //残った人は休憩者に入れる
            IEnumerable<Person> breakPersons = new List<Person>();
            breakPersons = attendPersonsList.Skip(index);

            return (games: games, breakPersons: breakPersons);
        }

        /// <summary>
        /// Person型の配列をシャッフルする
        /// </summary>
        /// <param name="maxNum">シャッフルしたい配列</param>
        /// <returns>シャッフルされた配列</returns>
        private List<Person> ShuffleMember(List<Person> targetList)
        {
            //ランダムに生成した数に該当する添え字（= j ）に入るものとi番目に入るものを入れ替える
            var random = new Random();
            for (int i = 0; i < targetList.Count; i++)
            {
                int j = random.Next(targetList.Count);
                var tmp = targetList[j];
                targetList[j] = targetList[i];
                targetList[i] = tmp;
            }
            return targetList;
        }

    }
}
