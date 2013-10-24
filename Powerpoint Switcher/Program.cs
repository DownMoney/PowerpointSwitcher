using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jamie
{
    class Program
    {
        static win Win = new win();
        static void Main(string[] args)
        {
            Console.Title = "pwp";
            IntPtr app = win.FindWindow(null, Console.Title);

            System.Diagnostics.Process.Start("1.pptx");
            
            System.Threading.Thread.Sleep(3000);
            if (keyboard.IsKeyPressed(keyboard.VirtualKeyStates.VK_LCONTROL))
                Console.WriteLine("dd");
            IntPtr bkg = win.GetForegroundWindow();
            win.SendMessage(bkg.ToInt32(), Win.start);
            System.Threading.Thread.Sleep(1000);
            IntPtr bkgSlide = win.GetForegroundWindow();
            win.ShowWindow(bkg, 0);
            System.Threading.Thread.Sleep(5000);            

            System.Diagnostics.Process.Start("2.pptx");
            System.Threading.Thread.Sleep(3000);
            IntPtr act = win.GetForegroundWindow();
            win.SendMessage(act.ToInt32(), Win.start);
            win.ShowWindow(act, 0);
            System.Threading.Thread.Sleep(1000);
            IntPtr actSlide = win.GetForegroundWindow();            
            win.ShowWindow(actSlide, 0);

           
            //System.Threading.Thread.Sleep(5000);
            
                showNext(actSlide, bkgSlide, 5000);
            Console.ReadLine();
        }

        static void showNext(IntPtr a, IntPtr b, int time)
        {
            win.SendMessage(a.ToInt32(), Win.next);
            win.ShowWindow(b, 0);
            win.ShowWindow(a,1);

            System.Threading.Thread.Sleep(time);

            win.ShowWindow(b, 1);
            win.ShowWindow(a, 0);
            win.SendMessage(b.ToInt32(), Win.next);
        }
    }
}
