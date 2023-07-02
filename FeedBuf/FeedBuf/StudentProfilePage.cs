using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;

namespace FeedBuf
{
    public partial class StudentProfilePage : Form
    {
        public int StudentId { get; set; }

        public Student student = new Student(0, "", "", "", "", "", 0, 0, 0, "");

        public StudentProfilePage(int id)
        {
            InitializeComponent();

            StudentId = id;

            Student singleStudent = student.GetSinglestudent(StudentId);

            label5.AutoSize = false;
            label5.Dock = DockStyle.Top;
            label5.Text = "Welkom " + singleStudent.FirstName + " " + singleStudent.LastName + "";

            textBox1.Text = singleStudent.FirstName;
            textBox2.Text = singleStudent.LastName;
            textBox3.Text = singleStudent.Email;
            textBox4.Text = singleStudent.Gender;

        }

        private void updateProfile(object sender, EventArgs e)
        {
            student.UpdateStudent(StudentId, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            string updatedFields = "Profiel geupdate";
            MessageBox.Show(updatedFields);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
