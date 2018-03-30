using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest
{
    /// <summary>
    /// Personに関する操作をするためのインターフェース
    /// </summary>
    interface IPersonRepository
    {
        /// <summary>
        /// 全メンバー情報を取得する
        /// </summary>
        /// <returns>全メンバー情報（List<Person>型）</returns>
        List<Person> GetPersons();

        /// <summary>
        /// 新たにメンバー情報を登録する
        /// </summary>
        /// <param name="new_person">新しいメンバー情報</param>
        /// <returns>登録できたかどうか</returns>
        bool AddPerson(Person new_person);

        /// <summary>
        /// メンバー情報を削除する
        /// ※物理削除ではなく、フラグを立てるのみ
        /// </summary>
        /// <param name="delete_persons">削除したいメンバーのリスト</param>
        /// <returns>削除した件数</returns>
        int DeletePersons(List<Person> delete_persons);

        /// <summary>
        /// メンバー情報を変更する
        /// </summary>
        /// <param name="update_person">変更したいメンバー情報</param>
        /// <returns>変更できたかどうか</returns>
        bool UpdatePerson(Person update_person);

    }
}
