using System.Collections.Generic;

namespace Forest
{
    /// <summary>
    /// Personに関する操作をするためのインターフェース
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// 削除されていない全メンバー情報を取得する
        /// </summary>
        /// <returns>削除されていない全メンバーの情報（List<Person>型）</returns>
        List<Person> GetAll();

        /// <summary>
        /// 新たにメンバー情報を登録する
        /// </summary>
        /// <param name="newPerson">新しいメンバー情報</param>
        /// <returns>登録できたかどうか</returns>
        bool Add(Person newPerson);

        /// <summary>
        /// メンバー情報を削除する
        /// ※物理削除ではなく、フラグを立てるのみ
        /// </summary>
        /// <param name="deletePersons">削除したいメンバーのリスト</param>
        /// <returns>削除した件数</returns>
        int Delete(List<Person> deletePersons);

        /// <summary>
        /// メンバー情報を変更する
        /// </summary>
        /// <param name="updatePerson">変更したいメンバー情報</param>
        /// <returns>変更できたかどうか</returns>
        bool Update(Person updatePerson);

    }
}
