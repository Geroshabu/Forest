using System;

namespace Forest
{
    /// <summary>
    /// Gender型を定義するクラス
    /// ToString()をオーバーライドしている
    /// </summary>
    public class Gender : IEquatable<Gender>
    {
        /// <summary>
        /// 性別を数字で表す
        /// 0：男　1：女
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
                return "男";
            }
            else if (GenderNum == 1)
            {
                return "女";
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
            return base.GetHashCode();
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
                if ((object)gender2 == null)
                {
                    return true;
                }
                //gender1だけがnullであればfalse
                return false;
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
