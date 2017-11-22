using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CmntInfo
    {
        public int CmntInfoId { set; get; }
        public int CmntAuthor { set; get; }
        public int InfoId { set; get; }
        public char CmntContent { set; get; }
        public DateTime CmntDate { set; get; }
        public int ReplyCount { set; get; }
        public int PraiseCount { set; get; }
    }
}
