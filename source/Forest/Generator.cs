using System;
using System.Collections.Generic;

namespace Forest
{
    /// <summary>
    /// 試合の組み合わせを決めるテンプレートのクラス
    /// </summary>
    public abstract class Generator : IGameGenerator
    {
        public GameRecorder GameRecorder = GameRecorder.GetInstance;

        /// <summary>
        /// コートを作る
        /// </summary>
        /// <param name="courtCounter">何個目のコートか</param>
        /// <param name="accommodateNumber">コートの収容人数</param>
        /// <returns>作ったコート</returns>
        private Court CreateCourt(int courtCounter, int accommodateNumber)
        {
            //コート名を決めるときに用いるアルファベット
            char[] Alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
        'O','P','Q','R','S','T','U','V','W','X','Y','Z'};

            //コートの用意
            var court = new Court
            {
                CourtName = "コート" + (Alphabet[courtCounter]),
                AccommodateNumber = accommodateNumber
            };

            //作ったコートを返す
            return court;
        }

        /// <summary>
        /// 組み合わせを決める。
        /// </summary>
        /// <param name="courtNum">コート数</param>
        /// <param name="attendPersons">試合の参加者</param>
        /// <param name="accommodateNumber">コートに入れる人数</param>
        /// <returns>Gameと休憩者のリスト</returns>
        public (Game[] games, IEnumerable<Person> breakPersons) Generate(int courtNum, IReadOnlyList<Person> attendPersons, int accommodateNumber)
        {
            //引数のチェック：コート数が負の数であるときは例外を出す
            if (courtNum <= 0)
            {
                throw new ArgumentOutOfRangeException("courtNumが負の数です");
            }

            //使うコートの数を決める
            int useCourtNum = attendPersons.Count / accommodateNumber;
            if (useCourtNum > courtNum)
            {
                useCourtNum = courtNum;
            }

            //休みの人を決める
            var breakPersonsNumber = attendPersons.Count - accommodateNumber * useCourtNum;
            var decideBreakPersonsResult = DecideBreakPersons(breakPersonsNumber, attendPersons);

            //組み合わせる
            var games = new List<Game>();
            var players = decideBreakPersonsResult.players;
            for (int i = 0; i < courtNum; i++)
            {
                if (i < useCourtNum)
                {
                    var decideOpponentResult = DecideOpponent(players, accommodateNumber);
                    players = decideOpponentResult.remainPlayers;
                    var game = new Game(CreateCourt(i, accommodateNumber), decideOpponentResult.team1.ToArray(), decideOpponentResult.team2.ToArray());
                    games.Add(game);
                }
                else
                {
                    //todo nullをGameにいれて空コートと判断するのは良くないので直す
                    games.Add(null);
                }
            }

            return (games: games.ToArray(), breakPersons: decideBreakPersonsResult.breakPersons);
        }

        /// <summary>
        /// 休憩者を決めるメソッド
        /// </summary>
        /// <param name="breakPersonsNumber">休憩者の人数</param>
        /// <param name="attendPersons">練習の参加者</param>
        /// <returns>試合をする人と休憩者</returns>
        protected abstract (List<Person> players, List<Person> breakPersons) DecideBreakPersons(int breakPersonsNumber, IReadOnlyList<Person> attendPersons);

        /// <summary>
        /// 対戦相手を決めるメソッド
        /// </summary>
        /// <param name="players">試合の参加者</param>
        /// <param name="accommodateNumber">1コートに入れる人数</param>
        /// <returns>残りの試合の参加者と対戦の組み合わせ</returns>
        protected abstract (List<Person> remainPlayers, List<Person> team1, List<Person> team2) DecideOpponent(List<Person> players, int accommodateNumber);

    }
}
