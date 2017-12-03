using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CurrentStar
    {
        public long     Id        { set; get; }
        public long     CurrentId { set; get; }
        public long     UserId    { set; get; }
        public DateTime StarDate  { set; get; }

    }
}
