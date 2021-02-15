using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRunKingdom
{
    public class Pos
    {
        public int loc1, loc2, loc3, loc4;

        public Pos(int pos1, int pos2, int pos3, int pos4)
        {
            this.loc1 = pos1;
            this.loc2 = pos2;
            this.loc3 = pos3;
            this.loc4 = pos4;
        }

        public Pos(int pos1, int pos2)
        {
            this.loc1 = pos1;
            this.loc2 = pos2;
            this.loc3 = 0;
            this.loc4 = 0;
        }

        public Pos()
        {

        }
    }
}
