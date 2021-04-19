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
                56.3,
                2,
                44.77,
                32.6548,
                87.0,
                47.999,
                34.6,
                75.89,
                88.899,
                466,
                1,
                34,
                45,
                33.3333333,
                6.987654,
                5
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

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            int count;
            count = GetCount(filePath);

            for (int counter = 1; counter < count; ++counter)
            {
                strRead = reader.ReadLine();
                taskItemBox.Items.Add(strRead);
            }

            reader.Close();
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