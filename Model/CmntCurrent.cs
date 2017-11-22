using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CmntCurrent
    {
        public int      CmntCurrentId {set; get;}
        public int      CurrentId     {set; get;}
        public int      CmntId        {set; get;}
        public string   CmntContent   { set; get; }
        public DateTime CmntDate      {set; get;}
        public int      PraiseCount   {set; get;}
    }
}
