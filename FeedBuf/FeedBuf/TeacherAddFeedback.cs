using Repository;

namespace FeedBuf
{
    public partial class TeacherAddFeedback : Form
    {
        public int TeacherID { get; set; }

        public string Type { get; set; }

        public TeacherAddFeedback(int teacherID, string type)
        {
            InitializeComponent();
            TeacherID = teacherID;
            Type = type;
        }

        private void SaveFeedback(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(0, 0, 0, new DateTime(2023, 1, 1), "", "", "", 0);

            try
            {
                int studentID = Int32.Parse(textBox2.Text);
                int teacherID = TeacherID;
                string givenfeedback = textBox1.Text;
                string course = textBox3.Text;
                DateTime date = dateTimePicker1.Value.Date;
                string type = Type;
                int goalID = 0;

                feedback.AddFeedback(teacherID, studentID, date, course, givenfeedback, type, goalID);
                Close();
            }
            catch
            {
                MessageBox.Show("kan doel niet maken!");
            }
        }
    }
}
