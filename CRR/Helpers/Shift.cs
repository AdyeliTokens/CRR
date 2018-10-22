using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRR.Helpers
{
    public class Shift
    {
        public static int Get()
        {
            var hh = DateTime.Now.Hour;
            var mm = DateTime.Now.Minute;
            var ss = DateTime.Now.Second;

            var time = ss + (mm * 60) + (hh * 60 * 60);

            if (time >= 23400 && time < 52200)
                return 1;
            if (time >= 52200 && time < 81000)
                return 2;
            if (time < 23400)
                return 3;
            
            return 3;
        }
    }
}