using System;

namespace Forest
{
    public class Level : IEquatable<Level>, IComparable
    {
        /// <summary>
        /// レベルを数字で表す
        /// 0：初級者　1：中級者　2：上級者
        /// </summary>
        public int LevelNum { get; set; }

        /// <summary>
        /// CompareTo()をオーバーライドするクラス
        /// LevelNumによってソート順を判断する
        /// </summary>
        /// <param name="obj">比較対象のオブジェクト</param>
        /// <returns>ソート順を決める数字</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            //引数をLevel型にキャスト
            //キャストできないときはnullが入る
            Level otherLevel = obj as Level;

            if(otherLevel != null)
            {
                //LevelNumでソート順を判断
                return this.LevelNum.CompareTo(otherLevel.LevelNum);
            }
            else
            {
                throw new ArgumentException("Level型ではないものと比較しようとしています");
            }
        }

        /// <summary>
        /// 引数のLevel型のオブジェクトと同じかを判定する
        /// </summary>
        /// <param name="level">比較対象</param>
        /// <returns>比較結果</returns>
        public bool Equals(Level level)
        {
            if ((object)level == null)
            {
                return false;
            }
            return LevelNum == level.LevelNum;
        }

        /// <summary>
        /// 引数のobject型のオブジェクトと同じかを判定する
        /// 最終的な判定はEquals(Level型)に任せる
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>判定結果</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Level))
            {
                return false;
            }

            //判断はEquals(Level型)に任せる
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
        /// 判定はEquals(Level型)に任せる
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
        /// <returns>結果</returns>
        public static bool operator !=(Level level1, Level level2)
        {
            return !(level1 == level2);
        }

    }
}
