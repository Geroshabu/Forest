using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    public class PersonHolder
    {
        //DBに登録されているサークルメンバーを保持しておくリスト
        private List<Person> Persons;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="persons">サークルに所属している全メンバー</param>
        public PersonHolder(IReadOnlyList<Person> persons)
        {
            //引数のリストをそのままにコピー
            Persons = persons.ToList();
        }

        /// <summary>
        /// 引数のIDをもつ人の参加フラグを立てる
        /// </summary>
        /// <param name="idList">参加者として選択されている人のID</param>
        public void Attend(List<string> idList)
        {
            //IDリストをはじめから見ていく
            foreach (string targetID in idList)
            {
                //リストの中にいる一致するIDの人を探す
                foreach (Person targetPerson in Persons)
                {
                    //一致するIDの人の参加フラグを立てる
                    if (targetPerson.ID == targetID)
                    {
                        targetPerson.AttendFlag = true;
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// 引数のIDをもつ人の参加フラグを下げる
        /// </summary>
        /// <param name="idList">参加を取り下げた人のID</param>
        public void Cancel(List<string> idList)
        {
            //IDリストをはじめから見ていく
            foreach (string targetID in idList)
            {
                //リストの中にいる一致するIDの人を探す
                foreach (Person targetPerson in Persons)
                {
                    //一致するIDの人の参加フラグを下げる
                    if (targetPerson.ID == targetID)
                    {
                        targetPerson.AttendFlag = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// DBに登録されているメンバーの中で削除されていないメンバー全員を返す
        /// </summary>
        /// <returns>削除されていないメンバー全員のリスト</returns>
        public List<Person> GetAll()
        {
            //削除されていないメンバー全員をリストに入れて返す
            return Persons.Where(x => !(x.DeleteFlag)).ToList();
        }

        /// <summary>
        /// 削除されていないメンバーの中でも練習に参加するメンバーを返す
        /// </summary>
        /// <returns>削除されていない、かつ練習に参加するメンバーのリスト</returns>
        public List<Person> GetAttended()
        {
            //削除されていないかつ練習に参加するメンバー全員
            //削除されていないメンバーの中から参加フラグが立っているメンバーをリストに追加して返す
            return GetAll().Where(x => x.AttendFlag).ToList();
        }

    }
}
