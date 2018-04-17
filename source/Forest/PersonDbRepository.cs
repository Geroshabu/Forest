using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Forest
{
    public class PersonDbRepository : IPersonRepository
    {
        private PersonContext Context;

        public PersonDbRepository()
        {
            //contextを新しく作る
            Context = new PersonContext();

            var peronDbRepository = new PersonDbRepository(new PersonContext());
        }

        public PersonDbRepository(PersonContext context)
        {
            //引数で受け取ったcontextを入れる
            Context = context;
            //DBが無ければ作る
            Context.Database.EnsureCreated();
        }

        /// <summary>
        /// 新たにメンバー情報を登録する
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns>DB登録できたかどうか</returns>
        public bool Add(Person newPerson)
        {
            try
            {
                //new_personを登録する
                Context.Persons.Add(newPerson);
                Context.SaveChanges();
            }
            //すでに登録されているIDが登録されたとき
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            //DB保存中にエラーが起きたとき
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
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
                //DB接続中にエラーが起きたとき
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
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
        /// メンバー情報を変更する
        /// </summary>
        /// <param name="updatePerson">変更内容</param>
        /// <returns>変更できたかどうか</returns>
        public bool Update(Person updatePerson)
        {
            try
            {
                //該当するIDの人を探す
                var targetPerson = Context.Persons.Where(x => x.ID == updatePerson.ID).FirstOrDefault();

                //対応するIDのメンバーが存在したとき
                if (targetPerson != null)
                {
                    targetPerson.Name = updatePerson.Name;
                    targetPerson.Gender.GenderNum = updatePerson.Gender.GenderNum;
                    targetPerson.Level.LevelNum = updatePerson.Level.LevelNum;
                    targetPerson.DeleteFlag = updatePerson.DeleteFlag;
                    targetPerson.AttendFlag = updatePerson.AttendFlag;
                    Context.SaveChanges();
                }
                //対応するIDのメンバーが存在しなかったとき
                else
                {
                    Console.WriteLine("対応するIDのメンバーが存在しませんでした");
                    return false;
                }

            }
            //DB保存中にエラーが起きたとき
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;

        }
    }
}
