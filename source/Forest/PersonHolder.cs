using System.Collections.Generic;
using System.Linq;

namespace Forest
{
    public class PersonHolder
    {
        //DBに登録されているサークルメンバーを保持しておくリスト
        private List<Person> Persons;

        public PersonHolder(IReadOnlyList<Person> persons)
        {
            //引数のリストをそのままPersonsにコピー
            foreach (var target in Persons = persons.ToList()) { }
        }

        /// <summary>
        /// 引数のIDをもつ人の参加フラグを立てる
        /// </summary>
        /// <param name="id_ist">参加者として選択されている人のID</param>
        public void Attend(List<string> id_list)
        {
            //IDリストをはじめから見ていく
            foreach (string targetID in id_list)
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
        /// <param name="id_list">参加を取り下げた人のID</param>
        public void Cancel(List<string> id_list)
        {
            //IDリストをはじめから見ていく
            foreach (string targetID in id_list)
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
            //削除されていないメンバー全員
            var notDeletedPersons = new List<Person>();

            //リストに入れて返す
            foreach (Person target in notDeletedPersons = Persons.Where(x => !(x.DeleteFlag)).ToList()) { }
            return notDeletedPersons;
        }

        /// <summary>
        /// 削除されていないメンバーの中でも練習に参加するメンバーを返す
        /// </summary>
        /// <returns>削除されていない、かつ練習に参加するメンバーのリスト</returns>
        public List<Person> GetAttended()
        {
            //削除されていないかつ練習に参加するメンバー全員
            var attendedPersons = new List<Person>();

            //削除されていないメンバーの中から参加フラグが立っているメンバーをリストに追加して返す
            foreach (Person target in attendedPersons = GetAll().Where(x => x.AttendFlag).ToList()) { }
            return attendedPersons;
        }

    }
}
