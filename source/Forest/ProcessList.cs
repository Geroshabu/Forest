using System;
using System.Collections.Generic;

namespace Forest
{
    /// <summary>
    /// リストの加工をする処理をまとめたクラス
    /// </summary>
    public class ProcessList
    {
        /// <summary>
        /// 引数のリストをシャッフルする
        /// </summary>
        /// <param name="targetList">シャッフルしたいリスト</param>
        /// <returns>シャッフル後のリスト</returns>
        public static List<Person> Shuffle(List<Person> targetList)
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

    }
}
