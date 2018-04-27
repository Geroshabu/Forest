using System;

namespace Forest
{
    public class Gender : IEquatable<Gender> , IComparable
    {
        /// <summary>
        /// 性別を数字で表す。
        /// 0：女　1：男
        /// </summary>
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
                return "女";
            }
            else if (GenderNum == 1)
            {
                return "男";
            }

            throw new InvalidOperationException("GenderNumが適切でないです。GenderNum：" + GenderNum);
        }

        /// <summary>
        /// 引数のものと同じかどうかをboolで返すメソッド
        /// ・Gender型でなければfalseを返す
        /// ・判断はEquals(Gender)メソッドに任せる
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>同じかどうか</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Gender))
            {
                return false;
            }

            return Equals((Gender)obj);
        }

        public override int GetHashCode()
        {
            return GenderNum.GetHashCode();
        }

        /// <summary>
        /// 引数のGender型のものと同じかどうかを返すメソッド
        /// ・引数がnullならfalseを返す
        /// ・中身の数字が等しければtrue,異なればfalseを返す
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public bool Equals(Gender gender)
        {
            if ((object)gender == null)
            {
                return false;
            }
            return GenderNum == gender.GenderNum;
        }

        /// <summary>
        /// CompareTo()をオーバーライドするクラス。
        /// GenderNumによってソート順を判断する。
        /// </summary>
        /// <param name="obj">比較対象のオブジェクト</param>
        /// <returns>ソート順を決める数字</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            //引数をGender型にキャスト
            //キャストできないときはnullが入る
            Gender otherGender = obj as Gender;

            if (otherGender != null)
            {
                //GenderNumでソート順を判断
                return this.GenderNum.CompareTo(otherGender.GenderNum);
            }
            else
            {
                throw new ArgumentException("Gender型ではないものと比較しようとしています");
            }
        }

        /// <summary>
        /// 右辺と左辺が等しいかどうかを返す
        /// </summary>
        /// <param name="gender1">左辺</param>
        /// <param name="gender2">右辺</param>
        /// <returns>結果</returns>
        public static bool operator ==(Gender gender1, Gender gender2)
        {
            if ((object)gender1 == null)
            {
                //両方ともnullであればtrue
                return (object)gender2 == null;
            }
            //判断はEquals(Gender型)に任せる
            return gender1.Equals(gender2);
        }

        /// <summary>
        /// == の逆の結果を返す
        /// </summary>
        /// <param name="gender1"></param>
        /// <param name="gender2"></param>
        /// <returns></returns>
        public static bool operator !=(Gender gender1, Gender gender2)
        {
            return !(gender1 == gender2);
        }
    }
}
