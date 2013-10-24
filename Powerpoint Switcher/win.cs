using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Jamie
{
    public class win
    {       
            // The WM_COMMAND message is sent when the user
            // selects a command item from a menu, 
            // when a control sends a notification message
            // to its parent window, or when an 
            // accelerator keystroke is translated.
            public const int WM_COMMAND = 0x111;

            public struct Message
            {
                public Int32 msg;
                public Int32 wParam;
                public Int32 lParam;
            }

            public Message start = new Message();
            public Message next = new Message();

            // The FindWindow function retrieves a handle
            // to the top-level window whose class name
            // and window name match the specified strings.
            // This function does not search child windows.
            // This function does not perform a case-sensitive search.
         /*   [DllImport("User32.dll")]
            public static extern int FindWindow(string strClassName,
                                                     string strWindowName);*/

            // The FindWindowEx function retrieves
            // a handle to a window whose class name 
            // and window name match the specified strings.
            // The function searches child windows, beginning
            // with the one following the specified child window.
            // This function does not perform a case-sensitive search.
            [DllImport("User32.dll")]
            public static extern int FindWindowEx(int hwndParent,
                int hwndChildAfter, string strClassName, string strWindowName);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetKeyboardState(byte[] lpKeyState);
            // The SendMessage function sends the specified message to a 
            // window or windows. It calls the window procedure for the specified 
            // window and does not return until the window procedure
            // has processed the message. 
            [DllImport("User32.dll")]
            public static extern Int32 SendMessage(
                int hWnd,               // handle to destination window
                int Msg,                // message
                int wParam,             // first message parameter
                [MarshalAs(UnmanagedType.LPStr)] string lParam);
            // second message parameter
            [DllImport("User32.dll")]
            public static extern Int32 SetActiveWindow(int hwnd);

            [DllImport("User32.dll")]
            public static extern Int32 SendMessage(
                int hWnd,               // handle to destination window
                int Msg,                // message
                int wParam,             // first message parameter
                int lParam);            // second message parameter

            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
           public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static Int32 SendMessage(int handle, Message m)
        {
            return SendMessage(handle, m.msg, m.wParam, m.lParam);
        }

            public win()
            {
                //START
                start.msg = 0x0111;
                start.wParam = 0x000100AC;
                start.lParam = 0x00000000;

                //NEXT
                next.msg = 0x0111;
                next.wParam = 0x000106EF;
                next.lParam = 0x00000000;

            }

            ~win()
            {
            }
        
    }
}
