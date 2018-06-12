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
        /// 休憩者と試合の組み合わせを決める。
        /// </summary>
        /// <param name="courtNum">コート数</param>
        /// <param name="attendPersons">試合の参加者</param>
        /// <returns>Gameと休憩者のリスト</returns>
        public override (Game[] games, IEnumerable<Person> breakPersons) Generate(int courtNum, List<Person> attendPersons)
        {
            //コート数が負の数であるときは例外を出す
            if (courtNum <= 0)
            {
                throw new ArgumentOutOfRangeException("courtNumが負の数です");
            }

            //コート数分だけ用意されたGameインスタンスの配列
            var games = new Game[courtNum];

            //参加者リストをシャッフルする
            var attendPersonsList = ShuffleMember(attendPersons);

            //最初に休憩者を決める
            const int accommodateNumber = 2;//今はシングルスのみだから2人
            int breakPersonsNumber = attendPersonsList.Count - courtNum * accommodateNumber;//休憩者の人数
            //人数に満たないコートは空にすることを考慮
            while(breakPersonsNumber < 0)
            {
                breakPersonsNumber += accommodateNumber;
                courtNum--;
            }
            
            //参加者のリストから抜き出す
            IEnumerable<Person> breakPersons = new List<Person>(attendPersonsList.GetRange(0, breakPersonsNumber));
            //抜き出した人はリストから消す
            attendPersonsList.RemoveRange(0, breakPersonsNumber);

            //試合の組み合わせを決めていく
            //コートに入れる順番で並べるリストを準備
            var playerList = new List<Person>();
            //Gender型の種類を入れたリストを用意
            var men = new Gender { GenderNum = 1 };
            var women = new Gender { GenderNum = 0 };
            Gender[] genderTypes = { men, women };
            //男、女の順番で並び替える
            foreach (var targetGender in genderTypes)
            {
                //残りのメンバーの中から対象の性別のメンバーを抜き出す
                playerList.AddRange(attendPersonsList.Where(person => person.Gender == targetGender));
            }

            //並び替えた人たちをコートに配置していく
            int playerCounter = 0;
            for (int i = 0; i < courtNum; i++)
            {
                if(playerList.Count >= playerCounter + accommodateNumber)
                {
                    //プレイヤーを入れていく
                    var player1 = new Person[accommodateNumber / 2];
                    player1[0] = new Person
                    {
                        ID = playerList[playerCounter].ID,
                        Gender = playerList[playerCounter].Gender,
                        Name = playerList[playerCounter].Name
                    };

                    playerCounter++;

                    var player2 = new Person[accommodateNumber / 2];
                    player2[0] = new Person
                    {
                        ID = playerList[playerCounter].ID,
                        Gender = playerList[playerCounter].Gender,
                        Name = playerList[playerCounter++].Name,
                    };

                    //ゲームにコートとプレイヤーを入れる
                    var game = new Game(CreateCourt(i, accommodateNumber), player1, player2);
                    games[i] = game;
                }
                else
                {
                    break;
                }

            }

            return (games: games, breakPersons: breakPersons);

        }

    }
}
