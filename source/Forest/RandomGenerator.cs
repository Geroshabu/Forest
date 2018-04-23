using System;
using System.Collections.Generic;

namespace Forest
{
    class RandomGenerator : IGameGenerator
    {
        /// <summary>
        /// 試合の組み合わせと休憩する人を決める
        /// </summary>
        /// <param name="courtNum">コート数</param>
        /// <param name="attendPersons">試合に参加する人</param>
        /// <param name="breakPersons">休憩する人</param>
        /// <returns></returns>
        public Game[] Generate(int courtNum, List<Person> attendPersons, out List<Person> breakPersons)
        {
            //コート数分だけ用意されたGameインスタンスの配列
            Game[] Games = new Game[courtNum];

            //コートと人が入るところを用意する
            int courtIndex = 1;
            int courtCounter;
            for (courtCounter = 0; courtCounter < courtNum; courtCounter++)
            {
                //Gameのインスタンスを作っておく
                var game = new Game();

                game.Court = new Court
                {
                    CourtName = "コート" + courtIndex++,
                    AccommodateNumber = 1 //今はシングルスのみだから
                };
                game.Player1 = new Person[1];
                game.Player2 = new Person[1];

                Games[courtCounter] = game;

            }

            //対戦相手を決めてコートに配置する【今はシングルスのみ】
            //シャッフルした数字の配列の先頭から順にメンバーを入れていく

            //シャッフルされた数字の配列
            int[] num = ShuffleNumber(attendPersons.Count);

            //シャッフルされた数字の配列のインデックスの数字
            int numCounter = 0;

            //コートに試合する人を入れていく
            for (courtCounter = 0; courtCounter < Games.Length; courtCounter++)
            {
                //対象とする試合
                var game = Games[courtCounter];

                //入れる人はランダムな数字の配列から指定
                if ((numCounter + 1) < attendPersons.Count)
                {
                    game.Player1[0] = new Person
                    {
                        ID = attendPersons[num[numCounter]].ID,
                        Name = attendPersons[num[numCounter++]].Name
                    };
                    game.Player2[0] = new Person
                    {
                        ID = attendPersons[num[numCounter]].ID,
                        Name = attendPersons[num[numCounter++]].Name
                    };
                }

            }

            //まだ人が余っていたら休憩者に入れる
            breakPersons = new List<Person>();
            while (numCounter < attendPersons.Count)
            {
                breakPersons.Add(attendPersons[num[numCounter++]]);
            }

            return Games;
        }

        /// <summary>
        /// 数字の入った配列をシャッフルする
        /// </summary>
        /// <param name="maxNum">シャッフルしたい最大の数字</param>
        /// <returns>シャッフルされた数字の配列</returns>
        public int[] ShuffleNumber(int maxNum)
        {
            //数字の配列を作成（個数は最大の数字と同じ）
            int[] target = new int[maxNum];
            for (int i = 0; i < maxNum; i++)
            {
                target[i] = i;
            }

            //配列をシャッフルする
            System.Random ramdom = new Random();
            for (int i = 0; i < (maxNum); i++)
            {
                //適当な場所を選ぶ
                int j = ramdom.Next(maxNum - 1);
                //退避用の変数に入れておく
                int tmp = target[j];
                //入れ替える
                target[j] = target[i];
                target[i] = tmp;
            }

            return target;
        }
    }
}
