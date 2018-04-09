using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    public class PersonHolder
    {
        //DBに登録されているサークルメンバーを保持しておくリスト
        public List<Person> Persons { get; set; }

        public PersonHolder(List<Person> persons)
        {
            //引数のリストをそのままPersonsにコピー
            Persons = new List<Person>();
            foreach(var target in persons)
            {
                Persons.Add(target);
            }
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
        /// 【未実装】
        /// </summary>
        /// <param name="new_person">新しく追加された人の情報</param>
        public void Add(Person new_person)
        {
            
        }

        /// <summary>
        /// 【未実装】
        /// </summary>
        /// <param name="id_list">削除する人のIDリスト</param>
        public void Delete(List<string> id_list)
        {

        }

        /// <summary>
        /// 【未実装】
        /// </summary>
        /// <param name="new_person">更新後の情報</param>
        public void update(Person new_person)
        {

        }

        /// <summary>
        /// DBに登録されているメンバーの中で削除されていないメンバー全員を返す
        /// </summary>
        /// <returns>削除されていないメンバー全員のリスト</returns>
        public List<Person> GetAllPersons()
        {
            //削除されていないメンバー全員
            var notDeletedPersons = new List<Person>();

            foreach (Person target in Persons)
            {
                //削除フラグが立っていなければリストに追加
                if(target.DeleteFlag == false)
                {
                    notDeletedPersons.Add(target);
                }
            }

            return notDeletedPersons;
        }

        /// <summary>
        /// 削除されていないメンバーの中でも練習に参加するメンバーを返す
        /// </summary>
        /// <returns>削除されていない、かつ練習に参加するメンバーのリスト</returns>
        public List<Person> GetAttendedPersons()
        {
            //削除されていないかつ練習に参加するメンバー全員
            var attendedPersons = new List<Person>();

            //削除されていないメンバーの中から参加フラグが立っているメンバーをリストに追加
            foreach(Person target in GetAllPersons())
            {
                if(target.AttendFlag == true)
                {
                    attendedPersons.Add(target);
                }
            }

            return attendedPersons;
        }

        

    }
}
