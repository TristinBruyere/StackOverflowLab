using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace StackOverflowLab.Models
{
    [Table("answers")]
    public class Answer
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string detail { get; set; }
        public int questionid { get; set; }
        public DateTime posted { get; set; }
        public int upvotes { get; set; }
    }
}
