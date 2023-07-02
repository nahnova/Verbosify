using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedBuf
{
    public partial class StudentHome : Form
    {
        public int StudentId { get; set; }
        public int CurrentXp { get; set; }
        public int CurrentLevel { get; set; }
        public int XpBar { get; set; }

        public Student student = new Student(0, "", "", "", "", "", 0, 0, 0, "");

        public StudentHome(int id)
        {
            InitializeComponent();
            StudentId = id;

            Student singleStudent = student.GetSinglestudent(StudentId);
            setStudentLevel(singleStudent.StudentLevel.ToString());

            XpBar = singleStudent.XpProgression;
            CurrentXp = singleStudent.XpProgression;
            CurrentLevel = singleStudent.StudentLevel;

            int i = 0;

            while (i < XpBar)
            {
                progressBar1.Value = i;
                i++;
            }

            SetLevel(singleStudent.StudentLevel);
        }

        private void GoToGoalOverview(object sender, EventArgs e)
        {
            StudentGoalOverview goalForm = new StudentGoalOverview(StudentId, CurrentXp, CurrentLevel);
            goalForm.Show();
            this.Hide();
            this.Close();
        }

        private void GoToProfilePage(object sender, EventArgs e)
        {
            StudentProfilePage profilePage = new StudentProfilePage(StudentId);
            profilePage.ShowDialog();
        }

        private void GoToFeedbackOverview(object sender, EventArgs e)
        {
            StudentFeedbackOverview studentFeedbackOverview = new StudentFeedbackOverview();
            studentFeedbackOverview.ShowDialog();
        }

        private void setStudentLevel(string studentLevel)
        {
            label1.Text = studentLevel;
        }

        private void SetLevel(int studentLevel)
        {
            switch (studentLevel)
            {
                case > 0 and < 10:
                    label2.Text = "Feedback Crook";
                    break;
                case > 9 and < 20:
                    label2.Text = "Feedback Initiate";
                    break;
                case > 19 and < 30:
                    label2.Text = "Feedback Mercenary";
                    break;
                case > 29 and < 40:
                    label2.Text = "Feedback Hitman";
                    break;
                case > 39 and < 50:
                    label2.Text = "Feedback Spy";
                    break;
                case > 49 and < 60:
                    label2.Text = "Feedback Soldier";
                    break;
                case > 59 and < 70:
                    label2.Text = "Feedback Commander";
                    break;
                case > 69 and < 80:
                    label2.Text = "Feedback General";
                    break;
                case > 79 and < 90:
                    label2.Text = "Feedback Godfather";
                    break;
                case > 89 and < 100:
                    label2.Text = "Feedback Supreme Overlord";
                    break;
                case > 100:
                    label2.Text = "Level 100 Maffia Boss";
                    break;
                default:
                    label2.Text = "Feedback Noob";
                    break;
            }
        }

        private void GoToLeaderboard(object sender, EventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.ShowDialog();
        }
    }
}
