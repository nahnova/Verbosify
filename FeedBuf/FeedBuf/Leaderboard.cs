using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedBuf
{
    public partial class Leaderboard : Form
    {
        Student student = new Student(0, "", "", "", "", "", 0, 0, 0, "");

        public Leaderboard()
        {
            InitializeComponent();
            Refresh_Listview();
        }

        public void Refresh_Listview()
        {
            try
            {
                listView1.Items.Clear();

                List<Student> students = student.GetStudents();

                foreach (Student student in students)
                {
                    ListViewItem item = new ListViewItem(student.FirstName);
                    item.SubItems.Add(student.StudentLevel.ToString());
                    item.SubItems.Add(student.Rank.ToString());
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Kan studenten niet laden!");
            }
        }

    }
}
