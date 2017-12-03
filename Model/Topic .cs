using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Topic
    {
        public long     Id        { get; set; }
        public string   Name      { get; set; }
        public long     UserId    { get; set; }
        public string   Detail    { get; set; }
        public int      JoinCount { get; set; }
        public DateTime CreatDate { get; set; }
    }
}
