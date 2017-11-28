using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CurrentStar
    {
        public int      Id        { set; get; }
        public int      CurrentId { set; get; }
        public int      UserId    { set; get; }
        public DateTime StarDate  { set; get; }

    }
}
