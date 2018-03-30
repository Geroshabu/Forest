using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    /// <summary>
    /// Level型を定義するクラス
    /// ToString()をオーバーライドしている
    /// </summary>
    public class Level
    {
        /// <summary>
        /// レベルを数字で表す
        /// 0：初級者　1：中級者　2：上級者
        /// </summary>
        [Key]
        public int level_num { get; set; }

        /// <summary>
        /// オーバーライドしているメソッド
        /// 数字によるレベルを文字列で返す
        /// </summary>
        /// <returns>レベル（string型）</returns>
        public override string ToString()
        {
            //●書き方はこれで良いのか…？
            if (base.Equals(0))
            {
                return "初級者";
            }
            else if (base.Equals(1))
            {
                return "中級者";
            }
            else if (base.Equals(2))
            {
                return "上級者";
            }

            return "レベル登録なし";
        }
    }
}
