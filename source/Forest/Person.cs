using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forest
{
    public class Person
    {
        /// <summary>
        /// システム内にてメンバー一人ずつに割り振る、一意の文字列
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// 名前（20字以内）
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 性別（男、女）
        /// </summary>
        [Required]
        public Gender Gender { get; set; }

        /// <summary>
        /// レベル（初級者、中級者、上級者）
        /// </summary>
        [Required]
        public Level Level { get; set; }

        /// <summary>
        /// 削除されているかどうか
        /// </summary>
        [Required]
        public bool DeleteFlag { get; set; }

        /// <summary>
        /// 試合に参加するかどうか(DBには登録しない)
        /// </summary>
        [NotMapped]
        public bool AttendFlag { get; set; }

    }
}
