using System;

namespace Forest
{
    /// <summary>
    /// Level型を定義するクラス
    /// ToString()をオーバーライドしている
    /// </summary>
    public class Level : IEquatable<Level>
    {
        /// <summary>
        /// レベルを数字で表す
        /// 0：初級者　1：中級者　2：上級者
        /// </summary>
        public int LevelNum { get; set; }

        public bool Equals(Level level)
        {
            if ((object)level == null)
            {
                return false;
            }
            return LevelNum == level.LevelNum;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Level))
            {
                return false;
            }

            return Equals((Level)obj);
        }

        public override int GetHashCode()
        {
            return LevelNum.GetHashCode();
        }


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

        /// <summary>
        /// 右辺と左辺が等しいかどうかを返す
        /// </summary>
        /// <param name="level1">左辺</param>
        /// <param name="level2">右辺</param>
        /// <returns>結果</returns>
        public static bool operator ==(Level level1, Level level2)
        {
            if ((object)level1 == null)
            {
                //両方ともnullであればtrue
                return (object)level2 == null;
            }
            //判断はEquals(Level型)に任せる
            return level1.Equals(level2);
        }

        /// <summary>
        /// == の逆の結果を返す
        /// </summary>
        /// <param name="level1"></param>
        /// <param name="level2"></param>
        /// <returns></returns>
        public static bool operator !=(Level level1, Level level2)
        {
            return !(level1 == level2);
        }

    }
}
