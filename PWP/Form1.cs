using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jamie;

namespace PWP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        win Win = new win();
        IntPtr bkgSlide = new IntPtr();
        IntPtr actSlide = new IntPtr();
        void showNext(IntPtr a, IntPtr b, int time)
        {
            win.SendMessage(a.ToInt32(), Win.next);
            win.ShowWindow(b, 0);
            win.ShowWindow(a, 1);

            System.Threading.Thread.Sleep(time);

            win.ShowWindow(b, 1);
            win.ShowWindow(a, 0);
            win.SendMessage(b.ToInt32(), Win.next);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyboard.IsKeyPressed(keyboard.VirtualKeyStates.VK_LCONTROL))
                showNext(actSlide, bkgSlide,Convert.ToInt32(textBox3.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("POWERPNT.EXE");
            }
            catch
            {
                MessageBox.Show("You need to have PowerPoint installed!");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            run();
        }

        void run()
        {
            System.Diagnostics.Process.Start(textBox1.Text);

            System.Threading.Thread.Sleep(3000);
            IntPtr bkg = win.GetForegroundWindow();
            win.SendMessage(bkg.ToInt32(), Win.start);
            System.Threading.Thread.Sleep(1000);
            bkgSlide = win.GetForegroundWindow();
            win.ShowWindow(bkg, 0);
            //System.Threading.Thread.Sleep(5000);

            System.Diagnostics.Process.Start(textBox2.Text);
            System.Threading.Thread.Sleep(3000);
            IntPtr act = win.GetForegroundWindow();
            win.SendMessage(act.ToInt32(), Win.start);
            win.ShowWindow(act, 0);
            System.Threading.Thread.Sleep(1000);
            actSlide = win.GetForegroundWindow();
            win.ShowWindow(actSlide, 0);
        }
    }
}
