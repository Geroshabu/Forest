using System.ComponentModel.DataAnnotations;

namespace Forest
{
    /// <summary>
    /// Person型を定義するクラス
    /// </summary>
    public class Person
    {
        [Required]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public bool DeleteFlag { get; set; }

        [Required]
        public bool AttendFlag { get; set; }

    }
}
