using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            numericUpDown1.Value = Form1.reloadTime / 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.reloadTime = (int)numericUpDown1.Value*1000;
            this.Close();
        }
    }
}
