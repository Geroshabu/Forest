using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    /// <summary>
    /// Gender型を定義するクラス
    /// ToString()をオーバーライドしている
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// 性別を数字で表す
        /// 0：男　1：女
        /// </summary>
        [Key]
        public int GenderNum { get; set; }

        /// <summary>
        /// オーバーライドしているメソッド
        /// 数字による性別を文字列で返す
        /// </summary>
        /// <returns>性別（string型）</returns>
        public override string ToString()
        {
            if (GenderNum == 0)
            {
                return "男";
            }
            else if (GenderNum == 1)
            {
                return "女";
            }

            throw new InvalidOperationException("GenderNumが適切でないです。GenderNum：" + GenderNum);
        }
    }
}
