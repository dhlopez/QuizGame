using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace QuestionsGame
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int points { get; set; }
        public string rank { get; set; }
    }
    /*
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    [Required]
    [StringLength(50)]
    public string sarMatch { get; set; }
    [StringLength(50)]
    public string sarMatch { get; set; }
    [StringLength(50)]
    public string sarMatch { get; set; }
    */
}
