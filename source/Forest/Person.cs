using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Gender gender { get; set; }

        [Required]
        public Level level { get; set; }

        [Required]
        public bool delete_flag { get; set; }

        [Required]
        public bool attend_flag { get; set; }

    }
}
