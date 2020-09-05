using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitness.Helpers
{
    public class MsgUnit
    {
        public int Code { get; set; }
        public string Msg { get; set; }

        public string LastID { get; set; }

        public int COID { get; set; }
        public int ID { get; set; }

        public int PrevID { get; set; }
    }
}