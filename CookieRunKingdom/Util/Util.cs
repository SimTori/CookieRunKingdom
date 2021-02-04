using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRunKingdom
{
    public class Util
    {
        public static List<Process> GetProcessList( string processname)
        {
            Process[] processesList = Process.GetProcesses();
            List<Process> list = new List<Process>();
            for (int i = 0; i < processesList.Length; i++)
            {
                if (processesList[i].ProcessName.Equals(processname))
                {
                    list.Add(processesList[i]);
                }
            }
            return list;
        }
    }
}
