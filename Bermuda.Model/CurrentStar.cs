using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class CurrentStar
    {
        public Int64    Id        { set; get; }
        public Int64    CurrentId { set; get; }
        public Int64    UserId    { set; get; }
        public DateTime StarDate  { set; get; }

    }
}
