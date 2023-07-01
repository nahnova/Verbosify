using FeedBuf;

namespace FeedBuf
{
    public partial class TeacherAddGoalFeedback : Form
    {
        public int TeacherID { get; set; }

        public int StudentID { get; set; }

        public int GoalID { get; set; }

        public Feedback feedback = new Feedback(0, 0, 0, new DateTime(2023, 1, 1), "", "", "", 0);

        public TeacherAddGoalFeedback(int teacherID, int studentID, int goalID)
        {
            InitializeComponent();
            TeacherID = teacherID;
            StudentID = studentID;
            GoalID = goalID;
        }

        private void SaveFeedback(object sender, EventArgs e)
        {
            try
            {
                int studentID = StudentID;
                int teacherID = TeacherID;
                string givenfeedback = textBox1.Text;
                string course = "";
                DateTime date = dateTimePicker1.Value.Date;
                string type = "doel";
                int goalID = GoalID;

                feedback.AddFeedback(teacherID,studentID,date,course,givenfeedback,type,goalID);
                Close();
            }
            catch
            {
                MessageBox.Show("kan doel niet maken!");
            }
        }
    }
}
