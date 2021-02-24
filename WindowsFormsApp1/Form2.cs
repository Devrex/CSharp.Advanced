using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Wait for it...";
            await Task.Delay(TimeSpan.FromSeconds(5));
            label1.Text = "It's beer o'clock!";
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"{e.X},{e.Y}";
        }
    }
}
