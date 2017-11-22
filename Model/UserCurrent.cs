using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class UserCurrent
    {
        public int      AuthorId { get; set; }
        public string   CurrentContent { get; set; }
        public DateTime PulishDate { get; set; }
        public string   CurrentType { get; set; }
        public int      CmntCount { get; set; }
        public int      StarCount { get; set; }
        public int      PraiseCount { get; set; }
        public string   Avatar { get; set; }
    }
}
