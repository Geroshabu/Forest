using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    public class Generator
    {
        /// <summary>
        /// 引数のリストをシャッフルする
        /// </summary>
        /// <param name="targetList">シャッフルしたいリスト</param>
        /// <returns>シャッフル後のリスト</returns>
        public List<Person> ShuffleMember(List<Person> targetList)
        {
            var resultList = new List<Person>();//結果のリスト
            var copyList = new List<Person>(targetList);//元のリストのコピー
            var random = new Random();
            //元のリストのコピー（ループ用のリスト）がなくなったらおしまい
            while (copyList.Count != 0)
            {
                //ランダムで選んだものを入れていく
                int j = random.Next(copyList.Count);
                resultList.Add(copyList[j]);
                copyList.RemoveAt(j);
            }
            return resultList;
        }

        /// <summary>
        /// コートを作る
        /// </summary>
        /// <param name="courtCounter">何個目のコートか</param>
        /// <param name="accommodateNumber">コートの収容人数</param>
        /// <returns>作ったコート</returns>
        public Court CreateCourt(int courtCounter, int accommodateNumber)
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

    }
}
