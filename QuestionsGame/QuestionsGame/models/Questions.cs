using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace QuestionsGame
{
    [Table("Questions")]
    public class Questions
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string question { get; set; }
        public string opt1 { get; set; }
        public string opt2 { get; set; }
        public string opt3 { get; set; }
        public string correctAns { get; set; }
        public string status { get; set; }
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
