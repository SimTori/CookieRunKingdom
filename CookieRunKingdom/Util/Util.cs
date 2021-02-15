using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                if (processesList[i].MainWindowTitle.Equals(""))
                {
                    continue;
                }
                list.Add(processesList[i]);
            }
            return list;
        }

        public static Rectangle GetWindowRect( IntPtr handle)
        {
            Rectangle rect;
            Dll.GetWindowRect(handle, out rect);
            Debug.Print("Width : " + rect.Width + " Height : " + rect.Height);
            rect = new Rectangle(rect.X, rect.Y, (rect.Width - rect.X ), (rect.Height - rect.Y ));
            Debug.Print("X : " + rect.X + " Y : " + rect.Y + " w : " + rect.Width + " h : " + rect.Height);

            return rect;
        }
    }
}
