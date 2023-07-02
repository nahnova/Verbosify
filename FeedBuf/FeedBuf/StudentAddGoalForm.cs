namespace FeedBuf
{
    public partial class StudentAddGoalForm : Form
    {
        public int UserID { get; set; }

        public Goal goal = new Goal(0,0,"","","","");

        public StudentAddGoalForm(int id)
        {
            InitializeComponent();
            UserID = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID = UserID;
                string createdgoal = textBox2.Text;
                string priority = comboBox1.Text;
                string time = textBox4.Text;

                goal.AddGoal(studentID, priority, createdgoal, time, "te doen");
                Close();
            }
            catch
            {
                MessageBox.Show("kan doel niet maken!");
            }
        }
    }
}
