namespace FeedBuf
{
    public partial class TeacherProfilePage : Form
    {
        public int TeacherID { get; set; }
        public Teacher teacher = new Teacher(0,"","","","","");

        public TeacherProfilePage(int id)
        {
            InitializeComponent();

            TeacherID = id;
            teacher.GetSingleTeacher(TeacherID);

            label5.AutoSize = false;
            label5.Dock = DockStyle.Top;
            label5.Text = "Welkom " + teacher.FirstName + " " + teacher.LastName + "";

            textBox1.Text = teacher.FirstName;
            textBox2.Text = teacher.LastName;
            textBox3.Text = teacher.Email;
            textBox4.Text = teacher.Phone;

        }

        private void updateProfile(object sender, EventArgs e)
        {
            teacher.UpdateTeacher(TeacherID, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            string updatedFields = "Profiel geupdate";
            MessageBox.Show(updatedFields);
        }
    }
}
