using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    /// <summary>
    /// Gender型を定義するクラス
    /// ToString()をオーバーライドしている
    /// </summary>
    class Gender
    {
        /// <summary>
        /// 性別を数字で表す
        /// 0：男　1：女
        /// </summary>
        private int gender_num;

        /// <summary>
        /// オーバーライドしているメソッド
        /// 数字による性別を文字列で返す
        /// </summary>
        /// <returns>性別（string型）</returns>
        public override string ToString()
        {
            //●書き方はこれで良いのか…？
            if(base.Equals(0))
            {
                return "男";
            }else if (base.Equals(1))
            {
                return "女";
            }

            return "性別登録なし";

        }
    }
}
