using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class LfInfo
    {
        public int LfInfoId { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string InfoContent { get; set; }
        public DateTime PublishDate { get; set; }
        public int CmntCount { get; set; }
        public int TraceCount { get; set; }
        public string InfoType { get; set; }
        public string Status { get; set; }
    }
}
