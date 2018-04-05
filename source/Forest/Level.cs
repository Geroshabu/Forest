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
        public int LevelNum { get; set; }

        /// <summary>
        /// オーバーライドしているメソッド
        /// 数字によるレベルを文字列で返す
        /// </summary>
        /// <returns>レベル（string型）</returns>
        public override string ToString()
        {
            if (LevelNum == 0)
            {
                return "初級者";
            }
            else if (LevelNum == 1)
            {
                return "中級者";
            }
            else if (LevelNum == 2)
            {
                return "上級者";
            }
            
            throw new InvalidOperationException("LevelNumが適切でないです。LevelNum：" + LevelNum);
        }
    }
}
