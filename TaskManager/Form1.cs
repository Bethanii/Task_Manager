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

namespace TaskManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
            int weekDay = weekDayBox.CheckedItems.Count;
            string[] w = new string[weekDay];
            int selectedIndex = 0;
            string buildString = "Week day:\r\n";

            foreach (var item in weekDayBox.CheckedItems)
            {
                w[selectedIndex] = item.ToString();
                buildString += w[selectedIndex] + "\r\n";
                ++selectedIndex;
            }

            int taskItem = taskItemBox.CheckedItems.Count;
            string[] task = new string[taskItem];
            selectedIndex = 0;
            buildString += "\r\nTasks assigned for the day: \r\n";

            foreach (var item in taskItemBox.CheckedItems)
            {
                task[selectedIndex] = item.ToString();
                buildString += task[selectedIndex] + "\r\n";
                ++selectedIndex;
            }

            MessageBox.Show(buildString);
            textBoxResults.Text = buildString;

            string filePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Tasks.txt";
            string strRead;

            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            int count;
            //count = GetCount(filePath);

            //for (int counter = 1; counter < count; ++counter)
            //{
            //    strRead = reader.Line();
            //    taskItemBox.Items.Add(strRead);
            //}
            writer.WriteLine(buildString);
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
    }
}