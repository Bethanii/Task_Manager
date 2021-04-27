using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLibrary;

namespace TaskManager
{
    public partial class TaskManager : Form
    {
        public TaskManager()
        {
            InitializeComponent();
        }
        TaskCode t = new TaskCode();
        private void Form1_Load(object sender, EventArgs e)
        {
            weekDayBox.Items.AddRange(new object[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            });

            taskItemBox.Items.AddRange(new object[]
            {
                "Do laundry",
                "Get groceries",
                "Taxes",
                "Do dishes",
                "Respond to emails",
                "Make vacation checklist",
                "Get vehicle oil change",
                "Mop floors",
                "Water plants",
                "Call grandma",
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaskCode t = new TaskCode();
            t.weekDay = weekDayBox.CheckedItems.Count;
            string[] w = new string[t.weekDay];
            t.selectedIndex = 0;
            t.BuildString = "Week day:\r\n";

            foreach (var item in weekDayBox.CheckedItems)
            {
                w[t.selectedIndex] = item.ToString();
                t.BuildString += w[t.selectedIndex] + "\r\n";
                ++t.selectedIndex;
            }

            t.taskItem = taskItemBox.CheckedItems.Count;
            string[] task = new string[t.taskItem];
            t.selectedIndex = 0;
            t.BuildString += "\r\nTasks assigned for the day: \r\n";

            foreach (var item in taskItemBox.CheckedItems)
            {
                task[t.selectedIndex] = item.ToString();
                t.BuildString += task[t.selectedIndex] + "\r\n";
                ++t.selectedIndex;
            }

            MessageBox.Show(t.BuildString);
            textBoxResults.Text = t.BuildString;

            string filePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Tasks.txt";

            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(t.BuildString);
            writer.Close();
            fs.Close();
        }
        static int GetCount(string file)
        {
            int count = 0; 
            string strRead;

            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader readerCount = new StreamReader(sr);

            strRead = readerCount.ReadLine();  
            while (strRead != null)
            {
                ++count;
                strRead = readerCount.ReadLine();               
            }

            readerCount.Close();
            sr.Close();

            return count;
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {

        }
    }
}