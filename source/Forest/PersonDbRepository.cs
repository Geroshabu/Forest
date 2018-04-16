using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Forest
{
    /// <summary>
    /// DbContext クラスを継承したクラス
    /// </summary>
    public class PersonDbRepository : IPersonRepository
    {
        private PersonContext Context;

        public PersonDbRepository()
        {
            //DBに接続
            Context = new PersonContext();
            var peronDbRepository = new PersonDbRepository(new PersonContext());        }

        public PersonDbRepository(PersonContext context)
        {
            //引数で受け取ったものを入れる
            Context = context;
            //DBが無ければ作る
            Context.Database.EnsureCreated();
        }

        /// <summary>
        /// 【実装中】新たにメンバー情報を登録する
        /// </summary>
        /// <param name="new_person"></param>
        /// <returns>DB登録できたかどうか</returns>
        public bool Add(Person new_person)
        {
            //new_personを登録する
            Context.Persons.Add(new_person);
            Context.SaveChanges();



            return true;
        }

        /// <summary>
        /// 【実装中】メンバー情報を削除する
        /// ※物理削除ではなく、フラグを立てるのみ
        /// </summary>
        /// <param name="delete_persons"></param>
        /// <returns>削除フラグを立てた件数</returns>
        public int Delete(List<Person> delete_persons)
        {
            //削除した件数
            int delete_num = 0;

            foreach (var person in delete_persons)
            {
                try
                {
                    //削除したい人のIDと一致する人をDBから探す
                    var target_person = Context.Persons.Where(x => x.ID == person.ID).FirstOrDefault();

                    //対応メンバーのdelete_flagをtrueにして、削除件数に1を足す
                    if (target_person != null)
                    {
                        target_person.DeleteFlag = true;
                        Context.SaveChanges();
                        delete_num++;
                    }
                    else
                    {
                        //対応するIDの人がいなかったとき
                        return -1;
                    }
                }
                //DBにアクセスできなかったとき
                catch (NullReferenceException)
                {
                    ShowDBError();
                    return -1;
                }

            }

            return delete_num;

        }

        /// <summary>
        /// 削除されていない全メンバー情報を取得する
        /// </summary>
        /// <returns>DBに登録されているメンバーのリスト</returns>
        public List<Person> GetAll()
        {
            //取得したメンバー情報を入れるためのリスト
            var persons = new List<Person>();
            //一行ずつ読んでpersonsリストに入れて返す
            foreach (var person in persons = Context.Persons.Where(x => !(x.DeleteFlag)).ToList()) { }
            return persons;
        }

        /// <summary>
        /// 【実装中】メンバー情報を変更する
        /// </summary>
        /// <param name="update_person"></param>
        /// <returns>変更できたかどうか</returns>
        public bool Update(Person update_person)
        {
            try
            {
                //nullが返ることがある
                var target_person = Context.Persons.Where(x => x.ID == update_person.ID).FirstOrDefault();

                //対応するIDのメンバーが存在したとき
                if (target_person != null)
                {
                    target_person.Name = update_person.Name;
                    target_person.Gender.GenderNum = update_person.Gender.GenderNum;
                    target_person.Level.LevelNum = update_person.Level.LevelNum;
                    target_person.DeleteFlag = update_person.DeleteFlag;
                    target_person.AttendFlag = update_person.AttendFlag;
                    Context.SaveChanges();
                }
                //対応するIDのメンバーが存在しなかったとき
                else
                {
                    return false;
                }

            }
            //DBにアクセスできなかったとき
            catch (NullReferenceException)
            {
                ShowDBError();
                return false;
            }

            return true;

        }

        /// <summary>
        /// 【たぶんいらない】ここで画面を出さない
        /// </summary>
        public void ShowDBError()
        {
            MessageBox.Show("データベースエラーが発生しました。（001）");
        }
    }
}
