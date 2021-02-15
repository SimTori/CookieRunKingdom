﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace CookieRunKingdom
{
    class Dll
    {
        /// <summary>
        /// 윈도우의 핸들 값 가져오는 함수
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowRgn(IntPtr hwnd, IntPtr hRgn);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("user32.dll", SetLastError = true)] 
        [return: MarshalAs(UnmanagedType.Bool)] 
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
    }
}
