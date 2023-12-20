using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public  partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            DataColumn idcolumn = new DataColumn("Id",Type.GetType("System.Int32"));
            DataColumn namecolumn = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn timestart = new DataColumn("TimeStart", Type.GetType("System.String"));
            DataColumn timeprocess = new DataColumn("TimeProcess", Type.GetType("System.String"));
            DataColumn countthread = new DataColumn("CountThread", Type.GetType("System.Int32"));
            dt.Columns.Add(idcolumn);
            dt.Columns.Add(namecolumn);
            dt.Columns.Add(timestart);
            dt.Columns.Add(timeprocess);
            dt.Columns.Add(countthread);
            ////dgMainFill(dataGridView1);
            reloadTime = 1000;
            timer1 = new System.Threading.Timer(dgMainFill, dataGridView1, reloadTime, reloadTime);
    
        }
        private static DataTable dt = new DataTable();
        private static Process[] processes;
        public static Int32 reloadTime;
        System.Threading.Timer timer1;
      
        public static void dgMainFill(object sender)
        {
            processes = Process.GetProcesses();
            foreach(Process process in processes)
            { string s,t;
                try { s = process.StartTime.ToString(); } catch { s = ""; }
                try {  t = process.TotalProcessorTime.ToString(); } catch { t = ""; }
                try { dt.Rows.Add(new object[] { process.Id, process.ProcessName, s, t, process.Threads.Count }); } catch { }
            }
             (sender as DataGridView).Invoke((MethodInvoker)delegate
            {
                (sender as DataGridView).DataSource = dt;
            });
        }

        private void TimeUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello!!");
            Form form = new Form2();
            form.ShowDialog();
            timer1.Change(reloadTime, reloadTime);
        }
    }
}
